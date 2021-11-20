using System;
using System.Collections.Generic;

namespace Spyder
{
    class Board
    {
        public const int Quantity_Rows = 10;
        private List<ICard>[] lists = new List<ICard>[Quantity_Rows];
        public List<ICard> GetCards(int row) { return lists[row]; }
        public ICard GetCard(int row, int index) { return lists[row][index]; }
        public int Num(int row)
        {
            if (row == 10)
                return 0;
            return lists[row].Count;
        }
        public int completeCards = 0;

        public Board()
        {
            for (int i = 0; i < Quantity_Rows; i++)
                lists[i] = new List<ICard>();
        }

        public bool HavingVacancy()
        {
            foreach (var i in lists)
                if (i.Count == 0)
                    return true;
            return false;
        }

        public bool FlipCard(int row, int index)
        {
            if (lists[row][index].IsFliped == false && index == Num(row) - 1)
            {
                lists[row][index].Flip();
                return true;
            }
            return false;
        }
        public bool Select(int row, int index)
        {
            if (!lists[row][index].IsFliped)
                return false;
            if (index == Num(row) - 1)
                return true;
            for (int i = index; i < Num(row) - 1; i++)
                if (!lists[row][i + 1].IsConsistant(lists[row][i]))
                    return false;
            return true;
        }

        public bool Move(int sourceRow, int headIndex, int targetRow)
        {
            if (sourceRow == targetRow)
                return false;
            if (lists[targetRow].Count == 0)
                return true;
            ICard card = lists[targetRow][Num(targetRow) - 1];
            if (card.IsFliped && lists[sourceRow][headIndex].IsConsistant(card))
                return true;
            return false;
        }

        public void MoveCards(int sourceRow, int headIndex, int targetRow)
        {
            int sum = lists[sourceRow].Count - headIndex;
            for (int i = headIndex; i < lists[sourceRow].Count; i++)
                lists[targetRow].Add(lists[sourceRow][i]);
            lists[sourceRow].RemoveRange(headIndex, sum);
        }

        public void RemoveCrads(int row)
        {
            int head = Num(row) - 13;
            lists[row].RemoveRange(head, 13);
            completeCards++;
        }
        public void AddCards(ICard[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
                lists[i].Add(cards[i]);
        }

        public void FlipTailCards()
        {
            for (int i = 0; i < Quantity_Rows; i++)
                if(Num(i) >= 0)
                    lists[i][Num(i) - 1].Flip();
        }

        public void FindAndRemoveCompleteCards()
        {

            for (int i = 0; i < Board.Quantity_Rows; i++)
                if (Num(i) >= 13)
                {
                    int head = Num(i) - 13;
                    if (lists[i][head].key != Key.KeyK)
                        continue;
                    for (int j = head; j < Num(i) - 1; j++)
                        if (!lists[i][j + 1].IsConsistant(lists[i][j]))
                            continue;
                    RemoveCrads(i);
                }
        }

        
    }
}
