﻿namespace MediaBazaarSystem
{
    partial class InformationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBoxInformation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBoxInformation
            // 
            this.txtBoxInformation.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtBoxInformation.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxInformation.Location = new System.Drawing.Point(13, 13);
            this.txtBoxInformation.Multiline = true;
            this.txtBoxInformation.Name = "txtBoxInformation";
            this.txtBoxInformation.ReadOnly = true;
            this.txtBoxInformation.Size = new System.Drawing.Size(509, 260);
            this.txtBoxInformation.TabIndex = 0;
            // 
            // InformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 285);
            this.Controls.Add(this.txtBoxInformation);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "InformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System\'s Information ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxInformation;
    }
}