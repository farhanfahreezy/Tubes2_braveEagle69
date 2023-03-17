using System;

namespace MazeSolver{
    class Maze{
        private int sizeX;
        private int sizeY;
        private Tile[,] maze;

        public Maze(char[,] charArray){
            // Bikin maze yang nambah luaran
            sizeY = charArray.Length;
            sizeX = charArray.GetLength(0);
            maze = new Tile[sizeY+2,sizeX+2];
            for(int i = 0;i<sizeY+2;i++){
                for(int j = 0;j<sizeX+2;j++){
                    if(i == 0 || i == sizeY+1 || j == 0 || j == sizeX+1){
                        maze[i,j] = new Tile('X');
                    } else {
                        maze[i,j] = new Tile(charArray[i-1,j-1]);
                    }
                }
            }
        }

        public void printMaze(){
            for(int i = 0; i<sizeY;i++){
                for(int j = 0; j<sizeX; j++){
                    Console.Write(maze[i+1,j+1]);
                }
                Console.Write("\n");
            }
        }
    }
}