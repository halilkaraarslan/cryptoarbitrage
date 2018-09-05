namespace BinanceArbitrage
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
            this.components = new System.ComponentModel.Container();
            this.txtProfitables = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLastAnalyze = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtProfitables
            // 
            this.txtProfitables.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtProfitables.Location = new System.Drawing.Point(0, 13);
            this.txtProfitables.Multiline = true;
            this.txtProfitables.Name = "txtProfitables";
            this.txtProfitables.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProfitables.Size = new System.Drawing.Size(719, 133);
            this.txtProfitables.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Profitable Arbitrages";
            // 
            // txtLastAnalyze
            // 
            this.txtLastAnalyze.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLastAnalyze.Location = new System.Drawing.Point(0, 159);
            this.txtLastAnalyze.Multiline = true;
            this.txtLastAnalyze.Name = "txtLastAnalyze";
            this.txtLastAnalyze.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLastAnalyze.Size = new System.Drawing.Size(719, 105);
            this.txtLastAnalyze.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Analyze";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 359);
            this.Controls.Add(this.txtLastAnalyze);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProfitables);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Binance Arbitrage";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProfitables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLastAnalyze;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

