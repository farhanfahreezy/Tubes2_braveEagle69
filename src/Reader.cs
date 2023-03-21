using System.Collections.Generic;
using System.IO;

namespace MazeSolver{
    class Reader{
        public List<List<char>> readFile(string filePath){
            IO io = new IO();

            StreamReader reader = new StreamReader(filePath);

        
            List<List<char>> charArray = new List<List<char>>();

            int i = 0;
            while(!reader.EndOfStream){
                string line = reader.ReadLine() ?? "";
                string[] token = io.tokenizeString(line, ' ');
                List<char> temp = new List<char>();
                for (int j = 0;j<token.Length;j++){
                    temp.Add(token[j][0]);
                }
                i++;
                charArray.Add(temp);

            }
            reader.Close();
            return charArray;
        }

        public bool validateInput(string filePath){
            IO io = new IO();
            StreamReader reader = new StreamReader(filePath);
            bool valid = true;
            int len = 0;
            while(!reader.EndOfStream && valid){
                string line = reader.ReadLine() ?? "";
                string[] token = io.tokenizeString(line, ' ');
                int tempLen = token.Length;
                if(len == 0){
                    len = tempLen;
                } else if(len != tempLen){
                    return false;
                }
                len = tempLen;
                int i = 0;
                while(i<len){
                    if(token[i].Length!=1){
                        return false;
                    } else {
                        if (token[i][0] != 'K' && token[i][0] != 'R' && token[i][0] != 'X' && token[i][0] != 'T'){
                            return false;
                        }
                    }
                    i++;
                }
            }
            return valid;
        }
    }
}