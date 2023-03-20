using System.Diagnostics;

namespace MazeSolver{
    class Program{
        static void Main(string[] args){
            IO io = new IO();
            Reader reader = new Reader();
            BFS bfs = new BFS();
            DFS dfs = new DFS();
            Stopwatch stopwatch = new Stopwatch();

            string filePath = io.getString("Masukkan nama file: ");
            Maze newMaze = new (reader.readFile(filePath));
            newMaze.printMaze();

            

            stopwatch.Start();
            List<char> path = bfs.Solver(newMaze);
            stopwatch.Stop();
            TimeSpan executionTime = stopwatch.Elapsed;
            
            // Output
            newMaze.printMaze();
            Console.WriteLine("");
            Console.WriteLine($"Path: {io.pathToString(path)}");
            Console.WriteLine($"Step: {path.Count}");
            Console.WriteLine($"Time: {executionTime.TotalMilliseconds} ms");            
        }
    }
}
