using System;

namespace MazeSolver{
    class Tile{
        private char type;
        private char pathBefore;
        private int status;
        private int numOfStepped;
        private Point position;
        private bool isChecked;

        public Tile(char c, int x, int y){
            position = new Point(x,y);
            type = c;
            pathBefore = 'Z';
            status = -1;
            isChecked = false;
        }

        public char getType(){
            return type;
        }

        public void setType(char c) {
            type=c;
        }
        public char getPathBefore()
        {
            return this.pathBefore;
        }

        public void setPathBefore(char pathBefore)
        {
            this.pathBefore = pathBefore;
        }

        public int getStatus()
        {
            return this.status;
        }

        public void setStatus(int newStatus)
        {
            this.status = newStatus;
        }

        public int getNumOfStepped()
        {
            return this.numOfStepped;
        }
        public void setNumOfStepped(int aaa)
        {
            this.numOfStepped = aaa;
        }
        public void addNumOfStepped(){
            numOfStepped++;
        }
        public void decreaseNumOfStepped(){
            numOfStepped--;
        }
        public void addStatus(){
            this.status++;
        }
        public Point getPosition(){
            return position;
        }
        public bool getIsChecked() { return isChecked; }
        public void setIsChecked(bool v) { isChecked=v; }

        public void printTile(){
            if(type == 'X'){
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
            } else if(numOfStepped!=0){
                if(numOfStepped == 1){
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                } else if(numOfStepped == 2) {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.White;
                } else if(numOfStepped == 3) {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                } else if(numOfStepped == 4) {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                } else if(numOfStepped == 5) {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } else {
                if(status == -1){
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                } else if(status == 0){
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                } else {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                } 
            }
            if(type == 'F'){
                Console.Write('T');
            } else {
                Console.Write(type);
            }
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}