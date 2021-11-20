using System;
using System.Drawing;

namespace Spyder
{
    public interface StateHolder
    {
        void ChangeState(IState state);
    }
    public interface IState
    {
        void HandleMouseInput(int X, int Y);
        void HandleKeyboardInput(char ch);
        void Draw(Graphics graphics, int screentWidth, int screenHeight);
        void SetArgument(int screenWidth, int screenHeight);
        void SetStateHolder(StateHolder holder);
        void ChangeState(IState state);
    }
}
