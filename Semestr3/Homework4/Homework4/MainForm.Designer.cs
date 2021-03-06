﻿namespace Homework4
{
    partial class MainForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.choosingLineComboBox = new System.Windows.Forms.ComboBox();
            this.secondEndButton = new System.Windows.Forms.RadioButton();
            this.firstEndButton = new System.Windows.Forms.RadioButton();
            this.changingButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.choosingLineComboBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.secondEndButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.firstEndButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.changingButton, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.RedoButton, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.undoButton, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(593, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(103, 290);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // choosingLineComboBox
            // 
            this.choosingLineComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.choosingLineComboBox.FormattingEnabled = true;
            this.choosingLineComboBox.Location = new System.Drawing.Point(3, 3);
            this.choosingLineComboBox.Name = "choosingLineComboBox";
            this.choosingLineComboBox.Size = new System.Drawing.Size(97, 21);
            this.choosingLineComboBox.TabIndex = 1;
            this.choosingLineComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // secondEndButton
            // 
            this.secondEndButton.AutoSize = true;
            this.secondEndButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondEndButton.Enabled = false;
            this.secondEndButton.Location = new System.Drawing.Point(3, 92);
            this.secondEndButton.Name = "secondEndButton";
            this.secondEndButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.secondEndButton.Size = new System.Drawing.Size(97, 24);
            this.secondEndButton.TabIndex = 3;
            this.secondEndButton.Text = "2";
            this.secondEndButton.UseVisualStyleBackColor = true;
            // 
            // firstEndButton
            // 
            this.firstEndButton.AutoSize = true;
            this.firstEndButton.Checked = true;
            this.firstEndButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstEndButton.Enabled = false;
            this.firstEndButton.Location = new System.Drawing.Point(3, 59);
            this.firstEndButton.Name = "firstEndButton";
            this.firstEndButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.firstEndButton.Size = new System.Drawing.Size(97, 27);
            this.firstEndButton.TabIndex = 2;
            this.firstEndButton.TabStop = true;
            this.firstEndButton.Text = "1";
            this.firstEndButton.UseVisualStyleBackColor = true;
            // 
            // changingButton
            // 
            this.changingButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changingButton.Enabled = false;
            this.changingButton.Location = new System.Drawing.Point(3, 122);
            this.changingButton.Name = "changingButton";
            this.changingButton.Size = new System.Drawing.Size(97, 55);
            this.changingButton.TabIndex = 5;
            this.changingButton.Text = "Поменять";
            this.changingButton.UseVisualStyleBackColor = true;
            this.changingButton.Click += new System.EventHandler(this.ChangingButtonClick);
            // 
            // RedoButton
            // 
            this.RedoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RedoButton.Enabled = false;
            this.RedoButton.Location = new System.Drawing.Point(3, 183);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(97, 47);
            this.RedoButton.TabIndex = 7;
            this.RedoButton.Text = "Вернуть";
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.Click += new System.EventHandler(this.RedoButtonClick);
            // 
            // undoButton
            // 
            this.undoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.undoButton.Enabled = false;
            this.undoButton.Location = new System.Drawing.Point(3, 236);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(97, 51);
            this.undoButton.TabIndex = 6;
            this.undoButton.Text = "Отменить";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.UndoButtonClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.42503F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.57496F));
            this.tableLayoutPanel1.Controls.Add(this.messageLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.canvas, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.4557F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(699, 316);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(3, 296);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(16, 13);
            this.messageLabel.TabIndex = 9;
            this.messageLabel.Text = "   ";
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(3, 3);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(584, 290);
            this.canvas.TabIndex = 8;
            this.canvas.TabStop = false;
            this.canvas.Click += new System.EventHandler(this.CanvasClick);
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 316);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(715, 355);
            this.Name = "MainForm";
            this.Text = "Редактор";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button RedoButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.ComboBox choosingLineComboBox;
        private System.Windows.Forms.RadioButton secondEndButton;
        private System.Windows.Forms.RadioButton firstEndButton;
        private System.Windows.Forms.Button changingButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label messageLabel;
    }
}

