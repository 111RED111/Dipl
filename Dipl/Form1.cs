using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom111.Game;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Diplom111
{
    public partial class Form1 : Form
    {

        ClassGame Game;
        Recording Record;

        public Form1()
        {
            InitializeComponent();
            Record = new Recording();
            //comboBox1.SelectedItem = "64";
            comboBox1.SelectedIndex = 0;

            Pool.SetLabel(KolKey); // передача метки, что бы можно было записывать

        }

        //Начинаем запись
        private void StartRecord_Click(object sender, EventArgs e)
        {
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // выбор куда сохранять аудио
            {
                Record.StartRecord(saveFileDialog1.FileName + ".wav"); // имя файлы
                StopRecord.Enabled = true; // включение второй кнопки при нажатии первой
                StartRecord.Enabled = false; // выключ первой кнопки 
                Convert.Enabled = false;
            }            
            
        }

        //Прерываем запись и конвертирование в цифры
        private void StopRecord_Click(object sender, EventArgs e)
        {
            Record.StopRecord();            
            StopRecord.Enabled = false;
            StartRecord.Enabled = true;
            Convert.Enabled = true;
        }

        //Конвертирование аудио в цифры
        private void Convert_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // выбор какой файл берём для конвертирования
            {
                Convert1.ProcConvert(openFileDialog1.FileName);
                StartGame.Enabled = true;
                Convert.Enabled = false;
                Save.Enabled = false;
            }
        }

        //Рисуем объекты
        private void StartGame_Click(object sender, EventArgs e)
        {            
            Pool.ClearPool(); // очищение пула
            KolKey.Text = "Ключей сгенерировано: 0";
            int DlinaKey = int.Parse(comboBox1.Text); // достаём длину ключа из комбобокса

            try // проверка на ввод символов
            {
                int KolObj = int.Parse(KolvoObj.Text); // достаём сколько объектов(интежер) нужно из текстбокса
                int NujKey = int.Parse(NujnoKey.Text); // достаём сколько ключей(интежер) нужно из текстбокса

                bool err = false;

                if (NujKey <= 0 || KolObj <= 0)
                {
                    err = true;
                    MessageBox.Show("Вы ввели число 0 или меньше!");                
                }

                if (NujKey > 2000)
                {
                    err = true;
                    MessageBox.Show("Вы ввели слишком большое количество ключей! Максимум 2000");
                }

                if (err == true)
                {
                    return;
                }
                   
                Game = new ClassGame(panel1, DlinaKey, NujKey, KolObj);
                Game.StartGame();
                //g.FillEllipse(new SolidBrush(Color.Black), 100, 100, 10, 10);
                Convert.Enabled = false;
                StartGame.Enabled = false;
                StopGame.Enabled = true;
                Save.Enabled = false;
                StartRecord.Enabled = false;
                comboBox1.Enabled = false;
                NujnoKey.Enabled = false;
                KolvoObj.Enabled = false;                                
            }
            catch (System.FormatException)
            { 
                MessageBox.Show("Вы ввели символ! Пожалуйста, введите цифрy");
            }
        }

        //Движение курсора по панели
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Game != null)
            {
                Game.SetMousePosition(e.Location);
            }            
        }

        //выбор игрока
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Game != null)
            {
                Game.CreatePlayer();
            }                
        }

        // закрытие формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Game != null)
            {
                Game.Stop();
            }
        }

        // остановка игры по кнопке
        private void StopGame_Click(object sender, EventArgs e)
        {
            if (Game != null)
            {
                Game.Stop();
            }
            Graphics g = panel1.CreateGraphics();//переменная, через которую рисуем
            g.Clear(Color.White);//обновление панели
            Convert.Enabled = true;
            StartGame.Enabled = true;
            StopGame.Enabled = false;
            Save.Enabled = true;
            StartRecord.Enabled = true;
            comboBox1.Enabled = true;
            NujnoKey.Enabled = true;
            KolvoObj.Enabled = true;
        }

        // сохранение ключей
        private void Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = ""; // очистка поля filename
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // выбор куда сохранить вывод
            {
                FileWrite.Zapisbin(saveFileDialog1.FileName);                 
                FileWrite.Zapistxt(saveFileDialog1.FileName);
            }
            
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e) //запись нового значения скорости
        {
            ClassGame.gamespeed = hScrollBar1.Maximum-hScrollBar1.Value+hScrollBar1.Minimum;      
        }
    }
}
