namespace KG1
{
    partial class MainForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.точечныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инверсияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.градацияСерогоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сепияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.яркостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cерыйМирToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матричныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размытиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размытиеПоГауссуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрСобеляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрЩарраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.резкостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шумToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расширениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сужениеErosiumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.замыканиеClosingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размыканиеOpeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструментToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topHatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.усреднениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.фильтрСобеляOXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрСобеляOYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(626, 398);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фильтрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.точечныеToolStripMenuItem,
            this.матричныеToolStripMenuItem,
            this.шумToolStripMenuItem,
            this.усреднениеToolStripMenuItem});
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // точечныеToolStripMenuItem
            // 
            this.точечныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.инверсияToolStripMenuItem,
            this.градацияСерогоToolStripMenuItem,
            this.сепияToolStripMenuItem,
            this.яркостьToolStripMenuItem,
            this.cерыйМирToolStripMenuItem});
            this.точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
            this.точечныеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.точечныеToolStripMenuItem.Text = "Точечные";
            // 
            // инверсияToolStripMenuItem
            // 
            this.инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
            this.инверсияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.инверсияToolStripMenuItem.Text = "Инверсия";
            this.инверсияToolStripMenuItem.Click += new System.EventHandler(this.инверсияToolStripMenuItem_Click);
            // 
            // градацияСерогоToolStripMenuItem
            // 
            this.градацияСерогоToolStripMenuItem.Name = "градацияСерогоToolStripMenuItem";
            this.градацияСерогоToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.градацияСерогоToolStripMenuItem.Text = "Градация серого";
            this.градацияСерогоToolStripMenuItem.Click += new System.EventHandler(this.градацияСерогоToolStripMenuItem_Click);
            // 
            // сепияToolStripMenuItem
            // 
            this.сепияToolStripMenuItem.Name = "сепияToolStripMenuItem";
            this.сепияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сепияToolStripMenuItem.Text = "Сепия";
            this.сепияToolStripMenuItem.Click += new System.EventHandler(this.сепияToolStripMenuItem_Click);
            // 
            // яркостьToolStripMenuItem
            // 
            this.яркостьToolStripMenuItem.Name = "яркостьToolStripMenuItem";
            this.яркостьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.яркостьToolStripMenuItem.Text = "Яркость";
            this.яркостьToolStripMenuItem.Click += new System.EventHandler(this.яркостьToolStripMenuItem_Click);
            // 
            // cерыйМирToolStripMenuItem
            // 
            this.cерыйМирToolStripMenuItem.Name = "cерыйМирToolStripMenuItem";
            this.cерыйМирToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cерыйМирToolStripMenuItem.Text = "\"Cерый Мир\"";
            this.cерыйМирToolStripMenuItem.Click += new System.EventHandler(this.cерыйМирToolStripMenuItem_Click);
            // 
            // матричныеToolStripMenuItem
            // 
            this.матричныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.размытиеToolStripMenuItem,
            this.размытиеПоГауссуToolStripMenuItem,
            this.фильтрСобеляOXToolStripMenuItem,
            this.фильтрСобеляOYToolStripMenuItem,
            this.фильтрСобеляToolStripMenuItem,
            this.резкостьToolStripMenuItem,
            this.фильтрЩарраToolStripMenuItem});
            this.матричныеToolStripMenuItem.Name = "матричныеToolStripMenuItem";
            this.матричныеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.матричныеToolStripMenuItem.Text = "Матричные";
            // 
            // размытиеToolStripMenuItem
            // 
            this.размытиеToolStripMenuItem.Name = "размытиеToolStripMenuItem";
            this.размытиеToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.размытиеToolStripMenuItem.Text = "Размытие";
            this.размытиеToolStripMenuItem.Click += new System.EventHandler(this.размытиеToolStripMenuItem_Click);
            // 
            // размытиеПоГауссуToolStripMenuItem
            // 
            this.размытиеПоГауссуToolStripMenuItem.Name = "размытиеПоГауссуToolStripMenuItem";
            this.размытиеПоГауссуToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.размытиеПоГауссуToolStripMenuItem.Text = "Размытие по Гауссу";
            this.размытиеПоГауссуToolStripMenuItem.Click += new System.EventHandler(this.размытиеПоГауссуToolStripMenuItem_Click);
            // 
            // фильтрСобеляToolStripMenuItem
            // 
            this.фильтрСобеляToolStripMenuItem.Name = "фильтрСобеляToolStripMenuItem";
            this.фильтрСобеляToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.фильтрСобеляToolStripMenuItem.Text = "Фильтр Собеля XY";
            this.фильтрСобеляToolStripMenuItem.Click += new System.EventHandler(this.фильтрСобеляToolStripMenuItem_Click);
            // 
            // фильтрЩарраToolStripMenuItem
            // 
            this.фильтрЩарраToolStripMenuItem.Name = "фильтрЩарраToolStripMenuItem";
            this.фильтрЩарраToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.фильтрЩарраToolStripMenuItem.Text = "Фильтр Щарра";
            this.фильтрЩарраToolStripMenuItem.Click += new System.EventHandler(this.фильтрЩарраToolStripMenuItem_Click);
            // 
            // резкостьToolStripMenuItem
            // 
            this.резкостьToolStripMenuItem.Name = "резкостьToolStripMenuItem";
            this.резкостьToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.резкостьToolStripMenuItem.Text = "Резкость";
            this.резкостьToolStripMenuItem.Click += new System.EventHandler(this.резкостьToolStripMenuItem_Click);
            // 
            // шумToolStripMenuItem
            // 
            this.шумToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.расширениеToolStripMenuItem,
            this.сужениеErosiumToolStripMenuItem,
            this.замыканиеClosingToolStripMenuItem,
            this.размыканиеOpeningToolStripMenuItem,
            this.инструментToolStripMenuItem,
            this.topHatToolStripMenuItem1});
            this.шумToolStripMenuItem.Name = "шумToolStripMenuItem";
            this.шумToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.шумToolStripMenuItem.Text = "Морфология";
            // 
            // расширениеToolStripMenuItem
            // 
            this.расширениеToolStripMenuItem.Name = "расширениеToolStripMenuItem";
            this.расширениеToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.расширениеToolStripMenuItem.Text = "Расширение(Dilation)";
            this.расширениеToolStripMenuItem.Click += new System.EventHandler(this.расширениеToolStripMenuItem_Click);
            // 
            // сужениеErosiumToolStripMenuItem
            // 
            this.сужениеErosiumToolStripMenuItem.Name = "сужениеErosiumToolStripMenuItem";
            this.сужениеErosiumToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.сужениеErosiumToolStripMenuItem.Text = "Сужение(Erosion)";
            this.сужениеErosiumToolStripMenuItem.Click += new System.EventHandler(this.сужениеErosiumToolStripMenuItem_Click);
            // 
            // замыканиеClosingToolStripMenuItem
            // 
            this.замыканиеClosingToolStripMenuItem.Name = "замыканиеClosingToolStripMenuItem";
            this.замыканиеClosingToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.замыканиеClosingToolStripMenuItem.Text = "Замыкание(Closing)";
            this.замыканиеClosingToolStripMenuItem.Click += new System.EventHandler(this.замыканиеClosingToolStripMenuItem_Click);
            // 
            // размыканиеOpeningToolStripMenuItem
            // 
            this.размыканиеOpeningToolStripMenuItem.Name = "размыканиеOpeningToolStripMenuItem";
            this.размыканиеOpeningToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.размыканиеOpeningToolStripMenuItem.Text = "Размыкание(Opening)";
            this.размыканиеOpeningToolStripMenuItem.Click += new System.EventHandler(this.размыканиеOpeningToolStripMenuItem_Click);
            // 
            // инструментToolStripMenuItem
            // 
            this.инструментToolStripMenuItem.Name = "инструментToolStripMenuItem";
            this.инструментToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.инструментToolStripMenuItem.Text = "Инструмент";
            this.инструментToolStripMenuItem.Click += new System.EventHandler(this.инструментToolStripMenuItem_Click);
            // 
            // topHatToolStripMenuItem1
            // 
            this.topHatToolStripMenuItem1.Name = "topHatToolStripMenuItem1";
            this.topHatToolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.topHatToolStripMenuItem1.Text = "TopHat";
            this.topHatToolStripMenuItem1.Click += new System.EventHandler(this.topHatToolStripMenuItem1_Click);
            // 
            // усреднениеToolStripMenuItem
            // 
            this.усреднениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boxFilterToolStripMenuItem});
            this.усреднениеToolStripMenuItem.Name = "усреднениеToolStripMenuItem";
            this.усреднениеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.усреднениеToolStripMenuItem.Text = "Усреднение";
            // 
            // boxFilterToolStripMenuItem
            // 
            this.boxFilterToolStripMenuItem.Name = "boxFilterToolStripMenuItem";
            this.boxFilterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.boxFilterToolStripMenuItem.Text = "Box Filter";
            this.boxFilterToolStripMenuItem.Click += new System.EventHandler(this.boxFilterToolStripMenuItem_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(847, 337);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(563, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 431);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(545, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // фильтрСобеляOXToolStripMenuItem
            // 
            this.фильтрСобеляOXToolStripMenuItem.Name = "фильтрСобеляOXToolStripMenuItem";
            this.фильтрСобеляOXToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.фильтрСобеляOXToolStripMenuItem.Text = "Фильтр Собеля OX";
            this.фильтрСобеляOXToolStripMenuItem.Click += new System.EventHandler(this.фильтрСобеляOXToolStripMenuItem_Click);
            // 
            // фильтрСобеляOYToolStripMenuItem
            // 
            this.фильтрСобеляOYToolStripMenuItem.Name = "фильтрСобеляOYToolStripMenuItem";
            this.фильтрСобеляOYToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.фильтрСобеляOYToolStripMenuItem.Text = "Фильтр Собеля OY";
            this.фильтрСобеляOYToolStripMenuItem.Click += new System.EventHandler(this.фильтрСобеляOYToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 466);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem точечныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem матричныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инверсияToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripMenuItem размытиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размытиеПоГауссуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem градацияСерогоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сепияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem яркостьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрСобеляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрЩарраToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem резкостьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cерыйМирToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шумToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расширениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сужениеErosiumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem усреднениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boxFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem замыканиеClosingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размыканиеOpeningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инструментToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topHatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem фильтрСобеляOXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрСобеляOYToolStripMenuItem;
    }
}

