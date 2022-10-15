using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonzolApp
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            List<Player> playingField = new();
            
            playingField.Add(new Player() { HP = 1 });
            playingField.Add(new Player() { HP = 2 });
            playingField.Add(new Player() { HP = 3 });

            //var maxHP = playingField.Max(p => p.HP);
            var maxHP = playingField.Select(p => p.HP).Max();

            var maxHpPlayer = playingField
                .Where(p => p.HP == maxHP).First();
            var areAllBelow5HP = playingField.All(p=>p.HP<=5);
            var isSomeoneAlive = playingField.Any(p => p.HP > 0);
            //Console.WriteLine(
            //    $"Max HP player with HP:{maxHpPlayer.HP}");
            Console.WriteLine(maxHpPlayer);

            var healing = new Healing(3); // { Strength = 3 };
            healing.Cast(maxHpPlayer);

            Console.WriteLine("All players:");
            foreach(var p in playingField)
                Console.WriteLine(p);

            // Sum using Aggregate
            var sumHP = playingField
                .Aggregate(0, (sum, p) => p.HP + sum);
        }
    }
}
