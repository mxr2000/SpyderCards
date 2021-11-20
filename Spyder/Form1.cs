using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spyder
{
    public partial class Form1 : Form, StateHolder
    {
        public Form1()
        {
            InitializeComponent();
            Beginnig.Instance().SetStateHolder(this);
            Gaming.Instance().SetStateHolder(this);
            HelpPage.Instance().SetStateHolder(this);
        }

        //数据
        private IState _state = Beginnig.Instance();
        public void ChangeState(IState state)
        {
            _state = state;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _state.Draw(e.Graphics, ClientSize.Width, ClientSize.Height);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            _state.HandleMouseInput(e.X, e.Y);
            Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
