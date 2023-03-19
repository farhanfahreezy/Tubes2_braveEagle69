using System;
namespace MazeSolver{
    class Point{
        private int x;
        private int y;
        public Point(int _x, int _y){
            this.x = _x;
            this.y = _y;
        }
        public int getX(){
            return this.x;
        }
        public int getY(){
            return this.y;
        }
        public void setX(int x){
            this.x = x;
        }
        public void setY(int y){
            this.y = y;
        }

        public void print(){
            Console.Write(x);
            Console.Write(" ");
            Console.Write(y);
        }
    }
}