﻿namespace VsmdWorkstation
{
    partial class VsmdSettingFrm
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridContainer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCidX = new System.Windows.Forms.TextBox();
            this.txtPosX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpeedX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbAutoUpdateX = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.ckbAutoUpdateZ = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSpeedZ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPosZ = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCidZ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.ckbAutoUpdateY = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSpeedY = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPosY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCidY = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gridContainer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.ckbAutoUpdateX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSpeedX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPosX);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCidX);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 178);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "X轴";
            // 
            // gridContainer
            // 
            this.gridContainer.Controls.Add(this.button1);
            this.gridContainer.Location = new System.Drawing.Point(12, 196);
            this.gridContainer.Name = "gridContainer";
            this.gridContainer.Size = new System.Drawing.Size(651, 259);
            this.gridContainer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cid：";
            // 
            // txtCidX
            // 
            this.txtCidX.Location = new System.Drawing.Point(66, 20);
            this.txtCidX.Name = "txtCidX";
            this.txtCidX.Size = new System.Drawing.Size(134, 21);
            this.txtCidX.TabIndex = 1;
            // 
            // txtPosX
            // 
            this.txtPosX.Location = new System.Drawing.Point(66, 47);
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.Size = new System.Drawing.Size(134, 21);
            this.txtPosX.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "位置：";
            // 
            // txtSpeedX
            // 
            this.txtSpeedX.Location = new System.Drawing.Point(66, 74);
            this.txtSpeedX.Name = "txtSpeedX";
            this.txtSpeedX.Size = new System.Drawing.Size(134, 21);
            this.txtSpeedX.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "速度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "自动更新：";
            // 
            // ckbAutoUpdateX
            // 
            this.ckbAutoUpdateX.AutoSize = true;
            this.ckbAutoUpdateX.Location = new System.Drawing.Point(66, 101);
            this.ckbAutoUpdateX.Name = "ckbAutoUpdateX";
            this.ckbAutoUpdateX.Size = new System.Drawing.Size(15, 14);
            this.ckbAutoUpdateX.TabIndex = 7;
            this.ckbAutoUpdateX.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(125, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.ckbAutoUpdateZ);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtSpeedZ);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtPosZ);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCidZ);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(450, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 178);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Z轴";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(125, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ckbAutoUpdateZ
            // 
            this.ckbAutoUpdateZ.AutoSize = true;
            this.ckbAutoUpdateZ.Location = new System.Drawing.Point(66, 101);
            this.ckbAutoUpdateZ.Name = "ckbAutoUpdateZ";
            this.ckbAutoUpdateZ.Size = new System.Drawing.Size(15, 14);
            this.ckbAutoUpdateZ.TabIndex = 7;
            this.ckbAutoUpdateZ.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "自动更新：";
            // 
            // txtSpeedZ
            // 
            this.txtSpeedZ.Location = new System.Drawing.Point(66, 74);
            this.txtSpeedZ.Name = "txtSpeedZ";
            this.txtSpeedZ.Size = new System.Drawing.Size(134, 21);
            this.txtSpeedZ.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "速度：";
            // 
            // txtPosZ
            // 
            this.txtPosZ.Location = new System.Drawing.Point(66, 47);
            this.txtPosZ.Name = "txtPosZ";
            this.txtPosZ.Size = new System.Drawing.Size(134, 21);
            this.txtPosZ.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "位置：";
            // 
            // txtCidZ
            // 
            this.txtCidZ.Location = new System.Drawing.Point(66, 20);
            this.txtCidZ.Name = "txtCidZ";
            this.txtCidZ.Size = new System.Drawing.Size(134, 21);
            this.txtCidZ.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cid：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.ckbAutoUpdateY);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtSpeedY);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtPosY);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtCidY);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(231, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 178);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Y轴";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(125, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "确定";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // ckbAutoUpdateY
            // 
            this.ckbAutoUpdateY.AutoSize = true;
            this.ckbAutoUpdateY.Location = new System.Drawing.Point(66, 101);
            this.ckbAutoUpdateY.Name = "ckbAutoUpdateY";
            this.ckbAutoUpdateY.Size = new System.Drawing.Size(15, 14);
            this.ckbAutoUpdateY.TabIndex = 7;
            this.ckbAutoUpdateY.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "自动更新：";
            // 
            // txtSpeedY
            // 
            this.txtSpeedY.Location = new System.Drawing.Point(66, 74);
            this.txtSpeedY.Name = "txtSpeedY";
            this.txtSpeedY.Size = new System.Drawing.Size(134, 21);
            this.txtSpeedY.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "速度：";
            // 
            // txtPosY
            // 
            this.txtPosY.Location = new System.Drawing.Point(66, 47);
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.Size = new System.Drawing.Size(134, 21);
            this.txtPosY.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "位置：";
            // 
            // txtCidY
            // 
            this.txtCidY.Location = new System.Drawing.Point(66, 20);
            this.txtCidY.Name = "txtCidY";
            this.txtCidY.Size = new System.Drawing.Size(134, 21);
            this.txtCidY.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "Cid：";
            // 
            // VsmdSettingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 466);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gridContainer);
            this.Controls.Add(this.groupBox1);
            this.Name = "VsmdSettingFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VsmdSettingFrm";
            this.Load += new System.EventHandler(this.VsmdSettingFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gridContainer.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel gridContainer;
        private System.Windows.Forms.TextBox txtSpeedX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPosX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCidX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox ckbAutoUpdateX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox ckbAutoUpdateZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSpeedZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPosZ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCidZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox ckbAutoUpdateY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSpeedY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPosY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCidY;
        private System.Windows.Forms.Label label12;
    }
}