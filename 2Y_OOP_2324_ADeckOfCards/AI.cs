using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class AI
    {
        public bool Choice(int Value, int Player)
        {
            bool Aggresive = strat(Value, Player);
            bool choice = Decision(Aggresive, Value);
            return choice;
        }
        private bool strat(int Value, int player)
        {
            //if true the computer will go for riskier plays
            if (Value < player)
            {
                return true;
            }
            else
                return false;
        }
        private bool Decision(bool Strat, int value)
        {
            bool Safe = false;
            if (value > 15)
                Safe = true;
            bool draw = false;

            if (Safe)
                draw = Safeplay(value, Strat);
            else
                draw = play(value, Strat);
                
            return draw;
        }
        private bool Safeplay(int Value, bool aggresive) 
        {
            Random rnd = new Random();
            int chance = 0;
            for(int i = 0; i < 7; i++)
                chance = rnd.Next(1, 100);
            bool draw = false;
            if(aggresive) 
            {
                if(chance > 70)
                {
                    draw= true;
                }
            }
            else
            {
                if (chance > 85)
                    draw = true;
            }
            return draw;
        }
        private bool play(int Value, bool aggresive)
        {
            Random rnd = new Random();
            int chance = 0;
            for (int i = 0; i < 7; i++)
                chance = rnd.Next(1, 100);
            bool draw = false;
            if (aggresive)
            {
                if (chance > 10)
                {
                    draw = true;
                }
            }
            else
            {
                if (chance > 25)
                    draw = true;
            }
            return draw;
        }

    }
}
