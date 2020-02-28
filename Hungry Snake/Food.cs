using System;
using System.Drawing;
namespace Hungry_Snake
{
    public class Food
    {
        public Rectangle piece;
        public int x, y, width = 10, height = 10;
        public Food(Random rand)
        {
            Generate(rand);
            piece = new Rectangle(x,y,width,height);
        }
        public void Draw(Graphics graphics)
        {
            piece.X = x;
            piece.Y = y;
            graphics.FillRectangle(Brushes.Blue,piece);
        }
        public void Generate(Random rand)
        {
            x = rand.Next(0, 30) * 10;
            y = rand.Next(0, 20) * 10;
        }
    }
}
