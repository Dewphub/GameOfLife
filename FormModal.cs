using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class FormModal : Form
    {
        public FormModal()
        {
            InitializeComponent();
        }

        public int Number
        {
            get
            {
                return (int)numericUpDown1.Value;
            }
            set
            {
                numericUpDown1.Value = value;
            }
        }

        private void RandButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            numericUpDown1.Value = random.Next(0, 100000);
        }
    }
}
