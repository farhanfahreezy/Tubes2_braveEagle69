using System;

namespace MazeSolver{
    class Program{
        static void Main(string[] args){
            string filePath = Console.ReadLine() ?? "";
            Reader reader = new Reader();
            Maze newMaze = new (reader.readFile(filePath));
            newMaze.printMaze();
        }
    }
}
