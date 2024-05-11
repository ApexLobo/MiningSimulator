using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static MiningSimulator.MiningNodeType;
using System.Xml.Linq;

namespace MiningSimulator {
    public class MiningNodeType {
        public enum MiningNodeName {
            Empty = 0,
            Dirt = 1,
            Light_Rock = 2,
            Dark_Rock = 3,
            Solid_Rock = 4,
            Diamond_T1 = 5,
            Diamond_T2 = 6,
            Diamond_T3 = 7,
            Red_Diamond_T1 = 8,
            Red_Diamond_T2 = 9,
            Red_Diamond_T3 = 10,
            Rune_T1 = 11,
            Rune_T2 = 12,
            Rune_T3 = 13,
            Bow_T1 = 14,
            Bow_T2 = 15,
            Bow_T3 = 16
        }
        public MiningNodeName name { get; set; }
        public int cost { get; set; }
        public bool active { get; set; }

        public Image typeImage { get; set; }

        public int importance { get; set; }

        public int rewardValue { get; set; }

        public Rune rune { get; set; }
        public MiningNodeType() {

        }
        public MiningNodeType(MiningNodeName name, bool active) {
            this.name = name;
            this.active = active;
            switch (name) {
                case MiningNodeName.Empty:
                    //typeImage = Properties.Resources.empty_space;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["empty_space"];
                    this.cost = 0;
                    this.importance = 0;
                    this.rewardValue = 0;
                    break;
                case MiningNodeName.Dirt:
                    //typeImage = Properties.Resources.dirt;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["dirt"];
                    this.cost = 1;
                    this.importance = 0;
                    this.rewardValue = 0;
                    break;
                case MiningNodeName.Light_Rock:
                    //typeImage = Properties.Resources.light_rock;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["light_rock"];
                    this.cost = 2;
                    this.importance = 0;
                    this.rewardValue = 0;
                    break;
                case MiningNodeName.Dark_Rock:
                    //typeImage = Properties.Resources.dark_rock;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["dark_rock"];
                    this.cost = 5;
                    this.importance = 0;
                    this.rewardValue = 0;
                    break;
                case MiningNodeName.Solid_Rock:
                    //typeImage = Properties.Resources.solid_rock;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["solid_rock"];
                    this.cost = 10;
                    this.importance = 0;
                    this.rewardValue = 0;
                    break;
                case MiningNodeName.Diamond_T1:
                    //typeImage = Properties.Resources.d_t1;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["d_t1"];
                    this.cost = 1;
                    this.importance = 1;
                    this.rewardValue = Globals.randomMineGeneration.Next(10, 31);
                    break;
                case MiningNodeName.Diamond_T2:
                    //typeImage = Properties.Resources.d_t2;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["d_t2"];
                    this.cost = 1;
                    this.importance = 2;
                    this.rewardValue = Globals.randomMineGeneration.Next(100, 301);
                    break;
                case MiningNodeName.Diamond_T3:
                    //typeImage = Properties.Resources.d_t3;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["d_t3"];
                    this.cost = 1;
                    this.importance = 3;
                    this.rewardValue = Globals.randomMineGeneration.Next(1000, 3001);
                    break;
                case MiningNodeName.Red_Diamond_T1:
                    //typeImage = Properties.Resources.rd_t1;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["rd_t1"];
                    this.cost = 2;
                    this.importance = 4;
                    this.rewardValue = Globals.randomMineGeneration.Next(1, 4);
                    break;
                case MiningNodeName.Red_Diamond_T2:
                    //typeImage = Properties.Resources.rd_t2;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["rd_t2"];
                    
                    this.cost = 2;
                    this.importance = 5;
                    this.rewardValue = Globals.randomMineGeneration.Next(4, 11);
                    break;
                case MiningNodeName.Red_Diamond_T3:
                    //typeImage = Properties.Resources.rd_t3;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["rd_t3"];
                    this.cost = 2;
                    this.importance = 6;
                    this.rewardValue = Globals.randomMineGeneration.Next(11, 21);
                    break;
                case MiningNodeName.Rune_T1:
                    //typeImage = Properties.Resources.rune_t1;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["rune_t1"];
                    this.cost = 10;
                    this.importance = 7;
                    this.rewardValue = 1;
                    this.rune = new Rune(1);
                    break;
                case MiningNodeName.Rune_T2:
                    //typeImage = Properties.Resources.rune_t2;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["rune_t2"];
                    this.cost = 20;
                    this.importance = 8;
                    this.rewardValue = 1;
                    this.rune = new Rune(2);
                    break;
                case MiningNodeName.Rune_T3:
                    //typeImage = Properties.Resources.rune_t3;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["rune_t3"];
                    this.cost = 50;
                    this.importance = 9;
                    this.rewardValue = 1;
                    this.rune = new Rune(3);
                    break;
                case MiningNodeName.Bow_T1:
                    //typeImage = Properties.Resources.bow_t1;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["bow_t1"];
                    this.cost = 50;
                    this.importance = 10;
                    this.rewardValue = 1;
                    break;
                case MiningNodeName.Bow_T2:
                    //typeImage = Properties.Resources.bow_t2;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["bow_t2"];
                    this.cost = 50;
                    this.importance = 11;
                    this.rewardValue = 1;
                    break;
                case MiningNodeName.Bow_T3:
                    //typeImage = Properties.Resources.bow_t3;
                    typeImage = BitmapJsonConverter.ResourceBitmaps.Bitmaps["bow_t3"];
                    this.cost = 50;
                    this.importance = 12;
                    this.rewardValue = 1;
                    break;
            }
            updateCostBasedOnPickDamage();
        }
        public MiningNodeType clone() {
            var clone = new MiningNodeType();
            clone.cost = this.cost;
            clone.active = this.active;
            clone.importance = this.importance;
            clone.name = this.name;
            clone.rewardValue = this.rewardValue;
            clone.typeImage = this.typeImage;
            if (this.rune != null) {
                clone.rune = this.rune.clone();
            }
            return clone;
        }
        public void updateCostBasedOnPickDamage() {
            //  Adjust cost based on pick level
            this.cost = (int)Math.Ceiling((double)cost / Globals.pickDamage);
        }
    }
    
