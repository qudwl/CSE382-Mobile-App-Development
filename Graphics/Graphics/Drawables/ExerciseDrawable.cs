using System;
using Microsoft.Maui.Graphics;
namespace Graphics.Drawables
{
    public class ExerciseDrawable : IDrawable
    {
        public string[] Labels { get; set; }
        public int[] Data { get; set; }
        private Color[] colors = {
                                Colors.Red, Colors.Green, Colors.Blue,
                                Colors.Cyan, Colors.Magenta, Colors.Yellow,
                                Colors.Gray, Colors.Orange,
                                };
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            float W = dirtyRect.Width;
            float H = dirtyRect.Height;

            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 3;
            canvas.DrawRectangle(0, 0, W, H);

            if (Data == null || Labels == null || Data.Length != Labels.Length)
            {
                return;
            }
            int numData = Data.Length;
            int sum = Data.Sum();
            float curY = 0;
            int barWidth = (int) (W / 2);
            float barX = (W - barWidth) / 2;

            for (int i = 0; i < numData; i++)
            {
                float barHeight = ((float)Data[i]) / sum * H;
                canvas.FillColor = colors[i % colors.Length];
                canvas.FillRectangle(barX, curY, barWidth, barHeight);
                canvas.FontColor = Colors.Black;
                canvas.FontSize = 12;
                canvas.DrawString(Labels[i], barX, curY, barWidth, barHeight, HorizontalAlignment.Center, VerticalAlignment.Center);
                curY += barHeight;
            }
        }
    }
}

