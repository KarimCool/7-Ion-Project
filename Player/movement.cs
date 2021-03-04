using Godot;
using System;

public class movement : KinematicBody2D
{
    [Export] private int speed;
    [Export] private int jumpSpeed;
    [Export] private int gravitation;
    Vector2 velocity;



    public movement()
    {
        speed = 100;
        jumpSpeed = 250;
        gravitation = 400;
        velocity = new Vector2(0, 0);


    }
    public override void _Ready()
    {

    }

    public void GetInput()
    {
        velocity.x = 0;

        if (Input.IsKeyPressed(16777233))
            velocity.x += speed;

        if (Input.IsKeyPressed(16777231))
            velocity.x -= speed;

        if (Input.IsKeyPressed(16777232) && IsOnFloor())
            velocity.y -= jumpSpeed;

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