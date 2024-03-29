﻿
namespace PersonalFolder {
    partial class ImportForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this.label1 = new System.Windows.Forms.Label();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.importInput = new System.Windows.Forms.TextBox();
            this.doneBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.minClassInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(545, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Данный радел позволяет выгрузить пользователей из различных систем ведения учётны" +
    "х записей.\r\n\r\nНа данный момент доступна только выгрузка из сервиса Дневник.ру";
            // 
            // codeBox
            // 
            this.codeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeBox.BackColor = System.Drawing.SystemColors.Window;
            this.codeBox.Font = new System.Drawing.Font("Consolas", 8F);
            this.codeBox.Location = new System.Drawing.Point(12, 150);
            this.codeBox.Multiline = true;
            this.codeBox.Name = "codeBox";
            this.codeBox.ReadOnly = true;
            this.codeBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codeBox.Size = new System.Drawing.Size(545, 179);
            this.codeBox.TabIndex = 1;
            this.codeBox.Text = resources.GetString("codeBox.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(499, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Шаг 1. Авторизуйтесь на сайте dnevnik.ru и перейдите в раздел \"Журналы\".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(548, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Шаг 2. Нажмите F12 и в открывшемнся окне выберете вкладку \"Console\" / \"Консоль\"";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(533, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Шаг 3. Скопируйте код ниже, вставьте в прошлое окно и нажмите клавишу [Enter]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(12, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(494, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Шаг 4. Дождитесь окончания обработки и вставьте результат в поле ниже";
            // 
            // importInput
            // 
            this.importInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importInput.Font = new System.Drawing.Font("Consolas", 8F);
            this.importInput.Location = new System.Drawing.Point(12, 360);
            this.importInput.Multiline = true;
            this.importInput.Name = "importInput";
            this.importInput.Size = new System.Drawing.Size(545, 178);
            this.importInput.TabIndex = 2;
            // 
            // doneBtn
            // 
            this.doneBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.doneBtn.Location = new System.Drawing.Point(482, 546);
            this.doneBtn.Name = "doneBtn";
            this.doneBtn.Size = new System.Drawing.Size(75, 23);
            this.doneBtn.TabIndex = 3;
            this.doneBtn.Text = "Готово";
            this.doneBtn.UseVisualStyleBackColor = true;
            this.doneBtn.Click += new System.EventHandler(this.Continue);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(401, 546);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.Cancel);
            // 
            // copyBtn
            // 
            this.copyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyBtn.Location = new System.Drawing.Point(443, 302);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(94, 23);
            this.copyBtn.TabIndex = 0;
            this.copyBtn.Text = "Скопировать";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.CopyCode);
            // 
            // minClassInput
            // 
            this.minClassInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minClassInput.Location = new System.Drawing.Point(102, 125);
            this.minClassInput.Name = "minClassInput";
            this.minClassInput.Size = new System.Drawing.Size(20, 21);
            this.minClassInput.TabIndex = 8;
            this.minClassInput.Text = "7";
            this.minClassInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minClassInput.TextChanged += new System.EventHandler(this.minClassInput_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Начать импорт с";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(123, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "класса";
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 581);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.minClassInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.doneBtn);
            this.Controls.Add(this.importInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(585, 620);
            this.MinimumSize = new System.Drawing.Size(585, 620);
            this.Name = "ImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Импорт пользователей";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox importInput;
        private System.Windows.Forms.Button doneBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.TextBox minClassInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}