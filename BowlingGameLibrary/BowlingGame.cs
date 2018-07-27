using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameLibrary
{

    public class BowlingGame
    {
        // 
        private int[] rolls = new int[21];
        private int currentRoll = 0;


        public int Score //Calculate Game Score
        {
            get
            {
                var score = 0;
                var rollIndex = 0;
                for (var frame = 0; frame < 10; frame++)
                {
                    if (IsStrike(rollIndex))
                    {
                        score += GetStrikeScore(rollIndex);
                        rollIndex++;

                    }
                    else if (IsSpare(rollIndex))
                    {
                        score += GetSpareScore(rollIndex);
                        rollIndex += 2;
                    }
                    else
                    {
                        score += GetStandardScore(rollIndex);
                        rollIndex += 2;
                    }

                }

                return score;
            }
        }

        // Score Helper Methods
        private int GetStrikeScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

        private int GetStandardScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }

        private int GetSpareScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        public void Roll(int pinCt)
        {
            rolls[currentRoll++] = pinCt;

        }
   
        
    }
}
