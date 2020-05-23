namespace lab12zad1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.авToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выфвToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ВыходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.авToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоСловToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повторяемостьБуквToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.авToolStripMenuItem,
            this.авToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // авToolStripMenuItem
            // 
            this.авToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выфвToolStripMenuItem,
            this.ВыходToolStripMenuItem});
            this.авToolStripMenuItem.Name = "авToolStripMenuItem";
            this.авToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.авToolStripMenuItem.Text = "Файл";
            this.авToolStripMenuItem.Click += new System.EventHandler(this.авToolStripMenuItem_Click);
            // 
            // выфвToolStripMenuItem
            // 
            this.выфвToolStripMenuItem.Name = "выфвToolStripMenuItem";
            this.выфвToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выфвToolStripMenuItem.Text = "Загрузить текст";
            this.выфвToolStripMenuItem.Click += new System.EventHandler(this.выфвToolStripMenuItem_Click);
            // 
            // ВыходToolStripMenuItem
            // 
            this.ВыходToolStripMenuItem.Name = "ВыходToolStripMenuItem";
            this.ВыходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ВыходToolStripMenuItem.Text = "Выход";
            this.ВыходToolStripMenuItem.Click += new System.EventHandler(this.папToolStripMenuItem_Click);
            // 
            // авToolStripMenuItem1
            // 
            this.авToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количествоСловToolStripMenuItem,
            this.повторяемостьБуквToolStripMenuItem});
            this.авToolStripMenuItem1.Name = "авToolStripMenuItem1";
            this.авToolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.авToolStripMenuItem1.Text = "Анализ";
            // 
            // количествоСловToolStripMenuItem
            // 
            this.количествоСловToolStripMenuItem.Name = "количествоСловToolStripMenuItem";
            this.количествоСловToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.количествоСловToolStripMenuItem.Text = "Количество слов";
            this.количествоСловToolStripMenuItem.Click += new System.EventHandler(this.количествоСловToolStripMenuItem_Click);
            // 
            // повторяемостьБуквToolStripMenuItem
            // 
            this.повторяемостьБуквToolStripMenuItem.Name = "повторяемостьБуквToolStripMenuItem";
            this.повторяемостьБуквToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.повторяемостьБуквToolStripMenuItem.Text = "Повторяемость букв";
            this.повторяемостьБуквToolStripMenuItem.Click += new System.EventHandler(this.повторяемостьБуквToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите букву для \"Повторяемость букв\"";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 99);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ЯковлевАС_8BT_17в";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem авToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem авToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выфвToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ВыходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem количествоСловToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повторяемостьБуквToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

