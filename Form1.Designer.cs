namespace compass_bundle_ui
{
    partial class main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

       

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.dirGrid = new System.Windows.Forms.DataGridView();
            this.DirPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirAction = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.delDir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ss = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtCLI = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dirGrid)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(465, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createToolStripMenuItem.Text = "&Create/Select";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.defaultToolStripMenuItem.Tag = "default";
            this.defaultToolStripMenuItem.Text = "&Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitWindowHander);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "&Setting";
            this.settingToolStripMenuItem.Visible = false;
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.configureToolStripMenuItem.Text = "&Configure";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "&Help";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aToolStripMenuItem.Text = "&About";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // newDirDialog
            // 
            this.newDirDialog.Description = "Select/Create a floder where you want to save your project";
            this.newDirDialog.HelpRequest += new System.EventHandler(this.newDirDialog_HelpRequest);
            // 
            // dirGrid
            // 
            this.dirGrid.AllowDrop = true;
            this.dirGrid.AllowUserToAddRows = false;
            this.dirGrid.AllowUserToDeleteRows = false;
            this.dirGrid.AllowUserToResizeColumns = false;
            this.dirGrid.AllowUserToResizeRows = false;
            this.dirGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dirGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dirGrid.CausesValidation = false;
            this.dirGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dirGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DirPath,
            this.DirAction,
            this.delDir});
            this.dirGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dirGrid.Location = new System.Drawing.Point(3, 3);
            this.dirGrid.MultiSelect = false;
            this.dirGrid.Name = "dirGrid";
            this.dirGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dirGrid.RowHeadersVisible = false;
            this.dirGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dirGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dirGrid.Size = new System.Drawing.Size(459, 175);
            this.dirGrid.TabIndex = 1;
            this.dirGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dirGrid_CellContentClick);
            // 
            // DirPath
            // 
            this.DirPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DirPath.DefaultCellStyle = dataGridViewCellStyle1;
            this.DirPath.HeaderText = "Folder";
            this.DirPath.Name = "DirPath";
            this.DirPath.ReadOnly = true;
            this.DirPath.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DirAction
            // 
            this.DirAction.FillWeight = 80F;
            this.DirAction.HeaderText = "Watch?";
            this.DirAction.MinimumWidth = 80;
            this.DirAction.Name = "DirAction";
            this.DirAction.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DirAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DirAction.ToolTipText = "compass watch ";
            this.DirAction.TrueValue = "";
            this.DirAction.Width = 80;
            // 
            // delDir
            // 
            this.delDir.FillWeight = 80F;
            this.delDir.HeaderText = "";
            this.delDir.MinimumWidth = 80;
            this.delDir.Name = "delDir";
            this.delDir.Text = "Delete";
            this.delDir.Width = 80;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ss});
            this.statusStrip1.Location = new System.Drawing.Point(0, 283);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(465, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ss
            // 
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(13, 17);
            this.ss.Text = "0";
            this.ss.Visible = false;
            // 
            // txtCLI
            // 
            this.txtCLI.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtCLI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCLI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCLI.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCLI.Location = new System.Drawing.Point(3, 184);
            this.txtCLI.Name = "txtCLI";
            this.txtCLI.ReadOnly = true;
            this.txtCLI.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtCLI.Size = new System.Drawing.Size(459, 72);
            this.txtCLI.TabIndex = 3;
            this.txtCLI.Text = "Outputs:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dirGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCLI, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(465, 259);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 305);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(481, 343);
            this.Name = "main";
            this.Text = "Compass Bundle UI";
            this.MinimumSizeChanged += new System.EventHandler(this.main_MinimumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dirGrid)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog newDirDialog;
        private System.Windows.Forms.DataGridView dirGrid;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DirAction;
        private System.Windows.Forms.DataGridViewButtonColumn delDir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ss;
        private System.Windows.Forms.RichTextBox txtCLI;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

