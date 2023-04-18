using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morpion
{
    public partial class frmHallOfFame : Form
    {
        private Label labelHailYou;
        public frmHallOfFame()
        {
            InitializeComponent();
            labelHailYou = new Label();
            labelHailYou.Text = "Bravo";
            labelHailYou.Name = "labelHailYou";
            labelHailYou.Location = new Point(250, 130);
            Controls.Add((Label)labelHailYou);
        }
    }
}
