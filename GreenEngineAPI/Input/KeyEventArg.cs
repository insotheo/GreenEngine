using System.Windows.Forms;

namespace GreenEngineAPI.Input
{
    public class KeyEventArg
    {
        public Key.KeyCode @Key;

        public KeyEventArg(KeyEventArgs e)
        {
            Key = (Key.KeyCode)e.KeyData;
        }

    }
}