    public class MiningNode : IComparable<MiningNode> {
        public int row { get; set; }
        public int col { get; set; }
        public int size { get; set; }



        public MiningNodeType type { get; set; }
        public MiningNode(int row, int col, int size) {
            this.row = row;
            this.col = col;
            this.size = size;
        }
        public MiningNode(int size) {
            this.size = size;
        }
        public MiningNode() {
            this.size = 88;
        }
        public MiningNode clone() {
            var clone = new MiningNode(this.row, this.col, this.size);
            clone.type = type.clone();
            return clone;
        }
        public Point positionToPoint() {
            return new Point(col, row);
        }
        public void updateMinedStats() {
            switch (type.name) {
                case MiningNodeName.Empty:
                    break;
                case MiningNodeName.Dirt:
                    Stats.totalDirtMined++;
                    break;
                case MiningNodeName.Light_Rock:
                    Stats.totalLightRockMined++;
                    break;
                case MiningNodeName.Dark_Rock:
                    Stats.totalDarkRockMined++;
                    break;
                case MiningNodeName.Solid_Rock:
                    Stats.totalSolidRockMined++;
                    break;
                case MiningNodeName.Diamond_T1:
                    Stats.addDiamondsMinedByTier(1);
                    Stats.totalDiamondValueMined += type.rewardValue;
                    break;
                case MiningNodeName.Diamond_T2:
                    Stats.addDiamondsMinedByTier(2);
                    Stats.totalDiamondValueMined += type.rewardValue;
                    break;
                case MiningNodeName.Diamond_T3:
                    Stats.addDiamondsMinedByTier(3);
                    Stats.totalDiamondValueMined += type.rewardValue;
                    break;
                case MiningNodeName.Red_Diamond_T1:
                    Stats.addRedDiamondsMinedByTier(1);
                    Stats.totalRedDiamondValueMined += type.rewardValue;
                    break;
                case MiningNodeName.Red_Diamond_T2:
                    Stats.addRedDiamondsMinedByTier(2);
                    Stats.totalRedDiamondValueMined += type.rewardValue;
                    break;
                case MiningNodeName.Red_Diamond_T3:
                    Stats.addRedDiamondsMinedByTier(3);
                    Stats.totalRedDiamondValueMined += type.rewardValue;
                    break;
                case MiningNodeName.Rune_T1:
                    Stats.addRunesMinedByTier(1);
                    Stats.addRuneMinedByTypeAndTier(type.rune.name, type.rune.tier);
                    break;
                case MiningNodeName.Rune_T2:
                    Stats.addRunesMinedByTier(2);
                    Stats.addRuneMinedByTypeAndTier(type.rune.name, type.rune.tier);
                    break;
                case MiningNodeName.Rune_T3:
                    Stats.addRunesMinedByTier(3);
                    Stats.addRuneMinedByTypeAndTier(type.rune.name, type.rune.tier);
                    break;
                case MiningNodeName.Bow_T1:

                    break;
                case MiningNodeName.Bow_T2:

                    break;
                case MiningNodeName.Bow_T3:

                    break;
            }
            Stats.totalPicksUsed += type.cost;
        }
        public int getCompositeScore() {
            return (this.type.importance * 100) + ((this.type.active ? 1000 : 200) * (4 - this.row));
        }
        public override string ToString() {
            return $"Node: ({row},{col}):{type.name}:{type.active} Score = {getCompositeScore()}";
        }
        public int CompareTo(MiningNode other) {
            // Calculate a composite score based on importance, row, and activity
            int thisCompositeScore = this.getCompositeScore();
            int otherCompositeScore = other.getCompositeScore();

            // Compare the composite scores
            return thisCompositeScore.CompareTo(otherCompositeScore);
        }
    }
}
