using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebraEvents
{
    public partial class IntroDebra : Form
    {
       /* [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeft,
            int nTop,
            int nRight,
            int Bottom,
            int nWidthEllipe,
            int nHeightEllipe
            );*/
        public IntroDebra()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DebraOption debraOption = new DebraOption();
            debraOption.Show();
            this.Hide();
        }

        private void IntroDebra_Load(object sender, EventArgs e)
        {
            //btnStart.Region = Region.FromHrgn(CreateRoundRectRgn(10, 10, btnStart.Width, btnStart.Height, 20, 20));
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            DebraOption debraOption = new DebraOption();
            debraOption.Show();
            this.Hide();
        }
    }
}
