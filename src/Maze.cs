using System;
using System.Collections.Generic;
using System.Drawing;

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
                    if (maze[i,j].getIsChecked())
                    {
                        numOfChecked++;
                    }
                }
            }
            return numOfChecked;
        }
        public void resetStatusMaze()
        {
            for(int i=1; i<sizeY+1; i++)
            {
                for (int j = 1; j < sizeX + 1; j++)
                {
                    Tile tile = getTile(j, i);
                    if (tile.getStatus() != -1) { tile.setStatus(-1); }
                }
            }
        }
        public void getPath(Tile check, Maze maze, List<char> path)
        {
            List<char> tempChar = new List<char>();
            Tile treasure = new Tile(check.getType(), check.getPosition().getX(), check.getPosition().getY());
            treasure.setPathBefore(check.getPathBefore());
            check.setType('F');
            check.addNumOfStepped();

            treasure = getPreviousPath(treasure, tempChar, maze);

            while (treasure.getPathBefore() != 'S')
            {
                treasure = getPreviousPath(treasure, tempChar, maze);
            }
            treasure.decreaseNumOfStepped();
            path.AddRange(tempChar);
        }
        public Tile getPreviousPath(Tile treasure, List<char> tempChar, Maze maze)
        {
            int treasureX = treasure.getPosition().getX();
            int treasureY = treasure.getPosition().getY();
            if (treasure.getType() == 'R')
            {
                coloringPath(treasure.getPosition().getX(), treasure.getPosition().getY(), treasure.getNumOfStepped());
            }
            if (treasure.getPathBefore() == 'U')
            {
                tempChar.Insert(0, 'D');
                treasure = maze.getTile(treasureX, treasureY - 1);
            }
            else if (treasure.getPathBefore() == 'D')
            {
                tempChar.Insert(0, 'U');
                treasure = maze.getTile(treasureX, treasureY + 1);
            }
            else if (treasure.getPathBefore() == 'L')
            {
                tempChar.Insert(0, 'R');
                treasure = maze.getTile(treasureX - 1, treasureY);
            }
            else if (treasure.getPathBefore() == 'R')
            {
                tempChar.Insert(0, 'L');
                treasure = maze.getTile(treasureX + 1, treasureY);
            }
            treasure.addNumOfStepped();
            return treasure;
        }
        public void coloringPath(int x, int y, int numStep)
        {
            if (numStep == 1)
            {
                Global.changeColor(x, y, Color.FromArgb(192,255,192));
            }
            else if (numStep == 2)
            {
                Global.changeColor(x, y, Color.FromArgb(128, 255, 128));
            }
            else if (numStep == 3)
            {
                Global.changeColor(x, y, Color.Lime);
            }
            else if (numStep == 4)
            {
                Global.changeColor(x, y, Color.FromArgb(0, 192, 0));
            }
            else if (numStep == 5)
            {
                Global.changeColor(x, y, Color.Green);
            }
            else if (numStep >= 6)
            {
                Global.changeColor(x, y, Color.FromArgb(0, 64, 0));
            }
        }
    }
}