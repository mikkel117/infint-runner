using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

public class readFIle : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private const string SaveFilePath = "user://scoreTestFile.txt";
    private Godot.File file = new File();
    private List<string> scores = new List<string>();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        /* scores.Add("1");
        scores.Add("2");
        scores.Add("3");
        scores.Add("4");
        scores.Add("5");
        scores.Add("6"); */
        LoadScore();
        foreach (var item in scores)
        {
            GD.Print(item);
        }
    }




    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
    public void _on_Button_pressed()
    {
        save(scores);
    }

    public void save(List<string> scores)
    {
        //var newList = new List<int>(){2,4,5,6,1,2,4,5 };
        file.Open(SaveFilePath, File.ModeFlags.Write);
        for (int i = 0; i < scores.Count; i++)
        {
            file.StoreLine(scores[i]);
        }
        GD.Print("done");
        file.Close();
    }
    public void LoadScore()
    {
        //var scores = new System.Collections.Generic.List<string>();
        if (file.FileExists(SaveFilePath))
        {
            file.Open(SaveFilePath, File.ModeFlags.Read);
            while (!file.EofReached())
            {
                var currentLine = file.GetLine();
                GD.Print("get " + currentLine);
                scores.Add(currentLine);
            }
            file.Close();

        }
        //return scores;
    }
}
