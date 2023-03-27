using Godot;
using System;

public class optical : RigidBody2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        ApplyImpulse(Vector2.Zero, new Vector2(Gloable.speed, 0));
    }


    public void _on_VisibilityNotifier2D_screen_exited()
    {
        QueueFree();
    }
}
