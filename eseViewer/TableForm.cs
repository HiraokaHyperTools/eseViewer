using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Microsoft.Isam.Esent.Interop;
using Microsoft.VisualBasic;
using System.IO;

namespace eseViewer {
    public partial class TableForm : Form {
        Table jt = null;

        public TableForm(VList vl, Table jt, bool isReadOnly) {
            InitializeComponent();

            this.jt = jt;

            bs.AllowNew = !isReadOnly;

            nav.AddNewItem.Enabled = !isReadOnly;
            nav.DeleteItem.Enabled = !isReadOnly;

            bs.DataSource = vl;
            gv.DataSource = bs;

            gv.ReadOnly = isReadOnly;
        }

        private void TableForm_Load(object sender, EventArgs e) {
        }

        public class MyRow : SortedDictionary<String, Object> {

        }

        public class MyCol : PropertyDescriptor {
            Type vt;

            public MyCol(String name, Type vt)
                : base(name, new Attribute[0]) {
                this.vt = vt;
            }

            public override bool CanResetValue(object component) { return true; }

            public override Type ComponentType { get { return typeof(MyRow); } }

            public override object GetValue(object component) {
                MyRow row = (MyRow)component;

                if (row.ContainsKey(Name))
                    return row[Name];
                if (vt.IsClass)
                    return null;
                return Converter.ConvertTo(0, vt);
            }

            public override bool IsReadOnly { get { return false; } }

            public override Type PropertyType {
                get { return vt; }
            }

            public override void ResetValue(object component) {
                MyRow row = (MyRow)component;
                row.Remove(Name);
            }

            public override void SetValue(object component, object value) {
                MyRow row = (MyRow)component;
                row[Name] = value;
            }

            public override bool ShouldSerializeValue(object component) {
                return true;
            }
        }

        public class MyList : Collection<MyRow>, ITypedList {
            #region ITypedList ÉÅÉìÉo

            public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors) {
                Debug.Assert(listAccessors == null);

                PropertyDescriptorCollection Many = new PropertyDescriptorCollection(new PropertyDescriptor[]{
                    new MyCol("ID", typeof(int)),
                    new MyCol("Str", typeof(string)),
                });
                return Many;
            }

            public string GetListName(PropertyDescriptor[] listAccessors) {
                return typeof(MyRow).Name;
            }

            #endregion
        }

        internal void DisconnectEsent() {
            bs.DataSource = null;
            gv.DataSource = null;
            jt = null;
        }

