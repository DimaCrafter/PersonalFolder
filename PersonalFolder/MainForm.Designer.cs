
namespace PersonalFolder {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupsSelect = new System.Windows.Forms.ListBox();
            this.usersSelect = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.systemIconButton1 = new PersonalFolder.SystemIconButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Группы:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(180, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пользователи:";
            // 
            // groupsSelect
            // 
            this.groupsSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupsSelect.FormattingEnabled = true;
            this.groupsSelect.IntegralHeight = false;
            this.groupsSelect.Location = new System.Drawing.Point(12, 68);
            this.groupsSelect.Name = "groupsSelect";
            this.groupsSelect.Size = new System.Drawing.Size(133, 306);
            this.groupsSelect.TabIndex = 4;
            this.groupsSelect.SelectedIndexChanged += new System.EventHandler(this.onGroupSelect);
            // 
            // usersSelect
            // 
            this.usersSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersSelect.FormattingEnabled = true;
            this.usersSelect.IntegralHeight = false;
            this.usersSelect.Location = new System.Drawing.Point(157, 69);
            this.usersSelect.Name = "usersSelect";
            this.usersSelect.Size = new System.Drawing.Size(196, 306);
            this.usersSelect.TabIndex = 5;
            this.usersSelect.DoubleClick += new System.EventHandler(this.OpenSelectedUser);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(341, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Используйте двойное нажатие левой кнопкой мыши на название пользователя, чтобы от" +
    "крыть его директорию.";
            // 
            // systemIconButton1
            // 
            this.systemIconButton1.BackColor = System.Drawing.SystemColors.Control;
            this.systemIconButton1.Icon = ((System.Drawing.Image)(resources.GetObject("systemIconButton1.Icon")));
            this.systemIconButton1.Location = new System.Drawing.Point(333, 45);
            this.systemIconButton1.Name = "systemIconButton1";
            this.systemIconButton1.Size = new System.Drawing.Size(20, 20);
            this.systemIconButton1.TabIndex = 7;
            this.systemIconButton1.Text = "systemIconButton1";
            this.systemIconButton1.Click += new System.EventHandler(this.OpenSettings);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PersonalFolder.Properties.Resources.user_directory;
            this.pictureBox2.Location = new System.Drawing.Point(158, 46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PersonalFolder.Properties.Resources.group;
            this.pictureBox1.Location = new System.Drawing.Point(13, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 391);
            this.Controls.Add(this.systemIconButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usersSelect);
            this.Controls.Add(this.groupsSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(385, 430);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(385, 430);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Личная папка";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox groupsSelect;
        private System.Windows.Forms.ListBox usersSelect;
        private System.Windows.Forms.Label label3;
        private SystemIconButton systemIconButton1;
    }
}