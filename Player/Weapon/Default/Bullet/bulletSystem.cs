using Godot;
using System;

public class bulletSystem : Node2D
{
    PackedScene rlBullet;
    Timer t;

    public bulletSystem()
    {
        rlBullet = (PackedScene)GD.Load("res://Player/Weapon/Default/Bullet/Instanced/Bullet.tscn");
        t = GetNode<Timer>("Node/bulletSystem/DELAY");
    }

    /*
    public override void _Ready()
    {
    }
    */

    public void shoot()
    {
        if (Input.IsKeyPressed(69))
        {

            var bullet = rlBullet.Instance() as Node2D;
            bullet.Position = GetNode<KinematicBody2D>("../Player").Position + new Vector2(32, -3);
            AddChild(bullet);

        }
    }
    public async void cooldown()
    {
        t.Start();
        await ToSignal(t, "timeout");
    }

    public override void _Process(float delta)
    {
        shoot();
        cooldown();
    }
}
