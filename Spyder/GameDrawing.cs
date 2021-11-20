using System;
using System.Drawing;

namespace Spyder
{
    class GameDrawing
    {
        private Board board;
        private Shuffler shuffler = new Shuffler();

        int SelectedRow = -1;
        int SelectedIndex = -1;
        public float cardBlank = 0.05F;
        public float coverPart = 0.2F;
        public float cardVerticalPart = 0.25F;

        //牌堆参数
        private float _pilesX = 0.1F;
        private float _pilesY = 0.75F;
        private float _pilesInterval = 0.1F;
        public float CoverPart(int row)
        {
            int num = board.Num(row);
            if (num < 10)
                return 0.2F;
            else if (num < 20)
                return 0.15F;
            else
                return 0.1F;
        }

        //洗牌器位置
        public float shufferCoordinateX = 0.75F;
        public float shufferCoordinateY = 0.75F;
        private float shufflerInterval = 0.1F;

        private SolidBrush backgroundBursh = new SolidBrush(Color.Green);

        //绘制背景
        public void PaintBackground(Graphics graphics, int CanvasX, int CanvasY, int CanvasCoordinateX, int CanvasCoordinateY)
        {
            graphics.FillRectangle(backgroundBursh, CanvasCoordinateX, CanvasCoordinateY, CanvasX, CanvasY);
        }

        //绘制发牌器
        public void PaintShuffler(Graphics graphics, int CanvasX, int CanvasY, int CanvasCoordinateX, int CanvasCoordinateY)
        {
            ICard card = new Card(Key.Key1, Type.Club);
            int leftUpX = Convert.ToInt32(CanvasX * shufferCoordinateX);
            int leftUpY = Convert.ToInt32(CanvasY * shufferCoordinateY);
            int width = Convert.ToInt32(CanvasX / 10 * (1 - 2 * cardBlank));
            int height = Convert.ToInt32(CanvasY * cardVerticalPart * (1 - 2 * cardBlank));
            int interval = Convert.ToInt32(CanvasX / 10 * shufflerInterval);
            for (int i = 0; i < shuffler.Remains / 10 ; i++)
                card.PaintBack(graphics, leftUpX + i * interval, leftUpY, width, height);
        }

        //绘制已经完成的排堆
        public void PaintPiles(Graphics graphics, int CanvasX, int CanvasY, int CanvasCoordinateX, int CanvasCoordinateY)
        {
            ICard card = new Card(Key.KeyK, Type.Club);
            card.Flip();
            int leftUpX = Convert.ToInt32(CanvasX * _pilesX);
            int leftUpY = Convert.ToInt32(CanvasY * _pilesY);
            int width = Convert.ToInt32(CanvasX / 10 * (1 - 2 * cardBlank));
            int height = Convert.ToInt32(CanvasY * cardVerticalPart * (1 - 2 * cardBlank));
            int interval = Convert.ToInt32(CanvasX / 10 * _pilesInterval);

            for (int i = 0; i < board.completeCards; i++)
                card.Paint(graphics, leftUpX + i * interval, leftUpY, width, height);
        }

