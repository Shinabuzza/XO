
namespace WindowsFormsApp3
{
    partial class game5x5
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
            this.cbVersusPC = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbVersusPC
            // 
            this.cbVersusPC.AutoSize = true;
            this.cbVersusPC.Location = new System.Drawing.Point(553, 42);
            this.cbVersusPC.Name = "cbVersusPC";
            this.cbVersusPC.Size = new System.Drawing.Size(53, 17);
            this.cbVersusPC.TabIndex = 0;
            this.cbVersusPC.Text = "VS AI";
            this.cbVersusPC.UseVisualStyleBackColor = true;
            this.cbVersusPC.Visible = false;
            // 
            // game5x5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 599);
            this.Controls.Add(this.cbVersusPC);
            this.Name = "game5x5";
            this.Text = "5x5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbVersusPC;
    }
}