﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiningSimulator {
    public class MiningNodeGenerator {
        public MiningNodeGenerator() {
        }

        public MiningNode generateRandomNode() {
            // Define rates for each MiningNodeName

            Dictionary<MiningNodeType.MiningNodeName, int> rates = new Dictionary<MiningNodeType.MiningNodeName, int> {
            { MiningNodeType.MiningNodeName.Empty, 10000 },
            { MiningNodeType.MiningNodeName.Dirt, 50000 },
            { MiningNodeType.MiningNodeName.Light_Rock, 20000 },
            { MiningNodeType.MiningNodeName.Dark_Rock, 20000 },
            { MiningNodeType.MiningNodeName.Solid_Rock, 10000 },
            { MiningNodeType.MiningNodeName.Diamond_T1, 3000 },
            { MiningNodeType.MiningNodeName.Diamond_T2, 2000 },
            { MiningNodeType.MiningNodeName.Diamond_T3, 1000 },
            { MiningNodeType.MiningNodeName.Red_Diamond_T1, 3000 },
            { MiningNodeType.MiningNodeName.Red_Diamond_T2, 2000 },
            { MiningNodeType.MiningNodeName.Red_Diamond_T3, 1000 },
            { MiningNodeType.MiningNodeName.Rune_T1, 3000 },
            { MiningNodeType.MiningNodeName.Rune_T2, 1000 },
            { MiningNodeType.MiningNodeName.Rune_T3, 10 },
            { MiningNodeType.MiningNodeName.Bow_T1, 0 },
            { MiningNodeType.MiningNodeName.Bow_T2, 0 },
            { MiningNodeType.MiningNodeName.Bow_T3, 0 }};


            // Calculate the total weight
            int totalWeight = 0;
            foreach (var pair in rates) {
                totalWeight += pair.Value;
            }


            // Generate a random number between 0 and totalWeight
            double randomNumber = Globals.randomMineGeneration.Next(totalWeight);


            // Select the node based on the random number
            foreach (var pair in rates) {
                if (randomNumber < pair.Value) {
                    // Create and return a MiningNode of the selected type
                    return new MiningNode(88) {
                        type = new MiningNodeType(pair.Key, false)
                    };
                }
                randomNumber -= pair.Value;
            }

            // This should not happen, but in case of issues, return a default node
            return new MiningNode(-1);
        }
    }
}
