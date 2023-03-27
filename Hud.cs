using Godot;
using System;

public class Hud : CanvasLayer
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    //  Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)

    //  {
    //      
    //  }

    public void UpdateScore(int score)
    {
        GetNode<Label>("score").Text = score.ToString();
    }
}
