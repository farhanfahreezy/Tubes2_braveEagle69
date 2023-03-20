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

        public T getElmt(int i){
            return stack[i];
        }

        public bool isInside(T elmt){
            return stack.Contains(elmt);
        }

        public void removeEl(T elmt){
            stack.Remove(elmt);
        }


        
    }
}