using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MemoryGame
{
    /// <summary>
    /// Gemaakt door Keanu.
    /// </summary>
    class Score
    {
        public Panel ScorePanel;
        public Label NameLabel;
        public Label SetsLabel;

        public string Name = "";
        public int Sets = 0;

        public Score()
        {

        }

        public Score(Panel scorePanel, Label nameLabel, Label setsLabel, string name, int sets)
        {
            ScorePanel = scorePanel;
            NameLabel = nameLabel;
            SetsLabel = setsLabel;
            Name = name;
            Sets = sets;
                        
            ScorePanel.Controls.Add(NameLabel);
            ScorePanel.Controls.Add(SetsLabel);
        }

        internal void SetNewScore(string name, int sets)
        {
            Name = name;
            Sets = sets;
            NameLabel.Text = "Name = " + Name;
            SetsLabel.Text = "Sets = " + sets.ToString();
        }
    }

    class Multiscore
    {
        public Score ScoreOne;
        public Score ScoreTwo;

        public void SetPanel()
        {
            ScoreTwo.ScorePanel = ScoreOne.ScorePanel;

            ScoreTwo.ScorePanel.Controls.Add(ScoreTwo.NameLabel);
            ScoreTwo.ScorePanel.Controls.Add(ScoreTwo.SetsLabel);
        }

        /// <summary>
        /// return de hoogste score zodat hij daarop gesorteert kan worden.
        /// </summary>
        /// <returns></returns>
        /// Gemaakt door Keanu.
        public Score GetHighest()
        {
            if(ScoreOne.Sets > ScoreTwo.Sets)
            {
                return ScoreOne;
            }
            else
            {
                return ScoreTwo;
            }
        }
    }
}