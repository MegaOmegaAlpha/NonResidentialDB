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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auctionType,
            this.auctionPlace,
            this.auctionOrganizer,
            this.building});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // auctionType
            // 
            this.auctionType.Name = "auctionType";
            this.auctionType.Size = new System.Drawing.Size(200, 22);
            this.auctionType.Text = "Тип аукциона";
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
            // 
            // building
            // 
            this.building.Name = "building";
            this.building.Size = new System.Drawing.Size(200, 22);
            this.building.Text = "Здание";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

