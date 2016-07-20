namespace eseViewer {
    partial class MForm {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MForm));
            this.tsc = new System.Windows.Forms.ToolStripContainer();
            this.lvt = new System.Windows.Forms.ListView();
            this.chTableName = new System.Windows.Forms.ColumnHeader();
            this.tstop = new System.Windows.Forms.ToolStrip();
            this.bOpen = new System.Windows.Forms.ToolStripSplitButton();
            this.bLiveMail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bRepair = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bRecover = new System.Windows.Forms.ToolStripButton();
            this.ofdDb = new System.Windows.Forms.OpenFileDialog();
            this.sfdNewdb = new System.Windows.Forms.SaveFileDialog();
            this.tsc.ContentPanel.SuspendLayout();
            this.tsc.TopToolStripPanel.SuspendLayout();
            this.tsc.SuspendLayout();
            this.tstop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsc
            // 
            // 
            // tsc.ContentPanel
            // 
            this.tsc.ContentPanel.Controls.Add(this.lvt);
            this.tsc.ContentPanel.Size = new System.Drawing.Size(435, 299);
            this.tsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsc.Location = new System.Drawing.Point(0, 0);
            this.tsc.Name = "tsc";
            this.tsc.Size = new System.Drawing.Size(435, 324);
            this.tsc.TabIndex = 0;
            this.tsc.Text = "toolStripContainer1";
            // 
            // tsc.TopToolStripPanel
            // 
            this.tsc.TopToolStripPanel.Controls.Add(this.tstop);
            // 
            // lvt
            // 
            this.lvt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTableName});
            this.lvt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvt.FullRowSelect = true;
            this.lvt.GridLines = true;
            this.lvt.Location = new System.Drawing.Point(0, 0);
            this.lvt.Name = "lvt";
            this.lvt.Size = new System.Drawing.Size(435, 299);
            this.lvt.TabIndex = 0;
            this.lvt.UseCompatibleStateImageBehavior = false;
            this.lvt.View = System.Windows.Forms.View.Details;
            this.lvt.ItemActivate += new System.EventHandler(this.lvt_ItemActivate);
            this.lvt.SelectedIndexChanged += new System.EventHandler(this.lvt_SelectedIndexChanged);
            // 
            // chTableName
            // 
            this.chTableName.Text = "TableName";
            this.chTableName.Width = 300;
            // 
            // tstop
            // 
            this.tstop.Dock = System.Windows.Forms.DockStyle.None;
            this.tstop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bOpen,
            this.toolStripSeparator1,
            this.bClose,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.bRepair,
            this.toolStripSeparator2,
            this.bRecover});
            this.tstop.Location = new System.Drawing.Point(3, 0);
            this.tstop.Name = "tstop";
            this.tstop.Size = new System.Drawing.Size(428, 25);
            this.tstop.TabIndex = 0;
            // 
            // bOpen
            // 
            this.bOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bLiveMail});
            this.bOpen.Image = ((System.Drawing.Image)(resources.GetObject("bOpen.Image")));
            this.bOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(82, 22);
            this.bOpen.Text = "&Open...";
            this.bOpen.ButtonClick += new System.EventHandler(this.bOpen_Click);
            // 
            // bLiveMail
            // 
            this.bLiveMail.Name = "bLiveMail";
            this.bLiveMail.Size = new System.Drawing.Size(203, 22);
            this.bLiveMail.Text = "Mail.MSMessageStore";
            this.bLiveMail.Click += new System.EventHandler(this.bLiveMail_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bClose
            // 
            this.bClose.Image = ((System.Drawing.Image)(resources.GetObject("bClose.Image")));
            this.bClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(59, 22);
            this.bClose.Text = "&Close";
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bRepair
            // 
            this.bRepair.Image = ((System.Drawing.Image)(resources.GetObject("bRepair.Image")));
            this.bRepair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRepair.Name = "bRepair";
            this.bRepair.Size = new System.Drawing.Size(176, 22);
            this.bRepair.Text = "Repair \"Dirty Shutdown\"?";
            this.bRepair.Click += new System.EventHandler(this.bRepair_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bRecover
            // 
            this.bRecover.Image = ((System.Drawing.Image)(resources.GetObject("bRecover.Image")));
            this.bRecover.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRecover.Name = "bRecover";
            this.bRecover.Size = new System.Drawing.Size(75, 22);
            this.bRecover.Text = "Recover";
            this.bRecover.Click += new System.EventHandler(this.bRecover_Click);
            // 
            // ofdDb
            // 
            this.ofdDb.Filter = "Extensible Storage Engine|*.MSMessageStore;Windows.edb";
            // 
            // MForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 324);
            this.Controls.Add(this.tsc);
            this.Name = "MForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eseViewer";
            this.Load += new System.EventHandler(this.MForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MForm_FormClosed);
            this.tsc.ContentPanel.ResumeLayout(false);
            this.tsc.TopToolStripPanel.ResumeLayout(false);
            this.tsc.TopToolStripPanel.PerformLayout();
            this.tsc.ResumeLayout(false);
            this.tsc.PerformLayout();
            this.tstop.ResumeLayout(false);
            this.tstop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tsc;
        private System.Windows.Forms.ToolStrip tstop;
        private System.Windows.Forms.OpenFileDialog ofdDb;
        private System.Windows.Forms.ListView lvt;
        private System.Windows.Forms.ColumnHeader chTableName;
        private System.Windows.Forms.ToolStripButton bClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog sfdNewdb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton bRepair;
        private System.Windows.Forms.ToolStripButton bRecover;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton bOpen;
        private System.Windows.Forms.ToolStripMenuItem bLiveMail;
    }
}

