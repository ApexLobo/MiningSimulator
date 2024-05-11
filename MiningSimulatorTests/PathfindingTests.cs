using MiningSimulator;
using Newtonsoft.Json;
using System.Drawing;

[TestClass]
public class PathfindingTests {
    [TestMethod]
    public void TestDijkstraPathfindingToRuneT2WithPickDamage1() {
        string outputDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectDir = Directory.GetParent(outputDir).Parent.Parent.Parent.FullName;

        string jsonFilePath = Path.Combine(projectDir, "test_grid.json");
        string json = File.ReadAllText(jsonFilePath);

        Globals.pickDamage = 1;

        // Deserialize the JSON string back into a MiningNodeGrid object
        MiningNodeGrid miningNodeGrid = JsonConvert.DeserializeObject<MiningNodeGrid>(json, new BitmapJsonConverter());


        Point startNode = new Point(3, 3);
        Point endNode = new Point(1, 1);
        var pathfinding = new DijkstraPathfinding();

        var (cost, path) = pathfinding.getShortestPath(miningNodeGrid, startNode, endNode);

        // Assert
        var expectedCost = 22;
        var expectedPath = new List<Point> { new Point(3, 2), new Point(2, 2), new Point(1, 2), new Point(1, 1) };

        Assert.AreEqual(expectedCost, cost);
        CollectionAssert.AreEqual(expectedPath, path);
    }
    [TestMethod]
    public void TestDijkstraPathfindingFromActiveRDT3ToRuneT2WithPickDamage1() {
        string outputDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectDir = Directory.GetParent(outputDir).Parent.Parent.Parent.FullName;

        string jsonFilePath = Path.Combine(projectDir, "test_grid.json");
        string json = File.ReadAllText(jsonFilePath);

        Globals.pickDamage = 1;

        // Deserialize the JSON string back into a MiningNodeGrid object
        MiningNodeGrid miningNodeGrid = JsonConvert.DeserializeObject<MiningNodeGrid>(json, new BitmapJsonConverter());


        Point startNode = new Point(4, 2);
        Point endNode = new Point(1, 1);
        var pathfinding = new DijkstraPathfinding();

        var (cost, path) = pathfinding.getShortestPath(miningNodeGrid, startNode, endNode);

        // Assert
        var expectedCost = 22;
        var expectedPaths = new List<List<Point>> {
            new List<Point> { new Point(3, 2), new Point(2, 2), new Point(1, 2), new Point(1, 1) },
            new List<Point> { new Point(3, 2), new Point(3, 1), new Point(3, 0), new Point(2, 0), new Point(1, 0), new Point(1, 1) }
        };

        Assert.AreEqual(expectedCost, cost);
        CollectionAssert.Contains(expectedPaths.Select(p => p.SequenceEqual(path)).ToList(), true);
    }
    [TestMethod]
    public void TestDijkstraPathfindingToRuneT2WithPickDamage2() {
        string outputDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectDir = Directory.GetParent(outputDir).Parent.Parent.Parent.FullName;

        string jsonFilePath = Path.Combine(projectDir, "test_grid.json");
        string json = File.ReadAllText(jsonFilePath);

        Globals.pickDamage = 2;

        // Deserialize the JSON string back into a MiningNodeGrid object
        MiningNodeGrid miningNodeGrid = JsonConvert.DeserializeObject<MiningNodeGrid>(json, new BitmapJsonConverter());
        miningNodeGrid.updateNodeCostsBasedOnPickDamage();

        Point startNode = new Point(3, 3);
        Point endNode = new Point(1, 1);
        var pathfinding = new DijkstraPathfinding();

        var (cost, path) = pathfinding.getShortestPath(miningNodeGrid, startNode, endNode);

        // Assert
        var expectedCost = 11;
        var expectedPath = new List<Point> { new Point(3, 2), new Point(3, 1), new Point(2, 1), new Point(1, 1) };
        Assert.AreEqual(expectedCost, cost);
        CollectionAssert.AreEqual(expectedPath, path);
    }
    [TestMethod]
    public void TestDijkstraPathfindingToInactiveRDT2WithPickDamage1() {
        string outputDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectDir = Directory.GetParent(outputDir).Parent.Parent.Parent.FullName;

        string jsonFilePath = Path.Combine(projectDir, "test_grid.json");
        string json = File.ReadAllText(jsonFilePath);

        Globals.pickDamage = 1;

        // Deserialize the JSON string back into a MiningNodeGrid object
        MiningNodeGrid miningNodeGrid = JsonConvert.DeserializeObject<MiningNodeGrid>(json, new BitmapJsonConverter());
        miningNodeGrid.updateNodeCostsBasedOnPickDamage();

        Point startNode = new Point(3, 3);
        Point endNode = new Point(0, 3);
        var pathfinding = new DijkstraPathfinding();

        var (cost, path) = pathfinding.getShortestPath(miningNodeGrid, startNode, endNode);

        // Assert
        var expectedCost = 4;
        var expectedPath = new List<Point> { new Point(3, 2), new Point(2, 2), new Point(1, 2), new Point(1, 3), new Point(0, 3) };
        Assert.AreEqual(expectedCost, cost);
        CollectionAssert.AreEqual(expectedPath, path);
    }
    [TestMethod]
    public void TestDijkstraPathfindingToInactiveRDT2WithPickDamage3() {
        string outputDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectDir = Directory.GetParent(outputDir).Parent.Parent.Parent.FullName;

        string jsonFilePath = Path.Combine(projectDir, "test_grid.json");
        string json = File.ReadAllText(jsonFilePath);

        Globals.pickDamage = 3;

        // Deserialize the JSON string back into a MiningNodeGrid object
        MiningNodeGrid miningNodeGrid = JsonConvert.DeserializeObject<MiningNodeGrid>(json, new BitmapJsonConverter());
        miningNodeGrid.updateNodeCostsBasedOnPickDamage();

        Point startNode = new Point(3, 3);
        Point endNode = new Point(0, 3);
        var pathfinding = new DijkstraPathfinding();

        var (cost, path) = pathfinding.getShortestPath(miningNodeGrid, startNode, endNode);

        // Assert
        var expectedCost = 4;
        var expectedPath = new List<Point> { new Point(2, 3), new Point(1, 3), new Point(0, 3) };
        Assert.AreEqual(expectedCost, cost);
        CollectionAssert.AreEqual(expectedPath, path);
    }
    [TestMethod]
    public void TestAStarPathfindingToRuneT2WithPickDamage1() {
        string outputDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectDir = Directory.GetParent(outputDir).Parent.Parent.Parent.FullName;

        string jsonFilePath = Path.Combine(projectDir, "test_grid.json");
        string json = File.ReadAllText(jsonFilePath);

        Globals.pickDamage = 1;

        // Deserialize the JSON string back into a MiningNodeGrid object
        MiningNodeGrid miningNodeGrid = JsonConvert.DeserializeObject<MiningNodeGrid>(json, new BitmapJsonConverter());
        miningNodeGrid.updateNodeCostsBasedOnPickDamage();

        Point startNode = new Point(3, 3);
        Point endNode = new Point(1, 1);
        var pathfinding = new AStarPathfinding();

        var (cost, path) = pathfinding.getShortestPath(miningNodeGrid, startNode, endNode);

        // Assert
        var expectedCost = 22;
        var expectedPath = new List<Point> { new Point(3, 2), new Point(2, 2), new Point(1, 2), new Point(1, 1) };
        Assert.AreEqual(expectedCost, cost);
        CollectionAssert.AreEqual(expectedPath, path);
    }
    [TestMethod]
    public void TestAStarPathfindingToRuneT2WithPickDamage2() {
        string outputDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectDir = Directory.GetParent(outputDir).Parent.Parent.Parent.FullName;

        string jsonFilePath = Path.Combine(projectDir, "test_grid.json");
        string json = File.ReadAllText(jsonFilePath);

        Globals.pickDamage = 2;

        // Deserialize the JSON string back into a MiningNodeGrid object
        MiningNodeGrid miningNodeGrid = JsonConvert.DeserializeObject<MiningNodeGrid>(json, new BitmapJsonConverter());
        miningNodeGrid.updateNodeCostsBasedOnPickDamage();

        Point startNode = new Point(3, 3);
        Point endNode = new Point(1, 1);
        var pathfinding = new AStarPathfinding();

        var (cost, path) = pathfinding.getShortestPath(miningNodeGrid, startNode, endNode);

        // Assert
        var expectedCost = 11;
        var expectedPath = new List<Point> { new Point(3, 2), new Point(3, 1), new Point(2, 1), new Point(1, 1) };
        Assert.AreEqual(expectedCost, cost);
        CollectionAssert.AreEqual(expectedPath, path);
    }
    [TestMethod]
    public void TestTSPPathfindingToInterestingItemsWithPickDamage2() {
        string outputDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectDir = Directory.GetParent(outputDir).Parent.Parent.Parent.FullName;

        string jsonFilePath = Path.Combine(projectDir, "test_grid.json");
        string json = File.ReadAllText(jsonFilePath);

        Globals.pickDamage = 2;

        // Deserialize the JSON string back into a MiningNodeGrid object
        MiningNodeGrid miningNodeGrid = JsonConvert.DeserializeObject<MiningNodeGrid>(json, new BitmapJsonConverter());
        miningNodeGrid.updateNodeCostsBasedOnPickDamage();

        Point startNode = new Point(3, 3);
        List<Point> endNodes = new List<Point>();
        endNodes.Add(new Point(4, 2));
        endNodes.Add(new Point(1, 1));
        endNodes.Add(new Point(0, 3));

        var pathfinding = new TravelingSalesmanPathfinding();

        var (cost, path) = pathfinding.getShortestPath(miningNodeGrid, startNode, endNodes);

        // Assert
        var expectedCost = 15;
        var expectedPath = new List<Point> { new Point(3, 3), new Point(3, 2), new Point(4, 2), new Point(3, 1), new Point(2, 1), new Point(1, 1), new Point(1, 2), new Point(1, 3), new Point(0, 3) };
        Assert.AreEqual(expectedCost, cost);
        CollectionAssert.AreEqual(expectedPath, path);
    }
    [TestMethod]
    public void Test2TSPPathfindingToInterestingItemsWithPickDamage2() {
        string outputDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectDir = Directory.GetParent(outputDir).Parent.Parent.Parent.FullName;

        string jsonFilePath = Path.Combine(projectDir, "test_grid2.json");
        string json = File.ReadAllText(jsonFilePath);

        Globals.pickDamage = 2;

        // Deserialize the JSON string back into a MiningNodeGrid object
        MiningNodeGrid miningNodeGrid = JsonConvert.DeserializeObject<MiningNodeGrid>(json, new BitmapJsonConverter());
        miningNodeGrid.updateNodeCostsBasedOnPickDamage();

        Point startNode = new Point(3, 3);
        List<Point> endNodes = new List<Point>();
        endNodes.Add(new Point(5, 1));
        endNodes.Add(new Point(6, 3));

        var pathfinding = new TravelingSalesmanPathfinding();

        var (cost, path) = pathfinding.getShortestPath(miningNodeGrid, startNode, endNodes);

        // Assert
        var expectedCost = 14;
        var expectedPath = new List<Point> { new Point(3, 3), new Point(3, 2), new Point(3, 1), new Point(4, 1), new Point(5, 1), new Point(5, 2), new Point(6, 2), new Point(6, 3)};
        Assert.AreEqual(expectedCost, cost);
        CollectionAssert.AreEqual(expectedPath, path);
    }
}
