using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using Diplom111.Game;

namespace Diplom111
{
    class FileWrite // вывод ключей в файл
    {

        public static void Zapisbin(string file_name) // запись в двоичный файл
        {
            LinkedList<BitArray> outpool; // пул для вывода            

            outpool = Pool.GetAllKey(); // запись в пул
            int keylen = ClassGame.DlinaKey/8; // длина одного ключа

            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                ///StreamWriter sw = new StreamWriter("E:\\111\\Testbin.txt");
                using (BinaryWriter binWriter = new BinaryWriter(File.Open(file_name, FileMode.Create))) // сохраняем в двоичном виде

                for (int i = 0; i < outpool.Count; i++) // проход по всему пулу
                {
                    BitArray poolelemet = outpool.ElementAt(i);  // достаём один ключ (poolelemet один ключ)
                    byte[] byteposled = new byte[keylen]; // массив байт, для переделывания из массива битов в массив байтов, для всех параметров (byteposled ключ в виде байтов)
                    poolelemet.CopyTo(byteposled, 0); // заполнение массива

                    ///sw.WriteLine(Encoding.ASCII.GetString(byteposled)); // запись байтов в виде строки
                    binWriter.Write(byteposled);
                    System.Diagnostics.Debug.WriteLine(" ");
                    System.Diagnostics.Debug.WriteLine("вывод");
                    System.Diagnostics.Debug.WriteLine(byteposled);
                    System.Diagnostics.Debug.WriteLine("вывод ASCII");
                    System.Diagnostics.Debug.WriteLine(Encoding.ASCII.GetString(byteposled));
                    System.Diagnostics.Debug.WriteLine("вывод UTF8");
                    System.Diagnostics.Debug.WriteLine(Encoding.UTF8.GetString(byteposled));
                }

                ///sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        public static void Zapistxt(string file_name) // запись в тхт файл
        {
            LinkedList<BitArray> outpool; // пул для вывода

            outpool = Pool.GetAllKey(); // запись в пул
            int keylen = ClassGame.DlinaKey / 8; // длина одного ключа

            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(file_name + ".txt");

                for (int i = 0; i < outpool.Count; i++) // проход по всему пулу
                {
                    BitArray poolelemet = outpool.ElementAt(i);  // достаём один ключ (poolelemet один ключ)
                    byte[] byteposled = new byte[keylen]; // массив байт, для переделывания из массива битов в массив байтов, для всех параметров (byteposled ключ в виде байтов)
                    poolelemet.CopyTo(byteposled, 0); // заполнение массива

                    string hex = BitConverter.ToString(byteposled).Replace("-", string.Empty); // перевод в 16-ичный вид

                    sw.WriteLine(hex); // запись байтов в виде строки
                    System.Diagnostics.Debug.WriteLine(" ");
                    System.Diagnostics.Debug.WriteLine("вывод 16");
                    System.Diagnostics.Debug.WriteLine(hex);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

    }  
}
