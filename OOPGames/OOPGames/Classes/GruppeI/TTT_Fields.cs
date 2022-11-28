using System;
using System.Collections.Generic;

namespace OOPGames.Classes.GruppeI
{
    public class I_TicTacToeField : I_ITicTacToeField
    {

        int[,] _Field = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int[,] _Field1 = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int[,] _Field2 = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int[,] _Field3 = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int[,] _Field4 = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int[,] _Field5 = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int[,] _Field6 = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int[,] _Field7 = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int[,] _Field8 = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        public List<int[,]> _MasterField = new List<int[,]>();

        public I_TicTacToeField()
        {
            _MasterField.Add(_Field);
            _MasterField.Add(_Field1);
            _MasterField.Add(_Field2);
            _MasterField.Add(_Field3);
            _MasterField.Add(_Field4);
            _MasterField.Add(_Field5);
            _MasterField.Add(_Field6);
            _MasterField.Add(_Field7);
            _MasterField.Add(_Field8);
        }

        public int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return _MasterField[0][r, c];
                }
                else
                {
                    return -1;
                }
                if (r >= 0 && r < 3 && c >= 3 && c < 5)
                {
                    return _MasterField[1][r, c];
                    //r und c sollte man umrechnen
                }
                else
                {
                    return -1;
                }
            }

            set
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    _MasterField[0][r, c] = value;
                }
            }
        }
        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is I_ITicTacToeField;
        }
    }
}

