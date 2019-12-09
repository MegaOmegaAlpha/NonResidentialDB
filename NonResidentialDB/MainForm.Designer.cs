namespace NonResidentialDB
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auctionType = new System.Windows.Forms.ToolStripMenuItem();
            this.auctionPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.auctionOrganizer = new System.Windows.Forms.ToolStripMenuItem();
            this.building = new System.Windows.Forms.ToolStripMenuItem();
            this.размерОтчисленийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.param_exec = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.buyerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1023, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.menuToolStripMenuItem.Text = "Меню";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auctionType,
            this.auctionPlace,
            this.auctionOrganizer,
            this.building,
            this.размерОтчисленийToolStripMenuItem,
            this.buyerToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // auctionType
            // 
            this.auctionType.Name = "auctionType";
            this.auctionType.Size = new System.Drawing.Size(200, 22);
            this.auctionType.Text = "Тип аукциона";
            this.auctionType.Click += new System.EventHandler(this.auctionType_Click);
            // 
            // auctionPlace
            // 
            this.auctionPlace.Name = "auctionPlace";
            this.auctionPlace.Size = new System.Drawing.Size(200, 22);
            this.auctionPlace.Text = "Место аукциона";
            this.auctionPlace.Click += new System.EventHandler(this.auctionPlace_Click);
            // 
            // auctionOrganizer
            // 
            this.auctionOrganizer.Name = "auctionOrganizer";
            this.auctionOrganizer.Size = new System.Drawing.Size(200, 22);
            this.auctionOrganizer.Text = "Организатор аукциона";
            this.auctionOrganizer.Click += new System.EventHandler(this.auctionOrganizer_Click);
            // 
            // building
            // 
            this.building.Name = "building";
            this.building.Size = new System.Drawing.Size(200, 22);
            this.building.Text = "Здание";
            this.building.Click += new System.EventHandler(this.building_Click);
            // 
            // размерОтчисленийToolStripMenuItem
            // 
            this.размерОтчисленийToolStripMenuItem.Name = "размерОтчисленийToolStripMenuItem";
            this.размерОтчисленийToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.размерОтчисленийToolStripMenuItem.Text = "Размер отчислений";
            this.размерОтчисленийToolStripMenuItem.Click += new System.EventHandler(this.размерОтчисленийToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(844, 411);
            this.dataGridView.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(872, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Минимальная начальная \r\nстоимость";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(875, 155);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 4;
            // 
            // param_exec
            // 
            this.param_exec.Location = new System.Drawing.Point(896, 181);
            this.param_exec.Name = "param_exec";
            this.param_exec.Size = new System.Drawing.Size(75, 23);
            this.param_exec.TabIndex = 5;
            this.param_exec.Text = "Показать";
            this.param_exec.UseVisualStyleBackColor = true;
            this.param_exec.Click += new System.EventHandler(this.param_exec_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(896, 210);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Отменить";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // buyerToolStripMenuItem
            // 
            this.buyerToolStripMenuItem.Name = "buyerToolStripMenuItem";
            this.buyerToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.buyerToolStripMenuItem.Text = "Покупатель";
            this.buyerToolStripMenuItem.Click += new System.EventHandler(this.buyerToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 475);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.param_exec);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auctionType;
        private System.Windows.Forms.ToolStripMenuItem auctionPlace;
        private System.Windows.Forms.ToolStripMenuItem auctionOrganizer;
        private System.Windows.Forms.ToolStripMenuItem building;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem размерОтчисленийToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button param_exec;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ToolStripMenuItem buyerToolStripMenuItem;
    }
}

