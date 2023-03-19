using System;

namespace MazeSolver{
    class Tile{
        private char type;
        private char pathBefore;
        private int status;

        public Tile(char c){
            type = c;
            pathBefore = 'Z';
            status = -1;
        }

        public char getType(){
            return type;
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

        public void printTile(){
            if(type == 'X'){
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
            } else if(status == -1){
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            } else if(status == 0){
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.White;
            } else if(status == 1){
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
            } else if(status == 2){
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            Console.Write(type);
            Console.ResetColor();
        }
    }
}