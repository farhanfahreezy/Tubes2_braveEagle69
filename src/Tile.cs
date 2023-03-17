using System;

namespace MazeSolver{
    class Tile{
        private char type;
        private char pathBefore;
        private int shortestPath;

        public Tile(char c){
            type = c;
            pathBefore = 'Z';
            shortestPath = -1;
        }

        public char getPathBefore()
        {
            return this.pathBefore;
        }

        public void setPathBefore(char pathBefore)
        {
            this.pathBefore = pathBefore;
        }

        public int getShortestPath()
        {
            return this.shortestPath;
        }

        public void setShortestPath(int shortestPath)
        {
            this.shortestPath = shortestPath;
        }

        public void printTile(){
            Console.Write(type);
        }
    }
}