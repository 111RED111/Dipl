﻿
namespace Diplom111
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.StartRecord = new System.Windows.Forms.Button();
            this.StopRecord = new System.Windows.Forms.Button();
            this.Convert = new System.Windows.Forms.Button();
            this.StartGame = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.StopGame = new System.Windows.Forms.Button();
            this.KolKey = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NujnoKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "64",
            "128",
            "256"});
            this.comboBox1.Location = new System.Drawing.Point(1130, 24);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // StartRecord
            // 
            this.StartRecord.Location = new System.Drawing.Point(30, 32);
            this.StartRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartRecord.Name = "StartRecord";
            this.StartRecord.Size = new System.Drawing.Size(122, 46);
            this.StartRecord.TabIndex = 1;
            this.StartRecord.Text = "Начать запись";
            this.StartRecord.UseVisualStyleBackColor = true;
            this.StartRecord.Click += new System.EventHandler(this.StartRecord_Click);
            // 
            // StopRecord
            // 
            this.StopRecord.Enabled = false;
            this.StopRecord.Location = new System.Drawing.Point(179, 31);
            this.StopRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopRecord.Name = "StopRecord";
            this.StopRecord.Size = new System.Drawing.Size(122, 46);
            this.StopRecord.TabIndex = 2;
            this.StopRecord.Text = "Остановить запись";
            this.StopRecord.UseVisualStyleBackColor = true;
            this.StopRecord.Click += new System.EventHandler(this.StopRecord_Click);
            // 
            // Convert
            // 
            this.Convert.Location = new System.Drawing.Point(487, 32);
            this.Convert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(122, 46);
            this.Convert.TabIndex = 3;
            this.Convert.Text = "Конвертировать";
            this.Convert.UseVisualStyleBackColor = true;
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // StartGame
            // 
            this.StartGame.Enabled = false;
            this.StartGame.Location = new System.Drawing.Point(334, 32);
            this.StartGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(122, 46);
            this.StartGame.TabIndex = 4;
            this.StartGame.Text = "Запуск игры";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(10, 107);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1309, 503);
            this.panel1.TabIndex = 5;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1107, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Длина последовательности";
            // 
            // StopGame
            // 
            this.StopGame.Enabled = false;
            this.StopGame.Location = new System.Drawing.Point(636, 32);
            this.StopGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StopGame.Name = "StopGame";
            this.StopGame.Size = new System.Drawing.Size(116, 46);
            this.StopGame.TabIndex = 7;
            this.StopGame.Text = "Конец игры";
            this.StopGame.UseVisualStyleBackColor = true;
            this.StopGame.Click += new System.EventHandler(this.StopGame_Click);
            // 
            // KolKey
            // 
            this.KolKey.AutoSize = true;
            this.KolKey.Location = new System.Drawing.Point(867, 44);
            this.KolKey.Name = "KolKey";
            this.KolKey.Size = new System.Drawing.Size(150, 15);
            this.KolKey.TabIndex = 8;
            this.KolKey.Text = "Ключей сгенерировано: 0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1146, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Нужно ключей";
            // 
            // NujnoKey
            // 
            this.NujnoKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NujnoKey.Location = new System.Drawing.Point(1162, 72);
            this.NujnoKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NujnoKey.Name = "NujnoKey";
            this.NujnoKey.Size = new System.Drawing.Size(67, 23);
            this.NujnoKey.TabIndex = 10;
            this.NujnoKey.Text = "100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 619);
            this.Controls.Add(this.NujnoKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KolKey);
            this.Controls.Add(this.StopGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StopRecord);
            this.Controls.Add(this.Convert);
            this.Controls.Add(this.StartRecord);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button StartRecord;
        private System.Windows.Forms.Button StopRecord;
        private System.Windows.Forms.Button Convert;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StopGame;
        private System.Windows.Forms.Label KolKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NujnoKey;
    }
}

