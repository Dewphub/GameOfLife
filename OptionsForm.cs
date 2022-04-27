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
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        public int Number
        {
            get { return (int)numericUpDownTime.Value; }
            set { numericUpDownTime.Value = value; }
        }
        public int WidthNum
        {
             get { return (int)numericUpDownWidth.Value; }
            set { numericUpDownWidth.Value = value; }
            
        }
        public int HeightNum
        {
            get { return (int)numericUpDownHeight.Value; }
            set { numericUpDownHeight.Value = value; }
        }

    }
}
