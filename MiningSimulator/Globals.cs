using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MiningSimulator.MiningNodeType;

namespace MiningSimulator {
    public static class Globals {
        public static readonly int randomSeed = 12345678;
        public static Random randomMineGeneration = new Random(randomSeed);
        public static Random randomRuneGeneration = new Random(randomSeed);
        public static Random randomPathfinding = new Random(randomSeed);
        public static readonly bool debug = false;
        public static readonly bool allowMoveDown = true;
        public static readonly MiningNodeName[] interestingItems = { MiningNodeName.Rune_T3, MiningNodeName.Rune_T2, MiningNodeName.Red_Diamond_T3, MiningNodeName.Red_Diamond_T2 };
        public static readonly MiningNodeName[] itemsToHunt = { MiningNodeName.Rune_T3, MiningNodeName.Rune_T2, MiningNodeName.Red_Diamond_T3 };
        public static int miningDelay = 0;
        public static int pickDamage = 1;
    }
}
