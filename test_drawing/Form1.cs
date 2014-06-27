using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_drawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            this.MaximumSize = new Size(800, 470);
            this.Height = 470;
            this.Width = 800;
        }

        public Graphics formGraphics;

    }
}
