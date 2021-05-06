﻿using System;
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
            saveFileDialog1.ShowDialog(); // выбор куда сохранять
            System.Diagnostics.Debug.WriteLine(saveFileDialog1.FileName); 
            Record.StartRecord(saveFileDialog1.FileName + ".wav"); // имя файлы

            StopRecord.Enabled = true; // включение второй кнопки при нажатии первой
            StartRecord.Enabled = false; // выключ первой кнопки 
            Convert.Enabled = false;
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
            openFileDialog1.ShowDialog(); // выбор какой файл берём для конвертирования
            System.Diagnostics.Debug.WriteLine(openFileDialog1.FileName);
            Convert1.ProcConvert(openFileDialog1.FileName);

            StartGame.Enabled = true;
            Convert.Enabled = false;
        }

        //Рисуем объекты
        private void StartGame_Click(object sender, EventArgs e)
        {            
            Pool.ClearPool(); // очищение пула
            KolKey.Text = "Ключей сгенерировано: 0";
            int DlinaKey = int.Parse(comboBox1.Text); // достаём длину ключа из комбобокса

            try // проверка на ввод символов
            {
                int NujKey = int.Parse(NujnoKey.Text); // достаём сколько ключей нужно из текстбокса
                if (NujKey<=2000)
                {
                    Game = new ClassGame(panel1, DlinaKey, NujKey);
                    Game.StartGame();
                    //g.FillEllipse(new SolidBrush(Color.Black), 100, 100, 10, 10);
                    Convert.Enabled = false;
                    StartGame.Enabled = false;
                    StopGame.Enabled = true;
                    Save.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Вы ввели слишком большое количество ключей! Максимум 2000");
                }
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
                Game.CreatePlayer(e.Location);
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
        }

        // сохранение ключей
        private void Save_Click(object sender, EventArgs e)
        {
            FileWrite.ZapisBin();
            FileWrite.Zapistxt();
        }
    }
}
