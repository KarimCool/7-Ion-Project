using Godot;
using System;

public class bulletSystem : Node2D
{
    PackedScene rlBullet;
    float ten;

    public bulletSystem()
    {
        rlBullet = (PackedScene)GD.Load("res://Player/Weapon/Default/Bullet/Instanced/Bullet.tscn");
    }

    public override void _Ready()
    {

    }


    public override void _Process(float delta)
    {
        if (Input.IsKeyPressed(69))
        {
            var Ballet = rlBullet.Instance();
            AddChild(Ballet);

        }
    }
}
