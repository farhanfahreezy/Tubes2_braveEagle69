using System;

namespace MazeSolver{
    class Program{
        static void Main(string[] args){
            IO input = new IO();
            Reader reader = new Reader();
            BFS bfs = new BFS();
            DFS dfs = new DFS();

            string filePath = input.getString("Masukkan nama file: ");
            Maze newMaze = new (reader.readFile(filePath));
            newMaze.printMaze();
            List<char> path = dfs.Solver(newMaze);
            foreach(char ch in path){
                Console.WriteLine(ch);
            }
            
        }
    }
}
