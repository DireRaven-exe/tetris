using System;
using System.Drawing;
using System.Windows.Forms;

namespace graphicGame
{
    public partial class Window : Form
    {
        MapController mapContorller;
        int size;
        Timer timer;
        public Window()
        {
            InitializeComponent();
            timer = new Timer();
            KeyUp += new KeyEventHandler(keyFunction);
            Init();
        }

        private void keyFunction(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up :
                    mapContorller.MoveRotate();
                    break;
                case Keys.Down :
                    timer.Interval = 10;
                    break;
                case Keys.Right :
                    mapContorller.MoveRight();
                    break;
                case Keys.Left :
                    mapContorller.MoveLeft();
                    break;
            }
        }

        public void Init()
        {
            mapContorller = new MapController(17, 9);
            size = 25;
            labelScore.Text = "Score: " + mapContorller.mapLogic.points;
            label1.Text = "Next Figure";
            timer.Interval = 500;
            mapContorller.map.AddFigure();
            timer.Tick += new EventHandler(update);
            timer.Start();
            Invalidate();
        }

        private void update(object sender, EventArgs e)
        {
            if (mapContorller.IsDefeat())
            {
                timer.Stop();
            }
            labelScore.Text = "Score: " + mapContorller.mapLogic.points;
            mapContorller.MoveDown();
            timer.Interval = 300;
            
            Invalidate();
        }

        public void DrawGrid(Graphics g)
        {
            for (int i = 0; i <= mapContorller.map.heightMap; i++)
            {
                g.DrawLine(Pens.Black, new Point(50, 50 + i * size), new Point(50 + mapContorller.map.widthMap * size, 50 + i * size));
            }

            for (int i = 0; i <= mapContorller.map.widthMap; i++)
            {
                g.DrawLine(Pens.Black, new Point(50 + i * size, 50), new Point(50 + i * size, 50 + mapContorller.map.heightMap * size));
            }
        }


        public void DrawFigure(Graphics g)
        {
            for (int i = 0; i < mapContorller.map.heightMap; i++)
            {
                for (int j = 0; j < mapContorller.map.widthMap; j++)
                {
                    Figure figure = mapContorller.map.arrayCell[i, j].Figure;
                    if (figure == null)
                    {
                        g.FillRectangle(Brushes.White, new Rectangle(50 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                    }
                    else
                    {
                        if (figure == mapContorller.map.currentFigure)
                        {
                            g.FillRectangle(mapContorller.map.GetColor(figure), new Rectangle(50 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                        else if (figure == mapContorller.map.OtherFigures)
                        {
                            g.FillRectangle(Brushes.Gray, new Rectangle(50 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                    }
                }
            }
        }

        public void DrawNextFigure(Graphics g)
        {
            for (int i = 0; i < mapContorller.map.nextCells.GetLength(0); i++)
            {
                for (int j = 0; j < mapContorller.map.nextCells.GetLength(1); j++)
                {

                    if (mapContorller.map.nextCells[i, j].Figure == mapContorller.map.nextFigure)
                    {
                        g.FillRectangle(Brushes.Green, new Rectangle(300 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                    }
                }
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
            DrawFigure(e.Graphics);
            DrawNextFigure(e.Graphics);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Window_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
  
        }
    }
}
