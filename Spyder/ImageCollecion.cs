using System;
using System.Drawing;

namespace Spyder
{
    class ImageCollecion
    {
        protected ImageCollecion() { }
        private static ImageCollecion _instance;
        public static ImageCollecion Instance { get { if (_instance == null) _instance = new ImageCollecion();return _instance; } }
        Image S1 = Image.FromFile("SA.jpg");
        Image S2 = Image.FromFile("S2.jpg");
        Image S3 = Image.FromFile("S3.jpg");
        Image S4 = Image.FromFile("S4.jpg");
        Image S5 = Image.FromFile("S5.jpg");
        Image S6 = Image.FromFile("S6.jpg");
        Image S7 = Image.FromFile("S7.jpg");
        Image S8 = Image.FromFile("S8.jpg");
        Image S9 = Image.FromFile("S9.jpg");
        Image S10 = Image.FromFile("S10.jpg");
        Image SJ = Image.FromFile("SJ.jpg");
        Image SQ = Image.FromFile("SQ.jpg");
        Image SK = Image.FromFile("SK.jpg");

        Image D1 = Image.FromFile("DA.jpg");
        Image D2 = Image.FromFile("D2.jpg");
        Image D3 = Image.FromFile("D3.jpg");
        Image D4 = Image.FromFile("D4.jpg");
        Image D5 = Image.FromFile("D5.jpg");
        Image D6 = Image.FromFile("D6.jpg");
        Image D7 = Image.FromFile("D7.jpg");
        Image D8 = Image.FromFile("D8.jpg");
        Image D9 = Image.FromFile("D9.jpg");
        Image D10 = Image.FromFile("D10.jpg");
        Image DJ = Image.FromFile("DJ.jpg");
        Image DQ = Image.FromFile("DQ.jpg");
        Image DK = Image.FromFile("DK.jpg");

        Image H1 = Image.FromFile("HA.jpg");
        Image H2 = Image.FromFile("H2.jpg");
        Image H3 = Image.FromFile("H3.jpg");
        Image H4 = Image.FromFile("H4.jpg");
        Image H5 = Image.FromFile("H5.jpg");
        Image H6 = Image.FromFile("H6.jpg");
        Image H7 = Image.FromFile("H7.jpg");
        Image H8 = Image.FromFile("H8.jpg");
        Image H9 = Image.FromFile("H9.jpg");
        Image H10 = Image.FromFile("H10.jpg");
        Image HJ = Image.FromFile("HJ.jpg");
        Image HQ = Image.FromFile("HQ.jpg");
        Image HK = Image.FromFile("HK.jpg");

        Image C1 = Image.FromFile("CA.jpg");
        Image C2 = Image.FromFile("C2.jpg");
        Image C3 = Image.FromFile("C3.jpg");
        Image C4 = Image.FromFile("C4.jpg");
        Image C5 = Image.FromFile("C5.jpg");
        Image C6 = Image.FromFile("C6.jpg");
        Image C7 = Image.FromFile("C7.jpg");
        Image C8 = Image.FromFile("C8.jpg");
        Image C9 = Image.FromFile("C9.jpg");
        Image C10 = Image.FromFile("C10.jpg");
        Image CJ = Image.FromFile("CJ.jpg");
        Image CQ = Image.FromFile("CQ.jpg");
        Image CK = Image.FromFile("CK.jpg");
        public Image back = Image.FromFile("mxr.jpg");
        public Image GetImage(ICard card)
        {
            switch(card.type)
            {
                case Type.Club:
                    switch(card.key)
                    {
                        case Key.Key1:return C1;
                        case Key.Key2: return C2;
                        case Key.Key3:return C3;
                        case Key.Key4:return C4;
                        case Key.Key5:return C5;
                        case Key.Key6:return C6;
                        case Key.Key7:return C7;
                        case Key.Key8:return C8;
                        case Key.Key9:return C9;
                        case Key.Key10:return C10;
                        case Key.KeyJ:return CJ;
                        case Key.KeyQ:return CQ;
                        case Key.KeyK:return CK;
                            
                    }break;
                case Type.Heart:
                    switch (card.key)
                    {
                        case Key.Key1: return H1;
                        case Key.Key2: return H2;
                        case Key.Key3: return H3;
                        case Key.Key4: return H4;
                        case Key.Key5: return H5;
                        case Key.Key6: return H6;
                        case Key.Key7: return H7;
                        case Key.Key8: return H8;
                        case Key.Key9: return H9;
                        case Key.Key10: return H10;
                        case Key.KeyJ: return HJ;
                        case Key.KeyQ: return HQ;
                        case Key.KeyK: return HK;

                    }
                    break;
                case Type.Spade:
                    switch (card.key)
                    {
                        case Key.Key1: return S1;
                        case Key.Key2: return S2;
                        case Key.Key3: return S3;
                        case Key.Key4: return S4;
                        case Key.Key5: return S5;
                        case Key.Key6: return S6;
                        case Key.Key7: return S7;
                        case Key.Key8: return S8;
                        case Key.Key9: return S9;
                        case Key.Key10: return S10;
                        case Key.KeyJ: return SJ;
                        case Key.KeyQ: return SQ;
                        case Key.KeyK: return SK;

                    }
                    break;
                case Type.Diamond:
                    switch (card.key)
                    {
                        case Key.Key1: return D1;
                        case Key.Key2: return D2;
                        case Key.Key3: return D3;
                        case Key.Key4: return D4;
                        case Key.Key5: return D5;
                        case Key.Key6: return D6;
                        case Key.Key7: return D7;
                        case Key.Key8: return D8;
                        case Key.Key9: return D9;
                        case Key.Key10: return D10;
                        case Key.KeyJ: return DJ;
                        case Key.KeyQ: return DQ;
                        case Key.KeyK: return DK;

                    }
                    break;
            }
            return S1;
        }
    }
}
