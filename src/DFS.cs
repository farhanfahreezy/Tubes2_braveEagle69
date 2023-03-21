using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

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
                // System.Threading.Thread.Sleep(500);
                // Console.Clear();
                // maze.printMaze();
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
                if(tileCheck.getType()!='X'&& check.getPathBefore()!='L'){
                    push(stack,tileCheck,'R');
                }
                // Check Down
                tileCheck = maze.getTile(checkX,checkY+1);
                if(tileCheck.getType()!='X' && check.getPathBefore() != 'D')
                {
                    push(stack,tileCheck,'U');
                }
                // Check Right
                tileCheck = maze.getTile(checkX+1,checkY);
                if(tileCheck.getType()!='X'&& check.getPathBefore() != 'R'){
                    push(stack,tileCheck,'L');
                }
                // Check Up
                tileCheck = maze.getTile(checkX,checkY-1);
                if(tileCheck.getType()!='X' && check.getPathBefore() != 'U'){
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
            if (add.getStatus() == 0 && add.getType() == 'R')
            {
                Global.changeColor(add.getPosition().getX(), add.getPosition().getY(), Color.LightGray);
            }
        }
        public Tile pop(Stack<Tile> stack){
            Tile pops = stack.pop();
            pops.addStatus();
            if (pops.getStatus() == 1 && pops.getType() == 'R')
            {
                Global.changeColor(pops.getPosition().getX(), pops.getPosition().getY(), Color.Gray);
            }
            return pops;
        }
        public void clearStack(Stack<Tile> stack){
            if(stack.getSize()!=0){
                for(int i = 0;i<stack.getSize();i++){
                    stack.getElmt(i).setStatus(stack.getElmt(i).getStatus()-1);
                    if (stack.getElmt(i).getStatus() == -1 && stack.getElmt(i).getType() == 'R')
                    {
                        Global.changeColor(stack.getElmt(i).getPosition().getX(), stack.getElmt(i).getPosition().getY(), Color.White);
                    }
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
            coloringPath(treasure.getPosition().getX(), treasure.getPosition().getY(), treasure.getNumOfStepped());
            if (treasure.getPathBefore() == 'U'){
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
        public void coloringPath(int x, int y, int numStep)
        {
            if (numStep == 1)
            {
                Global.changeColor(x, y, Color.LightGreen);
            }
            else if (numStep == 2)
            {
                Global.changeColor(x, y, Color.Green);
            }
            else if (numStep == 3)
            {
                Global.changeColor(x, y, Color.DarkGreen);
            }
        }
    }
}