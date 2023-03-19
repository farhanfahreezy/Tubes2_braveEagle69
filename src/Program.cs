using System;

namespace MazeSolver{
    class Program{
        static void Main(string[] args){
            IO input = new IO();
            Reader reader = new Reader();
            BFS bfs = new BFS();

            string filePath = input.getString("Masukkan nama file: ");
            Maze newMaze = new (reader.readFile(filePath));
            newMaze.printMaze();
            List<char> path = bfs.Solver(newMaze);
            foreach(char ch in path){
                Console.WriteLine(ch);
            }
            
        }
    }
}
