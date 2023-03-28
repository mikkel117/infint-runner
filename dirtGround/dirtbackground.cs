using Godot;
using System;

public class dirtbackground : Node2D
{

    [Export]

    public PackedScene treeScene;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    Timer treeSpawnTimer;
    public override void _Ready()
    {
        treeSpawnTimer = GetNode<Timer>("treeSpawnTimer");
        treeSpawnTimer.Start();
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }



    public void _on_treeSpawnTimer_timeout()
    {
        var tree = (tree)treeScene.Instance();
        var treeSpawn = GetNode<Position2D>("treeSpawner");
        tree.Position = treeSpawn.Position;
        AddChild(tree);
        treeSpawnTimer.WaitTime = 1;

    }
}
