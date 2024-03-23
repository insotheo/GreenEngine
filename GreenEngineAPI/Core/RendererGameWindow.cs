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


        public RendererGameWindow(Vector2D size, string title, ColorClass backgroundColor,GameCanvas.WindowStyles style)
        {
            WindowSize = size;
            WindowTitle = title;
            Window = new GameCanvas();

            //Apply settings to the window
            Window.Size = new Size((int)WindowSize.X, (int)WindowSize.Y);
            Window.Text = WindowTitle;
            Window.BackColor = backgroundColor.color;
            Window.FormBorderStyle = (FormBorderStyle)style;
            Window.StartPosition = FormStartPosition.CenterScreen;

            //Window events
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

        private void WindowOnClosing(object sender, FormClosingEventArgs e)
        {
            GameMainThread.Abort();
            Window.Dispose();
        }
    }
}
