using System.IO;

namespace MazeSolver{
    class Reader{
        public char[,] readFile(string fileName){
            string filePath = @"./test/"+fileName;
            StreamReader reader = new StreamReader(filePath);

            string line = reader.ReadLine() ?? "";
            char[,] charArray = new char[(int)line[0],(int) line[2]];
            int i = 0;
            while(!reader.EndOfStream){
                line = reader.ReadLine() ?? "".Replace(" ","");
                char[] lineChar = line.ToCharArray();
                for(int j = 0;j<lineChar.Length;j++){
                    charArray[i,j] = lineChar[j];
                }
                i++;
            }
            reader.Close();
            return charArray;
        }
    }
}