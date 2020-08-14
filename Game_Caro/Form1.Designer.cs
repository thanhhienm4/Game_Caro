namespace Game_Caro
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnl_chessboard = new System.Windows.Forms.Panel();
            this.pnl_avata = new System.Windows.Forms.Panel();
            this.pnl_info = new System.Windows.Forms.Panel();
            this.pgbCoolDown = new System.Windows.Forms.ProgressBar();
            this.ptbMark = new System.Windows.Forms.PictureBox();
            this.tbxIp = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tmCoolDown = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLAN = new System.Windows.Forms.Button();
            this.pnl_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMark)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_chessboard
            // 
            this.pnl_chessboard.AutoSize = true;
            this.pnl_chessboard.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnl_chessboard.Location = new System.Drawing.Point(0, 27);
            this.pnl_chessboard.Name = "pnl_chessboard";
            this.pnl_chessboard.Size = new System.Drawing.Size(511, 438);
            this.pnl_chessboard.TabIndex = 0;
            // 
            // pnl_avata
            // 
            this.pnl_avata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_avata.AutoSize = true;
            this.pnl_avata.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnl_avata.BackgroundImage = global::Game_Caro.Properties.Resources.icon;
            this.pnl_avata.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_avata.Location = new System.Drawing.Point(541, 44);
            this.pnl_avata.Name = "pnl_avata";
            this.pnl_avata.Size = new System.Drawing.Size(250, 223);
            this.pnl_avata.TabIndex = 1;
            // 
            // pnl_info
            // 
            this.pnl_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_info.AutoSize = true;
            this.pnl_info.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnl_info.Controls.Add(this.btnLAN);
            this.pnl_info.Controls.Add(this.pgbCoolDown);
            this.pnl_info.Controls.Add(this.ptbMark);
            this.pnl_info.Controls.Add(this.tbxIp);
            this.pnl_info.Controls.Add(this.tbxName);
            this.pnl_info.Location = new System.Drawing.Point(541, 286);
            this.pnl_info.Name = "pnl_info";
            this.pnl_info.Size = new System.Drawing.Size(250, 199);
            this.pnl_info.TabIndex = 1;
            // 
            // pgbCoolDown
            // 
            this.pgbCoolDown.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.pgbCoolDown.Location = new System.Drawing.Point(0, 97);
            this.pgbCoolDown.Name = "pgbCoolDown";
            this.pgbCoolDown.Size = new System.Drawing.Size(118, 23);
            this.pgbCoolDown.Step = 1;
            this.pgbCoolDown.TabIndex = 2;
            // 
            // ptbMark
            // 
            this.ptbMark.Location = new System.Drawing.Point(139, 23);
            this.ptbMark.Name = "ptbMark";
            this.ptbMark.Size = new System.Drawing.Size(100, 97);
            this.ptbMark.TabIndex = 2;
            this.ptbMark.TabStop = false;
            // 
            // tbxIp
            // 
            this.tbxIp.Location = new System.Drawing.Point(0, 60);
            this.tbxIp.Name = "tbxIp";
            this.tbxIp.Size = new System.Drawing.Size(118, 20);
            this.tbxIp.TabIndex = 1;
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(0, 23);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(118, 20);
            this.tbxName.TabIndex = 0;
            // 
            // tmCoolDown
            // 
            this.tmCoolDown.Tick += new System.EventHandler(this.tmCoolDown_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.newGameToolStripMenuItem.Text = "New game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // btnLAN
            // 
            this.btnLAN.AccessibleDescription = "";
            this.btnLAN.Location = new System.Drawing.Point(0, 127);
            this.btnLAN.Name = "btnLAN";
            this.btnLAN.Size = new System.Drawing.Size(118, 23);
            this.btnLAN.TabIndex = 3;
            this.btnLAN.Text = "LAN";
            this.btnLAN.UseVisualStyleBackColor = true;
            this.btnLAN.Click += new System.EventHandler(this.btnLAN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 488);
            this.Controls.Add(this.pnl_avata);
            this.Controls.Add(this.pnl_info);
            this.Controls.Add(this.pnl_chessboard);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.pnl_info.ResumeLayout(false);
            this.pnl_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMark)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_chessboard;
        private System.Windows.Forms.Panel pnl_avata;
        private System.Windows.Forms.Panel pnl_info;
        private System.Windows.Forms.PictureBox ptbMark;
        private System.Windows.Forms.TextBox tbxIp;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.ProgressBar pgbCoolDown;
        private System.Windows.Forms.Timer tmCoolDown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button btnLAN;
    }
}

