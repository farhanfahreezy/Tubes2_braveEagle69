using System;

namespace MazeSolver{
    class IO {
        public string getString(string command){
            Console.Write(command);
            string input = Console.ReadLine() ?? "";
            return input;
        }

        public int charToInt(char c){
            int val = (int) c;
            if (val >= 48 && val <=57){
                return val - 48;
            }
            return -1;
        }

        public int stringToInt(string str){
            int val = charToInt(str[0]);
            int i = 1;
            while(i!=str.Length){
                val = val*10 + charToInt(str[0]);
                i++;
            }
            return val;
        }

        public string[] tokenizeString(string input, char deliminator){
            string[] token = input.Split(deliminator);
            return token; 
        }

        public string pathToString(List<char> arr){
            string path = "";
            for(int i = 0;i<arr.Count;i++){
                path+=arr[i];
                if(i!=arr.Count-1){
                    path+='-';
                }
            }
            return path;
        }

    }
}