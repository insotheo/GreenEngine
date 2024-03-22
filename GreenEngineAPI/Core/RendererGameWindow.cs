using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenEngineAPI.Core
{
    public class RendererGameWindow
    {
        private GameCanvas Canvas;


        public RendererGameWindow()
        {
            Canvas = new GameCanvas();

            Log.Info("Window created", "GREEN ENGINE");
            Task.Delay(10).Wait();
            Application.Run(Canvas);
        }


        public void Dispose()
        {
            Canvas.Dispose();
        }
    }
}
