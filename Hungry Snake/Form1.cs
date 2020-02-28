using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hungry_Snake
{
    public partial class Form1 : Form
    {
        private int direction = 0;
        private int score = 1;
        private Timer gameloop = new Timer();
        private Random rand = new Random();
        private Graphics graphics;
        private Snake snake;
        private Food food;
        public Form1()
        {
            InitializeComponent();
            snake = new Snake();
            food = new Food(rand);
            gameloop.Interval = 75;
            gameloop.Tick += Update;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            snake.Draw(graphics);
            food.Draw(graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Enter:
                    if(label1.Visible)
                    {
                        label1.Visible = false;
                        gameloop.Start();
                    }
                    break;
                case Keys.Space:
                    if (!label1.Visible)
                        gameloop.Enabled = (gameloop.Enabled) ? false : true;
                    break;
                case Keys.Right:
                    if (direction != 2)
                        direction = 0;
                    break;
                case Keys.Down:
                    if (direction != 3)
                        direction = 1;
                    break;
                case Keys.Left:
                    if (direction != 0)
                        direction = 2;
                    break;
                case Keys.Up:
                    if (direction != 1)
                        direction = 3;
                    break;
                case Keys.CapsLock:
                    Application.Exit();
                    break;
            }
        }
        private void Update(object sender,EventArgs e)
        {
            this.Text = string.Format("Snake - Score: {0}",score);
            snake.Move(direction);
            for (int i = 1; i < snake.body.Length; i++)
                if (snake.body[0].IntersectsWith(snake.body[i]))
                    Restart();
            if (snake.body[0].X < 0 || snake.body[0].X > 806)
                Restart();
            if (snake.body[0].Y < 0 || snake.body[0].Y > 400)
                Restart();
            if(snake.body[0].IntersectsWith(food.piece))
            {
                score++;
                label3.Text = score.ToString();
                snake.Grow();
                food.Generate(rand);
            }
            this.Invalidate();
        }
        private void Restart()
        {
            gameloop.Stop();
            graphics.Clear(SystemColors.Control);
            snake = new Snake();
            food = new Food(rand);
            direction = 0;
            score = 0;
            label1.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
