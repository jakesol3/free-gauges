namespace FreeGaugesDemo
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
            this.circularGauge1 = new FreeGaugesDemo.CircularGauge();
            this.SuspendLayout();
            // 
            // circularGauge1
            // 
            this.circularGauge1.ArcColor = System.Drawing.Color.DimGray;
            this.circularGauge1.ArcStartAngle = 180;
            this.circularGauge1.ArcSweepAngle = 180;
            this.circularGauge1.ArcWidth = 40;
            this.circularGauge1.Increment = 5;
            this.circularGauge1.IncrementColor = System.Drawing.Color.WhiteSmoke;
            this.circularGauge1.IncrementWidth = 1;
            this.circularGauge1.Location = new System.Drawing.Point(200, 25);
            this.circularGauge1.MaxValue = 100;
            this.circularGauge1.MinValue = 0;
            this.circularGauge1.Name = "circularGauge1";
            this.circularGauge1.NeedleBaseColor = System.Drawing.Color.MediumAquamarine;
            this.circularGauge1.NeedleBaseVisible = true;
            this.circularGauge1.NeedleBaseWidth = 30;
            this.circularGauge1.NeedleColor = System.Drawing.Color.MediumAquamarine;
            this.circularGauge1.NeedleLength = 150;
            this.circularGauge1.NeedleOffset = -50;
            this.circularGauge1.NeedleWidth = 2;
            this.circularGauge1.NumberColor = System.Drawing.Color.DimGray;
            this.circularGauge1.NumberFont = new System.Drawing.Font("Segoe UI", 10F);
            this.circularGauge1.NumberOffset = 20;
            this.circularGauge1.Size = new System.Drawing.Size(400, 400);
            this.circularGauge1.TabIndex = 0;
            this.circularGauge1.Text = "circularGauge1";
            this.circularGauge1.Value = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.circularGauge1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CircularGauge circularGauge1;
    }
}

