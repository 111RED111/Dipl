using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Diplom111.Game
{
    //Общий класс объктов
    abstract class GameObjects
    {
        //protected Graphics g; //отрисовка шаров
        protected Point center; //центр шара 
        protected int radius; //размер шара
        protected Color color; //цвет шара
        static protected Random rnd = new Random(); //рандом, для характеристик ЕСЛИ ЧТО МОЖНО ЗАМЕНИТЬ РАНДОМ НА ЗВУК!!!!!!!!!!!!
        protected int step; //шаг шара

        bool delete = false; // помечает тех, кого надо удалить

        protected static int maxrad = 100; // макс радиус
        protected static int minrad = 10; // мин радиус
        protected static int maxspeed = 300; // максимальная скорость
        protected static int del = 10; // деление скорости

        protected Key key; // послеодовательность объекта
        protected BitArray StartPosled; // стартовая последовательность, из которой берём параметры

        //Параметры объектов
        protected GameObjects(Size panel_size) //panel_size - размер панели
        {

            center = new Point(rnd.Next(0, panel_size.Width), rnd.Next(0, panel_size.Height));//рандомное место респауна

            StartPosled = Posled.GetPosled(32); // зарезервировали место под все параметры (цвет, размер)
            byte[] byteparam = new byte[4]; // массив байт, для переделывания из массива битов в массив байтов, для всех параметров
            StartPosled.CopyTo(byteparam, 0); // заполнение массива

            radius = byteparam[0]/4; //размер 10-64 пикселей

            if (radius < minrad) //если размер из массива пришёл меньше 10, делать объект равным 10
            {
                radius = minrad;
            }

            step = (maxspeed - radius)/del; //скорость движения
                        
            color = Color.FromArgb(byteparam[1], byteparam[2], byteparam[3]); // цвет объектов
        }

        //Рисуем объект
        public virtual void DrawObject(Graphics g) 
        {
            g.FillEllipse(new SolidBrush(color), center.X - radius, center.Y - radius, 2 * radius, 2 * radius);//рисуем объект            
        }

        //Возвращает координаты объекта
        public Point GetCenter()
        {
            return center;
        }

        public int GetRadius()
        {
            return radius;
        }

        public Color GetColor()
        {
            return color;
        }

        public int GetStep()
        {
            return step;
        }


        //Сдвигаем объект
        public abstract void MoveObject(Point MousePosition, Size sizepanel, LinkedList<GameObjects>List1);
        //{
        //    int step = 10;
        //    Point MousePosition1 = new Point(MousePosition.X - radius, MousePosition.Y - radius);

        //    double dist = Math.Sqrt(Math.Pow(MousePosition1.X - center.X, 2) + Math.Pow(MousePosition1.Y - center.Y, 2)); //расчёт расстояния

        //    Console.WriteLine(dist);

        //    if (dist <= step) //сдвиг объекта
        //    {
        //        center = MousePosition1;
        //    }
        //    else
        //    {
        //        //сдвиг на шаг к курсору
        //        center.X = (int)(center.X + (MousePosition1.X - center.X) * (step / dist));
        //        center.Y = (int)(center.Y + (MousePosition1.Y - center.Y) * (step / dist));
        //    }
        //}

        protected void KillObj(LinkedList<GameObjects> List1, GameObjects target) //съедание
        {
            for (int i = 0; i < List1.Count; i++)
            {
                // if (List1.ElementAt(i) == null) // если кого-то съели пропускаем его(не высчитываем расстояние)
                if(List1.ElementAt(i).delete == true) // если кого-то съели пропускаем его(не высчитываем расстояние)
                {
                    continue;
                }
                //if (target != null) // проверка, что кто-то выбран для съедания
                //{
                    if (radius > List1.ElementAt(i).radius) // проверка кто больше
                    {
                        double dist = Math.Sqrt(Math.Pow(center.X - List1.ElementAt(i).GetCenter().X, 2) + Math.Pow(center.Y - List1.ElementAt(i).GetCenter().Y, 2)); // момент съедания(центр круга еды в круге охотника)
                        if (dist < radius) // проверка ^
                        {
                            //for (int i = 0; i < List1.Count; i++) // удалить кого съели
                            //{
                                //if (List1.ElementAt(i) == target)
                                //{
                                    
                            key.AddBitArray(List1.ElementAt(i).GetKey().GetKeyArray()); // тот, кто съедает кого-то получает его последовательность
                            IncRad(List1.ElementAt(i)); // вызов увеличения
                                                        //List1.Find(List1.ElementAt(i)).Value = null; // удалить из списка, кого съели
                            
                            List1.ElementAt(i).delete = true; // метка, что этот элемент надо удалить

                            if (radius > maxrad*0.9) // удаление объекта после набора 90% от максимального радиуса
                            {
                                int smert = rnd.Next(0, 100); // с 95% что выживет, когда кого-то съедает
                                if (smert > 95)
                                {
                                    //List1.Find(this).Value = null;
                                    delete = true; // пометили, что надо удалить
                                }
                            }
                        //break;
                        //}
                        //}
                       // List1.Find(List1.ElementAt(i)).Value = null; // удалить из списка, кого съели
                    }
                    }
                //}
            }            
        }

        public Key GetKey() // получить ключ
        {
            return key;
        }

        public virtual void IncRad(GameObjects target) // изменение размеров объекта и скорости
        {
            radius = radius + (target.radius) / 5; //увеличение радиуса на (радиус цели / 5 )
            if (radius > maxrad) //радиус не может быть больше 64
            {
                radius = maxrad;
            }
            step = (maxspeed - radius)/del;
            
        }

        public bool Del_Mark() // возвращение метки, тех кого надо удалить
        {
            return delete;
        }
    }
}
