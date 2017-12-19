namespace DGI01
{
    partial class parameters
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
            this.Win = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Win
            // 
            this.Win.AutoScroll = true;
            this.Win.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Win.Location = new System.Drawing.Point(12, 12);
            this.Win.Name = "Win";
            this.Win.Size = new System.Drawing.Size(420, 455);
            this.Win.TabIndex = 0;
            this.Win.Paint += new System.Windows.Forms.PaintEventHandler(this.Win_Paint);
            // 
            // parameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 491);
            this.Controls.Add(this.Win);
            this.Name = "parameters";
            this.Text = "parameters";
            this.Load += new System.EventHandler(this.parameters_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Win;
    }
}