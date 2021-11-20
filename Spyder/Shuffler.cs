using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spyder
{
    class Shuffler
    {
        private List<Card> _cards = new List<Card>();
        public int Remains { get; private set; }
        public Card[] cards = new Card[13 * 8];
        public Shuffler()
        {
            for (int i = 0; i < 13 * 8; i++)
                _cards.Add(new Card(Key.Key1, Type.Club));
            Remains = 13 * 8;
            for (int i = 0; i < 8; i++)
                InitializeCrads(13 * i, i % 4);

            Card[] aux = new Card[13 * 8];
            Random random = new Random(DateTime.Now.Minute);
            for (int i = 0; i < 13 * 8; i++)
            {
                int index = random.Next() % _cards.Count;
                aux[i] = _cards.ElementAt(index);
                _cards.RemoveAt(index);
            }
            aux.CopyTo(cards, 0);
        }

        private void InitializeCrads(int index, int typeIndex)
        {
            _cards[index] = new Card(Key.Key1, Type.Club);
            _cards[index + 1] = new Card(Key.Key2, Type.Club);
            _cards[index + 2] = new Card(Key.Key3, Type.Club);
            _cards[index + 3] = new Card(Key.Key4, Type.Club);
            _cards[index + 4] = new Card(Key.Key5, Type.Club);
            _cards[index + 5] = new Card(Key.Key6, Type.Club);
            _cards[index + 6] = new Card(Key.Key7, Type.Club);
            _cards[index + 7] = new Card(Key.Key8, Type.Club);
            _cards[index + 8] = new Card(Key.Key9, Type.Club);
            _cards[index + 9] = new Card(Key.Key10, Type.Club);
            _cards[index + 10] = new Card(Key.KeyJ, Type.Club);
            _cards[index + 11] = new Card(Key.KeyQ, Type.Club);
            _cards[index + 12] = new Card(Key.KeyK, Type.Club);

            Type type = Type.Spade;
            switch (typeIndex % 4)
            {
                case 0: type = Type.Club; break;
                case 1: type = Type.Diamond; break;
                case 2: type = Type.Heart; break;
                case 3: type = Type.Spade; break;
            }
            for (int i = index; i < index + 13; i++)
                _cards[i].type = type;

        }
        public Card[] SendCards(int num)
        {
            int numToSend = num > Remains ? Remains : num;
            Card[] ret = new Card[numToSend];
            for (int i = 0; i < numToSend; i++)
                ret[i] = cards[Remains - i - 1];
            Remains -= numToSend;
            return ret;
        }

    }
}
