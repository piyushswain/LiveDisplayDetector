namespace LiveDeviceDector2
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
            this.clearListBoxButton = new System.Windows.Forms.Button();
            this.messageListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // clearListBoxButton
            // 
            this.clearListBoxButton.Location = new System.Drawing.Point(97, 45);
            this.clearListBoxButton.Name = "clearListBoxButton";
            this.clearListBoxButton.Size = new System.Drawing.Size(75, 23);
            this.clearListBoxButton.TabIndex = 0;
            this.clearListBoxButton.Text = "Clear";
            this.clearListBoxButton.UseVisualStyleBackColor = true;
            this.clearListBoxButton.Click += new System.EventHandler(this.clearListBoxButton_Click_1);
            // 
            // messageListBox
            // 
            this.messageListBox.FormattingEnabled = true;
            this.messageListBox.HorizontalScrollbar = true;
            this.messageListBox.Location = new System.Drawing.Point(97, 140);
            this.messageListBox.Name = "messageListBox";
            this.messageListBox.Size = new System.Drawing.Size(622, 238);
            this.messageListBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.messageListBox);
            this.Controls.Add(this.clearListBoxButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clearListBoxButton;
        private System.Windows.Forms.ListBox messageListBox;
    }
}

