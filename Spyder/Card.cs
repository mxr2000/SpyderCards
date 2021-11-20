using System;
using System.Drawing;

namespace Spyder
{
    enum Key{ Key1, Key2, Key3, Key4, Key5, Key6, Key7, Key8, Key9, Key10, KeyJ, KeyQ, KeyK, KeyA, KeySmall, KeyBig }
    enum Type { Spade, Heart, Diamond, Club }

    interface ICard
    {
        //返回是否被翻过来
        bool IsFliped { get; }
        //返回1， 2， 3， 。。。
        Key key { get; }
        //返回花色
        Type type { get; }
        //把牌翻过来
        void Flip();
        //判断给定的牌是否与自己构成连续
        bool IsConsistant(ICard card);
        void PaintBack(Graphics graphics, float X, float Y, float length, float height);
        void Paint(Graphics graphics, Image image, float X, float Y, float length, float height);
        void Paint(Graphics graphics, float X, float Y, float length, float height);
        void Paint(Graphics graphics, SolidBrush brush, Pen pen, float X, float Y, float length, float height);
    }

    class Card : ICard
    {
        public Card(Key key, Type type) { this.key = key; this.type = type; }
        public bool IsFliped { get; private set; }
        public Key key { get; set; }
        public Type type { get; set; }

        public void Flip()
        {
            if (IsFliped == false)
                IsFliped = true;
        }

        public bool IsConsistant(ICard card)
        {
            bool token = false;
            
            switch(card.key)
            {
                case Key.KeyK:if (key == Key.KeyQ) token = true;break;
                case Key.KeyQ: if (key == Key.KeyJ) token = true; break;
                case Key.KeyJ: if (key == Key.Key10) token = true; break;
                case Key.Key10: if (key == Key.Key9) token = true; break;
                case Key.Key9: if (key == Key.Key8) token = true; break;
                case Key.Key8: if (key == Key.Key7) token = true; break;
                case Key.Key7: if (key == Key.Key6) token = true; break;
                case Key.Key6: if (key == Key.Key5) token = true; break;
                case Key.Key5: if (key == Key.Key4) token = true; break;
                case Key.Key4: if (key == Key.Key3) token = true; break;
                case Key.Key3: if (key == Key.Key2) token = true; break;
                case Key.Key2: if (key == Key.Key1) token = true; break;
            }
            return token;
        }


        public void PaintBack(Graphics graphics, float X, float Y, float length, float height)
        {
            Paint(graphics, ImageCollecion.Instance.back, X, Y, length, height);
        }
        public void Paint(Graphics graphics, float X, float Y, float length, float height)
        {
            if (IsFliped == false)
            {
                Paint(graphics, ImageCollecion.Instance.back, X, Y, length, height);
                return;
            }
            //Pen pen = new Pen(Color.Black);
            //Font font = new Font(FontFamily.GenericMonospace, 10);
            //SolidBrush brush = new SolidBrush(Color.Yellow);
            //graphics.FillRectangle(brush, X, Y, length, height);
            //graphics.DrawRectangle(pen, X, Y, length, height);
            //graphics.DrawString(key.ToString(), font, new SolidBrush(Color.Black), X, Y);
            Paint(graphics, ImageCollecion.Instance.GetImage(this), X, Y, length, height);
        }

        

        public void Paint(Graphics graphics, SolidBrush brush, Pen pen, float X, float Y, float length, float height)
        {
            if (IsFliped == false)
            {
                PaintBack(graphics, X, Y, length, height);
                return;
            }
            Font font = new Font(FontFamily.GenericMonospace, 10);
            //graphics.FillRectangle(brush, X, Y, length, height);
            graphics.DrawRectangle(pen, X, Y, length, height);
            //graphics.DrawString(key.ToString(), font, new SolidBrush(Color.Black), X, Y);
        }

        public void Paint(Graphics graphics, Image image, float X, float Y, float length, float height)
        {
            graphics.DrawImage(image, X, Y, length, height);
        }
    }
}
