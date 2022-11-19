using System.Drawing;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace OOPGames.Classes.GruppeJ
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBlack = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonYellow = new System.Windows.Forms.Button();
            this.buttonLime = new System.Windows.Forms.Button();
            this.buttonFuchsia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBlack
            // 
            this.buttonBlack.BackColor = Color.Black; //Schwarz
            this.buttonBlack.Location = new System.Drawing.Point(25, 75);
            this.buttonBlack.Name = "buttonBlack";
            this.buttonBlack.Size = new System.Drawing.Size(120, 50);
            this.buttonBlack.TabIndex = 0;
            this.buttonBlack.UseVisualStyleBackColor = false;
            this.buttonBlack.Click += new System.EventHandler(this.buttonBlack_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(150, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 60);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "";
            this.textBox1.Text = "Player1,\r\nwähle deine Farbe!";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonRed
            // 
            this.buttonRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonRed.Location = new System.Drawing.Point(175, 75);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(120, 50);
            this.buttonRed.TabIndex = 2;
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonRed_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.Color.Blue;
            this.buttonBlue.Location = new System.Drawing.Point(325, 75);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(120, 50);
            this.buttonBlue.TabIndex = 3;
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Click += new System.EventHandler(this.buttonBlue_Click);
            // 
            // buttonYellow
            // 
            this.buttonYellow.BackColor = System.Drawing.Color.Yellow;
            this.buttonYellow.Location = new System.Drawing.Point(25, 150);
            this.buttonYellow.Name = "buttonYellow";
            this.buttonYellow.Size = new System.Drawing.Size(120, 50);
            this.buttonYellow.TabIndex = 4;
            this.buttonYellow.UseVisualStyleBackColor = false;
            this.buttonYellow.Click += new System.EventHandler(this.buttonYellow_Click);
            // 
            // buttonLime
            // 
            this.buttonLime.BackColor = System.Drawing.Color.Lime;
            this.buttonLime.Location = new System.Drawing.Point(175, 150);
            this.buttonLime.Name = "buttonLime";
            this.buttonLime.Size = new System.Drawing.Size(120, 50);
            this.buttonLime.TabIndex = 5;
            this.buttonLime.UseVisualStyleBackColor = false;
            this.buttonLime.Click += new System.EventHandler(this.buttonLime_Click);
            // 
            // buttonFuchsia
            // 
            this.buttonFuchsia.BackColor = System.Drawing.Color.Fuchsia;
            this.buttonFuchsia.Location = new System.Drawing.Point(325, 150);
            this.buttonFuchsia.Name = "buttonFuchsia";
            this.buttonFuchsia.Size = new System.Drawing.Size(120, 50);
            this.buttonFuchsia.TabIndex = 6;
            this.buttonFuchsia.UseVisualStyleBackColor = false;
            this.buttonFuchsia.Click += new System.EventHandler(this.buttonFuchsia_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.buttonFuchsia);
            this.Controls.Add(this.buttonLime);
            this.Controls.Add(this.buttonYellow);
            this.Controls.Add(this.buttonBlue);
            this.Controls.Add(this.buttonRed);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonBlack);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farbauswahl";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBlack;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.Button buttonYellow;
        private System.Windows.Forms.Button buttonLime;
        private System.Windows.Forms.Button buttonFuchsia;
    }
}