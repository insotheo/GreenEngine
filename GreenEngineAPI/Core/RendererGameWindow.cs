using GreenEngineAPI.Graphics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GreenEngineAPI.Core
{
    public abstract class RendererGameWindow
    {
        private Thread GameMainThread;

        private GameCanvas Window;
        private Vector2D WindowSize;
        private string WindowTitle;

        protected ColorClass @Color;


        public RendererGameWindow(Vector2D size, string title, ColorClass backgroundColor, GameCanvas.WindowStyles style, bool topMost = false)
        {
            WindowSize = size;
            WindowTitle = title;
            @Color = backgroundColor;
            Window = new GameCanvas();

            Log.Info($"Window \"{WindowTitle}\" is starting...", "GREEN ENGINE");

            //Apply settings to the window
            Window.Size = new Size((int)WindowSize.X, (int)WindowSize.Y);
            Window.Text = WindowTitle;
            Window.BackColor = @Color.color;
            Window.FormBorderStyle = (FormBorderStyle)style;
            Window.TopMost = topMost;
            Window.StartPosition = FormStartPosition.CenterScreen;
            Window.Focus();


            //Window events
            Window.Paint += Renderer;
            Window.FormClosing += WindowOnClosing;

            Log.Info($"Window \"{WindowTitle}\" created", "GREEN ENGINE");

            GameMainThread = new Thread(GameLoop);
            GameMainThread.Start();

            Application.Run(Window);
        }

        private void GameLoop()
        {
            Log.Info("Main thread started", "GREEN ENGINE");
            while (GameMainThread.IsAlive)
            {

            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.Clear(@Color.color);
        }

        private void WindowOnClosing(object sender, FormClosingEventArgs e)
        {
            Log.Info($"Main thread is closing...", "GREEN ENGINE");
            GameMainThread.Abort();
            Log.Info($"Window \"{WindowTitle}\" is closing...", "GREEN ENGINE");
            Window.Dispose();
            Log.Info("Goodbye!", "");
        }
    }
}
