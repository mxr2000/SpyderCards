using System;
using System.Drawing;

namespace Spyder
{
    class HelpPage : IState
    {

        //Singleton模式
        protected HelpPage() { }
        private static HelpPage _instance = null;
        public static HelpPage Instance()
        {
            if (_instance == null)
                _instance = new HelpPage();
            return _instance;
        }
        //绘图
        int screenWidth;
        int screenHeight;
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush blackBrush = new SolidBrush(Color.Black);

        public void ChangeState(IState state)
        {
            holder.ChangeState(state);
        }

        public void Draw(Graphics graphics, int screenWidth, int screenHeight)
        {
            SetArgument(screenWidth, screenHeight);
            graphics.FillRectangle(blueBrush, screenWidth * 0.1F, screenHeight * 0.1F, screenWidth * 0.15F, screenHeight * 0.15F);
            Font font = new Font(FontFamily.GenericMonospace, 20, FontStyle.Bold);
            graphics.DrawString("返回", font, blackBrush, screenWidth * 0.1F + screenWidth * 0.15F * 0.1F,
                screenHeight * 0.1F + screenHeight * 0.15F * 0.2F);
            graphics.DrawString("经典蜘蛛纸牌玩法", font, blackBrush, screenWidth * 0.1F, screenHeight * 0.5F);
        }

        public void HandleKeyboardInput(char ch)
        {
            
        }

        public void HandleMouseInput(int X, int Y)
        {
            RectangleF rectangle1 = new RectangleF(screenWidth * 0.1F, screenHeight * 0.1F, screenWidth * 0.15F, screenHeight * 0.15F);
            if (rectangle1.Contains(X, Y))
                ChangeState(Beginnig.Instance());
        }

        public void SetArgument(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        StateHolder holder;
        public void SetStateHolder(StateHolder holder)
        {
            this.holder = holder;
        }
    }
}
