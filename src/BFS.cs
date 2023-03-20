using System;

namespace MazeSolver{
    class BFS{
        public List<char> Solver(Maze maze){
            Queue<Tile> queue = new Queue<Tile>();
            List<char> path = new List<char>();

            Tile start = maze.getTile(maze.getStart().getX(),maze.getStart().getY());
            start.addNumOfStepped();

            enqueue(queue,start,'S');

            while(maze.getTreasureCount()!=0){
                doTheThing(maze,queue,path);
                // System.Threading.Thread.Sleep(500);
                // Console.Clear();
                // maze.printMaze();
            }

            return path;
        }

        public void doTheThing(Maze maze, Queue<Tile> queue, List<char> path){
            Tile check = dequeue(queue);
            int checkX = check.getPosition().getX();
            int checkY = check.getPosition().getY();

            // Check current
            if(check.getType()=='T'){
                maze.decreaseTreasureCount();
                getPath(check,maze,path);
                clearQueue(queue);
                // resetMazeInfo(maze);
                enqueue(queue,check,'S');
            } else {
                // Check Up
                Tile tileCheck = maze.getTile(checkX,checkY-1);
                if(tileCheck.getType()!='X' && tileCheck.getStatus()<check.getStatus()){
                    enqueue(queue,tileCheck,'D');
                }
                // Check Right
                tileCheck = maze.getTile(checkX+1,checkY);
                if(tileCheck.getType()!='X'&& tileCheck.getStatus()<check.getStatus()){
                    enqueue(queue,tileCheck,'L');
                }
                // Check Down
                tileCheck = maze.getTile(checkX,checkY+1);
                if(tileCheck.getType()!='X' && tileCheck.getStatus()<check.getStatus()){
                    enqueue(queue,tileCheck,'U');
                }
                // Check Left
                tileCheck = maze.getTile(checkX-1,checkY);
                if(tileCheck.getType()!='X'&& tileCheck.getStatus()<check.getStatus()){
                    enqueue(queue,tileCheck,'R');
                }
            }
        }

        public void enqueue(Queue<Tile> queue, Tile add, char pathBefore){
            if(!queue.isInside(add)){
                add.addStatus();
                add.setPathBefore(pathBefore);
                queue.enqueue(add);
            }
        }
        public Tile dequeue(Queue<Tile> queue){
            Tile deque = queue.dequeue();
            deque.addStatus();
            return deque;
        }
        public void clearQueue(Queue<Tile> queue){
            if(queue.getSize()!=0){
                for(int i = 0;i<queue.getSize()-1;i++){
                    queue.getElmt(i).setStatus(queue.getElmt(i).getStatus()-1);
                }
                queue.clear();
            }
        }
        public void getPath(Tile check, Maze maze, List<char> path){
            List<char> tempChar = new List<char>();
            Tile treasure = new Tile(check.getType(),check.getPosition().getX(),check.getPosition().getY());
            treasure.setPathBefore(check.getPathBefore());
            check.setType('F');
            check.addNumOfStepped();

            treasure = getPreviousPath(treasure,tempChar,maze);

            while(treasure.getPathBefore()!='S'){
                treasure = getPreviousPath(treasure,tempChar,maze);
            }
            treasure.decreaseNumOfStepped();
            path.AddRange(tempChar);

        }

        public Tile getPreviousPath(Tile treasure,List<char> tempChar,Maze maze){
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
            treasure.addNumOfStepped();
            return treasure;

        }

        // DEBUG FUNTION
        public void resetMazeInfo(Maze maze){
            for(int i = 1; i<maze.getSizeY()+1; i++){
                for(int j = 1; j<maze.getSizeX()+1; j++){
                    Tile adhoc = maze.getTile(j,i);
                    if(adhoc.getStatus()>=2){
                        adhoc.setStatus(1);
                    }
                    // adhoc.setNumOfStepped(0);
                    // adhoc.setPathBefore('Z');
                }
            }
        }

    }
}