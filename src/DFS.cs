using System;

namespace MazeSolver{
    class DFS{
        public List<char> Solver(Maze maze){
            Stack<Tile> stack = new Stack<Tile>();
            List<char> path = new List<char>();

            Tile start = maze.getTile(maze.getStart().getX(),maze.getStart().getY());
            start.addNumOfStepped();

            push(stack,start,'S');

            while(maze.getTreasureCount()!=0){
                doTheThing(maze,stack,path);
                System.Threading.Thread.Sleep(500);
                Console.Clear();
                maze.printMaze();
            }

            return path;
        }

        public void doTheThing(Maze maze, Stack<Tile> stack, List<char> path){
            Tile check = pop(stack);
            int checkX = check.getPosition().getX();
            int checkY = check.getPosition().getY();

            // Check current
            if(check.getType()=='T'){
                maze.decreaseTreasureCount();
                getPath(check,maze,path);
                clearStack(stack);
                push(stack,check,'S');
            } else {
                // Check Left
                Tile tileCheck = maze.getTile(checkX-1,checkY);
                if(tileCheck.getType()!='X'&& tileCheck.getStatus()<check.getStatus()){
                    push(stack,tileCheck,'R');
                }
                // Check Down
                tileCheck = maze.getTile(checkX,checkY+1);
                if(tileCheck.getType()!='X' && tileCheck.getStatus()<check.getStatus()){
                    push(stack,tileCheck,'U');
                }
                // Check Right
                tileCheck = maze.getTile(checkX+1,checkY);
                if(tileCheck.getType()!='X'&& tileCheck.getStatus()<check.getStatus()){
                    push(stack,tileCheck,'L');
                }
                // Check Up
                tileCheck = maze.getTile(checkX,checkY-1);
                if(tileCheck.getType()!='X' && tileCheck.getStatus()<check.getStatus()){
                    push(stack,tileCheck,'D');
                }                
            }
        }

        public void push(Stack<Tile> stack, Tile add, char pathBefore){
            if(stack.isInside(add)){
                stack.removeEl(add);
            } else {
                add.addStatus();
            }
            stack.push(add);
            add.setPathBefore(pathBefore);
        }
        public Tile pop(Stack<Tile> stack){
            Tile pops = stack.pop();
            pops.addStatus();
            return pops;
        }
        public void clearStack(Stack<Tile> stack){
            if(stack.getSize()!=0){
                for(int i = 0;i<stack.getSize()-1;i++){
                    stack.getElmt(i).setStatus(stack.getElmt(i).getStatus()-1);
                }
                stack.clear();
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

    }
}