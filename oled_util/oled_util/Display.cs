using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace oled_util
{
    public partial class Display : Form
    {

        #region Constructor

        public Display()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Public Update Functions

        public void updateImage(Bitmap image)
        {
            pictureBoxBin.Image = image;
        }

        #endregion Public Update Functions

        #region Button Clicks

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Button Clicks

    }
}
