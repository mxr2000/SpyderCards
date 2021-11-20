using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Spyder
{
    class Beginnig : IState
    {
        //Singleton模式
        protected Beginnig() { }
        private static Beginnig _instance = null;
        public static Beginnig Instance()
        {
            if (_instance == null)
                _instance = new Beginnig();
            return _instance;
        }

        //绘图参数
        private float buttonWidthToScreenWidth = 0.5F;
        private float buttonHeightToScreenHeight = 0.2F;
        private float buttonVerticalIntervalToScreenHeight = 0.3F;
        private float buttonLeftUpHorizontalToOrigin = 0.25F;
        private float buttonLeftUpVerticalToOrigin = 0.25F;

        int width;
        int height;
        int buttonWidth;
        int buttonHeight;
        int buttonInterval;
        int leftUpX;
        int leftUpY;
        //绘图工具
        SolidBrush btnBrush = new SolidBrush(Color.Pink);
        

        public void HandleMouseInput(int X, int Y)
        {
            Rectangle rectangle1 = new Rectangle(leftUpX, leftUpY, buttonWidth, buttonHeight);
            Rectangle rectangle2 = new Rectangle(leftUpX, leftUpY + buttonInterval, buttonWidth, buttonHeight);

            if (rectangle1.Contains(X, Y))
                ChangeState(Gaming.Instance());
            else if (rectangle2.Contains(X, Y))
                ChangeState(HelpPage.Instance());

        }

        public void HandleKeyboardInput(char ch)
        {
            //什么也不做
        }

        public void Draw(Graphics graphics, int screentWidth, int screenHeight)
        {
            SetArgument(screentWidth, screenHeight);
            Font font = new Font(FontFamily.GenericMonospace, buttonWidth / 8, FontStyle.Bold);
            graphics.FillRectangle(btnBrush, leftUpX, leftUpY, buttonWidth, buttonHeight);
            graphics.FillRectangle(btnBrush, leftUpX, leftUpY + buttonInterval, buttonWidth, buttonHeight);
            graphics.DrawString("开始游戏", font, new SolidBrush(Color.Black), leftUpX + buttonWidth * 0.1F, leftUpY + buttonHeight * 0.2F);
            graphics.DrawString("游戏帮助", font, new SolidBrush(Color.Black), leftUpX + buttonWidth * 0.1F , leftUpY + buttonHeight * 0.2F + buttonInterval);
        }

        public void SetArgument(int screenWidth, int screenHeight)
        {
            buttonWidth = Convert.ToInt32(screenWidth * buttonWidthToScreenWidth);
            buttonHeight = Convert.ToInt32(screenHeight * buttonHeightToScreenHeight);
            buttonInterval = Convert.ToInt32(screenHeight * buttonVerticalIntervalToScreenHeight);
            leftUpX = Convert.ToInt32(screenWidth * buttonLeftUpHorizontalToOrigin);
            leftUpY = Convert.ToInt32(screenHeight * buttonLeftUpVerticalToOrigin);
        }

        StateHolder _stateHolder = null;
        public void SetStateHolder(StateHolder holder) { _stateHolder = holder; }
        public void ChangeState(IState state)
        {
            _stateHolder.ChangeState(state);
        }
    }
}
