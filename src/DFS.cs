using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace MazeSolver{
    class DFS{
        // Algoritma DFS untuk menemukan jalur yang melewati seluruh Treaasure di maze
        public List<char> Solver(Maze maze){
            Stack<Tile> stack = new Stack<Tile>();
            List<char> path = new List<char>();
            bool searchTSP = false;

            // Mengambil tile pertama yang akan dieksekusi
            Tile start = maze.getTile(maze.getStart().getX(),maze.getStart().getY());
            start.addNumOfStepped();
            push(stack,start,'S');

            // Melakukan algoritma DFS hingga ditemukan seluruh Treasure
            while(maze.getTreasureCount()!=0){
                doTheThing(maze,stack,path,searchTSP);

            }

            // Mencari jalan pulang (TSP)
            if (Global.getTSPstatus())
            {   
                searchTSP = true;
                while (stack.getSize()!=0)
                {
                    doTheThing(maze, stack, path, searchTSP);
                }
            }

            return path;
        }

        // Algoritma DFS
        public void doTheThing(Maze maze, Stack<Tile> stack, List<char> path, bool searchTSP){
            Tile check = pop(stack);
            int checkX = check.getPosition().getX();
            int checkY = check.getPosition().getY();

            // Mengecek apakah tile sekarang adalah Treasure
            if(check.getType()=='T'){
                maze.decreaseTreasureCount();
                maze.getPath(check,maze,path);
                clearStack(stack);
                maze.resetStatusMaze();
                push(stack,check,'S');
            } else if (searchTSP && check.getType() == 'K')
            {
                maze.getPath(check, maze, path);
                clearStack(stack);
                maze.resetStatusMaze();
            }

            // Mengecek adjacent Tile
            else {
                // Check Left
                Tile tileCheck = maze.getTile(checkX-1,checkY);
                if(tileCheck.getType()!='X'&& tileCheck.getStatus() < check.getStatus())
                {
                    push(stack,tileCheck,'R');
                }
                // Check Down
                tileCheck = maze.getTile(checkX,checkY+1);
                if(tileCheck.getType()!='X' && tileCheck.getStatus() < check.getStatus())
                {
                    push(stack,tileCheck,'U');
                }
                // Check Right
                tileCheck = maze.getTile(checkX+1,checkY);
                if(tileCheck.getType()!='X'&& tileCheck.getStatus() < check.getStatus())
                {
                    push(stack,tileCheck,'L');
                }
                // Check Up
                tileCheck = maze.getTile(checkX,checkY-1);
                if(tileCheck.getType()!='X' && tileCheck.getStatus() < check.getStatus())
                {
                    push(stack,tileCheck,'D');
                }                
            }
        }

        // Fungsi yang memasukkan Tile ke dalam stack
        public void push(Stack<Tile> stack, Tile add, char pathBefore){
            if(stack.isInside(add)){
                stack.removeEl(add);
            } else {
                add.addStatus();
            }
            stack.push(add);
            add.setPathBefore(pathBefore);
            // Mewarnai tile yang masuk ke dalam stack
            if (add.getStatus() == 0 && add.getType() == 'R' && !add.getIsChecked() && add.getNumOfStepped()==0)
            {
                Global.changeColor(add.getPosition().getX(), add.getPosition().getY(), Color.LightGray);
            }
        }

        // Fungsi yang mengeluarkan Tile dari stack
        public Tile pop(Stack<Tile> stack){
            Tile pops = stack.pop();
            pops.addStatus();
            pops.setIsChecked(true);
            if (pops.getType() == 'R' && pops.getNumOfStepped() == 0)
            {
                Global.changeColor(pops.getPosition().getX(), pops.getPosition().getY(), Color.Gray);
            }
            return pops;
        }

        // Mengosongkan stack
        public void clearStack(Stack<Tile> stack){
            if(stack.getSize()!=0){
                for(int i = 0;i<stack.getSize();i++){
                    stack.getElmt(i).setStatus(stack.getElmt(i).getStatus()-1);
                    if (stack.getElmt(i).getStatus() == -1 && stack.getElmt(i).getType() == 'R' && !stack.getElmt(i).getIsChecked() && stack.getElmt(i).getNumOfStepped() == 0)
                    {
                        Global.changeColor(stack.getElmt(i).getPosition().getX(), stack.getElmt(i).getPosition().getY(), Color.White);
                    }
                }
                stack.clear();
            }
        }
    }
}