using Godot;
using System;

public class movement : KinematicBody2D
{
    [Export] private int speed;
    [Export] private int jumpSpeed;
    [Export] private int gravitation;
    private Vector2 velocity;
    Area2D buflfet;

    public movement()
    {
        speed = 100;
        jumpSpeed = 250;
        gravitation = 400;
        velocity = new Vector2(0, 0);
        var rlBullet = (PackedScene)GD.Load("res://Player/Weapon/Default/Bullet.tscn");

    }
    public override void _Ready()
    {

    }

    public void GetInput(Area2D Ballet)
    {
        velocity.x = 0;

        if (Input.IsKeyPressed(16777233))
            velocity.x += speed;

        if (Input.IsKeyPressed(16777231))
            velocity.x -= speed;

        if (Input.IsKeyPressed(16777232) && IsOnFloor())
            velocity.y -= jumpSpeed;

        if (Input.IsKeyPressed(69))

            Ballet = rlBullet.instance();
    }

    public void gravity(float time)
    {
        if (!(IsOnFloor()))
        {
            velocity.y += gravitation * time;
        }
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        gravity(delta);
        velocity = MoveAndSlide(velocity, new Vector2(0, -1));
        //GD.Print(velocity.x);

    }

}