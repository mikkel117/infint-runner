using Godot;
using System;

public class Main : Node2D
{
    [Export]
    public PackedScene groundOpticalScene;
    private Random rnd = new Random();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Gloable.score = 0;
        Gloable.speed = -10;
        var groundTimer = GetNode<Timer>("groundTimer");
        groundTimer.Start();
        GetNode<Timer>("ScoreTimer").Start();
        GetNode<Hud>("mainHud").UpdateScore(Gloable.score);
    }


    //  Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }


    public void _on_groundTimer_timeout()
    {
        int number = rnd.Next(1, 3);
        var Optical = (optical)groundOpticalScene.Instance();
        var groundSpawn = GetNode<Position2D>("groundSpawner");
        var flyingSpawn = GetNode<Position2D>("groundSpawner2");
        if (number == 1)
        {
            Optical.Name = "ground";
            Optical.Position = groundSpawn.Position;
        }
        else
        {
            Optical.Name = "flying";
            Optical.Position = flyingSpawn.Position;
        }
        AddChild(Optical);
        GetNode<Timer>("groundTimer").WaitTime = rnd.Next(2, 4);
    }

    public void _on_ScoreTimer_timeout()
    {
        Gloable.score++;
        GetNode<Hud>("mainHud").UpdateScore(Gloable.score);
        if (Gloable.score % 5 == 0)
        {
            Gloable.speed -= 2;
        }
    }
    public void _on_Player_GameOver()
    {
        GetNode<Timer>("groundTimer").Stop();
        GetNode<Timer>("ScoreTimer").Stop();
        GetTree().ChangeScene("res://scens/mainMenu.tscn");
    }


}
