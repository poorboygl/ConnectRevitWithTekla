namespace myFirstPlugin
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
            this.wall_count = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wall_count
            // 
            this.wall_count.Location = new System.Drawing.Point(64, 38);
            this.wall_count.Name = "wall_count";
            this.wall_count.Size = new System.Drawing.Size(170, 81);
            this.wall_count.TabIndex = 0;
            this.wall_count.Text = "Create Foundation Tekla";
            this.wall_count.UseVisualStyleBackColor = true;
            this.wall_count.Click += new System.EventHandler(this.wall_count_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 166);
            this.Controls.Add(this.wall_count);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button wall_count;
    }
}