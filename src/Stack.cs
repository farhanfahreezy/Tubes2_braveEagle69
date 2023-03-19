using System;
using System.Collections.Generic;

namespace MazeSolver{
    class Stack<T>{
        private List<T> stack;

        public Stack(){
            stack = new List<T>();
        }

        public T pop(){
            T pop = stack[0];
            stack.RemoveAt(0);
            return pop;
        }

        public void push(T push){
            stack.Insert(0,push);
        }

        public int getSize(){
            return stack.Count;
        }

        public void clear(){
            stack.Clear();
        }
    }
}