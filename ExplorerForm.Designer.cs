
namespace PersonalFolder {
    partial class ExplorerForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent () {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerForm));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backBtn = new PersonalFolder.SystemIconButton();
            this.templatesBtn = new PersonalFolder.SystemIconButton();
            this.nextBtn = new PersonalFolder.SystemIconButton();
            this.pathInput = new System.Windows.Forms.ComboBox();
            this.systemIconButton6 = new PersonalFolder.SystemIconButton();
            this.systemIconButton5 = new PersonalFolder.SystemIconButton();
            this.systemIconButton3 = new PersonalFolder.SystemIconButton();
            this.systemIconButton1 = new PersonalFolder.SystemIconButton();
            this.templatesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 30);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(800, 420);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Controls.Add(this.templatesBtn);
            this.panel1.Controls.Add(this.nextBtn);
            this.panel1.Controls.Add(this.pathInput);
            this.panel1.Controls.Add(this.systemIconButton6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 30);
            this.panel1.TabIndex = 4;
            // 
            // backBtn
            // 
            this.backBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.backBtn.BackColor = System.Drawing.Color.White;
            this.backBtn.Icon = ((System.Drawing.Image)(resources.GetObject("backBtn.Icon")));
            this.backBtn.Location = new System.Drawing.Point(5, 5);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(20, 20);
            this.backBtn.TabIndex = 14;
            this.backBtn.Text = "Назад";
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // templatesBtn
            // 
            this.templatesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.templatesBtn.BackColor = System.Drawing.Color.White;
            this.templatesBtn.Icon = ((System.Drawing.Image)(resources.GetObject("templatesBtn.Icon")));
            this.templatesBtn.Location = new System.Drawing.Point(750, 5);
            this.templatesBtn.Name = "templatesBtn";
            this.templatesBtn.Size = new System.Drawing.Size(20, 20);
            this.templatesBtn.TabIndex = 11;
            this.templatesBtn.Text = "Заготовки";
            this.templatesBtn.Click += new System.EventHandler(this.systemIconButton7_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nextBtn.BackColor = System.Drawing.Color.White;
            this.nextBtn.Icon = ((System.Drawing.Image)(resources.GetObject("nextBtn.Icon")));
            this.nextBtn.Location = new System.Drawing.Point(27, 5);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(20, 20);
            this.nextBtn.TabIndex = 13;
            this.nextBtn.Text = "Вперёд";
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // pathInput
            // 
            this.pathInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pathInput.BackColor = System.Drawing.SystemColors.Menu;
            this.pathInput.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pathInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pathInput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathInput.FormattingEnabled = true;
            this.pathInput.Location = new System.Drawing.Point(49, 4);
            this.pathInput.Name = "pathInput";
            this.pathInput.Size = new System.Drawing.Size(696, 22);
            this.pathInput.TabIndex = 12;
            this.pathInput.Text = "\\";
            this.pathInput.SelectedIndexChanged += new System.EventHandler(this.pathInput_SelectedIndexChanged);
            this.pathInput.SelectionChangeCommitted += new System.EventHandler(this.pathInput_SelectionChangeCommitted);
            this.pathInput.TextUpdate += new System.EventHandler(this.pathInput_TextUpdate);
            this.pathInput.Click += new System.EventHandler(this.pathInput_Click);
            this.pathInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pathInput_KeyPress);
            // 
            // systemIconButton6
            // 
            this.systemIconButton6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.systemIconButton6.BackColor = System.Drawing.Color.White;
            this.systemIconButton6.Icon = ((System.Drawing.Image)(resources.GetObject("systemIconButton6.Icon")));
            this.systemIconButton6.Location = new System.Drawing.Point(776, 5);
            this.systemIconButton6.Name = "systemIconButton6";
            this.systemIconButton6.Size = new System.Drawing.Size(20, 20);
            this.systemIconButton6.TabIndex = 11;
            this.systemIconButton6.Text = "Перейти";
            this.systemIconButton6.Click += new System.EventHandler(this.systemIconButton6_Click);
            // 
            // systemIconButton5
            // 
            this.systemIconButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.systemIconButton5.BackColor = System.Drawing.Color.White;
            this.systemIconButton5.Icon = ((System.Drawing.Image)(resources.GetObject("systemIconButton5.Icon")));
            this.systemIconButton5.Location = new System.Drawing.Point(725, 428);
            this.systemIconButton5.Name = "systemIconButton5";
            this.systemIconButton5.Size = new System.Drawing.Size(20, 20);
            this.systemIconButton5.TabIndex = 10;
            this.systemIconButton5.Text = "Показывать таблицей";
            this.systemIconButton5.Click += new System.EventHandler(this.systemIconButton5_Click);
            // 
            // systemIconButton3
            // 
            this.systemIconButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.systemIconButton3.BackColor = System.Drawing.Color.White;
            this.systemIconButton3.Icon = ((System.Drawing.Image)(resources.GetObject("systemIconButton3.Icon")));
            this.systemIconButton3.Location = new System.Drawing.Point(751, 428);
            this.systemIconButton3.Name = "systemIconButton3";
            this.systemIconButton3.Size = new System.Drawing.Size(20, 20);
            this.systemIconButton3.TabIndex = 8;
            this.systemIconButton3.Text = "Показывать колонками";
            this.systemIconButton3.Click += new System.EventHandler(this.systemIconButton3_Click);
            // 
            // systemIconButton1
            // 
            this.systemIconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.systemIconButton1.BackColor = System.Drawing.Color.White;
            this.systemIconButton1.Icon = ((System.Drawing.Image)(resources.GetObject("systemIconButton1.Icon")));
            this.systemIconButton1.Location = new System.Drawing.Point(777, 428);
            this.systemIconButton1.Name = "systemIconButton1";
            this.systemIconButton1.Size = new System.Drawing.Size(20, 20);
            this.systemIconButton1.TabIndex = 6;
            this.systemIconButton1.Text = "Показывать списком";
            this.systemIconButton1.Click += new System.EventHandler(this.systemIconButton1_Click);
            // 
            // templatesMenu
            // 
            this.templatesMenu.Name = "templatesMenu";
            this.templatesMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.templatesMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // ExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.systemIconButton5);
            this.Controls.Add(this.systemIconButton3);
            this.Controls.Add(this.systemIconButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "ExplorerForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private SystemIconButton systemIconButton1;
        private SystemIconButton systemIconButton3;
        private SystemIconButton systemIconButton5;
        private SystemIconButton systemIconButton6;
        private System.Windows.Forms.ComboBox pathInput;
        private SystemIconButton backBtn;
        private SystemIconButton nextBtn;
        private SystemIconButton templatesBtn;
        private System.Windows.Forms.ContextMenuStrip templatesMenu;
    }
}

