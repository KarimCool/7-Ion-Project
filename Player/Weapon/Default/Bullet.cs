using Godot;
using System;

public class Bullet : Area2D
{
    private int speed;
    private Vector2 momentum;

    public override void _Ready()
    {
        speed = 320;
        momentum = new Vector2(speed, 0);

    }
    public override void _Process(float delta)
    {
        Position += momentum * delta;

    }
}
