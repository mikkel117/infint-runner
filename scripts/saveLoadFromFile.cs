using Godot;
using System;
using System.Linq;
using System.Collections.Generic;
namespace infintrunner
{
    public class saveLoadFromFile : Node
    {
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";

        private const string SaveFilePath = "user://score.txt";
        private Godot.File file = new File();
        // Called when the node enters the scene tree for the first time.
        // private System.Collections.Generic.List<string> data = new System.Collections.Generic.List<string>();
        public override void _Ready()
        {
            if (!file.FileExists(SaveFilePath))
            {
                file.Open(SaveFilePath, File.ModeFlags.Write);
                file.Close();
            }
        }


        //saves file to %APPDATA%\Godot\app_userdata
        public void save(List<scripts.ScoreBord> scores)
        {
            file.Open(SaveFilePath, File.ModeFlags.Write);
            foreach (var item in scores)
            {
                file.StoreString(item.Name);
                file.StoreString(" ");
                file.StoreString(item.Score.ToString());
                file.StoreLine("");
            }
            file.Close();
        }
        public List<scripts.ScoreBord> LoadScore()
        {

            var scores = new System.Collections.Generic.List<scripts.ScoreBord>();
            if (file.FileExists(SaveFilePath))
            {
                file.Open(SaveFilePath, File.ModeFlags.Read);
                while (!file.EofReached())
                {
                    var currentLine = file.GetLine();
                    if (currentLine.Empty() == false)
                    {
                        string[] words = currentLine.Split(" ");
                        scores.Add(new scripts.ScoreBord(words[0].ToString(), Int32.Parse(words[1])));
                    }
                }
                file.Close();
            }
            return scores;
        }

        public void Delete()
        {
            file.Open(SaveFilePath, File.ModeFlags.Write);
            file.Close();
            GD.Print("done");
        }


        //  // Called every frame. 'delta' is the elapsed time since the previous frame.
        //  public override void _Process(float delta)
        //  {
        //      
        //  }
    }
}
