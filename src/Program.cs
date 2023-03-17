using System;

namespace MazeSolver{
    class Program{
        static void Main(string[] args){
            IO input = new IO();
            Reader reader = new Reader();

            string filePath = input.getString("Masukkan nama file: ");
            Maze newMaze = new (reader.readFile(filePath));
            newMaze.printMaze();
        }
    }
}
