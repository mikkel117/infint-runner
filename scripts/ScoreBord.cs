using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infintrunner.scripts
{
    public class ScoreBord
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public ScoreBord(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}