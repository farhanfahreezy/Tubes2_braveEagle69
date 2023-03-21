using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reader reader = new Reader();
            Global.createMaze(reader.readFile(Global.getFilePath()));
            showTheFookingMaze();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                Global.setFilePath(fileName);
                label6_Click(fileName);

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BFS bfs = new BFS();
            DFS dfs = new DFS();
            IO io = new IO();
            Stopwatch stopwatch = new Stopwatch();
            int algo = Global.getAlgoChoosen();
            Maze maze = Global.getMaze();
            List<char> path = new List<char>();

            stopwatch.Start();
            if(algo == 1)
            {
                path = dfs.Solver(maze);
            } else
            {
                path = bfs.Solver(maze);
            }
            stopwatch.Stop();

            double executedTime = stopwatch.Elapsed.TotalMilliseconds;

            int step = path.Count();
            label9_Click(io.pathToString(path),step);
            label10_Click(step);
            label11_Click(maze.getNumOfChecked());
            label12_Click(executedTime);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
            Global.setAlgoChoosen(1);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            Global.setAlgoChoosen(2);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Global.changeTSPstatus();
        }

        private void label6_Click(string newLabel)
        {
            label6.Text = newLabel;
        }

        private void showTheFookingMaze()
        {
            Maze mazeShow = Global.getMaze();
            // Setting ukuran tiap cell
            int sizeY = mazeShow.getSizeY();
            int sizeX = mazeShow.getSizeX();
            double sizeFromY = 362 / sizeY;
            double sizeFromX = 785 / sizeX;
            double sizeSelected = Math.Min(sizeFromY,sizeFromX);
            int sizeCell = (int)Math.Floor(sizeSelected);
        
            // Atur size
            this.dataGridView1.Size = new Size(sizeX*sizeCell, sizeY * sizeCell);

            this.dataGridView1.ColumnCount = sizeX;
            this.dataGridView1.RowCount = sizeY;

            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.RowHeadersVisible = false;

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;

            this.dataGridView1.ScrollBars = ScrollBars.None;

            this.dataGridView1.ReadOnly = true;


            // Mewarnai
            for (int i = 0; i < sizeY; i++)
            {
                for(int j=0; j < sizeX; j++)
                {
                    this.dataGridView1.Columns[j].Width = sizeCell;
                    this.dataGridView1.Rows[i].Height = sizeCell;
                    Tile tile = mazeShow.getTile(j+1,i+1);
                    if (tile.getType() == 'X')
                    {
                        this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                    } else if (tile.getType() == 'K')
                    {
                        this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;
                    }
                    else if (tile.getType() == 'F' || tile.getType() == 'T')
                    {
                        this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        this.dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
            }
            this.dataGridView1.DefaultCellStyle.BackColor = Color.Black;

        }

        private void label9_Click(string path, int len)
        {
            this.label9.Font = new System.Drawing.Font("SF UI Display SemBd", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            if (len > 40)
            {
                this.label9.Font = new System.Drawing.Font("SF UI Display SemBd", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            this.label9.Text = path;
        }

        private void label10_Click(int n)
        {
            this.label10.Text = n.ToString();
        }
        private void label11_Click(int n)
        {
            this.label11.Text = n.ToString();
        }
        private void label12_Click(double n)
        {
            this.label12.Text = n.ToString() + " ms";
        }
    }
}
