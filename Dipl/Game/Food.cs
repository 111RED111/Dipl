using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace Diplom111.Game
{
    //еда
    class Food : GameObjects
    {

        public Food(Size panel_size) : base(panel_size)
        {
            StartPosled = Posled.GetPosled(8); // зарезервировали место под послед в еду
            byte[] byteparam = new byte[1]; // массив байт, для переделывания из массива битов в массив байтов, для всех параметров
            StartPosled.CopyTo(byteparam, 0); // заполнение массива

            color = Color.Black; //характеристики еды
            radius = 5;
            key = new KeyNPC(ClassGame.GetDlinaKey()); // создали новый пустой ключ для еды
            key.AddBitArray(StartPosled); // записали последовательность в еду
        }
        public override void MoveObject(Point MousePosition, Size sizepanel, LinkedList<GameObjects> List1)
        {

        }

    }
}
