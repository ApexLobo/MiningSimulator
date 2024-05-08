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
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalLightRockMined = 0;
        public static int totalLightRockMined {
            get => _totalLightRockMined;
            set {
                if (_totalLightRockMined != value) {
                    _totalLightRockMined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalDarkRockMined = 0;
        public static int totalDarkRockMined {
            get => _totalDarkRockMined;
            set {
                if (_totalDarkRockMined != value) {
                    _totalDarkRockMined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalSolidRockMined = 0;
        public static int totalSolidRockMined {
            get => _totalSolidRockMined;
            set {
                if (_totalSolidRockMined != value) {
                    _totalSolidRockMined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalDiamondsT1Mined = 0;
        public static int totalDiamondsT1Mined {
            get => _totalDiamondsT1Mined;
            set {
                if (_totalDiamondsT1Mined != value) {
                    _totalDiamondsT1Mined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalDiamondsT2Mined = 0;
        public static int totalDiamondsT2Mined {
            get => _totalDiamondsT2Mined;
            set {
                if (_totalDiamondsT2Mined != value) {
                    _totalDiamondsT2Mined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalDiamondsT3Mined = 0;
        public static int totalDiamondsT3Mined {
            get => _totalDiamondsT3Mined;
            set {
                if (_totalDiamondsT3Mined != value) {
                    _totalDiamondsT3Mined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalRedDiamondsT1Mined = 0;
        public static int totalRedDiamondsT1Mined {
            get => _totalRedDiamondsT1Mined;
            set {
                if (_totalRedDiamondsT1Mined != value) {
                    _totalRedDiamondsT1Mined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalRedDiamondsT2Mined = 0;
        public static int totalRedDiamondsT2Mined {
            get => _totalRedDiamondsT2Mined;
            set {
                if (_totalRedDiamondsT2Mined != value) {
                    _totalRedDiamondsT2Mined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalRedDiamondsT3Mined = 0;
        public static int totalRedDiamondsT3Mined {
            get => _totalRedDiamondsT3Mined;
            set {
                if (_totalRedDiamondsT3Mined != value) {
                    _totalRedDiamondsT3Mined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalRunesT1Mined = 0;
        public static int totalRunesT1Mined {
            get => _totalRunesT1Mined;
            set {
                if (_totalRunesT1Mined != value) {
                    _totalRunesT1Mined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalRunesT2Mined = 0;
        public static int totalRunesT2Mined {
            get => _totalRunesT2Mined;
            set {
                if (_totalRunesT2Mined != value) {
                    _totalRunesT2Mined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalRunesT3Mined = 0;
        public static int totalRunesT3Mined {
            get => _totalRunesT3Mined;
            set {
                if (_totalRunesT3Mined != value) {
                    _totalRunesT3Mined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalDiamondValueMined = 0;
        public static int totalDiamondValueMined {
            get => _totalDiamondValueMined;
            set {
                if (_totalDiamondValueMined != value) {
                    _totalDiamondValueMined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalRedDiamondValueMined = 0;
        public static int totalRedDiamondValueMined {
            get => _totalRedDiamondValueMined;
            set {
                if (_totalRedDiamondValueMined != value) {
                    _totalRedDiamondValueMined = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalPicksUsed = 0;
        public static int totalPicksUsed {
            get => _totalPicksUsed;
            set {
                if (_totalPicksUsed != value) {
                    _totalPicksUsed = value;
                    OnStatisticsChanged();
                }
            }
        }

        private static int _totalDepthMined = 0;
        public static int totalDepthMined {
            get => _totalDepthMined;
            set {
                if (_totalDepthMined != value) {
                    _totalDepthMined = value;
                    OnStatisticsChanged();
                }
            }
        }
        private static int _totalDiamondsT1Seen = 0;
        public static int totalDiamondsT1Seen {
            get => _totalDiamondsT1Seen;
            set {
                if (_totalDiamondsT1Seen != value) {
                    _totalDiamondsT1Seen = value;
                    OnStatisticsChanged();
                }
            }
        }
        private static int _totalDiamondsT2Seen = 0;
        public static int totalDiamondsT2Seen {
            get => _totalDiamondsT2Seen;
            set {
                if (_totalDiamondsT2Seen != value) {
                    _totalDiamondsT2Seen = value;
                    OnStatisticsChanged();
                }
            }
        }
        private static int _totalDiamondsT3Seen = 0;
        public static int totalDiamondsT3Seen {
            get => _totalDiamondsT3Seen;
            set {
                if (_totalDiamondsT3Seen != value) {
                    _totalDiamondsT3Seen = value;
                    OnStatisticsChanged();
                }
            }
        }
        private static int _totalRedDiamondsT1Seen = 0;
        public static int totalRedDiamondsT1Seen {
            get => _totalRedDiamondsT1Seen;
            set {
                if (_totalRedDiamondsT1Seen != value) {
                    _totalRedDiamondsT1Seen = value;
                    OnStatisticsChanged();
                }
            }
        }
        private static int _totalRedDiamondsT2Seen = 0;
        public static int totalRedDiamondsT2Seen {
            get => _totalRedDiamondsT2Seen;
            set {
                if (_totalRedDiamondsT2Seen != value) {
                    _totalRedDiamondsT2Seen = value;
                    OnStatisticsChanged();
                }
            }
        }
        private static int _totalRedDiamondsT3Seen = 0;
        public static int totalRedDiamondsT3Seen {
            get => _totalRedDiamondsT3Seen;
            set {
                if (_totalRedDiamondsT3Seen != value) {
                    _totalRedDiamondsT3Seen = value;
                    OnStatisticsChanged();
                }
            }
        }
        private static int _totalRunesT1Seen = 0;
        public static int totalRunesT1Seen {
            get => _totalRunesT1Seen;
            set {
                if (_totalRunesT1Seen != value) {
                    _totalRunesT1Seen = value;
                    OnStatisticsChanged();
                }
            }
        }
        private static int _totalRunesT2Seen = 0;
        public static int totalRunesT2Seen {
            get => _totalRunesT2Seen;
            set {
                if (_totalRunesT2Seen != value) {
                    _totalRunesT2Seen = value;
                    OnStatisticsChanged();
                }
            }
        }
        private static int _totalRunesT3Seen = 0;
        public static int totalRunesT3Seen {
            get => _totalRunesT3Seen;
            set {
                if (_totalRunesT3Seen != value) {
                    _totalRunesT3Seen = value;
                    OnStatisticsChanged();
                }
            }
        }

        // Variable for tracking mined runes of each type and tier
        private static int[,] _minedRunesByTier = new int[10,3];

        // Properties for accessing and setting mined runes of each type and tier
        public static int getRunesMinedByTier(Rune.RuneName runeName, int tier) {
            return _minedRunesByTier[(int)runeName, tier - 1];
        }

        public static void addRuneMinedByTier(Rune.RuneName runeName, int tier) {
            _minedRunesByTier[(int)runeName, tier - 1]++;
            OnStatisticsChanged();
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
            Console.WriteLine($"Total Diamonds T1 Mined: {totalDiamondsT1Mined} out of {totalDiamondsT1Seen}");
            Console.WriteLine($"Total Diamonds T2 Mined: {totalDiamondsT2Mined} out of {totalDiamondsT2Seen}");
            Console.WriteLine($"Total Diamonds T3 Mined: {totalDiamondsT3Mined} out of {totalDiamondsT3Seen}");
            Console.WriteLine($"Total Red Diamonds T1 Mined: {totalRedDiamondsT1Mined} out of {totalRedDiamondsT1Seen}");
            Console.WriteLine($"Total Red Diamonds T2 Mined: {totalRedDiamondsT2Mined} out of {totalRedDiamondsT2Seen}");
            Console.WriteLine($"Total Red Diamonds T3 Mined: {totalRedDiamondsT3Mined} out of {totalRedDiamondsT3Seen}");
            Console.WriteLine($"Total Runes T1 Mined: {totalRunesT1Mined} out of {totalRunesT1Seen}");
            Console.WriteLine($"Total Runes T2 Mined: {totalRunesT2Mined} out of {totalRunesT2Seen}");
            Console.WriteLine($"Total Runes T3 Mined: {totalRunesT3Mined} out of {totalRunesT3Seen}");
            Console.WriteLine($"Total Diamond Value Mined: {totalDiamondValueMined}");
            Console.WriteLine($"Total Red Diamond Value Mined: {totalRedDiamondValueMined}");
            Console.WriteLine("");
            Console.WriteLine("===== Rune simulation statistics =====");
            // Adding mined rune statistics by tier
            foreach (Rune.RuneName runeName in Enum.GetValues(typeof(Rune.RuneName))) {
                for (int tier = 1; tier <= 3; tier++) {
                    int count = getRunesMinedByTier(runeName, tier);
                    Console.WriteLine($"Total {runeName} T{tier} Mined: {count}");
                }
            }
        }
        // Method to raise the stats changed event
        private static void OnStatisticsChanged() {
            // Check if there are any subscribers to the event
            statisticsChanged?.Invoke();
        }
    }
}
