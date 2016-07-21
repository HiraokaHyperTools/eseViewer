using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Isam.Esent.Interop;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace eseViewer {
    public partial class MForm : Form {
        public MForm() {
            InitializeComponent();
        }

        class AH : IDisposable {
            Cursor prev;

            public AH() { prev = Cursor.Current; Cursor.Current = Cursors.WaitCursor; }

            #region IDisposable ÉÅÉìÉo

            public void Dispose() { Cursor.Current = prev; }

            #endregion
        }

        private void bLiveMail_Click(object sender, EventArgs e) {
            ofdDb.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Microsoft\Windows Live Mail\Mail.MSMessageStore");
            bOpen_Click(sender, e);
        }

        private void bOpen_Click(object sender, EventArgs e) {
            if (ofdDb.ShowDialog(this) == DialogResult.OK) {
                using (OpenForm form = new OpenForm()) {
                    form.tbfp.Text = ofdDb.FileName;

                    String dirDb = Path.GetDirectoryName(ofdDb.FileName);
                    form.tbLogFilePath.Text = dirDb;
                    form.tbTempPath.Text = dirDb;
                    form.tbSystemPath.Text = dirDb;

                    if (form.ShowDialog() == DialogResult.OK) {
                        int? DatabasePageSize = null; { int tmp; if (int.TryParse(form.tbDatabasePageSize.Text, out tmp)) { DatabasePageSize = tmp; } }

                        using (AH ah = new AH())
                            es.Open2(form.tbfp.Text
                                , form.tbLogFilePath.Text
                                , form.tbTempPath.Text
                                , form.tbSystemPath.Text
                                , form.rbReadOnly.Checked
                                , DatabasePageSize
                                );

                        lvt.Items.Clear();
                        foreach (String tableName in Api.GetTableNames(es.sesid, es.dbid)) {
                            lvt.Items.Add(tableName).Name = tableName;
                        }
                    }
                }
            }
        }

        ES es = new ES();

        class ES : IDisposable {
            String baseDir = String.Empty;
            String instId = "eseViewer";

            public JET_INSTANCE instance = JET_INSTANCE.Nil;
            public JET_SESID sesid = JET_SESID.Nil;
            public JET_DBID dbid = JET_DBID.Nil;

            public bool isReadOnly;

            public event EventHandler Disposed;

            public void Open(String fpdb) {
                baseDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(baseDir);

                String tmp1 = Path.Combine(baseDir, "1");
                Directory.CreateDirectory(tmp1);
                String tmp2 = Path.Combine(baseDir, "2");
                Directory.CreateDirectory(tmp2);
                String tmp3 = Path.Combine(baseDir, "3");
                Directory.CreateDirectory(tmp3);

                Open2(fpdb, tmp1, tmp2, tmp3, true, null);
            }

            public void Open2(String fpdb, String tmp1, String tmp2, String tmp3, bool isReadOnly, int? DatabasePageSize) {
                Dispose();

                this.isReadOnly = isReadOnly;

                if (DatabasePageSize.HasValue) SystemParameters.DatabasePageSize = DatabasePageSize.Value;
                Api.JetCreateInstance(out instance, instId);
                Api.JetSetSystemParameter(instance, JET_SESID.Nil, JET_param.LogFilePath, 0, tmp1 + "\\");
                Api.JetSetSystemParameter(instance, JET_SESID.Nil, JET_param.TempPath, 0, tmp2 + "\\");
                Api.JetSetSystemParameter(instance, JET_SESID.Nil, JET_param.SystemPath, 0, tmp3 + "\\");
                Api.JetInit(ref instance);
                Api.JetBeginSession(instance, out sesid, null, null);
                EUt.Check(Api.JetAttachDatabase(sesid, fpdb, isReadOnly ? AttachDatabaseGrbit.ReadOnly : AttachDatabaseGrbit.None), "JetAttachDatabase");
                EUt.Check(Api.JetOpenDatabase(sesid, fpdb, null, out dbid, isReadOnly ? OpenDatabaseGrbit.ReadOnly : OpenDatabaseGrbit.None), "JetOpenDatabase");
            }

            class EUt {
                internal static void Check(JET_wrn wrn, String message) {
                    if (wrn == JET_wrn.Success) return;
                    throw new ApplicationException(message + " " + wrn);
                }
            }

            #region IDisposable ÉÅÉìÉo

            public void Dispose() {
                if (dbid != JET_DBID.Nil) {
                    Api.JetCloseDatabase(sesid, dbid, CloseDatabaseGrbit.None);
                    dbid = JET_DBID.Nil;
                }
                if (sesid != JET_SESID.Nil) {
                    Api.JetEndSession(sesid, EndSessionGrbit.None);
                    sesid = JET_SESID.Nil;
                }
                if (instance != JET_INSTANCE.Nil) {
                    Api.JetTerm(instance);
                    instance = JET_INSTANCE.Nil;
                }
                if (Disposed != null) {
                    Disposed(this, new EventArgs());
                }
            }

            #endregion
        }

        private void MForm_FormClosed(object sender, FormClosedEventArgs e) {
            es.Dispose();
        }

        private void lvt_SelectedIndexChanged(object sender, EventArgs e) {
        }

        private Encoding GetEnc(String t, String c) {
            String a = t + "\\" + c;

            if (a == @"Folders\FLDCOL_NAME") return Encoding.Default;
            if (a == @"Folders\FLDCOL_NAMEW") return Encoding.Unicode;
            if (a == @"Folders\FLDCOL_PATH") return Encoding.Unicode;
            if (a == @"Messages\MSGCOL_DISPLAYFROM") return Encoding.Unicode;
            if (a == @"Messages\MSGCOL_DISPLAYTO") return Encoding.Unicode;
            if (a == @"Messages\MSGCOL_NORMALSUBJ") return Encoding.Unicode;
            if (a == @"Messages\MSGCOL_SUBJECT") return Encoding.Unicode;
            if (a == @"Messages\MSGCOL_ACCOUNTNAME") return Encoding.Unicode;
            if (a == @"Streams\Path") return Encoding.Unicode;

            return Encoding.GetEncoding("iso-8859-1");
        }

        private void bClose_Click(object sender, EventArgs e) {
            es.Dispose();
            lvt.Items.Clear();
        }

        private void MForm_Load(object sender, EventArgs e) {
            Text += " " + Application.ProductVersion;
        }

        private void lvt_ItemActivate(object sender, EventArgs e) {
            foreach (ListViewItem lvi in lvt.SelectedItems) {
                using (AH ah = new AH()) {
                    Table t = new Table(es.sesid, es.dbid, lvi.Name, es.isReadOnly ? OpenTableGrbit.ReadOnly : OpenTableGrbit.None);
                    List<VCol> alvcol = new List<VCol>();
                    foreach (ColumnInfo jci in Api.GetTableColumns(es.sesid, t.JetTableid)) {
                        alvcol.Add(new VCol(jci).WithEnc(GetEnc(lvi.Name, jci.Name)));
                    }
                    VList vl = new VList(alvcol.ToArray());
                    vl.sesid = es.sesid;
                    vl.tableid = t.JetTableid;
                    if (Api.TryMoveFirst(es.sesid, t.JetTableid)) {
                        byte[] tmpMark = new byte[1024];
                        for (int y = 0; ; y++) {
                            int cbMark = tmpMark.Length;
                            Api.JetGetBookmark(es.sesid, t.JetTableid, tmpMark, tmpMark.Length, out cbMark);

                            vl.Add(new VRow(y, UtBytea.Cut(tmpMark, 0, cbMark)));

                            if (Api.TryMoveNext(es.sesid, t.JetTableid))
                                continue;
                            break;
                        }
                    }
                    TableForm form = new TableForm(vl, t, es.isReadOnly);
                    form.Text = lvi.Name;
                    es.Disposed += delegate {
                        form.DisconnectEsent();
                        form.Close();
                    };
                    WPUt.Center(form, this);
                    form.Show();
                }
            }
        }

        class UtBytea {
            internal static byte[] Cut(byte[] src, int x, int cx) {
                byte[] dst = new byte[cx];
                Buffer.BlockCopy(src, x, dst, 0, cx);
                return dst;
            }
        }

        private void bRepair_Click(object sender, EventArgs e) {
            if (ofdDb.ShowDialog(this) != DialogResult.OK)
                return;

            ProcessStartInfo psi = new ProcessStartInfo(
                Environment.ExpandEnvironmentVariables("%SYSTEMROOT%\\system32\\CMD.exe"),
                Environment.ExpandEnvironmentVariables(" /k %SYSTEMROOT%\\system32\\esentutl.exe /p \"" + ofdDb.FileName + "\" ")
                );
            psi.WorkingDirectory = Path.GetDirectoryName(ofdDb.FileName);

            if (MessageBox.Show(this, "Execute the following command?\n\n" + psi.FileName + " " + psi.Arguments, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                return;

            Process.Start(psi);
        }

        private void bRecover_Click(object sender, EventArgs e) {
            if (ofdDb.ShowDialog(this) != DialogResult.OK)
                return;

            ProcessStartInfo psi = new ProcessStartInfo(
                Environment.ExpandEnvironmentVariables("%SYSTEMROOT%\\system32\\CMD.exe"),
                Environment.ExpandEnvironmentVariables(" /k %SYSTEMROOT%\\system32\\esentutl.exe /r \"" + ofdDb.FileName + "\" ")
                );
            psi.WorkingDirectory = Path.GetDirectoryName(ofdDb.FileName);

            if (MessageBox.Show(this, "Execute the following command?\n\n" + psi.FileName + " " + psi.Arguments, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                return;

            Process.Start(psi);
        }

    }

    public class VCol : PropertyDescriptor {
        internal ColumnInfo jci;
        internal Type vt;
        internal Encoding enc = Encoding.GetEncoding("iso-8859-1");

        public VCol(ColumnInfo jci)
            : base(jci.Name, new Attribute[0]) {

            this.jci = jci;
            this.vt = TyUt.Map(jci.Coltyp);
        }

        public override bool CanResetValue(object component) { return true; }

        public override Type ComponentType { get { return typeof(VRow); } }

        class EUt {
            internal static void Check(JET_wrn wrn, String message) {
                if (wrn == JET_wrn.Success) return;
                throw new ApplicationException(message + " " + wrn);
            }
        }

        class TyUt {
            internal static Type Map(JET_coltyp colty) {
                switch (colty) {
                    case JET_coltyp.Bit: return typeof(bool);
                    case JET_coltyp.UnsignedByte: return typeof(byte);
                    case JET_coltyp.Short: return typeof(Int16);
                    case JET_coltyp.Long: return typeof(Int32);
                    case JET_coltyp.Currency: return typeof(Int64);
                    case JET_coltyp.DateTime: return typeof(DateTime);
                    default:
                    case JET_coltyp.Text:
                    case JET_coltyp.LongText:
                        return typeof(string);
                }
            }
        }

        public override object GetValue(object component) {
            VRow row = (VRow)component;

            if (row.offset < 0) {
                if (row.newRow.ContainsKey(Name))
                    return row.newRow[Name];
                if (vt.IsClass)
                    return null;
                return Convert.ChangeType(0, vt);
            }

            if (true) {
                Api.JetGotoBookmark(row.sesid, row.tableid, row.mark, row.mark.Length);
            }
            else {
                //Api.JetMove(row.sesid, row.tableid, JET_Move.First, MoveGrbit.None);
                //Api.JetMove(row.sesid, row.tableid, row.offset, MoveGrbit.None);
            }

            switch (jci.Coltyp) {
                case JET_coltyp.Bit: return Api.RetrieveColumnAsBoolean(row.sesid, row.tableid, jci.Columnid);
                case JET_coltyp.UnsignedByte: return Api.RetrieveColumnAsByte(row.sesid, row.tableid, jci.Columnid);
                case JET_coltyp.Short: return Api.RetrieveColumnAsInt16(row.sesid, row.tableid, jci.Columnid);
                case JET_coltyp.Long: return Api.RetrieveColumnAsInt32(row.sesid, row.tableid, jci.Columnid);
                case JET_coltyp.Currency: return Api.RetrieveColumnAsInt64(row.sesid, row.tableid, jci.Columnid);
                case JET_coltyp.DateTime: return Api.RetrieveColumnAsDateTime(row.sesid, row.tableid, jci.Columnid);
                default:
                case JET_coltyp.Text:
                case JET_coltyp.LongText: return Api.RetrieveColumnAsString(row.sesid, row.tableid, jci.Columnid, enc);
            }
        }

        public byte[] GetBin(object component) {
            VRow row = (VRow)component;

            if (row.offset < 0) {
                return null;
            }

            if (true) {
                Api.JetGotoBookmark(row.sesid, row.tableid, row.mark, row.mark.Length);
            }
            else {
                //Api.JetMove(row.sesid, row.tableid, JET_Move.First, MoveGrbit.None);
                //Api.JetMove(row.sesid, row.tableid, row.offset, MoveGrbit.None);
            }

            return Api.RetrieveColumn(row.sesid, row.tableid, jci.Columnid);
        }

        public override bool IsReadOnly { get { return false; } }

        public override Type PropertyType {
            get { return vt; }
        }

        public override void ResetValue(object component) {
            VRow row = (VRow)component;
        }

        public override void SetValue(object component, object value) {
            VRow row = (VRow)component;

            if (row.offset < 0) {
                // new row
                row.newRow[Name] = Convert.ChangeType(value, PropertyType);
                return;
            }

            if (true) {
                Api.JetGotoBookmark(row.sesid, row.tableid, row.mark, row.mark.Length);
            }
            else {
                //Api.JetMove(row.sesid, row.tableid, JET_Move.First, MoveGrbit.None);
                //Api.JetMove(row.sesid, row.tableid, row.offset, MoveGrbit.None);
            }

            Api.JetPrepareUpdate(row.sesid, row.tableid, JET_prep.Replace);

            if (value == null || value is DBNull) {
                Api.JetSetColumn(row.sesid, row.tableid, jci.Columnid, new byte[0], 0, SetColumnGrbit.None, null);
            }
            else {
                SetColVal(row, value);
            }

            Api.JetUpdate(row.sesid, row.tableid);
        }

        internal void SetColVal(VRow row, object value) {
            switch (jci.Coltyp) {
                case JET_coltyp.Bit: Api.SetColumn(row.sesid, row.tableid, jci.Columnid, Convert.ToBoolean(value)); break;
                case JET_coltyp.UnsignedByte: Api.SetColumn(row.sesid, row.tableid, jci.Columnid, Convert.ToByte(value)); break;
                case JET_coltyp.Short: Api.SetColumn(row.sesid, row.tableid, jci.Columnid, Convert.ToInt16(value)); break;
                case JET_coltyp.Long: Api.SetColumn(row.sesid, row.tableid, jci.Columnid, Convert.ToInt32(value)); break;
                case JET_coltyp.Currency: Api.SetColumn(row.sesid, row.tableid, jci.Columnid, Convert.ToInt64(value)); break;
                case JET_coltyp.DateTime: Api.SetColumn(row.sesid, row.tableid, jci.Columnid, Convert.ToDateTime(value)); break;
                case JET_coltyp.Text:
                case JET_coltyp.LongText:
                    using (Transaction tr = new Transaction(row.sesid)) {
                        Api.SetColumn(row.sesid, row.tableid, jci.Columnid, enc.GetBytes(Convert.ToString(value)), SetColumnGrbit.None);
                        tr.Commit(CommitTransactionGrbit.None);
                    }
                    break;
                default: throw new NotSupportedException("Set to: " + jci.Coltyp);
            }
        }

        public override bool ShouldSerializeValue(object component) {
            return true;
        }

        internal VCol WithEnc(Encoding enc) {
            this.enc = enc;
            return this;
        }
    }

    public class VRow {
        public int offset = -1;
        public byte[] mark = new byte[0];
        public VList vl;

        public JET_SESID sesid { get { return vl.sesid; } }
        public JET_TABLEID tableid { get { return vl.tableid; } }

        public SortedDictionary<String, Object> newRow = new SortedDictionary<String, Object>();

        public VRow() {

        }

        public VRow(int i, byte[] mark) {
            this.offset = i;
            this.mark = mark;
        }
    }

    public class VList : BindingList<VRow>, ITypedList {
        public VCol[] alvcol;

        public JET_SESID sesid;
        public JET_TABLEID tableid;

        public VList(VCol[] alvcol) {
            this.alvcol = alvcol;
        }

        public IEnumerable<IndexInfo> GetIndices() {
            return Api.GetTableIndexes(sesid, tableid);
        }

        protected override void InsertItem(int index, VRow item) {
            base.InsertItem(index, item);
            if (this[index] != null) this[index].vl = this;
        }

        protected override void SetItem(int index, VRow item) {
            if (this[index] != null) this[index].vl = null;
            base.SetItem(index, item);
            if (this[index] != null) this[index].vl = this;
        }

        protected override void RemoveItem(int index) {
            if (this[index] != null) {
                byte[] tmpMark = this[index].mark;
                if (tmpMark != null && tmpMark.Length != 0) {
                    Api.JetGotoBookmark(sesid, tableid, tmpMark, tmpMark.Length);
                    Api.JetDelete(sesid, tableid);
                }
            }
            if (this[index] != null) this[index].vl = null;
            base.RemoveItem(index);
        }

        public override void CancelNew(int itemIndex) {
            base.CancelNew(itemIndex);
        }

        public override void EndNew(int itemIndex) {
            base.EndNew(itemIndex);
            VRow row;
            if (0 <= itemIndex && (row = (VRow)this[itemIndex]) != null && row.offset < 0) {
                Api.JetPrepareUpdate(sesid, tableid, JET_prep.Insert);
                foreach (VCol vcol in alvcol) {
                    if (row.newRow.ContainsKey(vcol.Name)) {
                        vcol.SetColVal(row, row.newRow[vcol.Name]);
                    }
                }
                byte[] mark = new byte[1024];
                int cbMark = mark.Length;
                try {
                    Api.JetUpdate(sesid, tableid, mark, mark.Length, out cbMark);
                }
                catch (EsentKeyDuplicateException err) {
                    Api.JetPrepareUpdate(sesid, tableid, JET_prep.Cancel);
                    throw new ApplicationException(null, err);
                }
                row.offset = itemIndex;
                row.mark = UtBytea.Cut(mark, 0, cbMark);
            }
        }

        class UtBytea {
            internal static byte[] Cut(byte[] baSrc, int x, int cx) {
                byte[] baDst = new byte[cx];
                Buffer.BlockCopy(baSrc, x, baDst, 0, cx);
                return baDst;
            }
        }

        #region ITypedList ÉÅÉìÉo

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors) {
            return new PropertyDescriptorCollection(alvcol);
        }

        public string GetListName(PropertyDescriptor[] listAccessors) {
            return typeof(VList).Name;
        }

        #endregion

        public IEnumerable<IndexBytes> GetIndicesByMark(VRow vr) {
            foreach (IndexInfo ii in GetIndices()) {
                Api.JetSetCurrentIndex(sesid, tableid, ii.Name);
                Api.JetGotoBookmark(sesid, tableid, vr.mark, vr.mark.Length);
                yield return new IndexBytes(ii, Api.RetrieveKey(sesid, tableid, RetrieveKeyGrbit.None));
            }
        }
    }

    public class IndexBytes {
        public IndexInfo ii;
        public byte[] idx;

        public IndexBytes(IndexInfo ii, byte[] idx) {
            this.ii = ii;
            this.idx = idx;
        }
    }
}