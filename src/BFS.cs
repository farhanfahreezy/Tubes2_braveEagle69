using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace MazeSolver{
    class BFS{
        // Algoritma BFS untuk menemukan jalur yang melewati seluruh Treaasure di maze
        public List<char> Solver(Maze maze){
            Queue<Tile> queue = new Queue<Tile>();
            List<char> path = new List<char>();
            bool searchTSP = false;

            // Mengambil tile pertama yang akan dieksekusi
            Tile start = maze.getTile(maze.getStart().getX(),maze.getStart().getY());
            start.addNumOfStepped();
            enqueue(queue,start,'S');

            // Melakukan algoritma BFS hingga ditemukan seluruh Treasure
            while(maze.getTreasureCount()!=0){
                doTheThing(maze,queue,path,searchTSP);
            }

            // Mencari jalan pulang (TSP)
            if (Global.getTSPstatus())
            {
                searchTSP = true;
                while (queue.getSize() != 0)
                {
                    doTheThing(maze, queue, path, searchTSP);
                }
            }

            return path;
        }

        // Algoritma BFS
        public void doTheThing(Maze maze, Queue<Tile> queue, List<char> path, bool searchTSP){
            Tile check = dequeue(queue);
            int checkX = check.getPosition().getX();
            int checkY = check.getPosition().getY();

            // Mengecek apakah tile sekarang adalah Treasure
            if(check.getType()=='T'){
                maze.decreaseTreasureCount();
                maze.getPath(check,maze,path);
                clearQueue(queue);
                maze.resetStatusMaze();
                enqueue(queue,check,'S');
            }
            else if (searchTSP && check.getType() == 'K')
            {
                maze.getPath(check, maze, path);
                clearQueue(queue);
                maze.resetStatusMaze();
            }

            // Mengecek adjacent Tile
            else {
                // Check Up
                Tile tileCheck = maze.getTile(checkX,checkY-1);
                if(tileCheck.getType()!='X' && tileCheck.getStatus()<check.getStatus())
                {
                    enqueue(queue,tileCheck,'D');
                }
                // Check Right
                tileCheck = maze.getTile(checkX+1,checkY);
                if(tileCheck.getType()!='X'&& tileCheck.getStatus() < check.getStatus())
                {
                    enqueue(queue,tileCheck,'L');
                }
                // Check Down
                tileCheck = maze.getTile(checkX,checkY+1);
                if(tileCheck.getType()!='X' && tileCheck.getStatus() < check.getStatus())
                {
                    enqueue(queue,tileCheck,'U');
                }
                // Check Left
                tileCheck = maze.getTile(checkX-1,checkY);
                if(tileCheck.getType()!='X'&& tileCheck.getStatus() < check.getStatus())
                {
                    enqueue(queue,tileCheck,'R');
                }
            }
        }

        // Fungsi yang memasukkan Tile ke dalam queue
        public void enqueue(Queue<Tile> queue, Tile add, char pathBefore){
            if(!queue.isInside(add)){
                add.addStatus();
                add.setPathBefore(pathBefore);
                queue.enqueue(add);

                // Mewarnai tile yang masuk ke dalam queue
                if (add.getStatus() == 0 && add.getType() == 'R' && add.getNumOfStepped() == 0 && !add.getIsChecked())
                {
                    Global.changeColor(add.getPosition().getX(), add.getPosition().getY(), Color.LightGray);
                }
            }
        }
        
        // Fungsi yang mengeluarkan Tile dari queue
        public Tile dequeue(Queue<Tile> queue){
            Tile deque = queue.dequeue();
            deque.addStatus();
            deque.setIsChecked(true);
            if (deque.getStatus() == 1 && deque.getType() == 'R' && deque.getNumOfStepped()==0)
            {
                Global.changeColor(deque.getPosition().getX(), deque.getPosition().getY(), Color.Gray);
            }
            return deque;
        }
        
        // Mengosongkan queue
        public void clearQueue(Queue<Tile> queue){
            if(queue.getSize()!=0){
                for(int i = 0;i<queue.getSize();i++){
                    queue.getElmt(i).setStatus(queue.getElmt(i).getStatus()-1);
                    if (queue.getElmt(i).getStatus() == -1 && queue.getElmt(i).getType() == 'R' && !queue.getElmt(i).getIsChecked())
                    {
                        Global.changeColor(queue.getElmt(i).getPosition().getX(), queue.getElmt(i).getPosition().getY(), Color.White);
                    }
                }
                queue.clear();
            }
        }
        
    }
}