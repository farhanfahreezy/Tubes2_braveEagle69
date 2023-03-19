using System;

namespace MazeSolver{
    class BFS{
        public List<char> Solver(Maze maze){
            Queue<Tile> queue = new Queue<Tile>();
            List<char> path = new List<char>();

            Tile start = maze.getTile(maze.getStart().getX(),maze.getStart().getY());

            queue.enqueue(start);

            while(maze.getTreasureCount()!=0){
                doTheThing(maze,queue,path);
            }

            return path;
        }

        public void doTheThing(Maze maze, Queue<Tile> queue, List<char> path){
            Tile check = queue.dequeue();
            int checkX = check.getPosition().getX();
            int checkY = check.getPosition().getY();

            // Check current
            if(check.getType()=='T'){
                maze.decreaseTreasureCount();
                getPath(check,maze,path);
            }

            // Check Up
            Tile tileCheck = maze.getTile(checkX,checkY-1);
            if(tileCheck.getType()!='X' || tileCheck.getStatus()== -1){
                enqueue(queue,tileCheck,'D');
            }
            // Check Right
            tileCheck = maze.getTile(checkX+1,checkY);
            if(tileCheck.getType()!='X' || tileCheck.getStatus()== -1){
                enqueue(queue,tileCheck,'L');
            }
            // Check Down
            tileCheck = maze.getTile(checkX,checkY+1);
            if(tileCheck.getType()!='X' || tileCheck.getStatus()== -1){
                enqueue(queue,tileCheck,'U');
            }
            // Check Left
            tileCheck = maze.getTile(checkX-1,checkY);
            if(tileCheck.getType()!='X' || tileCheck.getStatus()== -1){
                enqueue(queue,tileCheck,'R');
            }

        }

        public void enqueue(Queue<Tile> queue, Tile add, char pathBefore){
            add.addStatus();
            add.setPathBefore(pathBefore);
            queue.enqueue(add);
        }
        public Tile dequeue(Queue<Tile> queue){
            Tile deque = queue.dequeue();
            deque.addStatus();
            return deque;
        }
        public void getPath(Tile treasure, Maze maze, List<char> path){
            List<char> tempChar = new List<char>();

            int treasureX = treasure.getPosition().getX();
            int treasureY = treasure.getPosition().getY();


            if(treasure.getPathBefore() == 'U'){
                tempChar.Insert(0,'D');
                treasure = maze.getTile(treasureX,treasureY-1);
            } else if(treasure.getPathBefore() == 'D'){
                tempChar.Insert(0,'U');
                treasure = maze.getTile(treasureX,treasureY+1);
            } else if(treasure.getPathBefore() == 'L'){
                tempChar.Insert(0,'R');
                treasure = maze.getTile(treasureX-1,treasureY);
            } else if(treasure.getPathBefore() == 'R'){
                tempChar.Insert(0,'L');
                treasure = maze.getTile(treasureX+1,treasureY);
            }

            while(treasure.getPathBefore()!='Z'){
                treasureX = treasure.getPosition().getX();
                treasureY = treasure.getPosition().getY();
                if(treasure.getPathBefore() == 'U'){
                    tempChar.Insert(0,'D');
                    treasure = maze.getTile(treasureX,treasureY-1);
                } else if(treasure.getPathBefore() == 'D'){
                    tempChar.Insert(0,'U');
                    treasure = maze.getTile(treasureX,treasureY+1);
                } else if(treasure.getPathBefore() == 'L'){
                    tempChar.Insert(0,'R');
                    treasure = maze.getTile(treasureX-1,treasureY);
                } else if(treasure.getPathBefore() == 'R'){
                    tempChar.Insert(0,'L');
                    treasure = maze.getTile(treasureX+1,treasureY);
                }
            }

            tempChar.Reverse();
            path.AddRange(tempChar);

        }

    }
}