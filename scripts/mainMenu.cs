using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

namespace infintrunner.scripts
{
    public class mainMenu : Node2D
    {
        public int lastScore;

        private saveLoadFromFile scoreScript;
        // Called when the node enters the scene tree for the first time.
        private System.Collections.Generic.List<ScoreBord> scoreList = new System.Collections.Generic.List<ScoreBord>();
        private Godot.ItemList itemList;
        private LineEdit inputField;
        public override void _Ready()
        {

            //scoreScript = (saveLoadFromFile)ResourceLoader.Load<CSharpScript>("res://scripts/saveLoadFromFile.cs").New();
            inputField = (LineEdit)GetNode<CanvasLayer>("CanvasLayer").GetNode("LineEdit");
            scoreScript = (saveLoadFromFile)ResourceLoader.Load<CSharpScript>("res://scripts/saveLoadFromFile.cs").New();
            itemList = (ItemList)GetNode<CanvasLayer>("CanvasLayer").GetNode("ItemList");
            scoreList = scoreScript.LoadScore();
            inputField.Hide();
            if (Gloable.score != 0)
            {
                var scoreLabel = (Label)GetNode<CanvasLayer>("CanvasLayer").GetNode("score");
                scoreLabel.Text = Gloable.score.ToString();
                inputField.Show();
            }
            SortScores();
        }

        //  Called every frame. 'delta' is the elapsed time since the previous frame.
        //  public override void _Process(float delta)
        //  {
        //      
        //  }

        private void SortScores()
        {
            itemList.Clear();
            var sortedScores = scoreList.OrderByDescending(x => x.Score).ToList();
            foreach (var item in sortedScores)
            {
                itemList.AddItem(item.Name + ": " + item.Score.ToString(), null, false);
            }
        }


        public void _on_LineEdit_text_entered(string text)
        {
            scoreList.Add(new ScoreBord(text, Gloable.score));
            scoreScript.save(scoreList);
            SortScores();
            inputField.Hide();
        }
        public void _on_delete_pressed()
        {
            scoreScript.Delete();
            var itemList = (ItemList)GetNode<CanvasLayer>("CanvasLayer").GetNode("ItemList");
            itemList.Clear();
        }


        public void _on_StartButton_pressed()
        {
            GetTree().ChangeScene("res://scens/Main.tscn");
        }
    }
}