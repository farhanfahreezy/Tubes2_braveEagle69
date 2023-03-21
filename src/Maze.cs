using System;
using System.Collections.Generic;

namespace MazeSolver{
    class Maze{
        private int sizeX;
        private int sizeY;
        private Tile[,] maze;
        private Point start;
        private int treasureCount;

        public Maze(List<List<char>> charArray){
            // Bikin maze yang nambah luaran
            sizeY = charArray.Count;
            sizeX = charArray[0].Count;

            maze = new Tile[sizeY+2,sizeX+2];
            int xtemp = 0;
            int ytemp = 0;
            for(int i = 0;i<sizeY+2;i++){
                for(int j = 0;j<sizeX+2;j++){
                    if(i == 0 || i == sizeY+1 || j == 0 || j == sizeX+1){
                        maze[i,j] = new Tile('X',j,i);
                    } else {
                        maze[i,j] = new Tile(charArray[i-1][j-1],j,i);
                        if(maze[i,j].getType() == 'K'){
                            xtemp = j;
                            ytemp = i;
                        }
                        else if(maze[i,j].getType() == 'T'){
                            treasureCount++;
                        }
                    }
                }
            }
            start = new Point(xtemp,ytemp);
        }
        public void printMaze(){
            for(int i = 0; i<sizeY;i++){
                for(int j = 0; j<sizeX; j++){
                    maze[i+1,j+1].printTile();
                    Console.Write(' ');
                }
                Console.Write("\n");
            }
        }
        public Point getStart(){
            return start;
        }
        public int getTreasureCount(){
            return treasureCount;
        }
        public void decreaseTreasureCount(){
            treasureCount--;
        }
        public Tile getTile(int x, int y){
            return maze[y,x];
        }
        public int getSizeX(){
            return sizeX;
        }
        public int getSizeY(){
            return sizeY;
        }
        public int getNumOfChecked()
        {
            int numOfChecked = 0;
            for(int i = 1; i < sizeY+1; i++)
            {
                for(int j = 0;j<sizeX+1; j++)
                {
                    if (maze[i,j].getStatus() >= 1)
                    {
                        numOfChecked++;
                    }
                }
            }
            return numOfChecked;
        }
    }
}