        //绘制所有牌组
        public void PaintCards(Graphics graphics, int CanvasX, int CanvasY, int CanvasCoordinateX, int CanvasCoordinateY)
        {
            //绘制参数
            float intervalX = CanvasX * 1.0F / Board.Quantity_Rows;
            float length = intervalX * (1 - 2 * cardBlank);
            float intervalY = CanvasY * cardVerticalPart;
            float height = intervalY * (1 - 2 * cardBlank);

            for (int i = 0; i < Board.Quantity_Rows; i++)
                for (int j = 0; j < board.Num(i); j++)
                {
                    ICard card = board.GetCard(i, j);
                    card.Paint(graphics, CanvasCoordinateX + i * intervalX + intervalX * cardBlank, CanvasCoordinateY + j * intervalY * CoverPart(i) + intervalY * cardBlank, length, height);
                }
        }
        //绘制等待的牌组
        public void PaintSlectedCards(Graphics graphics, int CanvasX, int CanvasY, int CanvasCoordinateX, int CanvasCoordinateY)
        {
            
            if (SelectedIndex == -1)
                return;
            SolidBrush selectedBrush = new SolidBrush(Color.Pink);
            Pen pen = new Pen(Color.Black, 2);
            int row = SelectedRow;
            int index = SelectedIndex;
            int num = board.Num(row);

            //绘制参数
            float intervalX = CanvasX * 1.0F / Board.Quantity_Rows;
            float length = intervalX * (1 - 2 * cardBlank);
            float intervalY = CanvasY * cardVerticalPart;
            float height = intervalY * (1 - 2 * cardBlank);

            for (int i = index; i < num; i++)
                board.GetCard(row, i).Paint(graphics, selectedBrush, pen, CanvasCoordinateX + row * intervalX + intervalX * cardBlank, CanvasCoordinateY + i * intervalY * CoverPart(row) + intervalY * cardBlank, length, height);
        }
        public GameDrawing(Board board) { this.board = board; }

        //判断是否有效点击，若有效则切换
        public bool MouseClickInCards(int X, int Y, int CanvasX, int CanvasY, int CanvasCoordinateX, int CanvasCoordinateY)
        {
            //选择点到的牌
            X -= CanvasCoordinateX;
            Y -= CanvasCoordinateY;

            int length = CanvasX / Board.Quantity_Rows;
            int height = Convert.ToInt32(CanvasY * cardVerticalPart);

            int row = X / length > 9 ? 9 : X / length;
            int index;
            if (board.Num(row) == 0 && SelectedIndex == -1)
                return false;
            if (Y > (board.Num(row) - 1) * height * CoverPart(row) && Y < (board.Num(row) - 1) * height * CoverPart(row) + height)
                index = board.Num(row) - 1;
            else
                index = (Y - Convert.ToInt32(height * cardBlank)) / Convert.ToInt32(height * CoverPart(row));
            if(index > board.Num(row))
            {
                SelectedIndex = SelectedRow = -1;
                return true;
            }
            //选择牌
            if (row == 10)
                row--;
            if (SelectedIndex == -1)
                MouseToSetSelected(row, index);
            //判断移动并移动
            else if(!MouseToMove(row, index))
                MouseToSetSelected(row, index);
            return true;
        }

        //无选定牌操作
        private void MouseToSetSelected(int row, int index)
        {
            if (board.FlipCard(row, index))
                ;
            else if (board.Select(row, index))
            {
                SelectedIndex = index;
                SelectedRow = row;
            }
        }
        
        //判断移动并移动并移除完整牌组
        private bool MouseToMove(int row, int index)
        {
            bool token = false;
            if (board.Move(SelectedRow, SelectedIndex, row))
            {
                board.MoveCards(SelectedRow, SelectedIndex, row);
                token = true;
                board.FindAndRemoveCompleteCards();
            }
            SelectedIndex = SelectedRow = -1;
            return token;
        }
        //判断是否点击发牌器
        public bool MouseClickInShuffer(int X, int Y, int CanvasX, int CanvasY, int CanvasCoordinateX, int CanvasCoordinateY)
        {

            if (X > CanvasCoordinateX + CanvasX * shufferCoordinateX && X < CanvasCoordinateX + CanvasX * shufferCoordinateX + 50
                && Y > CanvasCoordinateY + CanvasY * shufferCoordinateY && Y < CanvasCoordinateY + CanvasY * shufferCoordinateY + 50)
                return true;
            return false;
        }

        //发牌
        public void Shuffle(int num)
        {
            Card[] newCards = shuffler.SendCards(num);
            board.AddCards(newCards);
            SelectedRow = SelectedIndex = -1;
        }

        public void FlipTailCards() { board.FlipTailCards(); }
        public bool Finished() { return board.completeCards == 8; }

    }
}
