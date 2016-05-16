namespace Clock
{
    partial class Clock
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
            this.components = new System.ComponentModel.Container();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.colon = new System.Windows.Forms.Label();
            this.minutes = new System.Windows.Forms.Label();
            this.hours = new System.Windows.Forms.Label();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 3;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainLayout.Controls.Add(this.colon, 1, 0);
            this.mainLayout.Controls.Add(this.minutes, 2, 0);
            this.mainLayout.Controls.Add(this.hours, 0, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(152, 49);
            this.mainLayout.TabIndex = 0;
            // 
            // colon
            // 
            this.colon.AutoSize = true;
            this.colon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colon.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colon.Location = new System.Drawing.Point(53, 0);
            this.colon.Name = "colon";
            this.colon.Size = new System.Drawing.Size(44, 49);
            this.colon.TabIndex = 1;
            this.colon.Text = ":";
            this.colon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minutes
            // 
            this.minutes.AutoSize = true;
            this.minutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minutes.Location = new System.Drawing.Point(103, 0);
            this.minutes.Name = "minutes";
            this.minutes.Size = new System.Drawing.Size(46, 49);
            this.minutes.TabIndex = 2;
            this.minutes.Text = "10";
            this.minutes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hours
            // 
            this.hours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hours.Location = new System.Drawing.Point(3, 0);
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(44, 49);
            this.hours.TabIndex = 3;
            this.hours.Text = "10";
            this.hours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clockTimer
            // 
            this.clockTimer.Enabled = true;
            this.clockTimer.Interval = 750;
            this.clockTimer.Tick += new System.EventHandler(this.OnClockTimerTick);
            // 
            // Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 49);
            this.Controls.Add(this.mainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(168, 88);
            this.Name = "Clock";
            this.ShowIcon = false;
            this.Text = "Clock";
            this.Resize += new System.EventHandler(this.ClockResize);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Label colon;
        private System.Windows.Forms.Label minutes;
        private System.Windows.Forms.Label hours;
        private System.Windows.Forms.Timer clockTimer;
    }
}

