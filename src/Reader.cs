using System.IO;

namespace MazeSolver{
    class Reader{
        public char[,] readFile(string fileName){
            IO io = new IO();

            string filePath = @"./test/"+fileName;
            StreamReader reader = new StreamReader(filePath);


            string line = reader.ReadLine() ?? "";
            string[] token = io.tokenizeString(line,' ');
            char[,] charArray = new char[io.stringToInt(token[0]),io.stringToInt(token[1])];
            
            int i = 0;
            while(!reader.EndOfStream){
                line = reader.ReadLine() ?? "".Replace(" ","");
                token = io.tokenizeString(line,' ');

                for(int j = 0;j<token.Length;j++){
                    charArray[i,j] = token[j][0];
                }
                i++;
            }
            reader.Close();
            return charArray;
        }
    }
}