using System.Collections.Generic;

namespace MazeSolver{
    class Queue{
        private List<Tile> queue;

        public Queue(){
            queue = new List<Tile>();
        }

        public Tile dequeue(){
            Tile deque = queue[0];
            queue.RemoveAt(0);
            return deque;
        }

        public void enqueue(Tile enq){
            queue.Add(enq);
        }

        public int getSize(){
            return queue.Count;
        }
    }
}