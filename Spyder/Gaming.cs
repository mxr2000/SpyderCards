using System;
using System.Drawing;
namespace Spyder
{
    class Gaming : IState
    {
        GameDrawing gameDrawing;
        //Singleton模式
        protected Gaming()
        {
            gameDrawing = new GameDrawing(new Board());
            gameDrawing.Shuffle(10);
            gameDrawing.Shuffle(10);
            gameDrawing.Shuffle(10);
            gameDrawing.Shuffle(9);
        }
        private static Gaming _instance = null;
        public static Gaming Instance()
        {
            if (_instance == null)
                _instance = new Gaming();
            return _instance;
        }

        //绘图参数
        int width;
        int height;

        public void ChangeState(IState state)
        {

        }

        public void Draw(Graphics graphics, int screentWidth, int screenHeight)
        {
            SetArgument(screentWidth, screenHeight);

            gameDrawing.PaintBackground(graphics, screentWidth, screentWidth, 0, 0);
            gameDrawing.PaintCards(graphics, screentWidth, screenHeight, 0, 0);
            gameDrawing.PaintSlectedCards(graphics, screentWidth, screenHeight, 0, 0);
            gameDrawing.PaintPiles(graphics, screentWidth, screenHeight, 0, 0); ;
            gameDrawing.PaintShuffler(graphics, screentWidth, screenHeight, 0, 0);
            gameDrawing.PaintSlectedCards(graphics, screentWidth, screenHeight, 0, 0);
        }

        public void HandleKeyboardInput(char ch)
        {
            //什么也不做
        }

        public void HandleMouseInput(int X, int Y)
        {
            if (gameDrawing.MouseClickInShuffer(X, Y, width, height, 0, 0))
            {
                gameDrawing.Shuffle(10);
                gameDrawing.FlipTailCards();
            }
            else if (gameDrawing.MouseClickInCards(X, Y, width, height, 0, 0))
                ;
            if (gameDrawing.Finished())
                ChangeState(Triumph.Instance());
        }

        public void SetArgument(int screenWidth, int screenHeight)
        {
            width = screenWidth;
            height = screenHeight;
        }

        StateHolder _holder = null;
        public void SetStateHolder(StateHolder holder)
        {
            _holder = holder;
        }
    }
}
