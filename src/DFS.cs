using System;

namespace MazeSolver{
    class DFS{
        public List<char> Solver(Maze maze){
            Stack<Tile> stack = new Stack<Tile>();
            List<char> path = new List<char>();

            Tile start = maze.getTile(maze.getStart().getX(),maze.getStart().getY());

            stack.push(start);
            start.addStatus();

            while(maze.getTreasureCount()!=0){
                doTheThing(maze,stack,path);
            }

            return path;
        }

        public void doTheThing(Maze maze, Stack<Tile> stack, List<char> path){
            Tile check = stack.pop();
            int checkX = check.getPosition().getX();
            int checkY = check.getPosition().getY();

            // Check current
            if(check.getType()=='T'){
                maze.decreaseTreasureCount();
                getPath(check,maze,path);
                stack.clear();
                stack.push(check);
                check.addStatus();
            }

            // Check Up
            Tile tileCheck = maze.getTile(checkX,checkY-1);
            if(tileCheck.getType()!='X' && tileCheck.getStatus()<check.getStatus()){
                push(stack,tileCheck,'D');
            }
            // Check Right
            tileCheck = maze.getTile(checkX+1,checkY);
            if(tileCheck.getType()!='X' && tileCheck.getStatus()<check.getStatus()){
                push(stack,tileCheck,'L');
            }
            // Check Down
            tileCheck = maze.getTile(checkX,checkY+1);
            if(tileCheck.getType()!='X' && tileCheck.getStatus()<check.getStatus()){
                push(stack,tileCheck,'U');
            }
            // Check Left
            tileCheck = maze.getTile(checkX-1,checkY);
            if(tileCheck.getType()!='X' && tileCheck.getStatus()<check.getStatus()){
                push(stack,tileCheck,'R');
            }

        }

        public void push(Stack<Tile> queue, Tile add, char pathBefore){
            add.addStatus();
            add.setPathBefore(pathBefore);
            queue.push(add);
        }
        public Tile pop(Stack<Tile> queue){
            Tile deque = queue.pop();
            deque.addStatus();
            return deque;
        }
        public void getPath(Tile check, Maze maze, List<char> path){
            List<char> tempChar = new List<char>();
            Tile treasure = new Tile(check.getType(),check.getPosition().getX(),check.getPosition().getY());
            treasure.setPathBefore(check.getPathBefore());
            int treasureX = treasure.getPosition().getX();
            int treasureY = treasure.getPosition().getY();

            check.setPathBefore('Z');
            check.setType('R');
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

            path.AddRange(tempChar);

        }

    }
}