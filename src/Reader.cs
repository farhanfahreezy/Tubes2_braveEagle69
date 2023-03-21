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
    }
}