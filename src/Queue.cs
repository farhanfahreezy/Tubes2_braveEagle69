using System.Collections.Generic;

namespace MazeSolver{
    class Queue<T>{
        private List<T> queue;

        public Queue(){
            queue = new List<T>();
        }

        public T dequeue(){
            T deque = queue[0];
            queue.RemoveAt(0);
            return deque;
        }

        public void enqueue(T enq){
            queue.Add(enq);
        }

        public int getSize(){
            return queue.Count;
        }
    }
}