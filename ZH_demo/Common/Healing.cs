using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Healing : ICharm
    {
        //public int Strength { get; set; }
        private int Strength;

        public Healing(int strength)
        {
            Strength = strength;
        }

        public void Cast(Player p)
        {
            p.HP += Strength;
        }
    }
}
