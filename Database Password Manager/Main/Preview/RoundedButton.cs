using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DatabasePasswordManager.Main.Preview
{
    internal sealed class RoundedButton : Button
    {
        #region GLOBAL_VARIABLES
        private int locationOffset;
        [DefaultValue(2)]
        public int LocationOffset
        {
            get { return locationOffset; }
            set { int locationOffset = value; if (locationOffset >= 0) { this.locationOffset = locationOffset; } }
        }

        private int sizeOffset;
        [DefaultValue(5)]
        public int SizeOffset
        {
            get { return sizeOffset; }
            set { int sizeOffset = value; if (sizeOffset >= 0) { this.sizeOffset = sizeOffset; } }
        }
        #endregion

        #region CONSTRUCTOR
        public RoundedButton()
        {
            locationOffset = 2;
            sizeOffset = 5;
        }
        #endregion

        #region COMPONENT_EVENT
        protected override void OnCreateControl()
        {
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                graphicsPath.AddEllipse(new Rectangle(LocationOffset, LocationOffset, (Width - SizeOffset), (Height - SizeOffset)));

                Region = new Region(graphicsPath);
            }

            base.OnCreateControl();
        }
        #endregion
    }
}
