using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace eseViewer {
    public partial class OpenForm : Form {
        public OpenForm() {
            InitializeComponent();
        }

        private void bUseTemp_Click(object sender, EventArgs e) {
            String baseDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(baseDir);

            tbLogFilePath.Text = tbSystemPath.Text = tbTempPath.Text = baseDir;
        }
    }
}