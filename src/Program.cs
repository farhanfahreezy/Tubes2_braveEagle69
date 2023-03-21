using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeSolver
{
    
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Global.setAlgoChoosen(1);
            Application.Run(new Form1());
        }

    }
    static class Global
    {
        private static int algoChoosen = 1;
        private static bool isTSP = false;
        private static Maze maze;
        private static string filePath;
        private static DataGridView dataGridView1 = new DataGridView();
        private static int sleepTime = 1000;

        public static int getAlgoChoosen() { return algoChoosen; }
        public static void setAlgoChoosen(int newAlgoChoosen) { algoChoosen = newAlgoChoosen; }
        public static bool getTSPstatus() { return isTSP; }
        public static void changeTSPstatus() {
            if (isTSP)
            {
                isTSP = false;
            } else
            {
                isTSP = true;
            }
        }
        public static void createMaze(List<List<char>> charArray)
        {
            maze = new Maze(charArray);
        }
        public static Maze getMaze() { return maze; }
        public static string getFilePath() { return filePath; }
        public static void setFilePath(string fP) { filePath = fP; }
        public static DataGridView getDataGridView1() { return dataGridView1; }
        public static void setDataGridView(DataGridView dgv) { dataGridView1 = dgv; }
        public static void changeColor(int x, int y, Color color)
        {
            dataGridView1.Rows[y-1].Cells[x-1].Style.BackColor = color;
            System.Threading.Thread.Sleep(getSleepTime());
            Application.DoEvents();
        }
        public static int getSleepTime() { return sleepTime; }
        public static void setSleepTime(int sT) { sleepTime = sT; }
    }
}
