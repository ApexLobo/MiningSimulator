namespace MiningSimulator {
    public static class Stats {
        // Define the event for statistics change
        public static event StatisticsChangedEventHandler statisticsChanged;

        private static int _totalDirtMined = 0;
        public static int totalDirtMined {
            get => _totalDirtMined;
            set {
                if (_totalDirtMined != value) {
                    _totalDirtMined = value;
                    onStatisticsChanged();
                }
            }
        }

        private static int _totalLightRockMined = 0;
        public static int totalLightRockMined {
            get => _totalLightRockMined;
            set {
                if (_totalLightRockMined != value) {
                    _totalLightRockMined = value;
                    onStatisticsChanged();
                }
            }
        }

        private static int _totalDarkRockMined = 0;
        public static int totalDarkRockMined {
            get => _totalDarkRockMined;
            set {
                if (_totalDarkRockMined != value) {
                    _totalDarkRockMined = value;
                    onStatisticsChanged();
                }
            }
        }

        private static int _totalSolidRockMined = 0;
        public static int totalSolidRockMined {
            get => _totalSolidRockMined;
            set {
                if (_totalSolidRockMined != value) {
                    _totalSolidRockMined = value;
                    onStatisticsChanged();
                }
            }
        }

        // Variables for tracking mined and seen items of each of the reward types and tier
        private static int[] _totalDiamondsMinedByTier = new int[3];
        private static int[] _totalDiamondsSeenByTier = new int[3];
        private static int[] _totalRedDiamondsMinedByTier = new int[3];
        private static int[] _totalRedDiamondsSeenByTier = new int[3];
        private static int[] _totalRunesMinedByTier = new int[3];
        private static int[] _totalRunesSeenByTier = new int[3];

        // Variable for tracking mined runes of each type and tier
        private static int[,] _minedRunesByTypeAndTier = new int[10, 3];

        // Getter and setter for _totalDiamondsMinedByTier
        public static int getDiamondsMinedByTier(int tier) {
            return _totalDiamondsMinedByTier[tier - 1];
        }

        public static void addDiamondsMinedByTier(int tier) {
            _totalDiamondsMinedByTier[tier - 1]++;
            onStatisticsChanged();
        }

        // Getter and adder for _totalDiamondsSeenByTier
        public static int getDiamondsSeenByTier(int tier) {
            return _totalDiamondsSeenByTier[tier - 1];
        }

        public static void addDiamondsSeenByTier(int tier) {
            _totalDiamondsSeenByTier[tier - 1]++;
            onStatisticsChanged();
        }

        // Getter and setter for _totalRedDiamondsMinedByTier
        public static int getRedDiamondsMinedByTier(int tier) {
            return _totalRedDiamondsMinedByTier[tier - 1];
        }

        public static void addRedDiamondsMinedByTier(int tier) {
            _totalRedDiamondsMinedByTier[tier - 1]++;
            onStatisticsChanged();
        }

        // Getter and adder for _totalRedDiamondsSeenByTier
        public static int getRedDiamondsSeenByTier(int tier) {
            return _totalRedDiamondsSeenByTier[tier - 1];
        }

        public static void addRedDiamondsSeenByTier(int tier) {
            _totalRedDiamondsSeenByTier[tier - 1]++;
            onStatisticsChanged();
        }

        // Getter and adder for _totalRunesMinedByTier
        public static int getRunesMinedByTier(int tier) {
            return _totalRunesMinedByTier[tier - 1];
        }

        public static void addRunesMinedByTier(int tier) {
            _totalRunesMinedByTier[tier - 1]++;
            onStatisticsChanged();
        }

        // Getter and adder for _totalRunesSeenByTier
        public static int getRunesSeenByTier(int tier) {
            return _totalRunesSeenByTier[tier - 1];
        }

        public static void addRunesSeenByTier(int tier) {
            _totalRunesSeenByTier[tier - 1]++;
            onStatisticsChanged();
        }

        // Getter and adder for _minedRunesByTypeAndTier
        public static int getRunesMinedByTypeAndTier(Rune.RuneName runeName, int tier) {
            return _minedRunesByTypeAndTier[(int)runeName, tier - 1];
        }

        public static void addRuneMinedByTypeAndTier(Rune.RuneName runeName, int tier) {
            _minedRunesByTypeAndTier[(int)runeName, tier - 1]++;
            onStatisticsChanged();
        }


        private static int _totalDiamondValueMined = 0;
        public static int totalDiamondValueMined {
            get => _totalDiamondValueMined;
            set {
                if (_totalDiamondValueMined != value) {
                    _totalDiamondValueMined = value;
                    onStatisticsChanged();
                }
            }
        }

        private static int _totalRedDiamondValueMined = 0;
        public static int totalRedDiamondValueMined {
            get => _totalRedDiamondValueMined;
            set {
                if (_totalRedDiamondValueMined != value) {
                    _totalRedDiamondValueMined = value;
                    onStatisticsChanged();
                }
            }
        }

        private static int _totalPicksUsed = 0;
        public static int totalPicksUsed {
            get => _totalPicksUsed;
            set {
                if (_totalPicksUsed != value) {
                    _totalPicksUsed = value;
                    onStatisticsChanged();
                }
            }
        }

        private static int _totalDepthMined = 0;
        public static int totalDepthMined {
            get => _totalDepthMined;
            set {
                if (_totalDepthMined != value) {
                    _totalDepthMined = value;
                    onStatisticsChanged();
                }
            }
        }

        // Method to print statistics to the console
        public static void printStatistics() {
            Console.WriteLine("===== Statistics =====");
            Console.WriteLine($"Pick Damage: {Globals.pickDamage}");
            Console.WriteLine($"Total Picks Used: {totalPicksUsed}");
            Console.WriteLine($"Total Depth Mined: {totalDepthMined}");
            Console.WriteLine($"Total Dirt Mined: {totalDirtMined}");
            Console.WriteLine($"Total Light Rock Mined: {totalLightRockMined}");
            Console.WriteLine($"Total Dark Rock Mined: {totalDarkRockMined}");
            Console.WriteLine($"Total Solid Rock Mined: {totalSolidRockMined}");

            // Print Diamonds by tier
            for (int tier = 1; tier <= 3; tier++) {
                Console.WriteLine($"Total Diamonds T{tier} Mined: {getDiamondsMinedByTier(tier)} out of {getDiamondsSeenByTier(tier)}");
            }

            // Print Red Diamonds by tier
            for (int tier = 1; tier <= 3; tier++) {
                Console.WriteLine($"Total Red Diamonds T{tier} Mined: {getRedDiamondsMinedByTier(tier)} out of {getRedDiamondsSeenByTier(tier)}");
            }

            // Print Runes by tier
            for (int tier = 1; tier <= 3; tier++) {
                Console.WriteLine($"Total Runes T{tier} Mined: {getRunesMinedByTier(tier)} out of {getRunesSeenByTier(tier)}");
            }

            Console.WriteLine($"Total Diamond Value Mined: {totalDiamondValueMined}");
            Console.WriteLine($"Total Red Diamond Value Mined: {totalRedDiamondValueMined}");
            Console.WriteLine("");
            Console.WriteLine("===== Rune simulation statistics =====");

            // Adding mined rune statistics by tier
            foreach (Rune.RuneName runeName in Enum.GetValues(typeof(Rune.RuneName))) {
                for (int tier = 1; tier <= 3; tier++) {
                    int count = getRunesMinedByTypeAndTier(runeName, tier);
                    Console.WriteLine($"Total {runeName} T{tier} Mined: {count}");
                }
            }
        }

        // Method to raise the stats changed event
        private static void onStatisticsChanged() {
            // Check if there are any subscribers to the event
            statisticsChanged?.Invoke();
        }
    }
}
