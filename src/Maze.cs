using System;

namespace MazeSolver{
    class Maze{
        private int sizeX;
        private int sizeY;
        private Tile[,] maze;
        private Point start;
        private int treasureCount;

        public Maze(char[,] charArray){
            // Bikin maze yang nambah luaran
            sizeY = charArray.Length/charArray.GetLength(0);
            sizeX = charArray.GetLength(0);
            maze = new Tile[sizeY+2,sizeX+2];
            int xtemp = 0;
            int ytemp = 0;
            for(int i = 0;i<sizeY+2;i++){
                for(int j = 0;j<sizeX+2;j++){
                    if(i == 0 || i == sizeY+1 || j == 0 || j == sizeX+1){
                        maze[i,j] = new Tile('X',j,i);
                    } else {
                        maze[i,j] = new Tile(charArray[i-1,j-1],j,i);
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
            Console.WriteLine(this.treasureCount);
            start.print();
            Console.Write('\n');
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
    }
}