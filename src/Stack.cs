using System;
using System.Collections.Generic;

namespace MazeSolver{
    class Stack{
        private List<Tile> stack;

        public Stack(){
            stack = new List<Tile>();
        }

        public Tile pop(){
            Tile pop = stack[0];
            stack.RemoveAt(0);
            return pop;
        }

        public void push(Tile push){
            stack.Insert(0,push);
        }

        public int getSize(){
            return stack.Count;
        }
    }
}