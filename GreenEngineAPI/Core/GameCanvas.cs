﻿using System.Windows.Forms;

namespace GreenEngineAPI.Core
{
    public class GameCanvas : Form
    {
        public enum WindowStyles
        {
            None,
            FixedSingle,
            Fixed3D,
            FixedDialog,
            Sizable,
            FixedToolWindow,
            SizableToolWindow
        }

        internal GameCanvas()
        {
            this.DoubleBuffered = true;
        }
    }
}
