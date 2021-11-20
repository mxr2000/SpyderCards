using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spyder
{
    class Triumph : IState
    {
        protected Triumph() { }
        private static Triumph _instance = null;
        public static Triumph Instance()
        {
            if (_instance == null)
                _instance = new Triumph();
            return _instance;
        }

        public void ChangeState(IState state)
        {
            _holder.ChangeState(state);
        }

        public void Draw(Graphics graphics, int screentWidth, int screenHeight)
        {
            //绘制完成画面
        }

        public void HandleKeyboardInput(char ch)
        {
            //什么也不做
        }

        public void HandleMouseInput(int X, int Y)
        {
            
        }

        public void SetArgument(int screenWidth, int screenHeight)
        {
            
        }

        StateHolder _holder = null;
        public void SetStateHolder(StateHolder holder)
        {
            holder = _holder;
        }
    }
}
