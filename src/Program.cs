using System.Diagnostics;

namespace MazeSolver{
    class Program{
        static void Main(string[] args){
            IO io = new IO();
            Reader reader = new Reader();
            BFS bfs = new BFS();
            DFS dfs = new DFS();
            Stopwatch stopwatch = new Stopwatch();
            List<char> path = new List<char>();

            string filePath = io.getString("Masukkan nama file: ");
            Maze newMaze = new (reader.readFile(filePath));
            newMaze.printMaze();

            
            int option = io.getInt("Masukkan Algorima: ",1,2);
            stopwatch.Start();
            if(option == 1){
                Console.WriteLine("BFS");
                path = bfs.Solver(newMaze);
            } else {
                Console.WriteLine("DFS");
                path = dfs.Solver(newMaze);
            }
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
