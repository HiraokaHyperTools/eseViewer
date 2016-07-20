using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Isam.Esent.Interop;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace eseViewer {
    static class Program {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            //Test();

            Api.JetSetSystemParameter(JET_INSTANCE.Nil, JET_SESID.Nil, JET_param.DatabasePageSize, 8192, null);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MForm());
        }

        private static void Test() {
            String dirTmp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(dirTmp);

            Api.JetSetSystemParameter(JET_INSTANCE.Nil, JET_SESID.Nil, JET_param.DatabasePageSize, 8192, null);

            String instId = "a65edf63-9219-4d13-8d67-87b61c61df0c";
            JET_INSTANCE instance;
            Api.JetCreateInstance(out instance, instId);
            Api.JetSetSystemParameter(instance, JET_SESID.Nil, JET_param.LogFilePath, 0, dirTmp);
            Api.JetInit(ref instance);
            JET_SESID sesid;
            Api.JetBeginSession(instance, out sesid, null, null);
            String fp = @"C:\A\Mail";
            JET_wrn wrn;
            Trace.Assert((wrn = Api.JetAttachDatabase(sesid, fp, AttachDatabaseGrbit.ReadOnly)) == JET_wrn.Success);
            JET_DBID dbid;
            Trace.Assert((wrn = Api.JetOpenDatabase(sesid, fp, null, out dbid, OpenDatabaseGrbit.ReadOnly)) == JET_wrn.Success);

            JET_OBJECTLIST ol;
            Api.JetGetObjectInfo(sesid, dbid, out ol);
            JET_TABLEID tableid = ol.tableid;
            while (true) {
                String objectName = Api.RetrieveColumnAsString(sesid, tableid, ol.columnidobjectname, Encoding.Default);
                int objTyp = Api.RetrieveColumnAsInt32(sesid, tableid, ol.columnidobjtyp).Value;

                JET_TABLEID tid2;
                Api.JetOpenTable(sesid, dbid, objectName, null, 0, OpenTableGrbit.ReadOnly, out tid2);
                foreach (ColumnInfo ci in Api.GetTableColumns(sesid, tid2)) {
                    Console.Write("");
                }
                Api.JetCloseTable(sesid, tid2);

                if (!Api.TryMoveNext(sesid, tableid))
                    break;
            }
            Api.JetCloseTable(sesid, ol.tableid);

            Api.JetCloseDatabase(sesid, dbid, CloseDatabaseGrbit.None);
            Api.JetEndSession(sesid, EndSessionGrbit.None);
            Api.JetTerm(instance);
        }
    }
}