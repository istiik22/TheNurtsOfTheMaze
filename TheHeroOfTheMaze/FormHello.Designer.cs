namespace TheHeroOfTheMaze
{
    partial class FormHello
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
            this.buttonPlayGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAuthor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPlayGame
            // 
            this.buttonPlayGame.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPlayGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlayGame.Location = new System.Drawing.Point(861, 263);
            this.buttonPlayGame.Name = "buttonPlayGame";
            this.buttonPlayGame.Size = new System.Drawing.Size(183, 66);
            this.buttonPlayGame.TabIndex = 0;
            this.buttonPlayGame.Text = "Играть";
            this.buttonPlayGame.UseVisualStyleBackColor = false;
            this.buttonPlayGame.Click += new System.EventHandler(this.buttonPlayGame_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(677, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(521, 72);
            this.label1.TabIndex = 1;
            this.label1.Text = "Лабиринт Нартов";
            // 
            // buttonAuthor
            // 
            this.buttonAuthor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAuthor.Location = new System.Drawing.Point(1106, 767);
            this.buttonAuthor.Name = "buttonAuthor";
            this.buttonAuthor.Size = new System.Drawing.Size(103, 50);
            this.buttonAuthor.TabIndex = 2;
            this.buttonAuthor.Text = "Об игре";
            this.buttonAuthor.UseVisualStyleBackColor = false;
            this.buttonAuthor.Click += new System.EventHandler(this.buttonAuthor_Click);
            // 
            // FormHello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheHeroOfTheMaze.Properties.Resources.hello;
            this.ClientSize = new System.Drawing.Size(1256, 875);
            this.Controls.Add(this.buttonAuthor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPlayGame);
            this.Name = "FormHello";
            this.Text = "FormHello";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlayGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAuthor;
    }
}