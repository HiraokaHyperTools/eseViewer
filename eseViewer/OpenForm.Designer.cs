namespace eseViewer {
    partial class OpenForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbfp = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbLogFilePath = new System.Windows.Forms.TextBox();
            this.tbTempPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSystemPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbinstId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDatabasePageSize = new System.Windows.Forms.TextBox();
            this.rbReadOnly = new System.Windows.Forms.RadioButton();
            this.rbEdit = new System.Windows.Forms.RadioButton();
            this.bOpen = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.bUseTemp = new System.Windows.Forms.Button();
            this.tlpC = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpC.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "FileName:";
            // 
            // tbfp
            // 
            this.tbfp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbfp.Location = new System.Drawing.Point(108, 3);
            this.tbfp.Name = "tbfp";
            this.tbfp.Size = new System.Drawing.Size(404, 19);
            this.tbfp.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tlpC, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbfp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbLogFilePath, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbTempPath, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbSystemPath, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbinstId, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbDatabasePageSize, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(514, 206);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbLogFilePath
            // 
            this.tbLogFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLogFilePath.Location = new System.Drawing.Point(108, 28);
            this.tbLogFilePath.Name = "tbLogFilePath";
            this.tbLogFilePath.Size = new System.Drawing.Size(404, 19);
            this.tbLogFilePath.TabIndex = 3;
            // 
            // tbTempPath
            // 
            this.tbTempPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTempPath.Location = new System.Drawing.Point(108, 53);
            this.tbTempPath.Name = "tbTempPath";
            this.tbTempPath.Size = new System.Drawing.Size(404, 19);
            this.tbTempPath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "LogFilePath";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "TempPath";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "SystemPath";
            // 
            // tbSystemPath
            // 
            this.tbSystemPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSystemPath.Location = new System.Drawing.Point(108, 78);
            this.tbSystemPath.Name = "tbSystemPath";
            this.tbSystemPath.Size = new System.Drawing.Size(404, 19);
            this.tbSystemPath.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Instance Name";
            // 
            // tbinstId
            // 
            this.tbinstId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbinstId.Location = new System.Drawing.Point(108, 103);
            this.tbinstId.Name = "tbinstId";
            this.tbinstId.Size = new System.Drawing.Size(100, 19);
            this.tbinstId.TabIndex = 9;
            this.tbinstId.Text = "eseViewer";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "DatabasePageSize";
            // 
            // tbDatabasePageSize
            // 
            this.tbDatabasePageSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDatabasePageSize.Location = new System.Drawing.Point(108, 128);
            this.tbDatabasePageSize.Name = "tbDatabasePageSize";
            this.tbDatabasePageSize.Size = new System.Drawing.Size(100, 19);
            this.tbDatabasePageSize.TabIndex = 11;
            this.tbDatabasePageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbReadOnly
            // 
            this.rbReadOnly.AutoSize = true;
            this.rbReadOnly.Checked = true;
            this.rbReadOnly.Location = new System.Drawing.Point(5, 5);
            this.rbReadOnly.Name = "rbReadOnly";
            this.rbReadOnly.Padding = new System.Windows.Forms.Padding(3);
            this.rbReadOnly.Size = new System.Drawing.Size(78, 22);
            this.rbReadOnly.TabIndex = 0;
            this.rbReadOnly.TabStop = true;
            this.rbReadOnly.Text = "ReadOnly";
            this.rbReadOnly.UseVisualStyleBackColor = true;
            // 
            // rbEdit
            // 
            this.rbEdit.AutoSize = true;
            this.rbEdit.Location = new System.Drawing.Point(91, 5);
            this.rbEdit.Name = "rbEdit";
            this.rbEdit.Padding = new System.Windows.Forms.Padding(3);
            this.rbEdit.Size = new System.Drawing.Size(70, 22);
            this.rbEdit.TabIndex = 1;
            this.rbEdit.TabStop = true;
            this.rbEdit.Text = "Editable";
            this.rbEdit.UseVisualStyleBackColor = true;
            // 
            // bOpen
            // 
            this.bOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOpen.Location = new System.Drawing.Point(12, 244);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(75, 23);
            this.bOpen.TabIndex = 1;
            this.bOpen.Text = "&Open";
            this.bOpen.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(127, 244);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bUseTemp
            // 
            this.bUseTemp.Location = new System.Drawing.Point(374, 244);
            this.bUseTemp.Name = "bUseTemp";
            this.bUseTemp.Size = new System.Drawing.Size(150, 23);
            this.bUseTemp.TabIndex = 3;
            this.bUseTemp.Text = "Alloc temp directory";
            this.bUseTemp.UseVisualStyleBackColor = true;
            this.bUseTemp.Click += new System.EventHandler(this.bUseTemp_Click);
            // 
            // tlpC
            // 
            this.tlpC.AutoSize = true;
            this.tlpC.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpC.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpC.ColumnCount = 2;
            this.tlpC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpC.Controls.Add(this.rbEdit, 1, 0);
            this.tlpC.Controls.Add(this.rbReadOnly, 0, 0);
            this.tlpC.Location = new System.Drawing.Point(108, 153);
            this.tlpC.Name = "tlpC";
            this.tlpC.RowCount = 1;
            this.tlpC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpC.Size = new System.Drawing.Size(174, 32);
            this.tlpC.TabIndex = 14;
            // 
            // OpenForm
            // 
            this.AcceptButton = this.bOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(538, 279);
            this.Controls.Add(this.bUseTemp);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OpenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpC.ResumeLayout(false);
            this.tlpC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Button bCancel;
        internal System.Windows.Forms.TextBox tbfp;
        internal System.Windows.Forms.TextBox tbLogFilePath;
        internal System.Windows.Forms.TextBox tbTempPath;
        internal System.Windows.Forms.TextBox tbSystemPath;
        internal System.Windows.Forms.TextBox tbinstId;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox tbDatabasePageSize;
        private System.Windows.Forms.Button bUseTemp;
        private System.Windows.Forms.RadioButton rbEdit;
        internal System.Windows.Forms.RadioButton rbReadOnly;
        private System.Windows.Forms.TableLayoutPanel tlpC;
    }
}