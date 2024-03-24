using GreenEngineAPI.Graphics;
using System.Drawing;
using System;
using System.Collections.Generic;
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

        protected static SceneManager SceneManager;

        public RendererGameWindow(Vector2D size, string title, ColorClass backgroundColor, GameCanvas.WindowStyles style, bool topMost = false)
        {
            WindowSize = size;
            WindowTitle = title;
            Window = new GameCanvas();

            SceneManager = new SceneManager(new Scene2D(backgroundColor,
                new Camera2D(Vector2D.ZeroVector2D(), new Vector2D(1, 1), 0), 
                new List<RendererObject2D>()));
            SceneManager.LoadScene(0);

            Log.Info($"Window \"{WindowTitle}\" is starting...", "GREEN ENGINE");

            //Apply settings to the window
            Window.Size = new Size((int)WindowSize.X, (int)WindowSize.Y);
            Window.Text = WindowTitle;
            Window.BackColor = SceneManager.GetCurrentScene().Color.color;
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
            OnGameLoad();
            while (GameMainThread.IsAlive)
            {
                try
                {
                    SceneManager.GetCurrentScene().OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    SceneManager.GetCurrentScene().OnUpdate();
                    Thread.Sleep(1);
                }
                catch(Exception ex)
                {
                    Log.Error(ex.Message, "GAME THREAD");
                }
            }
        }

        public static void AddRendererObject(RendererObject2D rendererObject)
        {
            SceneManager.GetCurrentScene().SceneRendererObjects.Add(rendererObject);
        }

        public static void RemoveRendererObject(RendererObject2D rendererObject)
        {
            SceneManager.GetCurrentScene().SceneRendererObjects.Remove(rendererObject);
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.TranslateTransform(SceneManager.GetCurrentScene().Camera.Position.X,
                SceneManager.GetCurrentScene().Camera.Position.Y);
            graphics.ScaleTransform(SceneManager.GetCurrentScene().Camera.Scale.X,
                SceneManager.GetCurrentScene().Camera.Scale.Y);
            graphics.RotateTransform(SceneManager.GetCurrentScene().Camera.RotationAngle);
            graphics.Clear(SceneManager.GetCurrentScene().Color.color);
            foreach(RendererObject2D rendererObject in SceneManager.GetCurrentScene().SceneRendererObjects)
            {
                if(rendererObject == null)
                {
                    Log.Error("Renderer object is null", WindowTitle);
                    continue;
                }
                graphics.DrawImage(rendererObject.Sprite,
                    rendererObject.Position.X, rendererObject.Position.Y,
                    rendererObject.Scale.X, rendererObject.Scale.Y);
            }
        }

        private void WindowOnClosing(object sender, FormClosingEventArgs e)
        {
            Log.Info($"Main thread is closing...", "GREEN ENGINE");
            GameMainThread.Abort();
            Log.Info($"Window \"{WindowTitle}\" is closing...", "GREEN ENGINE");
            Window.Dispose();
            Log.Info("Goodbye!", "");
        }

        protected abstract void OnGameLoad();
    }
}