        private void TableForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (jt != null) jt.Dispose();
        }

        private void bChangeEnc_Click(object sender, EventArgs e) {
            VList vl = bs.DataSource as VList;
            if (vl == null) return;
            VCol vcol = Array.Find(vl.alvcol, delegate(VCol vcol0) { return vcol0.Name == gv.Columns[gv.CurrentCell.ColumnIndex].DataPropertyName; });
            if (vcol == null) return;
            String s = Interaction.InputBox("Encoding?", "", vcol.enc.BodyName, -1, -1);
            if (s.Length == 0) return;
            vcol.enc = Encoding.GetEncoding(s);
            gv.InvalidateColumn(gv.CurrentCell.ColumnIndex);
        }

        private void bViewHex_Click(object sender, EventArgs e) {
            VList vl = bs.DataSource as VList;
            if (vl == null) return;
            VCol vcol = Array.Find(vl.alvcol, delegate(VCol vcol0) { return vcol0.Name == gv.Columns[gv.CurrentCell.ColumnIndex].DataPropertyName; });
            if (vcol == null) return;
            byte[] bin = vcol.GetBin((VRow)gv.CurrentRow.DataBoundItem);
            DispHex(bin);
        }

        private void DispHex(byte[] bin) {
            BinForm form = new BinForm();
            StringBuilder str = new StringBuilder();
            int i = 0;
            for (int y = 0; i < bin.Length; y++) {
                int oi = i;
                int x;
                for (x = 0; x < 16 && i < bin.Length; x++, i++) {
                    str.AppendFormat("{0:X2} ", bin[i]);
                }
                for (; x < 16; x++) str.Append("   ");
                i = oi;
                for (x = 0; x < 16 && i < bin.Length; x++, i++) {
                    char c = (char)bin[i];
                    str.Append((32 <= c && c <= 126) ? c : '.');
                }
                str.AppendLine();
            }
            form.tb.Text = str.ToString();
            form.tb.Select(0, 0);
            WPUt.Center(form, this);
            form.Show();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) {

        }

        private void bDetailCol_Click(object sender, EventArgs e) {
            VList vl = bs.DataSource as VList;
            if (vl == null) return;
            VCol vcol = Array.Find(vl.alvcol, delegate(VCol vcol0) { return vcol0.Name == gv.Columns[gv.CurrentCell.ColumnIndex].DataPropertyName; });
            if (vcol == null) return;

            Form form = new Form();
            PropertyGrid g = new PropertyGrid();
            g.SelectedObject = vcol.jci;
            g.Parent = form;
            g.Dock = DockStyle.Fill;
            WPUt.Center(form, this);
            form.Show();
        }

        private void bViewSchema_Click(object sender, EventArgs e) {
            VList vl = bs.DataSource as VList;
            if (vl == null) return;
            StringWriter wr = new StringWriter();
            foreach (VCol vcol in vl.alvcol) {
                ColumnInfo ci = vcol.jci;
                wr.WriteLine("{0}\t{1}\t{2}", ci.Name, ci.Coltyp, ci.MaxLength);
            }
            Form form = new Form();
            form.StartPosition = FormStartPosition.CenterParent;
            TextBox tb = new TextBox();
            tb.Multiline = true;
            tb.ScrollBars = ScrollBars.Both;
            tb.WordWrap = false;
            tb.Text = wr.ToString();
            tb.Parent = form;
            tb.Dock = DockStyle.Fill;
            WPUt.Center(form, this);
            form.Show(this);
        }

        private void bViewIdx_Click(object sender, EventArgs e) {
            VList vl = bs.DataSource as VList;
            if (vl == null) return;

            Form form = new Form();
            PropertyGrid g = new PropertyGrid();
            g.Parent = form;
            g.Dock = DockStyle.Fill;

            ComboBox cbIdx = new ComboBox();
            cbIdx.Parent = form;
            cbIdx.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIdx.Dock = DockStyle.Top;
            cbIdx.Items.AddRange(new List<IndexInfo>(vl.GetIndices()).ToArray());
            cbIdx.SelectedIndexChanged += delegate(object sender2, EventArgs e2) {
                g.SelectedObject = cbIdx.SelectedItem;
            };
            cbIdx.SelectedIndex = 0;

            WPUt.Center(form, this);
            form.Show();
        }

        private void gv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {

        }

        private void bBookmark_Click(object sender, EventArgs e) {
            VRow vr = (VRow)gv.CurrentRow.DataBoundItem;
            if (vr == null) return;
            DispHex(vr.mark);
        }

        private void bIndexBins_Click(object sender, EventArgs e) {
            VList vl = bs.DataSource as VList;
            if (vl == null) return;

            VRow vr = (VRow)gv.CurrentRow.DataBoundItem;
            if (vr == null) return;

            StringWriter wr = new StringWriter();

            foreach (IndexBytes ib in vl.GetIndicesByMark(vr)) {
                wr.WriteLine("--- {0}", ib.ii);
                wr.WriteLine();
                wr.WriteLine(BUt.ToHex(ib.idx));
                wr.WriteLine();
            }

            BinForm form = new BinForm();
            form.tb.Text = wr.ToString();
            form.tb.Select(0, 0);
            WPUt.Center(form, this);
            form.Show();

        }

        class BUt {
            internal static string ToHex(byte[] bin) {
                StringBuilder str = new StringBuilder();
                int i = 0;
                for (int y = 0; i < bin.Length; y++) {
                    int oi = i;
                    int x;
                    for (x = 0; x < 16 && i < bin.Length; x++, i++) {
                        str.AppendFormat("{0:X2} ", bin[i]);
                    }
                    for (; x < 16; x++) str.Append("   ");
                    i = oi;
                    for (x = 0; x < 16 && i < bin.Length; x++, i++) {
                        char c = (char)bin[i];
                        str.Append((32 <= c && c <= 126) ? c : '.');
                    }
                    str.AppendLine();
                }
                return str.ToString();
            }
        }
    }
}
