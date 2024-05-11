using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningSimulator {
    public class Rune {
        public int tier { get; set; }
        public RuneName name { get; set; }
        public enum RuneName {
            Expert = 0,
            Master = 1,
            Rebirth = 2,
            Health = 3,
            Cure = 4,
            Attack = 5,
            Critical = 6,
            Luck = 7,
            Blitz = 8,
            Blessing = 9
        }
        public Rune(RuneName name, int tier) {
            this.name = name;
            this.tier = tier;
        }
        public Rune(int tier) {
            this.tier = tier;

            // Generates a random number between 0 and 9
            int randomRuneIndex = Globals.randomRuneGeneration.Next(10);

            // Assigning the corresponding RuneName based on the random index
            this.name = (RuneName)randomRuneIndex;
        }
        public Rune() {

        }
        public Rune clone() {
            var clone = new Rune();
            clone.tier = this.tier;
            clone.name = this.name; 
            return clone;
        }
    }
}
