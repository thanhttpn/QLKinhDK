namespace QlyKinh
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;

    [Serializable, ToolboxItem(true), DesignerCategory("code"), DebuggerStepThrough]
    public class dsDataset : DataSet
    {
        private PRC_BCNHAPKHODataTable tablePRC_BCNHAPKHO;
        private PRC_BCXUATKHODataTable tablePRC_BCXUATKHO;
        private PRC_THEKHODataTable tablePRC_THEKHO;
        private PRC_TINHTIENBANKINHDataTable tablePRC_TINHTIENBANKINH;
        private PRC_TKCTKBCKHDataTable tablePRC_TKCTKBCKH;
        private PRC_TKKNDataTable tablePRC_TKKN;
        private PRC_TKKXDataTable tablePRC_TKKX;
        private PRC_TONKHODataTable tablePRC_TONKHO;
        private PRC_XNTKKDataTable tablePRC_XNTKK;
        private viewInPhieuNhapDataTable tableviewInPhieuNhap;
        private viewInPhieuXuatDataTable tableviewInPhieuXuat;

        public dsDataset()
        {
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
        }

        protected dsDataset(SerializationInfo info, StreamingContext context)
        {
            string s = (string) info.GetValue("XmlSchema", typeof(string));
            if (s != null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                if (dataSet.Tables["PRC_TINHTIENBANKINH"] != null)
                {
                    base.Tables.Add(new PRC_TINHTIENBANKINHDataTable(dataSet.Tables["PRC_TINHTIENBANKINH"]));
                }
                if (dataSet.Tables["PRC_XNTKK"] != null)
                {
                    base.Tables.Add(new PRC_XNTKKDataTable(dataSet.Tables["PRC_XNTKK"]));
                }
                if (dataSet.Tables["PRC_BCNHAPKHO"] != null)
                {
                    base.Tables.Add(new PRC_BCNHAPKHODataTable(dataSet.Tables["PRC_BCNHAPKHO"]));
                }
                if (dataSet.Tables["PRC_BCXUATKHO"] != null)
                {
                    base.Tables.Add(new PRC_BCXUATKHODataTable(dataSet.Tables["PRC_BCXUATKHO"]));
                }
                if (dataSet.Tables["PRC_THEKHO"] != null)
                {
                    base.Tables.Add(new PRC_THEKHODataTable(dataSet.Tables["PRC_THEKHO"]));
                }
                if (dataSet.Tables["PRC_TKKN"] != null)
                {
                    base.Tables.Add(new PRC_TKKNDataTable(dataSet.Tables["PRC_TKKN"]));
                }
                if (dataSet.Tables["PRC_TKKX"] != null)
                {
                    base.Tables.Add(new PRC_TKKXDataTable(dataSet.Tables["PRC_TKKX"]));
                }
                if (dataSet.Tables["PRC_TKCTKBCKH"] != null)
                {
                    base.Tables.Add(new PRC_TKCTKBCKHDataTable(dataSet.Tables["PRC_TKCTKBCKH"]));
                }
                if (dataSet.Tables["PRC_TONKHO"] != null)
                {
                    base.Tables.Add(new PRC_TONKHODataTable(dataSet.Tables["PRC_TONKHO"]));
                }
                if (dataSet.Tables["viewInPhieuXuat"] != null)
                {
                    base.Tables.Add(new viewInPhieuXuatDataTable(dataSet.Tables["viewInPhieuXuat"]));
                }
                if (dataSet.Tables["viewInPhieuNhap"] != null)
                {
                    base.Tables.Add(new viewInPhieuNhapDataTable(dataSet.Tables["viewInPhieuNhap"]));
                }
                base.DataSetName = dataSet.DataSetName;
                base.Prefix = dataSet.Prefix;
                base.Namespace = dataSet.Namespace;
                base.Locale = dataSet.Locale;
                base.CaseSensitive = dataSet.CaseSensitive;
                base.EnforceConstraints = dataSet.EnforceConstraints;
                base.Merge(dataSet, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                this.InitClass();
            }
            base.GetSerializationData(info, context);
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
        }

        public override DataSet Clone()
        {
            dsDataset dataset = (dsDataset) base.Clone();
            dataset.InitVars();
            return dataset;
        }

        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            base.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        private void InitClass()
        {
            base.DataSetName = "dsDataset";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/dsDataset.xsd";
            base.Locale = new CultureInfo("en-US");
            base.CaseSensitive = false;
            base.EnforceConstraints = true;
            this.tablePRC_TINHTIENBANKINH = new PRC_TINHTIENBANKINHDataTable();
            base.Tables.Add(this.tablePRC_TINHTIENBANKINH);
            this.tablePRC_XNTKK = new PRC_XNTKKDataTable();
            base.Tables.Add(this.tablePRC_XNTKK);
            this.tablePRC_BCNHAPKHO = new PRC_BCNHAPKHODataTable();
            base.Tables.Add(this.tablePRC_BCNHAPKHO);
            this.tablePRC_BCXUATKHO = new PRC_BCXUATKHODataTable();
            base.Tables.Add(this.tablePRC_BCXUATKHO);
            this.tablePRC_THEKHO = new PRC_THEKHODataTable();
            base.Tables.Add(this.tablePRC_THEKHO);
            this.tablePRC_TKKN = new PRC_TKKNDataTable();
            base.Tables.Add(this.tablePRC_TKKN);
            this.tablePRC_TKKX = new PRC_TKKXDataTable();
            base.Tables.Add(this.tablePRC_TKKX);
            this.tablePRC_TKCTKBCKH = new PRC_TKCTKBCKHDataTable();
            base.Tables.Add(this.tablePRC_TKCTKBCKH);
            this.tablePRC_TONKHO = new PRC_TONKHODataTable();
            base.Tables.Add(this.tablePRC_TONKHO);
            this.tableviewInPhieuXuat = new viewInPhieuXuatDataTable();
            base.Tables.Add(this.tableviewInPhieuXuat);
            this.tableviewInPhieuNhap = new viewInPhieuNhapDataTable();
            base.Tables.Add(this.tableviewInPhieuNhap);
        }

        internal void InitVars()
        {
            this.tablePRC_TINHTIENBANKINH = (PRC_TINHTIENBANKINHDataTable) base.Tables["PRC_TINHTIENBANKINH"];
            if (this.tablePRC_TINHTIENBANKINH != null)
            {
                this.tablePRC_TINHTIENBANKINH.InitVars();
            }
            this.tablePRC_XNTKK = (PRC_XNTKKDataTable) base.Tables["PRC_XNTKK"];
            if (this.tablePRC_XNTKK != null)
            {
                this.tablePRC_XNTKK.InitVars();
            }
            this.tablePRC_BCNHAPKHO = (PRC_BCNHAPKHODataTable) base.Tables["PRC_BCNHAPKHO"];
            if (this.tablePRC_BCNHAPKHO != null)
            {
                this.tablePRC_BCNHAPKHO.InitVars();
            }
            this.tablePRC_BCXUATKHO = (PRC_BCXUATKHODataTable) base.Tables["PRC_BCXUATKHO"];
            if (this.tablePRC_BCXUATKHO != null)
            {
                this.tablePRC_BCXUATKHO.InitVars();
            }
            this.tablePRC_THEKHO = (PRC_THEKHODataTable) base.Tables["PRC_THEKHO"];
            if (this.tablePRC_THEKHO != null)
            {
                this.tablePRC_THEKHO.InitVars();
            }
            this.tablePRC_TKKN = (PRC_TKKNDataTable) base.Tables["PRC_TKKN"];
            if (this.tablePRC_TKKN != null)
            {
                this.tablePRC_TKKN.InitVars();
            }
            this.tablePRC_TKKX = (PRC_TKKXDataTable) base.Tables["PRC_TKKX"];
            if (this.tablePRC_TKKX != null)
            {
                this.tablePRC_TKKX.InitVars();
            }
            this.tablePRC_TKCTKBCKH = (PRC_TKCTKBCKHDataTable) base.Tables["PRC_TKCTKBCKH"];
            if (this.tablePRC_TKCTKBCKH != null)
            {
                this.tablePRC_TKCTKBCKH.InitVars();
            }
            this.tablePRC_TONKHO = (PRC_TONKHODataTable) base.Tables["PRC_TONKHO"];
            if (this.tablePRC_TONKHO != null)
            {
                this.tablePRC_TONKHO.InitVars();
            }
            this.tableviewInPhieuXuat = (viewInPhieuXuatDataTable) base.Tables["viewInPhieuXuat"];
            if (this.tableviewInPhieuXuat != null)
            {
                this.tableviewInPhieuXuat.InitVars();
            }
            this.tableviewInPhieuNhap = (viewInPhieuNhapDataTable) base.Tables["viewInPhieuNhap"];
            if (this.tableviewInPhieuNhap != null)
            {
                this.tableviewInPhieuNhap.InitVars();
            }
        }

        protected override void ReadXmlSerializable(XmlReader reader)
        {
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["PRC_TINHTIENBANKINH"] != null)
            {
                base.Tables.Add(new PRC_TINHTIENBANKINHDataTable(dataSet.Tables["PRC_TINHTIENBANKINH"]));
            }
            if (dataSet.Tables["PRC_XNTKK"] != null)
            {
                base.Tables.Add(new PRC_XNTKKDataTable(dataSet.Tables["PRC_XNTKK"]));
            }
            if (dataSet.Tables["PRC_BCNHAPKHO"] != null)
            {
                base.Tables.Add(new PRC_BCNHAPKHODataTable(dataSet.Tables["PRC_BCNHAPKHO"]));
            }
            if (dataSet.Tables["PRC_BCXUATKHO"] != null)
            {
                base.Tables.Add(new PRC_BCXUATKHODataTable(dataSet.Tables["PRC_BCXUATKHO"]));
            }
            if (dataSet.Tables["PRC_THEKHO"] != null)
            {
                base.Tables.Add(new PRC_THEKHODataTable(dataSet.Tables["PRC_THEKHO"]));
            }
            if (dataSet.Tables["PRC_TKKN"] != null)
            {
                base.Tables.Add(new PRC_TKKNDataTable(dataSet.Tables["PRC_TKKN"]));
            }
            if (dataSet.Tables["PRC_TKKX"] != null)
            {
                base.Tables.Add(new PRC_TKKXDataTable(dataSet.Tables["PRC_TKKX"]));
            }
            if (dataSet.Tables["PRC_TKCTKBCKH"] != null)
            {
                base.Tables.Add(new PRC_TKCTKBCKHDataTable(dataSet.Tables["PRC_TKCTKBCKH"]));
            }
            if (dataSet.Tables["PRC_TONKHO"] != null)
            {
                base.Tables.Add(new PRC_TONKHODataTable(dataSet.Tables["PRC_TONKHO"]));
            }
            if (dataSet.Tables["viewInPhieuXuat"] != null)
            {
                base.Tables.Add(new viewInPhieuXuatDataTable(dataSet.Tables["viewInPhieuXuat"]));
            }
            if (dataSet.Tables["viewInPhieuNhap"] != null)
            {
                base.Tables.Add(new viewInPhieuNhapDataTable(dataSet.Tables["viewInPhieuNhap"]));
            }
            base.DataSetName = dataSet.DataSetName;
            base.Prefix = dataSet.Prefix;
            base.Namespace = dataSet.Namespace;
            base.Locale = dataSet.Locale;
            base.CaseSensitive = dataSet.CaseSensitive;
            base.EnforceConstraints = dataSet.EnforceConstraints;
            base.Merge(dataSet, false, MissingSchemaAction.Add);
            this.InitVars();
        }

        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        private bool ShouldSerializePRC_BCNHAPKHO()
        {
            return false;
        }

        private bool ShouldSerializePRC_BCXUATKHO()
        {
            return false;
        }

        private bool ShouldSerializePRC_THEKHO()
        {
            return false;
        }

        private bool ShouldSerializePRC_TINHTIENBANKINH()
        {
            return false;
        }

        private bool ShouldSerializePRC_TKCTKBCKH()
        {
            return false;
        }

        private bool ShouldSerializePRC_TKKN()
        {
            return false;
        }

        private bool ShouldSerializePRC_TKKX()
        {
            return false;
        }

        private bool ShouldSerializePRC_TONKHO()
        {
            return false;
        }

        private bool ShouldSerializePRC_XNTKK()
        {
            return false;
        }

        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        private bool ShouldSerializeviewInPhieuNhap()
        {
            return false;
        }

        private bool ShouldSerializeviewInPhieuXuat()
        {
            return false;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PRC_BCNHAPKHODataTable PRC_BCNHAPKHO
        {
            get
            {
                return this.tablePRC_BCNHAPKHO;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PRC_BCXUATKHODataTable PRC_BCXUATKHO
        {
            get
            {
                return this.tablePRC_BCXUATKHO;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PRC_THEKHODataTable PRC_THEKHO
        {
            get
            {
                return this.tablePRC_THEKHO;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PRC_TINHTIENBANKINHDataTable PRC_TINHTIENBANKINH
        {
            get
            {
                return this.tablePRC_TINHTIENBANKINH;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PRC_TKCTKBCKHDataTable PRC_TKCTKBCKH
        {
            get
            {
                return this.tablePRC_TKCTKBCKH;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PRC_TKKNDataTable PRC_TKKN
        {
            get
            {
                return this.tablePRC_TKKN;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public PRC_TKKXDataTable PRC_TKKX
        {
            get
            {
                return this.tablePRC_TKKX;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PRC_TONKHODataTable PRC_TONKHO
        {
            get
            {
                return this.tablePRC_TONKHO;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PRC_XNTKKDataTable PRC_XNTKK
        {
            get
            {
                return this.tablePRC_XNTKK;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Browsable(false)]
        public viewInPhieuNhapDataTable viewInPhieuNhap
        {
            get
            {
                return this.tableviewInPhieuNhap;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public viewInPhieuXuatDataTable viewInPhieuXuat
        {
            get
            {
                return this.tableviewInPhieuXuat;
            }
        }

        [DebuggerStepThrough]
        public class PRC_BCNHAPKHODataTable : DataTable, IEnumerable
        {
            private DataColumn columnDONGIA;
            private DataColumn columnMAPHIEUNHAP;
            private DataColumn columnMAVATTU;
            private DataColumn columnNGAYNHAP;
            private DataColumn columnQUICACH;
            private DataColumn columnSOLUONG;
            private DataColumn columnTENVATTU;
            private DataColumn columnTHANHTIEN;

            public event dsDataset.PRC_BCNHAPKHORowChangeEventHandler PRC_BCNHAPKHORowChanged;

            public event dsDataset.PRC_BCNHAPKHORowChangeEventHandler PRC_BCNHAPKHORowChanging;

            public event dsDataset.PRC_BCNHAPKHORowChangeEventHandler PRC_BCNHAPKHORowDeleted;

            public event dsDataset.PRC_BCNHAPKHORowChangeEventHandler PRC_BCNHAPKHORowDeleting;

            internal PRC_BCNHAPKHODataTable() : base("PRC_BCNHAPKHO")
            {
                this.InitClass();
            }

            internal PRC_BCNHAPKHODataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
                base.DisplayExpression = table.DisplayExpression;
            }

            public void AddPRC_BCNHAPKHORow(dsDataset.PRC_BCNHAPKHORow row)
            {
                base.Rows.Add(row);
            }

            public dsDataset.PRC_BCNHAPKHORow AddPRC_BCNHAPKHORow(DateTime NGAYNHAP, int MAPHIEUNHAP, string MAVATTU, string TENVATTU, string QUICACH, double DONGIA, int SOLUONG, double THANHTIEN)
            {
                dsDataset.PRC_BCNHAPKHORow row = (dsDataset.PRC_BCNHAPKHORow) base.NewRow();
                row.ItemArray = new object[] { NGAYNHAP, MAPHIEUNHAP, MAVATTU, TENVATTU, QUICACH, DONGIA, SOLUONG, THANHTIEN };
                base.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                dsDataset.PRC_BCNHAPKHODataTable table = (dsDataset.PRC_BCNHAPKHODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new dsDataset.PRC_BCNHAPKHODataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(dsDataset.PRC_BCNHAPKHORow);
            }

            private void InitClass()
            {
                this.columnNGAYNHAP = new DataColumn("NGAYNHAP", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnNGAYNHAP);
                this.columnMAPHIEUNHAP = new DataColumn("MAPHIEUNHAP", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMAPHIEUNHAP);
                this.columnMAVATTU = new DataColumn("MAVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAVATTU);
                this.columnTENVATTU = new DataColumn("TENVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENVATTU);
                this.columnQUICACH = new DataColumn("QUICACH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnQUICACH);
                this.columnDONGIA = new DataColumn("DONGIA", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnDONGIA);
                this.columnSOLUONG = new DataColumn("SOLUONG", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSOLUONG);
                this.columnTHANHTIEN = new DataColumn("THANHTIEN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIEN);
                this.columnMAPHIEUNHAP.AllowDBNull = false;
                this.columnMAVATTU.AllowDBNull = false;
                this.columnTHANHTIEN.ReadOnly = true;
            }

            internal void InitVars()
            {
                this.columnNGAYNHAP = base.Columns["NGAYNHAP"];
                this.columnMAPHIEUNHAP = base.Columns["MAPHIEUNHAP"];
                this.columnMAVATTU = base.Columns["MAVATTU"];
                this.columnTENVATTU = base.Columns["TENVATTU"];
                this.columnQUICACH = base.Columns["QUICACH"];
                this.columnDONGIA = base.Columns["DONGIA"];
                this.columnSOLUONG = base.Columns["SOLUONG"];
                this.columnTHANHTIEN = base.Columns["THANHTIEN"];
            }

            public dsDataset.PRC_BCNHAPKHORow NewPRC_BCNHAPKHORow()
            {
                return (dsDataset.PRC_BCNHAPKHORow) base.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDataset.PRC_BCNHAPKHORow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRC_BCNHAPKHORowChanged != null)
                {
                    this.PRC_BCNHAPKHORowChanged(this, new dsDataset.PRC_BCNHAPKHORowChangeEvent((dsDataset.PRC_BCNHAPKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRC_BCNHAPKHORowChanging != null)
                {
                    this.PRC_BCNHAPKHORowChanging(this, new dsDataset.PRC_BCNHAPKHORowChangeEvent((dsDataset.PRC_BCNHAPKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PRC_BCNHAPKHORowDeleted != null)
                {
                    this.PRC_BCNHAPKHORowDeleted(this, new dsDataset.PRC_BCNHAPKHORowChangeEvent((dsDataset.PRC_BCNHAPKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRC_BCNHAPKHORowDeleting != null)
                {
                    this.PRC_BCNHAPKHORowDeleting(this, new dsDataset.PRC_BCNHAPKHORowChangeEvent((dsDataset.PRC_BCNHAPKHORow) e.Row, e.Action));
                }
            }

            public void RemovePRC_BCNHAPKHORow(dsDataset.PRC_BCNHAPKHORow row)
            {
                base.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            internal DataColumn DONGIAColumn
            {
                get
                {
                    return this.columnDONGIA;
                }
            }

            public dsDataset.PRC_BCNHAPKHORow this[int index]
            {
                get
                {
                    return (dsDataset.PRC_BCNHAPKHORow) base.Rows[index];
                }
            }

            internal DataColumn MAPHIEUNHAPColumn
            {
                get
                {
                    return this.columnMAPHIEUNHAP;
                }
            }

            internal DataColumn MAVATTUColumn
            {
                get
                {
                    return this.columnMAVATTU;
                }
            }

            internal DataColumn NGAYNHAPColumn
            {
                get
                {
                    return this.columnNGAYNHAP;
                }
            }

            internal DataColumn QUICACHColumn
            {
                get
                {
                    return this.columnQUICACH;
                }
            }

            internal DataColumn SOLUONGColumn
            {
                get
                {
                    return this.columnSOLUONG;
                }
            }

            internal DataColumn TENVATTUColumn
            {
                get
                {
                    return this.columnTENVATTU;
                }
            }

            internal DataColumn THANHTIENColumn
            {
                get
                {
                    return this.columnTHANHTIEN;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_BCNHAPKHORow : DataRow
        {
            private dsDataset.PRC_BCNHAPKHODataTable tablePRC_BCNHAPKHO;

            internal PRC_BCNHAPKHORow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRC_BCNHAPKHO = (dsDataset.PRC_BCNHAPKHODataTable) base.Table;
            }

            public bool IsDONGIANull()
            {
                return base.IsNull(this.tablePRC_BCNHAPKHO.DONGIAColumn);
            }

            public bool IsNGAYNHAPNull()
            {
                return base.IsNull(this.tablePRC_BCNHAPKHO.NGAYNHAPColumn);
            }

            public bool IsQUICACHNull()
            {
                return base.IsNull(this.tablePRC_BCNHAPKHO.QUICACHColumn);
            }

            public bool IsSOLUONGNull()
            {
                return base.IsNull(this.tablePRC_BCNHAPKHO.SOLUONGColumn);
            }

            public bool IsTENVATTUNull()
            {
                return base.IsNull(this.tablePRC_BCNHAPKHO.TENVATTUColumn);
            }

            public bool IsTHANHTIENNull()
            {
                return base.IsNull(this.tablePRC_BCNHAPKHO.THANHTIENColumn);
            }

            public void SetDONGIANull()
            {
                base[this.tablePRC_BCNHAPKHO.DONGIAColumn] = Convert.DBNull;
            }

            public void SetNGAYNHAPNull()
            {
                base[this.tablePRC_BCNHAPKHO.NGAYNHAPColumn] = Convert.DBNull;
            }

            public void SetQUICACHNull()
            {
                base[this.tablePRC_BCNHAPKHO.QUICACHColumn] = Convert.DBNull;
            }

            public void SetSOLUONGNull()
            {
                base[this.tablePRC_BCNHAPKHO.SOLUONGColumn] = Convert.DBNull;
            }

            public void SetTENVATTUNull()
            {
                base[this.tablePRC_BCNHAPKHO.TENVATTUColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENNull()
            {
                base[this.tablePRC_BCNHAPKHO.THANHTIENColumn] = Convert.DBNull;
            }

            public double DONGIA
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_BCNHAPKHO.DONGIAColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_BCNHAPKHO.DONGIAColumn] = value;
                }
            }

            public int MAPHIEUNHAP
            {
                get
                {
                    return (int) base[this.tablePRC_BCNHAPKHO.MAPHIEUNHAPColumn];
                }
                set
                {
                    base[this.tablePRC_BCNHAPKHO.MAPHIEUNHAPColumn] = value;
                }
            }

            public string MAVATTU
            {
                get
                {
                    return (string) base[this.tablePRC_BCNHAPKHO.MAVATTUColumn];
                }
                set
                {
                    base[this.tablePRC_BCNHAPKHO.MAVATTUColumn] = value;
                }
            }

            public DateTime NGAYNHAP
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tablePRC_BCNHAPKHO.NGAYNHAPColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tablePRC_BCNHAPKHO.NGAYNHAPColumn] = value;
                }
            }

            public string QUICACH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_BCNHAPKHO.QUICACHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_BCNHAPKHO.QUICACHColumn] = value;
                }
            }

            public int SOLUONG
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_BCNHAPKHO.SOLUONGColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_BCNHAPKHO.SOLUONGColumn] = value;
                }
            }

            public string TENVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_BCNHAPKHO.TENVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_BCNHAPKHO.TENVATTUColumn] = value;
                }
            }

            public double THANHTIEN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_BCNHAPKHO.THANHTIENColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_BCNHAPKHO.THANHTIENColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_BCNHAPKHORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDataset.PRC_BCNHAPKHORow eventRow;

            public PRC_BCNHAPKHORowChangeEvent(dsDataset.PRC_BCNHAPKHORow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public dsDataset.PRC_BCNHAPKHORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRC_BCNHAPKHORowChangeEventHandler(object sender, dsDataset.PRC_BCNHAPKHORowChangeEvent e);

        [DebuggerStepThrough]
        public class PRC_BCXUATKHODataTable : DataTable, IEnumerable
        {
            private DataColumn columnDONGIA;
            private DataColumn columnMAPHIEUXUAT;
            private DataColumn columnMAVATTU;
            private DataColumn columnNGAYXUAT;
            private DataColumn columnQUICACH;
            private DataColumn columnSOLUONG;
            private DataColumn columnTENVATTU;
            private DataColumn columnTHANHTIEN;

            public event dsDataset.PRC_BCXUATKHORowChangeEventHandler PRC_BCXUATKHORowChanged;

            public event dsDataset.PRC_BCXUATKHORowChangeEventHandler PRC_BCXUATKHORowChanging;

            public event dsDataset.PRC_BCXUATKHORowChangeEventHandler PRC_BCXUATKHORowDeleted;

            public event dsDataset.PRC_BCXUATKHORowChangeEventHandler PRC_BCXUATKHORowDeleting;

            internal PRC_BCXUATKHODataTable() : base("PRC_BCXUATKHO")
            {
                this.InitClass();
            }

            internal PRC_BCXUATKHODataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
                base.DisplayExpression = table.DisplayExpression;
            }

            public void AddPRC_BCXUATKHORow(dsDataset.PRC_BCXUATKHORow row)
            {
                base.Rows.Add(row);
            }

            public dsDataset.PRC_BCXUATKHORow AddPRC_BCXUATKHORow(DateTime NGAYXUAT, int MAPHIEUXUAT, string MAVATTU, string TENVATTU, string QUICACH, double DONGIA, int SOLUONG, double THANHTIEN)
            {
                dsDataset.PRC_BCXUATKHORow row = (dsDataset.PRC_BCXUATKHORow) base.NewRow();
                row.ItemArray = new object[] { NGAYXUAT, MAPHIEUXUAT, MAVATTU, TENVATTU, QUICACH, DONGIA, SOLUONG, THANHTIEN };
                base.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                dsDataset.PRC_BCXUATKHODataTable table = (dsDataset.PRC_BCXUATKHODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new dsDataset.PRC_BCXUATKHODataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(dsDataset.PRC_BCXUATKHORow);
            }

            private void InitClass()
            {
                this.columnNGAYXUAT = new DataColumn("NGAYXUAT", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnNGAYXUAT);
                this.columnMAPHIEUXUAT = new DataColumn("MAPHIEUXUAT", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMAPHIEUXUAT);
                this.columnMAVATTU = new DataColumn("MAVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAVATTU);
                this.columnTENVATTU = new DataColumn("TENVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENVATTU);
                this.columnQUICACH = new DataColumn("QUICACH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnQUICACH);
                this.columnDONGIA = new DataColumn("DONGIA", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnDONGIA);
                this.columnSOLUONG = new DataColumn("SOLUONG", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSOLUONG);
                this.columnTHANHTIEN = new DataColumn("THANHTIEN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIEN);
                this.columnMAPHIEUXUAT.AllowDBNull = false;
                this.columnMAVATTU.AllowDBNull = false;
                this.columnTHANHTIEN.ReadOnly = true;
            }

            internal void InitVars()
            {
                this.columnNGAYXUAT = base.Columns["NGAYXUAT"];
                this.columnMAPHIEUXUAT = base.Columns["MAPHIEUXUAT"];
                this.columnMAVATTU = base.Columns["MAVATTU"];
                this.columnTENVATTU = base.Columns["TENVATTU"];
                this.columnQUICACH = base.Columns["QUICACH"];
                this.columnDONGIA = base.Columns["DONGIA"];
                this.columnSOLUONG = base.Columns["SOLUONG"];
                this.columnTHANHTIEN = base.Columns["THANHTIEN"];
            }

            public dsDataset.PRC_BCXUATKHORow NewPRC_BCXUATKHORow()
            {
                return (dsDataset.PRC_BCXUATKHORow) base.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDataset.PRC_BCXUATKHORow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRC_BCXUATKHORowChanged != null)
                {
                    this.PRC_BCXUATKHORowChanged(this, new dsDataset.PRC_BCXUATKHORowChangeEvent((dsDataset.PRC_BCXUATKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRC_BCXUATKHORowChanging != null)
                {
                    this.PRC_BCXUATKHORowChanging(this, new dsDataset.PRC_BCXUATKHORowChangeEvent((dsDataset.PRC_BCXUATKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PRC_BCXUATKHORowDeleted != null)
                {
                    this.PRC_BCXUATKHORowDeleted(this, new dsDataset.PRC_BCXUATKHORowChangeEvent((dsDataset.PRC_BCXUATKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRC_BCXUATKHORowDeleting != null)
                {
                    this.PRC_BCXUATKHORowDeleting(this, new dsDataset.PRC_BCXUATKHORowChangeEvent((dsDataset.PRC_BCXUATKHORow) e.Row, e.Action));
                }
            }

            public void RemovePRC_BCXUATKHORow(dsDataset.PRC_BCXUATKHORow row)
            {
                base.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            internal DataColumn DONGIAColumn
            {
                get
                {
                    return this.columnDONGIA;
                }
            }

            public dsDataset.PRC_BCXUATKHORow this[int index]
            {
                get
                {
                    return (dsDataset.PRC_BCXUATKHORow) base.Rows[index];
                }
            }

            internal DataColumn MAPHIEUXUATColumn
            {
                get
                {
                    return this.columnMAPHIEUXUAT;
                }
            }

            internal DataColumn MAVATTUColumn
            {
                get
                {
                    return this.columnMAVATTU;
                }
            }

            internal DataColumn NGAYXUATColumn
            {
                get
                {
                    return this.columnNGAYXUAT;
                }
            }

            internal DataColumn QUICACHColumn
            {
                get
                {
                    return this.columnQUICACH;
                }
            }

            internal DataColumn SOLUONGColumn
            {
                get
                {
                    return this.columnSOLUONG;
                }
            }

            internal DataColumn TENVATTUColumn
            {
                get
                {
                    return this.columnTENVATTU;
                }
            }

            internal DataColumn THANHTIENColumn
            {
                get
                {
                    return this.columnTHANHTIEN;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_BCXUATKHORow : DataRow
        {
            private dsDataset.PRC_BCXUATKHODataTable tablePRC_BCXUATKHO;

            internal PRC_BCXUATKHORow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRC_BCXUATKHO = (dsDataset.PRC_BCXUATKHODataTable) base.Table;
            }

            public bool IsDONGIANull()
            {
                return base.IsNull(this.tablePRC_BCXUATKHO.DONGIAColumn);
            }

            public bool IsNGAYXUATNull()
            {
                return base.IsNull(this.tablePRC_BCXUATKHO.NGAYXUATColumn);
            }

            public bool IsQUICACHNull()
            {
                return base.IsNull(this.tablePRC_BCXUATKHO.QUICACHColumn);
            }

            public bool IsSOLUONGNull()
            {
                return base.IsNull(this.tablePRC_BCXUATKHO.SOLUONGColumn);
            }

            public bool IsTENVATTUNull()
            {
                return base.IsNull(this.tablePRC_BCXUATKHO.TENVATTUColumn);
            }

            public bool IsTHANHTIENNull()
            {
                return base.IsNull(this.tablePRC_BCXUATKHO.THANHTIENColumn);
            }

            public void SetDONGIANull()
            {
                base[this.tablePRC_BCXUATKHO.DONGIAColumn] = Convert.DBNull;
            }

            public void SetNGAYXUATNull()
            {
                base[this.tablePRC_BCXUATKHO.NGAYXUATColumn] = Convert.DBNull;
            }

            public void SetQUICACHNull()
            {
                base[this.tablePRC_BCXUATKHO.QUICACHColumn] = Convert.DBNull;
            }

            public void SetSOLUONGNull()
            {
                base[this.tablePRC_BCXUATKHO.SOLUONGColumn] = Convert.DBNull;
            }

            public void SetTENVATTUNull()
            {
                base[this.tablePRC_BCXUATKHO.TENVATTUColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENNull()
            {
                base[this.tablePRC_BCXUATKHO.THANHTIENColumn] = Convert.DBNull;
            }

            public double DONGIA
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_BCXUATKHO.DONGIAColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_BCXUATKHO.DONGIAColumn] = value;
                }
            }

            public int MAPHIEUXUAT
            {
                get
                {
                    return (int) base[this.tablePRC_BCXUATKHO.MAPHIEUXUATColumn];
                }
                set
                {
                    base[this.tablePRC_BCXUATKHO.MAPHIEUXUATColumn] = value;
                }
            }

            public string MAVATTU
            {
                get
                {
                    return (string) base[this.tablePRC_BCXUATKHO.MAVATTUColumn];
                }
                set
                {
                    base[this.tablePRC_BCXUATKHO.MAVATTUColumn] = value;
                }
            }

            public DateTime NGAYXUAT
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tablePRC_BCXUATKHO.NGAYXUATColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tablePRC_BCXUATKHO.NGAYXUATColumn] = value;
                }
            }

            public string QUICACH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_BCXUATKHO.QUICACHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_BCXUATKHO.QUICACHColumn] = value;
                }
            }

            public int SOLUONG
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_BCXUATKHO.SOLUONGColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_BCXUATKHO.SOLUONGColumn] = value;
                }
            }

            public string TENVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_BCXUATKHO.TENVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_BCXUATKHO.TENVATTUColumn] = value;
                }
            }

            public double THANHTIEN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_BCXUATKHO.THANHTIENColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_BCXUATKHO.THANHTIENColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_BCXUATKHORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDataset.PRC_BCXUATKHORow eventRow;

            public PRC_BCXUATKHORowChangeEvent(dsDataset.PRC_BCXUATKHORow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public dsDataset.PRC_BCXUATKHORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRC_BCXUATKHORowChangeEventHandler(object sender, dsDataset.PRC_BCXUATKHORowChangeEvent e);

        [DebuggerStepThrough]
        public class PRC_THEKHODataTable : DataTable, IEnumerable
        {
            private DataColumn columnDENNGAY;
            private DataColumn columnMAPHIEU;
            private DataColumn columnMAVATTU;
            private DataColumn columnNGAYLAP;
            private DataColumn columnQUICACH;
            private DataColumn columnSLN;
            private DataColumn columnSLX;
            private DataColumn columnTENLIDO;
            private DataColumn columnTENVATTU;
            private DataColumn columnTUNGAY;

            public event dsDataset.PRC_THEKHORowChangeEventHandler PRC_THEKHORowChanged;

            public event dsDataset.PRC_THEKHORowChangeEventHandler PRC_THEKHORowChanging;

            public event dsDataset.PRC_THEKHORowChangeEventHandler PRC_THEKHORowDeleted;

            public event dsDataset.PRC_THEKHORowChangeEventHandler PRC_THEKHORowDeleting;

            internal PRC_THEKHODataTable() : base("PRC_THEKHO")
            {
                this.InitClass();
            }

            internal PRC_THEKHODataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
                base.DisplayExpression = table.DisplayExpression;
            }

            public void AddPRC_THEKHORow(dsDataset.PRC_THEKHORow row)
            {
                base.Rows.Add(row);
            }

            public dsDataset.PRC_THEKHORow AddPRC_THEKHORow(string TUNGAY, string DENNGAY, string MAVATTU, string TENVATTU, string QUICACH, string MAPHIEU, DateTime NGAYLAP, string TENLIDO, int SLN, int SLX)
            {
                dsDataset.PRC_THEKHORow row = (dsDataset.PRC_THEKHORow) base.NewRow();
                row.ItemArray = new object[] { TUNGAY, DENNGAY, MAVATTU, TENVATTU, QUICACH, MAPHIEU, NGAYLAP, TENLIDO, SLN, SLX };
                base.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                dsDataset.PRC_THEKHODataTable table = (dsDataset.PRC_THEKHODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new dsDataset.PRC_THEKHODataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(dsDataset.PRC_THEKHORow);
            }

            private void InitClass()
            {
                this.columnTUNGAY = new DataColumn("TUNGAY", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTUNGAY);
                this.columnDENNGAY = new DataColumn("DENNGAY", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDENNGAY);
                this.columnMAVATTU = new DataColumn("MAVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAVATTU);
                this.columnTENVATTU = new DataColumn("TENVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENVATTU);
                this.columnQUICACH = new DataColumn("QUICACH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnQUICACH);
                this.columnMAPHIEU = new DataColumn("MAPHIEU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAPHIEU);
                this.columnNGAYLAP = new DataColumn("NGAYLAP", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnNGAYLAP);
                this.columnTENLIDO = new DataColumn("TENLIDO", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENLIDO);
                this.columnSLN = new DataColumn("SLN", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSLN);
                this.columnSLX = new DataColumn("SLX", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSLX);
            }

            internal void InitVars()
            {
                this.columnTUNGAY = base.Columns["TUNGAY"];
                this.columnDENNGAY = base.Columns["DENNGAY"];
                this.columnMAVATTU = base.Columns["MAVATTU"];
                this.columnTENVATTU = base.Columns["TENVATTU"];
                this.columnQUICACH = base.Columns["QUICACH"];
                this.columnMAPHIEU = base.Columns["MAPHIEU"];
                this.columnNGAYLAP = base.Columns["NGAYLAP"];
                this.columnTENLIDO = base.Columns["TENLIDO"];
                this.columnSLN = base.Columns["SLN"];
                this.columnSLX = base.Columns["SLX"];
            }

            public dsDataset.PRC_THEKHORow NewPRC_THEKHORow()
            {
                return (dsDataset.PRC_THEKHORow) base.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDataset.PRC_THEKHORow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRC_THEKHORowChanged != null)
                {
                    this.PRC_THEKHORowChanged(this, new dsDataset.PRC_THEKHORowChangeEvent((dsDataset.PRC_THEKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRC_THEKHORowChanging != null)
                {
                    this.PRC_THEKHORowChanging(this, new dsDataset.PRC_THEKHORowChangeEvent((dsDataset.PRC_THEKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PRC_THEKHORowDeleted != null)
                {
                    this.PRC_THEKHORowDeleted(this, new dsDataset.PRC_THEKHORowChangeEvent((dsDataset.PRC_THEKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRC_THEKHORowDeleting != null)
                {
                    this.PRC_THEKHORowDeleting(this, new dsDataset.PRC_THEKHORowChangeEvent((dsDataset.PRC_THEKHORow) e.Row, e.Action));
                }
            }

            public void RemovePRC_THEKHORow(dsDataset.PRC_THEKHORow row)
            {
                base.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            internal DataColumn DENNGAYColumn
            {
                get
                {
                    return this.columnDENNGAY;
                }
            }

            public dsDataset.PRC_THEKHORow this[int index]
            {
                get
                {
                    return (dsDataset.PRC_THEKHORow) base.Rows[index];
                }
            }

            internal DataColumn MAPHIEUColumn
            {
                get
                {
                    return this.columnMAPHIEU;
                }
            }

            internal DataColumn MAVATTUColumn
            {
                get
                {
                    return this.columnMAVATTU;
                }
            }

            internal DataColumn NGAYLAPColumn
            {
                get
                {
                    return this.columnNGAYLAP;
                }
            }

            internal DataColumn QUICACHColumn
            {
                get
                {
                    return this.columnQUICACH;
                }
            }

            internal DataColumn SLNColumn
            {
                get
                {
                    return this.columnSLN;
                }
            }

            internal DataColumn SLXColumn
            {
                get
                {
                    return this.columnSLX;
                }
            }

            internal DataColumn TENLIDOColumn
            {
                get
                {
                    return this.columnTENLIDO;
                }
            }

            internal DataColumn TENVATTUColumn
            {
                get
                {
                    return this.columnTENVATTU;
                }
            }

            internal DataColumn TUNGAYColumn
            {
                get
                {
                    return this.columnTUNGAY;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_THEKHORow : DataRow
        {
            private dsDataset.PRC_THEKHODataTable tablePRC_THEKHO;

            internal PRC_THEKHORow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRC_THEKHO = (dsDataset.PRC_THEKHODataTable) base.Table;
            }

            public bool IsDENNGAYNull()
            {
                return base.IsNull(this.tablePRC_THEKHO.DENNGAYColumn);
            }

            public bool IsMAPHIEUNull()
            {
                return base.IsNull(this.tablePRC_THEKHO.MAPHIEUColumn);
            }

            public bool IsMAVATTUNull()
            {
                return base.IsNull(this.tablePRC_THEKHO.MAVATTUColumn);
            }

            public bool IsNGAYLAPNull()
            {
                return base.IsNull(this.tablePRC_THEKHO.NGAYLAPColumn);
            }

            public bool IsQUICACHNull()
            {
                return base.IsNull(this.tablePRC_THEKHO.QUICACHColumn);
            }

            public bool IsSLNNull()
            {
                return base.IsNull(this.tablePRC_THEKHO.SLNColumn);
            }

            public bool IsSLXNull()
            {
                return base.IsNull(this.tablePRC_THEKHO.SLXColumn);
            }

            public bool IsTENLIDONull()
            {
                return base.IsNull(this.tablePRC_THEKHO.TENLIDOColumn);
            }

            public bool IsTENVATTUNull()
            {
                return base.IsNull(this.tablePRC_THEKHO.TENVATTUColumn);
            }

            public bool IsTUNGAYNull()
            {
                return base.IsNull(this.tablePRC_THEKHO.TUNGAYColumn);
            }

            public void SetDENNGAYNull()
            {
                base[this.tablePRC_THEKHO.DENNGAYColumn] = Convert.DBNull;
            }

            public void SetMAPHIEUNull()
            {
                base[this.tablePRC_THEKHO.MAPHIEUColumn] = Convert.DBNull;
            }

            public void SetMAVATTUNull()
            {
                base[this.tablePRC_THEKHO.MAVATTUColumn] = Convert.DBNull;
            }

            public void SetNGAYLAPNull()
            {
                base[this.tablePRC_THEKHO.NGAYLAPColumn] = Convert.DBNull;
            }

            public void SetQUICACHNull()
            {
                base[this.tablePRC_THEKHO.QUICACHColumn] = Convert.DBNull;
            }

            public void SetSLNNull()
            {
                base[this.tablePRC_THEKHO.SLNColumn] = Convert.DBNull;
            }

            public void SetSLXNull()
            {
                base[this.tablePRC_THEKHO.SLXColumn] = Convert.DBNull;
            }

            public void SetTENLIDONull()
            {
                base[this.tablePRC_THEKHO.TENLIDOColumn] = Convert.DBNull;
            }

            public void SetTENVATTUNull()
            {
                base[this.tablePRC_THEKHO.TENVATTUColumn] = Convert.DBNull;
            }

            public void SetTUNGAYNull()
            {
                base[this.tablePRC_THEKHO.TUNGAYColumn] = Convert.DBNull;
            }

            public string DENNGAY
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_THEKHO.DENNGAYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_THEKHO.DENNGAYColumn] = value;
                }
            }

            public string MAPHIEU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_THEKHO.MAPHIEUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_THEKHO.MAPHIEUColumn] = value;
                }
            }

            public string MAVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_THEKHO.MAVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_THEKHO.MAVATTUColumn] = value;
                }
            }

            public DateTime NGAYLAP
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tablePRC_THEKHO.NGAYLAPColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tablePRC_THEKHO.NGAYLAPColumn] = value;
                }
            }

            public string QUICACH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_THEKHO.QUICACHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_THEKHO.QUICACHColumn] = value;
                }
            }

            public int SLN
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_THEKHO.SLNColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_THEKHO.SLNColumn] = value;
                }
            }

            public int SLX
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_THEKHO.SLXColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_THEKHO.SLXColumn] = value;
                }
            }

            public string TENLIDO
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_THEKHO.TENLIDOColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_THEKHO.TENLIDOColumn] = value;
                }
            }

            public string TENVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_THEKHO.TENVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_THEKHO.TENVATTUColumn] = value;
                }
            }

            public string TUNGAY
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_THEKHO.TUNGAYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_THEKHO.TUNGAYColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_THEKHORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDataset.PRC_THEKHORow eventRow;

            public PRC_THEKHORowChangeEvent(dsDataset.PRC_THEKHORow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public dsDataset.PRC_THEKHORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRC_THEKHORowChangeEventHandler(object sender, dsDataset.PRC_THEKHORowChangeEvent e);

        [DebuggerStepThrough]
        public class PRC_TINHTIENBANKINHDataTable : DataTable, IEnumerable
        {
            private DataColumn columnColumn1;
            private DataColumn columnColumn2;
            private DataColumn columnMANVTHU;
            private DataColumn columnTENNHANVIEN;
            private DataColumn columnTIENTHU;
            private DataColumn columnTIENTRA;
            private DataColumn columnTONGTIEN;

            public event dsDataset.PRC_TINHTIENBANKINHRowChangeEventHandler PRC_TINHTIENBANKINHRowChanged;

            public event dsDataset.PRC_TINHTIENBANKINHRowChangeEventHandler PRC_TINHTIENBANKINHRowChanging;

            public event dsDataset.PRC_TINHTIENBANKINHRowChangeEventHandler PRC_TINHTIENBANKINHRowDeleted;

            public event dsDataset.PRC_TINHTIENBANKINHRowChangeEventHandler PRC_TINHTIENBANKINHRowDeleting;

            internal PRC_TINHTIENBANKINHDataTable() : base("PRC_TINHTIENBANKINH")
            {
                this.InitClass();
            }

            internal PRC_TINHTIENBANKINHDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
                base.DisplayExpression = table.DisplayExpression;
            }

            public void AddPRC_TINHTIENBANKINHRow(dsDataset.PRC_TINHTIENBANKINHRow row)
            {
                base.Rows.Add(row);
            }

            public dsDataset.PRC_TINHTIENBANKINHRow AddPRC_TINHTIENBANKINHRow(string Column1, string Column2, int MANVTHU, double TIENTHU, double TIENTRA, double TONGTIEN, string TENNHANVIEN)
            {
                dsDataset.PRC_TINHTIENBANKINHRow row = (dsDataset.PRC_TINHTIENBANKINHRow) base.NewRow();
                row.ItemArray = new object[] { Column1, Column2, MANVTHU, TIENTHU, TIENTRA, TONGTIEN, TENNHANVIEN };
                base.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                dsDataset.PRC_TINHTIENBANKINHDataTable table = (dsDataset.PRC_TINHTIENBANKINHDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new dsDataset.PRC_TINHTIENBANKINHDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(dsDataset.PRC_TINHTIENBANKINHRow);
            }

            private void InitClass()
            {
                this.columnColumn1 = new DataColumn("Column1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColumn1);
                this.columnColumn2 = new DataColumn("Column2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColumn2);
                this.columnMANVTHU = new DataColumn("MANVTHU", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMANVTHU);
                this.columnTIENTHU = new DataColumn("TIENTHU", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTIENTHU);
                this.columnTIENTRA = new DataColumn("TIENTRA", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTIENTRA);
                this.columnTONGTIEN = new DataColumn("TONGTIEN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTONGTIEN);
                this.columnTENNHANVIEN = new DataColumn("TENNHANVIEN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENNHANVIEN);
                this.columnColumn1.ReadOnly = true;
                this.columnColumn2.ReadOnly = true;
                this.columnTIENTRA.ReadOnly = true;
                this.columnTONGTIEN.ReadOnly = true;
            }

            internal void InitVars()
            {
                this.columnColumn1 = base.Columns["Column1"];
                this.columnColumn2 = base.Columns["Column2"];
                this.columnMANVTHU = base.Columns["MANVTHU"];
                this.columnTIENTHU = base.Columns["TIENTHU"];
                this.columnTIENTRA = base.Columns["TIENTRA"];
                this.columnTONGTIEN = base.Columns["TONGTIEN"];
                this.columnTENNHANVIEN = base.Columns["TENNHANVIEN"];
            }

            public dsDataset.PRC_TINHTIENBANKINHRow NewPRC_TINHTIENBANKINHRow()
            {
                return (dsDataset.PRC_TINHTIENBANKINHRow) base.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDataset.PRC_TINHTIENBANKINHRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRC_TINHTIENBANKINHRowChanged != null)
                {
                    this.PRC_TINHTIENBANKINHRowChanged(this, new dsDataset.PRC_TINHTIENBANKINHRowChangeEvent((dsDataset.PRC_TINHTIENBANKINHRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRC_TINHTIENBANKINHRowChanging != null)
                {
                    this.PRC_TINHTIENBANKINHRowChanging(this, new dsDataset.PRC_TINHTIENBANKINHRowChangeEvent((dsDataset.PRC_TINHTIENBANKINHRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PRC_TINHTIENBANKINHRowDeleted != null)
                {
                    this.PRC_TINHTIENBANKINHRowDeleted(this, new dsDataset.PRC_TINHTIENBANKINHRowChangeEvent((dsDataset.PRC_TINHTIENBANKINHRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRC_TINHTIENBANKINHRowDeleting != null)
                {
                    this.PRC_TINHTIENBANKINHRowDeleting(this, new dsDataset.PRC_TINHTIENBANKINHRowChangeEvent((dsDataset.PRC_TINHTIENBANKINHRow) e.Row, e.Action));
                }
            }

            public void RemovePRC_TINHTIENBANKINHRow(dsDataset.PRC_TINHTIENBANKINHRow row)
            {
                base.Rows.Remove(row);
            }

            internal DataColumn Column1Column
            {
                get
                {
                    return this.columnColumn1;
                }
            }

            internal DataColumn Column2Column
            {
                get
                {
                    return this.columnColumn2;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            public dsDataset.PRC_TINHTIENBANKINHRow this[int index]
            {
                get
                {
                    return (dsDataset.PRC_TINHTIENBANKINHRow) base.Rows[index];
                }
            }

            internal DataColumn MANVTHUColumn
            {
                get
                {
                    return this.columnMANVTHU;
                }
            }

            internal DataColumn TENNHANVIENColumn
            {
                get
                {
                    return this.columnTENNHANVIEN;
                }
            }

            internal DataColumn TIENTHUColumn
            {
                get
                {
                    return this.columnTIENTHU;
                }
            }

            internal DataColumn TIENTRAColumn
            {
                get
                {
                    return this.columnTIENTRA;
                }
            }

            internal DataColumn TONGTIENColumn
            {
                get
                {
                    return this.columnTONGTIEN;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_TINHTIENBANKINHRow : DataRow
        {
            private dsDataset.PRC_TINHTIENBANKINHDataTable tablePRC_TINHTIENBANKINH;

            internal PRC_TINHTIENBANKINHRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRC_TINHTIENBANKINH = (dsDataset.PRC_TINHTIENBANKINHDataTable) base.Table;
            }

            public bool IsColumn1Null()
            {
                return base.IsNull(this.tablePRC_TINHTIENBANKINH.Column1Column);
            }

            public bool IsColumn2Null()
            {
                return base.IsNull(this.tablePRC_TINHTIENBANKINH.Column2Column);
            }

            public bool IsMANVTHUNull()
            {
                return base.IsNull(this.tablePRC_TINHTIENBANKINH.MANVTHUColumn);
            }

            public bool IsTENNHANVIENNull()
            {
                return base.IsNull(this.tablePRC_TINHTIENBANKINH.TENNHANVIENColumn);
            }

            public bool IsTIENTHUNull()
            {
                return base.IsNull(this.tablePRC_TINHTIENBANKINH.TIENTHUColumn);
            }

            public bool IsTIENTRANull()
            {
                return base.IsNull(this.tablePRC_TINHTIENBANKINH.TIENTRAColumn);
            }

            public bool IsTONGTIENNull()
            {
                return base.IsNull(this.tablePRC_TINHTIENBANKINH.TONGTIENColumn);
            }

            public void SetColumn1Null()
            {
                base[this.tablePRC_TINHTIENBANKINH.Column1Column] = Convert.DBNull;
            }

            public void SetColumn2Null()
            {
                base[this.tablePRC_TINHTIENBANKINH.Column2Column] = Convert.DBNull;
            }

            public void SetMANVTHUNull()
            {
                base[this.tablePRC_TINHTIENBANKINH.MANVTHUColumn] = Convert.DBNull;
            }

            public void SetTENNHANVIENNull()
            {
                base[this.tablePRC_TINHTIENBANKINH.TENNHANVIENColumn] = Convert.DBNull;
            }

            public void SetTIENTHUNull()
            {
                base[this.tablePRC_TINHTIENBANKINH.TIENTHUColumn] = Convert.DBNull;
            }

            public void SetTIENTRANull()
            {
                base[this.tablePRC_TINHTIENBANKINH.TIENTRAColumn] = Convert.DBNull;
            }

            public void SetTONGTIENNull()
            {
                base[this.tablePRC_TINHTIENBANKINH.TONGTIENColumn] = Convert.DBNull;
            }

            public string Column1
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TINHTIENBANKINH.Column1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TINHTIENBANKINH.Column1Column] = value;
                }
            }

            public string Column2
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TINHTIENBANKINH.Column2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TINHTIENBANKINH.Column2Column] = value;
                }
            }

            public int MANVTHU
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_TINHTIENBANKINH.MANVTHUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TINHTIENBANKINH.MANVTHUColumn] = value;
                }
            }

            public string TENNHANVIEN
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TINHTIENBANKINH.TENNHANVIENColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TINHTIENBANKINH.TENNHANVIENColumn] = value;
                }
            }

            public double TIENTHU
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TINHTIENBANKINH.TIENTHUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TINHTIENBANKINH.TIENTHUColumn] = value;
                }
            }

            public double TIENTRA
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TINHTIENBANKINH.TIENTRAColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TINHTIENBANKINH.TIENTRAColumn] = value;
                }
            }

            public double TONGTIEN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TINHTIENBANKINH.TONGTIENColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TINHTIENBANKINH.TONGTIENColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_TINHTIENBANKINHRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDataset.PRC_TINHTIENBANKINHRow eventRow;

            public PRC_TINHTIENBANKINHRowChangeEvent(dsDataset.PRC_TINHTIENBANKINHRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public dsDataset.PRC_TINHTIENBANKINHRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRC_TINHTIENBANKINHRowChangeEventHandler(object sender, dsDataset.PRC_TINHTIENBANKINHRowChangeEvent e);

        [DebuggerStepThrough]
        public class PRC_TKCTKBCKHDataTable : DataTable, IEnumerable
        {
            private DataColumn columnColumn1;
            private DataColumn columnColumn2;
            private DataColumn columnGIABAN;
            private DataColumn columnMAPHIEUXUAT;
            private DataColumn columnMAVATTU;
            private DataColumn columnNGAYBAN;
            private DataColumn columnQUICACH;
            private DataColumn columnSL;
            private DataColumn columnTENKHACHHANG;
            private DataColumn columnTENNHANVIEN;
            private DataColumn columnTENVATTU;
            private DataColumn columnTHANHTIEN;

            public event dsDataset.PRC_TKCTKBCKHRowChangeEventHandler PRC_TKCTKBCKHRowChanged;

            public event dsDataset.PRC_TKCTKBCKHRowChangeEventHandler PRC_TKCTKBCKHRowChanging;

            public event dsDataset.PRC_TKCTKBCKHRowChangeEventHandler PRC_TKCTKBCKHRowDeleted;

            public event dsDataset.PRC_TKCTKBCKHRowChangeEventHandler PRC_TKCTKBCKHRowDeleting;

            internal PRC_TKCTKBCKHDataTable() : base("PRC_TKCTKBCKH")
            {
                this.InitClass();
            }

            internal PRC_TKCTKBCKHDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
                base.DisplayExpression = table.DisplayExpression;
            }

            public void AddPRC_TKCTKBCKHRow(dsDataset.PRC_TKCTKBCKHRow row)
            {
                base.Rows.Add(row);
            }

            public dsDataset.PRC_TKCTKBCKHRow AddPRC_TKCTKBCKHRow(string Column1, string Column2, string TENKHACHHANG, string NGAYBAN, string MAVATTU, string TENVATTU, string QUICACH, int SL, double GIABAN, double THANHTIEN, string TENNHANVIEN)
            {
                dsDataset.PRC_TKCTKBCKHRow row = (dsDataset.PRC_TKCTKBCKHRow) base.NewRow();
                object[] objArray = new object[12];
                objArray[0] = Column1;
                objArray[1] = Column2;
                objArray[2] = TENKHACHHANG;
                objArray[4] = NGAYBAN;
                objArray[5] = MAVATTU;
                objArray[6] = TENVATTU;
                objArray[7] = QUICACH;
                objArray[8] = SL;
                objArray[9] = GIABAN;
                objArray[10] = THANHTIEN;
                objArray[11] = TENNHANVIEN;
                row.ItemArray = objArray;
                base.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                dsDataset.PRC_TKCTKBCKHDataTable table = (dsDataset.PRC_TKCTKBCKHDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new dsDataset.PRC_TKCTKBCKHDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(dsDataset.PRC_TKCTKBCKHRow);
            }

            private void InitClass()
            {
                this.columnColumn1 = new DataColumn("Column1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColumn1);
                this.columnColumn2 = new DataColumn("Column2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnColumn2);
                this.columnTENKHACHHANG = new DataColumn("TENKHACHHANG", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENKHACHHANG);
                this.columnMAPHIEUXUAT = new DataColumn("MAPHIEUXUAT", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMAPHIEUXUAT);
                this.columnNGAYBAN = new DataColumn("NGAYBAN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNGAYBAN);
                this.columnMAVATTU = new DataColumn("MAVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAVATTU);
                this.columnTENVATTU = new DataColumn("TENVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENVATTU);
                this.columnQUICACH = new DataColumn("QUICACH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnQUICACH);
                this.columnSL = new DataColumn("SL", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSL);
                this.columnGIABAN = new DataColumn("GIABAN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnGIABAN);
                this.columnTHANHTIEN = new DataColumn("THANHTIEN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIEN);
                this.columnTENNHANVIEN = new DataColumn("TENNHANVIEN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENNHANVIEN);
                this.columnColumn1.ReadOnly = true;
                this.columnColumn2.ReadOnly = true;
                this.columnMAPHIEUXUAT.AutoIncrement = true;
                this.columnMAPHIEUXUAT.AllowDBNull = false;
                this.columnMAPHIEUXUAT.ReadOnly = true;
                this.columnNGAYBAN.ReadOnly = true;
                this.columnMAVATTU.AllowDBNull = false;
                this.columnSL.ReadOnly = true;
                this.columnTHANHTIEN.ReadOnly = true;
            }

            internal void InitVars()
            {
                this.columnColumn1 = base.Columns["Column1"];
                this.columnColumn2 = base.Columns["Column2"];
                this.columnTENKHACHHANG = base.Columns["TENKHACHHANG"];
                this.columnMAPHIEUXUAT = base.Columns["MAPHIEUXUAT"];
                this.columnNGAYBAN = base.Columns["NGAYBAN"];
                this.columnMAVATTU = base.Columns["MAVATTU"];
                this.columnTENVATTU = base.Columns["TENVATTU"];
                this.columnQUICACH = base.Columns["QUICACH"];
                this.columnSL = base.Columns["SL"];
                this.columnGIABAN = base.Columns["GIABAN"];
                this.columnTHANHTIEN = base.Columns["THANHTIEN"];
                this.columnTENNHANVIEN = base.Columns["TENNHANVIEN"];
            }

            public dsDataset.PRC_TKCTKBCKHRow NewPRC_TKCTKBCKHRow()
            {
                return (dsDataset.PRC_TKCTKBCKHRow) base.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDataset.PRC_TKCTKBCKHRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRC_TKCTKBCKHRowChanged != null)
                {
                    this.PRC_TKCTKBCKHRowChanged(this, new dsDataset.PRC_TKCTKBCKHRowChangeEvent((dsDataset.PRC_TKCTKBCKHRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRC_TKCTKBCKHRowChanging != null)
                {
                    this.PRC_TKCTKBCKHRowChanging(this, new dsDataset.PRC_TKCTKBCKHRowChangeEvent((dsDataset.PRC_TKCTKBCKHRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PRC_TKCTKBCKHRowDeleted != null)
                {
                    this.PRC_TKCTKBCKHRowDeleted(this, new dsDataset.PRC_TKCTKBCKHRowChangeEvent((dsDataset.PRC_TKCTKBCKHRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRC_TKCTKBCKHRowDeleting != null)
                {
                    this.PRC_TKCTKBCKHRowDeleting(this, new dsDataset.PRC_TKCTKBCKHRowChangeEvent((dsDataset.PRC_TKCTKBCKHRow) e.Row, e.Action));
                }
            }

            public void RemovePRC_TKCTKBCKHRow(dsDataset.PRC_TKCTKBCKHRow row)
            {
                base.Rows.Remove(row);
            }

            internal DataColumn Column1Column
            {
                get
                {
                    return this.columnColumn1;
                }
            }

            internal DataColumn Column2Column
            {
                get
                {
                    return this.columnColumn2;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            internal DataColumn GIABANColumn
            {
                get
                {
                    return this.columnGIABAN;
                }
            }

            public dsDataset.PRC_TKCTKBCKHRow this[int index]
            {
                get
                {
                    return (dsDataset.PRC_TKCTKBCKHRow) base.Rows[index];
                }
            }

            internal DataColumn MAPHIEUXUATColumn
            {
                get
                {
                    return this.columnMAPHIEUXUAT;
                }
            }

            internal DataColumn MAVATTUColumn
            {
                get
                {
                    return this.columnMAVATTU;
                }
            }

            internal DataColumn NGAYBANColumn
            {
                get
                {
                    return this.columnNGAYBAN;
                }
            }

            internal DataColumn QUICACHColumn
            {
                get
                {
                    return this.columnQUICACH;
                }
            }

            internal DataColumn SLColumn
            {
                get
                {
                    return this.columnSL;
                }
            }

            internal DataColumn TENKHACHHANGColumn
            {
                get
                {
                    return this.columnTENKHACHHANG;
                }
            }

            internal DataColumn TENNHANVIENColumn
            {
                get
                {
                    return this.columnTENNHANVIEN;
                }
            }

            internal DataColumn TENVATTUColumn
            {
                get
                {
                    return this.columnTENVATTU;
                }
            }

            internal DataColumn THANHTIENColumn
            {
                get
                {
                    return this.columnTHANHTIEN;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_TKCTKBCKHRow : DataRow
        {
            private dsDataset.PRC_TKCTKBCKHDataTable tablePRC_TKCTKBCKH;

            internal PRC_TKCTKBCKHRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRC_TKCTKBCKH = (dsDataset.PRC_TKCTKBCKHDataTable) base.Table;
            }

            public bool IsColumn1Null()
            {
                return base.IsNull(this.tablePRC_TKCTKBCKH.Column1Column);
            }

            public bool IsColumn2Null()
            {
                return base.IsNull(this.tablePRC_TKCTKBCKH.Column2Column);
            }

            public bool IsGIABANNull()
            {
                return base.IsNull(this.tablePRC_TKCTKBCKH.GIABANColumn);
            }

            public bool IsNGAYBANNull()
            {
                return base.IsNull(this.tablePRC_TKCTKBCKH.NGAYBANColumn);
            }

            public bool IsQUICACHNull()
            {
                return base.IsNull(this.tablePRC_TKCTKBCKH.QUICACHColumn);
            }

            public bool IsSLNull()
            {
                return base.IsNull(this.tablePRC_TKCTKBCKH.SLColumn);
            }

            public bool IsTENKHACHHANGNull()
            {
                return base.IsNull(this.tablePRC_TKCTKBCKH.TENKHACHHANGColumn);
            }

            public bool IsTENNHANVIENNull()
            {
                return base.IsNull(this.tablePRC_TKCTKBCKH.TENNHANVIENColumn);
            }

            public bool IsTENVATTUNull()
            {
                return base.IsNull(this.tablePRC_TKCTKBCKH.TENVATTUColumn);
            }

            public bool IsTHANHTIENNull()
            {
                return base.IsNull(this.tablePRC_TKCTKBCKH.THANHTIENColumn);
            }

            public void SetColumn1Null()
            {
                base[this.tablePRC_TKCTKBCKH.Column1Column] = Convert.DBNull;
            }

            public void SetColumn2Null()
            {
                base[this.tablePRC_TKCTKBCKH.Column2Column] = Convert.DBNull;
            }

            public void SetGIABANNull()
            {
                base[this.tablePRC_TKCTKBCKH.GIABANColumn] = Convert.DBNull;
            }

            public void SetNGAYBANNull()
            {
                base[this.tablePRC_TKCTKBCKH.NGAYBANColumn] = Convert.DBNull;
            }

            public void SetQUICACHNull()
            {
                base[this.tablePRC_TKCTKBCKH.QUICACHColumn] = Convert.DBNull;
            }

            public void SetSLNull()
            {
                base[this.tablePRC_TKCTKBCKH.SLColumn] = Convert.DBNull;
            }

            public void SetTENKHACHHANGNull()
            {
                base[this.tablePRC_TKCTKBCKH.TENKHACHHANGColumn] = Convert.DBNull;
            }

            public void SetTENNHANVIENNull()
            {
                base[this.tablePRC_TKCTKBCKH.TENNHANVIENColumn] = Convert.DBNull;
            }

            public void SetTENVATTUNull()
            {
                base[this.tablePRC_TKCTKBCKH.TENVATTUColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENNull()
            {
                base[this.tablePRC_TKCTKBCKH.THANHTIENColumn] = Convert.DBNull;
            }

            public string Column1
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TKCTKBCKH.Column1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.Column1Column] = value;
                }
            }

            public string Column2
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TKCTKBCKH.Column2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.Column2Column] = value;
                }
            }

            public double GIABAN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TKCTKBCKH.GIABANColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.GIABANColumn] = value;
                }
            }

            public int MAPHIEUXUAT
            {
                get
                {
                    return (int) base[this.tablePRC_TKCTKBCKH.MAPHIEUXUATColumn];
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.MAPHIEUXUATColumn] = value;
                }
            }

            public string MAVATTU
            {
                get
                {
                    return (string) base[this.tablePRC_TKCTKBCKH.MAVATTUColumn];
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.MAVATTUColumn] = value;
                }
            }

            public string NGAYBAN
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TKCTKBCKH.NGAYBANColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.NGAYBANColumn] = value;
                }
            }

            public string QUICACH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TKCTKBCKH.QUICACHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.QUICACHColumn] = value;
                }
            }

            public int SL
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_TKCTKBCKH.SLColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.SLColumn] = value;
                }
            }

            public string TENKHACHHANG
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TKCTKBCKH.TENKHACHHANGColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.TENKHACHHANGColumn] = value;
                }
            }

            public string TENNHANVIEN
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TKCTKBCKH.TENNHANVIENColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.TENNHANVIENColumn] = value;
                }
            }

            public string TENVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TKCTKBCKH.TENVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.TENVATTUColumn] = value;
                }
            }

            public double THANHTIEN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TKCTKBCKH.THANHTIENColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKCTKBCKH.THANHTIENColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_TKCTKBCKHRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDataset.PRC_TKCTKBCKHRow eventRow;

            public PRC_TKCTKBCKHRowChangeEvent(dsDataset.PRC_TKCTKBCKHRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public dsDataset.PRC_TKCTKBCKHRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRC_TKCTKBCKHRowChangeEventHandler(object sender, dsDataset.PRC_TKCTKBCKHRowChangeEvent e);

        [DebuggerStepThrough]
        public class PRC_TKKNDataTable : DataTable, IEnumerable
        {
            private DataColumn columnColumn1;
            private DataColumn columnColumn2;
            private DataColumn columnGIABAN;
            private DataColumn columnMAVATTU;
            private DataColumn columnNHAPTRONGKY;
            private DataColumn columnQUICACH;
            private DataColumn columnTENVATTU;
            private DataColumn columnTHANHTIENNTK;
            private DataColumn columnTHANHTIENTDK;
            private DataColumn columnTONDAUKY;

            public event dsDataset.PRC_TKKNRowChangeEventHandler PRC_TKKNRowChanged;

            public event dsDataset.PRC_TKKNRowChangeEventHandler PRC_TKKNRowChanging;

            public event dsDataset.PRC_TKKNRowChangeEventHandler PRC_TKKNRowDeleted;

            public event dsDataset.PRC_TKKNRowChangeEventHandler PRC_TKKNRowDeleting;

            internal PRC_TKKNDataTable() : base("PRC_TKKN")
            {
                this.InitClass();
            }

            internal PRC_TKKNDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
                base.DisplayExpression = table.DisplayExpression;
            }

            public void AddPRC_TKKNRow(dsDataset.PRC_TKKNRow row)
            {
                base.Rows.Add(row);
            }

            public dsDataset.PRC_TKKNRow AddPRC_TKKNRow(DateTime Column1, DateTime Column2, string MAVATTU, string TENVATTU, string QUICACH, double GIABAN, int TONDAUKY, double THANHTIENTDK, int NHAPTRONGKY, double THANHTIENNTK)
            {
                dsDataset.PRC_TKKNRow row = (dsDataset.PRC_TKKNRow) base.NewRow();
                row.ItemArray = new object[] { Column1, Column2, MAVATTU, TENVATTU, QUICACH, GIABAN, TONDAUKY, THANHTIENTDK, NHAPTRONGKY, THANHTIENNTK };
                base.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                dsDataset.PRC_TKKNDataTable table = (dsDataset.PRC_TKKNDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new dsDataset.PRC_TKKNDataTable();
            }

            public dsDataset.PRC_TKKNRow FindByMAVATTU(string MAVATTU)
            {
                return (dsDataset.PRC_TKKNRow) base.Rows.Find(new object[] { MAVATTU });
            }

            public IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(dsDataset.PRC_TKKNRow);
            }

            private void InitClass()
            {
                this.columnColumn1 = new DataColumn("Column1", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnColumn1);
                this.columnColumn2 = new DataColumn("Column2", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnColumn2);
                this.columnMAVATTU = new DataColumn("MAVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAVATTU);
                this.columnTENVATTU = new DataColumn("TENVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENVATTU);
                this.columnQUICACH = new DataColumn("QUICACH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnQUICACH);
                this.columnGIABAN = new DataColumn("GIABAN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnGIABAN);
                this.columnTONDAUKY = new DataColumn("TONDAUKY", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnTONDAUKY);
                this.columnTHANHTIENTDK = new DataColumn("THANHTIENTDK", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIENTDK);
                this.columnNHAPTRONGKY = new DataColumn("NHAPTRONGKY", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnNHAPTRONGKY);
                this.columnTHANHTIENNTK = new DataColumn("THANHTIENNTK", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIENNTK);
                base.Constraints.Add(new UniqueConstraint("dsDatasetKey2", new DataColumn[] { this.columnMAVATTU }, true));
                this.columnColumn1.ReadOnly = true;
                this.columnColumn2.ReadOnly = true;
                this.columnMAVATTU.AllowDBNull = false;
                this.columnMAVATTU.Unique = true;
                this.columnTONDAUKY.ReadOnly = true;
                this.columnTHANHTIENTDK.ReadOnly = true;
                this.columnNHAPTRONGKY.ReadOnly = true;
                this.columnTHANHTIENNTK.ReadOnly = true;
            }

            internal void InitVars()
            {
                this.columnColumn1 = base.Columns["Column1"];
                this.columnColumn2 = base.Columns["Column2"];
                this.columnMAVATTU = base.Columns["MAVATTU"];
                this.columnTENVATTU = base.Columns["TENVATTU"];
                this.columnQUICACH = base.Columns["QUICACH"];
                this.columnGIABAN = base.Columns["GIABAN"];
                this.columnTONDAUKY = base.Columns["TONDAUKY"];
                this.columnTHANHTIENTDK = base.Columns["THANHTIENTDK"];
                this.columnNHAPTRONGKY = base.Columns["NHAPTRONGKY"];
                this.columnTHANHTIENNTK = base.Columns["THANHTIENNTK"];
            }

            public dsDataset.PRC_TKKNRow NewPRC_TKKNRow()
            {
                return (dsDataset.PRC_TKKNRow) base.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDataset.PRC_TKKNRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRC_TKKNRowChanged != null)
                {
                    this.PRC_TKKNRowChanged(this, new dsDataset.PRC_TKKNRowChangeEvent((dsDataset.PRC_TKKNRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRC_TKKNRowChanging != null)
                {
                    this.PRC_TKKNRowChanging(this, new dsDataset.PRC_TKKNRowChangeEvent((dsDataset.PRC_TKKNRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PRC_TKKNRowDeleted != null)
                {
                    this.PRC_TKKNRowDeleted(this, new dsDataset.PRC_TKKNRowChangeEvent((dsDataset.PRC_TKKNRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRC_TKKNRowDeleting != null)
                {
                    this.PRC_TKKNRowDeleting(this, new dsDataset.PRC_TKKNRowChangeEvent((dsDataset.PRC_TKKNRow) e.Row, e.Action));
                }
            }

            public void RemovePRC_TKKNRow(dsDataset.PRC_TKKNRow row)
            {
                base.Rows.Remove(row);
            }

            internal DataColumn Column1Column
            {
                get
                {
                    return this.columnColumn1;
                }
            }

            internal DataColumn Column2Column
            {
                get
                {
                    return this.columnColumn2;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            internal DataColumn GIABANColumn
            {
                get
                {
                    return this.columnGIABAN;
                }
            }

            public dsDataset.PRC_TKKNRow this[int index]
            {
                get
                {
                    return (dsDataset.PRC_TKKNRow) base.Rows[index];
                }
            }

            internal DataColumn MAVATTUColumn
            {
                get
                {
                    return this.columnMAVATTU;
                }
            }

            internal DataColumn NHAPTRONGKYColumn
            {
                get
                {
                    return this.columnNHAPTRONGKY;
                }
            }

            internal DataColumn QUICACHColumn
            {
                get
                {
                    return this.columnQUICACH;
                }
            }

            internal DataColumn TENVATTUColumn
            {
                get
                {
                    return this.columnTENVATTU;
                }
            }

            internal DataColumn THANHTIENNTKColumn
            {
                get
                {
                    return this.columnTHANHTIENNTK;
                }
            }

            internal DataColumn THANHTIENTDKColumn
            {
                get
                {
                    return this.columnTHANHTIENTDK;
                }
            }

            internal DataColumn TONDAUKYColumn
            {
                get
                {
                    return this.columnTONDAUKY;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_TKKNRow : DataRow
        {
            private dsDataset.PRC_TKKNDataTable tablePRC_TKKN;

            internal PRC_TKKNRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRC_TKKN = (dsDataset.PRC_TKKNDataTable) base.Table;
            }

            public bool IsColumn1Null()
            {
                return base.IsNull(this.tablePRC_TKKN.Column1Column);
            }

            public bool IsColumn2Null()
            {
                return base.IsNull(this.tablePRC_TKKN.Column2Column);
            }

            public bool IsGIABANNull()
            {
                return base.IsNull(this.tablePRC_TKKN.GIABANColumn);
            }

            public bool IsNHAPTRONGKYNull()
            {
                return base.IsNull(this.tablePRC_TKKN.NHAPTRONGKYColumn);
            }

            public bool IsQUICACHNull()
            {
                return base.IsNull(this.tablePRC_TKKN.QUICACHColumn);
            }

            public bool IsTENVATTUNull()
            {
                return base.IsNull(this.tablePRC_TKKN.TENVATTUColumn);
            }

            public bool IsTHANHTIENNTKNull()
            {
                return base.IsNull(this.tablePRC_TKKN.THANHTIENNTKColumn);
            }

            public bool IsTHANHTIENTDKNull()
            {
                return base.IsNull(this.tablePRC_TKKN.THANHTIENTDKColumn);
            }

            public bool IsTONDAUKYNull()
            {
                return base.IsNull(this.tablePRC_TKKN.TONDAUKYColumn);
            }

            public void SetColumn1Null()
            {
                base[this.tablePRC_TKKN.Column1Column] = Convert.DBNull;
            }

            public void SetColumn2Null()
            {
                base[this.tablePRC_TKKN.Column2Column] = Convert.DBNull;
            }

            public void SetGIABANNull()
            {
                base[this.tablePRC_TKKN.GIABANColumn] = Convert.DBNull;
            }

            public void SetNHAPTRONGKYNull()
            {
                base[this.tablePRC_TKKN.NHAPTRONGKYColumn] = Convert.DBNull;
            }

            public void SetQUICACHNull()
            {
                base[this.tablePRC_TKKN.QUICACHColumn] = Convert.DBNull;
            }

            public void SetTENVATTUNull()
            {
                base[this.tablePRC_TKKN.TENVATTUColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENNTKNull()
            {
                base[this.tablePRC_TKKN.THANHTIENNTKColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENTDKNull()
            {
                base[this.tablePRC_TKKN.THANHTIENTDKColumn] = Convert.DBNull;
            }

            public void SetTONDAUKYNull()
            {
                base[this.tablePRC_TKKN.TONDAUKYColumn] = Convert.DBNull;
            }

            public DateTime Column1
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tablePRC_TKKN.Column1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tablePRC_TKKN.Column1Column] = value;
                }
            }

            public DateTime Column2
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tablePRC_TKKN.Column2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tablePRC_TKKN.Column2Column] = value;
                }
            }

            public double GIABAN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TKKN.GIABANColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKKN.GIABANColumn] = value;
                }
            }

            public string MAVATTU
            {
                get
                {
                    return (string) base[this.tablePRC_TKKN.MAVATTUColumn];
                }
                set
                {
                    base[this.tablePRC_TKKN.MAVATTUColumn] = value;
                }
            }

            public int NHAPTRONGKY
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_TKKN.NHAPTRONGKYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKKN.NHAPTRONGKYColumn] = value;
                }
            }

            public string QUICACH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TKKN.QUICACHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TKKN.QUICACHColumn] = value;
                }
            }

            public string TENVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TKKN.TENVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TKKN.TENVATTUColumn] = value;
                }
            }

            public double THANHTIENNTK
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TKKN.THANHTIENNTKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKKN.THANHTIENNTKColumn] = value;
                }
            }

            public double THANHTIENTDK
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TKKN.THANHTIENTDKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKKN.THANHTIENTDKColumn] = value;
                }
            }

            public int TONDAUKY
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_TKKN.TONDAUKYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKKN.TONDAUKYColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_TKKNRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDataset.PRC_TKKNRow eventRow;

            public PRC_TKKNRowChangeEvent(dsDataset.PRC_TKKNRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public dsDataset.PRC_TKKNRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRC_TKKNRowChangeEventHandler(object sender, dsDataset.PRC_TKKNRowChangeEvent e);

        [DebuggerStepThrough]
        public class PRC_TKKXDataTable : DataTable, IEnumerable
        {
            private DataColumn columnColumn1;
            private DataColumn columnColumn2;
            private DataColumn columnGIABAN;
            private DataColumn columnMAVATTU;
            private DataColumn columnQUICACH;
            private DataColumn columnTENVATTU;
            private DataColumn columnTHANHTIENTDK;
            private DataColumn columnTHANHTIENXTK;
            private DataColumn columnTONDAUKY;
            private DataColumn columnXUATTRONGKY;

            public event dsDataset.PRC_TKKXRowChangeEventHandler PRC_TKKXRowChanged;

            public event dsDataset.PRC_TKKXRowChangeEventHandler PRC_TKKXRowChanging;

            public event dsDataset.PRC_TKKXRowChangeEventHandler PRC_TKKXRowDeleted;

            public event dsDataset.PRC_TKKXRowChangeEventHandler PRC_TKKXRowDeleting;

            internal PRC_TKKXDataTable() : base("PRC_TKKX")
            {
                this.InitClass();
            }

            internal PRC_TKKXDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
                base.DisplayExpression = table.DisplayExpression;
            }

            public void AddPRC_TKKXRow(dsDataset.PRC_TKKXRow row)
            {
                base.Rows.Add(row);
            }

            public dsDataset.PRC_TKKXRow AddPRC_TKKXRow(DateTime Column1, DateTime Column2, string MAVATTU, string TENVATTU, string QUICACH, double GIABAN, int TONDAUKY, double THANHTIENTDK, int XUATTRONGKY, double THANHTIENXTK)
            {
                dsDataset.PRC_TKKXRow row = (dsDataset.PRC_TKKXRow) base.NewRow();
                row.ItemArray = new object[] { Column1, Column2, MAVATTU, TENVATTU, QUICACH, GIABAN, TONDAUKY, THANHTIENTDK, XUATTRONGKY, THANHTIENXTK };
                base.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                dsDataset.PRC_TKKXDataTable table = (dsDataset.PRC_TKKXDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new dsDataset.PRC_TKKXDataTable();
            }

            public dsDataset.PRC_TKKXRow FindByMAVATTU(string MAVATTU)
            {
                return (dsDataset.PRC_TKKXRow) base.Rows.Find(new object[] { MAVATTU });
            }

            public IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(dsDataset.PRC_TKKXRow);
            }

            private void InitClass()
            {
                this.columnColumn1 = new DataColumn("Column1", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnColumn1);
                this.columnColumn2 = new DataColumn("Column2", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnColumn2);
                this.columnMAVATTU = new DataColumn("MAVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAVATTU);
                this.columnTENVATTU = new DataColumn("TENVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENVATTU);
                this.columnQUICACH = new DataColumn("QUICACH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnQUICACH);
                this.columnGIABAN = new DataColumn("GIABAN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnGIABAN);
                this.columnTONDAUKY = new DataColumn("TONDAUKY", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnTONDAUKY);
                this.columnTHANHTIENTDK = new DataColumn("THANHTIENTDK", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIENTDK);
                this.columnXUATTRONGKY = new DataColumn("XUATTRONGKY", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnXUATTRONGKY);
                this.columnTHANHTIENXTK = new DataColumn("THANHTIENXTK", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIENXTK);
                base.Constraints.Add(new UniqueConstraint("dsDatasetKey3", new DataColumn[] { this.columnMAVATTU }, true));
                this.columnColumn1.ReadOnly = true;
                this.columnColumn2.ReadOnly = true;
                this.columnMAVATTU.AllowDBNull = false;
                this.columnMAVATTU.Unique = true;
                this.columnTONDAUKY.ReadOnly = true;
                this.columnTHANHTIENTDK.ReadOnly = true;
                this.columnXUATTRONGKY.ReadOnly = true;
                this.columnTHANHTIENXTK.ReadOnly = true;
            }

            internal void InitVars()
            {
                this.columnColumn1 = base.Columns["Column1"];
                this.columnColumn2 = base.Columns["Column2"];
                this.columnMAVATTU = base.Columns["MAVATTU"];
                this.columnTENVATTU = base.Columns["TENVATTU"];
                this.columnQUICACH = base.Columns["QUICACH"];
                this.columnGIABAN = base.Columns["GIABAN"];
                this.columnTONDAUKY = base.Columns["TONDAUKY"];
                this.columnTHANHTIENTDK = base.Columns["THANHTIENTDK"];
                this.columnXUATTRONGKY = base.Columns["XUATTRONGKY"];
                this.columnTHANHTIENXTK = base.Columns["THANHTIENXTK"];
            }

            public dsDataset.PRC_TKKXRow NewPRC_TKKXRow()
            {
                return (dsDataset.PRC_TKKXRow) base.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDataset.PRC_TKKXRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRC_TKKXRowChanged != null)
                {
                    this.PRC_TKKXRowChanged(this, new dsDataset.PRC_TKKXRowChangeEvent((dsDataset.PRC_TKKXRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRC_TKKXRowChanging != null)
                {
                    this.PRC_TKKXRowChanging(this, new dsDataset.PRC_TKKXRowChangeEvent((dsDataset.PRC_TKKXRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PRC_TKKXRowDeleted != null)
                {
                    this.PRC_TKKXRowDeleted(this, new dsDataset.PRC_TKKXRowChangeEvent((dsDataset.PRC_TKKXRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRC_TKKXRowDeleting != null)
                {
                    this.PRC_TKKXRowDeleting(this, new dsDataset.PRC_TKKXRowChangeEvent((dsDataset.PRC_TKKXRow) e.Row, e.Action));
                }
            }

            public void RemovePRC_TKKXRow(dsDataset.PRC_TKKXRow row)
            {
                base.Rows.Remove(row);
            }

            internal DataColumn Column1Column
            {
                get
                {
                    return this.columnColumn1;
                }
            }

            internal DataColumn Column2Column
            {
                get
                {
                    return this.columnColumn2;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            internal DataColumn GIABANColumn
            {
                get
                {
                    return this.columnGIABAN;
                }
            }

            public dsDataset.PRC_TKKXRow this[int index]
            {
                get
                {
                    return (dsDataset.PRC_TKKXRow) base.Rows[index];
                }
            }

            internal DataColumn MAVATTUColumn
            {
                get
                {
                    return this.columnMAVATTU;
                }
            }

            internal DataColumn QUICACHColumn
            {
                get
                {
                    return this.columnQUICACH;
                }
            }

            internal DataColumn TENVATTUColumn
            {
                get
                {
                    return this.columnTENVATTU;
                }
            }

            internal DataColumn THANHTIENTDKColumn
            {
                get
                {
                    return this.columnTHANHTIENTDK;
                }
            }

            internal DataColumn THANHTIENXTKColumn
            {
                get
                {
                    return this.columnTHANHTIENXTK;
                }
            }

            internal DataColumn TONDAUKYColumn
            {
                get
                {
                    return this.columnTONDAUKY;
                }
            }

            internal DataColumn XUATTRONGKYColumn
            {
                get
                {
                    return this.columnXUATTRONGKY;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_TKKXRow : DataRow
        {
            private dsDataset.PRC_TKKXDataTable tablePRC_TKKX;

            internal PRC_TKKXRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRC_TKKX = (dsDataset.PRC_TKKXDataTable) base.Table;
            }

            public bool IsColumn1Null()
            {
                return base.IsNull(this.tablePRC_TKKX.Column1Column);
            }

            public bool IsColumn2Null()
            {
                return base.IsNull(this.tablePRC_TKKX.Column2Column);
            }

            public bool IsGIABANNull()
            {
                return base.IsNull(this.tablePRC_TKKX.GIABANColumn);
            }

            public bool IsQUICACHNull()
            {
                return base.IsNull(this.tablePRC_TKKX.QUICACHColumn);
            }

            public bool IsTENVATTUNull()
            {
                return base.IsNull(this.tablePRC_TKKX.TENVATTUColumn);
            }

            public bool IsTHANHTIENTDKNull()
            {
                return base.IsNull(this.tablePRC_TKKX.THANHTIENTDKColumn);
            }

            public bool IsTHANHTIENXTKNull()
            {
                return base.IsNull(this.tablePRC_TKKX.THANHTIENXTKColumn);
            }

            public bool IsTONDAUKYNull()
            {
                return base.IsNull(this.tablePRC_TKKX.TONDAUKYColumn);
            }

            public bool IsXUATTRONGKYNull()
            {
                return base.IsNull(this.tablePRC_TKKX.XUATTRONGKYColumn);
            }

            public void SetColumn1Null()
            {
                base[this.tablePRC_TKKX.Column1Column] = Convert.DBNull;
            }

            public void SetColumn2Null()
            {
                base[this.tablePRC_TKKX.Column2Column] = Convert.DBNull;
            }

            public void SetGIABANNull()
            {
                base[this.tablePRC_TKKX.GIABANColumn] = Convert.DBNull;
            }

            public void SetQUICACHNull()
            {
                base[this.tablePRC_TKKX.QUICACHColumn] = Convert.DBNull;
            }

            public void SetTENVATTUNull()
            {
                base[this.tablePRC_TKKX.TENVATTUColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENTDKNull()
            {
                base[this.tablePRC_TKKX.THANHTIENTDKColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENXTKNull()
            {
                base[this.tablePRC_TKKX.THANHTIENXTKColumn] = Convert.DBNull;
            }

            public void SetTONDAUKYNull()
            {
                base[this.tablePRC_TKKX.TONDAUKYColumn] = Convert.DBNull;
            }

            public void SetXUATTRONGKYNull()
            {
                base[this.tablePRC_TKKX.XUATTRONGKYColumn] = Convert.DBNull;
            }

            public DateTime Column1
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tablePRC_TKKX.Column1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tablePRC_TKKX.Column1Column] = value;
                }
            }

            public DateTime Column2
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tablePRC_TKKX.Column2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tablePRC_TKKX.Column2Column] = value;
                }
            }

            public double GIABAN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TKKX.GIABANColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKKX.GIABANColumn] = value;
                }
            }

            public string MAVATTU
            {
                get
                {
                    return (string) base[this.tablePRC_TKKX.MAVATTUColumn];
                }
                set
                {
                    base[this.tablePRC_TKKX.MAVATTUColumn] = value;
                }
            }

            public string QUICACH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TKKX.QUICACHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TKKX.QUICACHColumn] = value;
                }
            }

            public string TENVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TKKX.TENVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TKKX.TENVATTUColumn] = value;
                }
            }

            public double THANHTIENTDK
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TKKX.THANHTIENTDKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKKX.THANHTIENTDKColumn] = value;
                }
            }

            public double THANHTIENXTK
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TKKX.THANHTIENXTKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKKX.THANHTIENXTKColumn] = value;
                }
            }

            public int TONDAUKY
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_TKKX.TONDAUKYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKKX.TONDAUKYColumn] = value;
                }
            }

            public int XUATTRONGKY
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_TKKX.XUATTRONGKYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TKKX.XUATTRONGKYColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_TKKXRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDataset.PRC_TKKXRow eventRow;

            public PRC_TKKXRowChangeEvent(dsDataset.PRC_TKKXRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public dsDataset.PRC_TKKXRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRC_TKKXRowChangeEventHandler(object sender, dsDataset.PRC_TKKXRowChangeEvent e);

        [DebuggerStepThrough]
        public class PRC_TONKHODataTable : DataTable, IEnumerable
        {
            private DataColumn columnMAVATTU;
            private DataColumn columnQUICACH;
            private DataColumn columnSOLUONG;
            private DataColumn columnTENLOAIVATTU;
            private DataColumn columnTENVATTU;
            private DataColumn columnTHANHTIEN;

            public event dsDataset.PRC_TONKHORowChangeEventHandler PRC_TONKHORowChanged;

            public event dsDataset.PRC_TONKHORowChangeEventHandler PRC_TONKHORowChanging;

            public event dsDataset.PRC_TONKHORowChangeEventHandler PRC_TONKHORowDeleted;

            public event dsDataset.PRC_TONKHORowChangeEventHandler PRC_TONKHORowDeleting;

            internal PRC_TONKHODataTable() : base("PRC_TONKHO")
            {
                this.InitClass();
            }

            internal PRC_TONKHODataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
                base.DisplayExpression = table.DisplayExpression;
            }

            public void AddPRC_TONKHORow(dsDataset.PRC_TONKHORow row)
            {
                base.Rows.Add(row);
            }

            public dsDataset.PRC_TONKHORow AddPRC_TONKHORow(string MAVATTU, string TENVATTU, string QUICACH, int SOLUONG, double THANHTIEN, string TENLOAIVATTU)
            {
                dsDataset.PRC_TONKHORow row = (dsDataset.PRC_TONKHORow) base.NewRow();
                row.ItemArray = new object[] { MAVATTU, TENVATTU, QUICACH, SOLUONG, THANHTIEN, TENLOAIVATTU };
                base.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                dsDataset.PRC_TONKHODataTable table = (dsDataset.PRC_TONKHODataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new dsDataset.PRC_TONKHODataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(dsDataset.PRC_TONKHORow);
            }

            private void InitClass()
            {
                this.columnMAVATTU = new DataColumn("MAVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAVATTU);
                this.columnTENVATTU = new DataColumn("TENVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENVATTU);
                this.columnQUICACH = new DataColumn("QUICACH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnQUICACH);
                this.columnSOLUONG = new DataColumn("SOLUONG", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSOLUONG);
                this.columnTHANHTIEN = new DataColumn("THANHTIEN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIEN);
                this.columnTENLOAIVATTU = new DataColumn("TENLOAIVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENLOAIVATTU);
                this.columnMAVATTU.AllowDBNull = false;
                this.columnSOLUONG.ReadOnly = true;
                this.columnTHANHTIEN.ReadOnly = true;
            }

            internal void InitVars()
            {
                this.columnMAVATTU = base.Columns["MAVATTU"];
                this.columnTENVATTU = base.Columns["TENVATTU"];
                this.columnQUICACH = base.Columns["QUICACH"];
                this.columnSOLUONG = base.Columns["SOLUONG"];
                this.columnTHANHTIEN = base.Columns["THANHTIEN"];
                this.columnTENLOAIVATTU = base.Columns["TENLOAIVATTU"];
            }

            public dsDataset.PRC_TONKHORow NewPRC_TONKHORow()
            {
                return (dsDataset.PRC_TONKHORow) base.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDataset.PRC_TONKHORow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRC_TONKHORowChanged != null)
                {
                    this.PRC_TONKHORowChanged(this, new dsDataset.PRC_TONKHORowChangeEvent((dsDataset.PRC_TONKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRC_TONKHORowChanging != null)
                {
                    this.PRC_TONKHORowChanging(this, new dsDataset.PRC_TONKHORowChangeEvent((dsDataset.PRC_TONKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PRC_TONKHORowDeleted != null)
                {
                    this.PRC_TONKHORowDeleted(this, new dsDataset.PRC_TONKHORowChangeEvent((dsDataset.PRC_TONKHORow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRC_TONKHORowDeleting != null)
                {
                    this.PRC_TONKHORowDeleting(this, new dsDataset.PRC_TONKHORowChangeEvent((dsDataset.PRC_TONKHORow) e.Row, e.Action));
                }
            }

            public void RemovePRC_TONKHORow(dsDataset.PRC_TONKHORow row)
            {
                base.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            public dsDataset.PRC_TONKHORow this[int index]
            {
                get
                {
                    return (dsDataset.PRC_TONKHORow) base.Rows[index];
                }
            }

            internal DataColumn MAVATTUColumn
            {
                get
                {
                    return this.columnMAVATTU;
                }
            }

            internal DataColumn QUICACHColumn
            {
                get
                {
                    return this.columnQUICACH;
                }
            }

            internal DataColumn SOLUONGColumn
            {
                get
                {
                    return this.columnSOLUONG;
                }
            }

            internal DataColumn TENLOAIVATTUColumn
            {
                get
                {
                    return this.columnTENLOAIVATTU;
                }
            }

            internal DataColumn TENVATTUColumn
            {
                get
                {
                    return this.columnTENVATTU;
                }
            }

            internal DataColumn THANHTIENColumn
            {
                get
                {
                    return this.columnTHANHTIEN;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_TONKHORow : DataRow
        {
            private dsDataset.PRC_TONKHODataTable tablePRC_TONKHO;

            internal PRC_TONKHORow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRC_TONKHO = (dsDataset.PRC_TONKHODataTable) base.Table;
            }

            public bool IsQUICACHNull()
            {
                return base.IsNull(this.tablePRC_TONKHO.QUICACHColumn);
            }

            public bool IsSOLUONGNull()
            {
                return base.IsNull(this.tablePRC_TONKHO.SOLUONGColumn);
            }

            public bool IsTENLOAIVATTUNull()
            {
                return base.IsNull(this.tablePRC_TONKHO.TENLOAIVATTUColumn);
            }

            public bool IsTENVATTUNull()
            {
                return base.IsNull(this.tablePRC_TONKHO.TENVATTUColumn);
            }

            public bool IsTHANHTIENNull()
            {
                return base.IsNull(this.tablePRC_TONKHO.THANHTIENColumn);
            }

            public void SetQUICACHNull()
            {
                base[this.tablePRC_TONKHO.QUICACHColumn] = Convert.DBNull;
            }

            public void SetSOLUONGNull()
            {
                base[this.tablePRC_TONKHO.SOLUONGColumn] = Convert.DBNull;
            }

            public void SetTENLOAIVATTUNull()
            {
                base[this.tablePRC_TONKHO.TENLOAIVATTUColumn] = Convert.DBNull;
            }

            public void SetTENVATTUNull()
            {
                base[this.tablePRC_TONKHO.TENVATTUColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENNull()
            {
                base[this.tablePRC_TONKHO.THANHTIENColumn] = Convert.DBNull;
            }

            public string MAVATTU
            {
                get
                {
                    return (string) base[this.tablePRC_TONKHO.MAVATTUColumn];
                }
                set
                {
                    base[this.tablePRC_TONKHO.MAVATTUColumn] = value;
                }
            }

            public string QUICACH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TONKHO.QUICACHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TONKHO.QUICACHColumn] = value;
                }
            }

            public int SOLUONG
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_TONKHO.SOLUONGColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TONKHO.SOLUONGColumn] = value;
                }
            }

            public string TENLOAIVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TONKHO.TENLOAIVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TONKHO.TENLOAIVATTUColumn] = value;
                }
            }

            public string TENVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_TONKHO.TENVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_TONKHO.TENVATTUColumn] = value;
                }
            }

            public double THANHTIEN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_TONKHO.THANHTIENColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_TONKHO.THANHTIENColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_TONKHORowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDataset.PRC_TONKHORow eventRow;

            public PRC_TONKHORowChangeEvent(dsDataset.PRC_TONKHORow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public dsDataset.PRC_TONKHORow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRC_TONKHORowChangeEventHandler(object sender, dsDataset.PRC_TONKHORowChangeEvent e);

        [DebuggerStepThrough]
        public class PRC_XNTKKDataTable : DataTable, IEnumerable
        {
            private DataColumn columnColumn1;
            private DataColumn columnColumn2;
            private DataColumn columnGIABAN;
            private DataColumn columnMAVATTU;
            private DataColumn columnQUICACH;
            private DataColumn columnSLNTK;
            private DataColumn columnSLTCK;
            private DataColumn columnSLTDK;
            private DataColumn columnSLXTK;
            private DataColumn columnTENVATTU;
            private DataColumn columnTHANHTIENNTK;
            private DataColumn columnTHANHTIENTCK;
            private DataColumn columnTHANHTIENTDK;
            private DataColumn columnTHANHTIENXTK;

            public event dsDataset.PRC_XNTKKRowChangeEventHandler PRC_XNTKKRowChanged;

            public event dsDataset.PRC_XNTKKRowChangeEventHandler PRC_XNTKKRowChanging;

            public event dsDataset.PRC_XNTKKRowChangeEventHandler PRC_XNTKKRowDeleted;

            public event dsDataset.PRC_XNTKKRowChangeEventHandler PRC_XNTKKRowDeleting;

            internal PRC_XNTKKDataTable() : base("PRC_XNTKK")
            {
                this.InitClass();
            }

            internal PRC_XNTKKDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
                base.DisplayExpression = table.DisplayExpression;
            }

            public void AddPRC_XNTKKRow(dsDataset.PRC_XNTKKRow row)
            {
                base.Rows.Add(row);
            }

            public dsDataset.PRC_XNTKKRow AddPRC_XNTKKRow(DateTime Column1, DateTime Column2, string MAVATTU, string TENVATTU, string QUICACH, double GIABAN, int SLTDK, double THANHTIENTDK, int SLNTK, double THANHTIENNTK, int SLXTK, double THANHTIENXTK, int SLTCK, double THANHTIENTCK)
            {
                dsDataset.PRC_XNTKKRow row = (dsDataset.PRC_XNTKKRow) base.NewRow();
                row.ItemArray = new object[] { Column1, Column2, MAVATTU, TENVATTU, QUICACH, GIABAN, SLTDK, THANHTIENTDK, SLNTK, THANHTIENNTK, SLXTK, THANHTIENXTK, SLTCK, THANHTIENTCK };
                base.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                dsDataset.PRC_XNTKKDataTable table = (dsDataset.PRC_XNTKKDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new dsDataset.PRC_XNTKKDataTable();
            }

            public dsDataset.PRC_XNTKKRow FindByMAVATTU(string MAVATTU)
            {
                return (dsDataset.PRC_XNTKKRow) base.Rows.Find(new object[] { MAVATTU });
            }

            public IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(dsDataset.PRC_XNTKKRow);
            }

            private void InitClass()
            {
                this.columnColumn1 = new DataColumn("Column1", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnColumn1);
                this.columnColumn2 = new DataColumn("Column2", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnColumn2);
                this.columnMAVATTU = new DataColumn("MAVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAVATTU);
                this.columnTENVATTU = new DataColumn("TENVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENVATTU);
                this.columnQUICACH = new DataColumn("QUICACH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnQUICACH);
                this.columnGIABAN = new DataColumn("GIABAN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnGIABAN);
                this.columnSLTDK = new DataColumn("SLTDK", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSLTDK);
                this.columnTHANHTIENTDK = new DataColumn("THANHTIENTDK", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIENTDK);
                this.columnSLNTK = new DataColumn("SLNTK", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSLNTK);
                this.columnTHANHTIENNTK = new DataColumn("THANHTIENNTK", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIENNTK);
                this.columnSLXTK = new DataColumn("SLXTK", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSLXTK);
                this.columnTHANHTIENXTK = new DataColumn("THANHTIENXTK", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIENXTK);
                this.columnSLTCK = new DataColumn("SLTCK", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSLTCK);
                this.columnTHANHTIENTCK = new DataColumn("THANHTIENTCK", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTHANHTIENTCK);
                base.Constraints.Add(new UniqueConstraint("dsDatasetKey1", new DataColumn[] { this.columnMAVATTU }, true));
                this.columnColumn1.ReadOnly = true;
                this.columnColumn2.ReadOnly = true;
                this.columnMAVATTU.AllowDBNull = false;
                this.columnMAVATTU.Unique = true;
                this.columnTHANHTIENTDK.ReadOnly = true;
                this.columnTHANHTIENNTK.ReadOnly = true;
                this.columnTHANHTIENXTK.ReadOnly = true;
                this.columnTHANHTIENTCK.ReadOnly = true;
            }

            internal void InitVars()
            {
                this.columnColumn1 = base.Columns["Column1"];
                this.columnColumn2 = base.Columns["Column2"];
                this.columnMAVATTU = base.Columns["MAVATTU"];
                this.columnTENVATTU = base.Columns["TENVATTU"];
                this.columnQUICACH = base.Columns["QUICACH"];
                this.columnGIABAN = base.Columns["GIABAN"];
                this.columnSLTDK = base.Columns["SLTDK"];
                this.columnTHANHTIENTDK = base.Columns["THANHTIENTDK"];
                this.columnSLNTK = base.Columns["SLNTK"];
                this.columnTHANHTIENNTK = base.Columns["THANHTIENNTK"];
                this.columnSLXTK = base.Columns["SLXTK"];
                this.columnTHANHTIENXTK = base.Columns["THANHTIENXTK"];
                this.columnSLTCK = base.Columns["SLTCK"];
                this.columnTHANHTIENTCK = base.Columns["THANHTIENTCK"];
            }

            public dsDataset.PRC_XNTKKRow NewPRC_XNTKKRow()
            {
                return (dsDataset.PRC_XNTKKRow) base.NewRow();
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDataset.PRC_XNTKKRow(builder);
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PRC_XNTKKRowChanged != null)
                {
                    this.PRC_XNTKKRowChanged(this, new dsDataset.PRC_XNTKKRowChangeEvent((dsDataset.PRC_XNTKKRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PRC_XNTKKRowChanging != null)
                {
                    this.PRC_XNTKKRowChanging(this, new dsDataset.PRC_XNTKKRowChangeEvent((dsDataset.PRC_XNTKKRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PRC_XNTKKRowDeleted != null)
                {
                    this.PRC_XNTKKRowDeleted(this, new dsDataset.PRC_XNTKKRowChangeEvent((dsDataset.PRC_XNTKKRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PRC_XNTKKRowDeleting != null)
                {
                    this.PRC_XNTKKRowDeleting(this, new dsDataset.PRC_XNTKKRowChangeEvent((dsDataset.PRC_XNTKKRow) e.Row, e.Action));
                }
            }

            public void RemovePRC_XNTKKRow(dsDataset.PRC_XNTKKRow row)
            {
                base.Rows.Remove(row);
            }

            internal DataColumn Column1Column
            {
                get
                {
                    return this.columnColumn1;
                }
            }

            internal DataColumn Column2Column
            {
                get
                {
                    return this.columnColumn2;
                }
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            internal DataColumn GIABANColumn
            {
                get
                {
                    return this.columnGIABAN;
                }
            }

            public dsDataset.PRC_XNTKKRow this[int index]
            {
                get
                {
                    return (dsDataset.PRC_XNTKKRow) base.Rows[index];
                }
            }

            internal DataColumn MAVATTUColumn
            {
                get
                {
                    return this.columnMAVATTU;
                }
            }

            internal DataColumn QUICACHColumn
            {
                get
                {
                    return this.columnQUICACH;
                }
            }

            internal DataColumn SLNTKColumn
            {
                get
                {
                    return this.columnSLNTK;
                }
            }

            internal DataColumn SLTCKColumn
            {
                get
                {
                    return this.columnSLTCK;
                }
            }

            internal DataColumn SLTDKColumn
            {
                get
                {
                    return this.columnSLTDK;
                }
            }

            internal DataColumn SLXTKColumn
            {
                get
                {
                    return this.columnSLXTK;
                }
            }

            internal DataColumn TENVATTUColumn
            {
                get
                {
                    return this.columnTENVATTU;
                }
            }

            internal DataColumn THANHTIENNTKColumn
            {
                get
                {
                    return this.columnTHANHTIENNTK;
                }
            }

            internal DataColumn THANHTIENTCKColumn
            {
                get
                {
                    return this.columnTHANHTIENTCK;
                }
            }

            internal DataColumn THANHTIENTDKColumn
            {
                get
                {
                    return this.columnTHANHTIENTDK;
                }
            }

            internal DataColumn THANHTIENXTKColumn
            {
                get
                {
                    return this.columnTHANHTIENXTK;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_XNTKKRow : DataRow
        {
            private dsDataset.PRC_XNTKKDataTable tablePRC_XNTKK;

            internal PRC_XNTKKRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePRC_XNTKK = (dsDataset.PRC_XNTKKDataTable) base.Table;
            }

            public bool IsColumn1Null()
            {
                return base.IsNull(this.tablePRC_XNTKK.Column1Column);
            }

            public bool IsColumn2Null()
            {
                return base.IsNull(this.tablePRC_XNTKK.Column2Column);
            }

            public bool IsGIABANNull()
            {
                return base.IsNull(this.tablePRC_XNTKK.GIABANColumn);
            }

            public bool IsQUICACHNull()
            {
                return base.IsNull(this.tablePRC_XNTKK.QUICACHColumn);
            }

            public bool IsSLNTKNull()
            {
                return base.IsNull(this.tablePRC_XNTKK.SLNTKColumn);
            }

            public bool IsSLTCKNull()
            {
                return base.IsNull(this.tablePRC_XNTKK.SLTCKColumn);
            }

            public bool IsSLTDKNull()
            {
                return base.IsNull(this.tablePRC_XNTKK.SLTDKColumn);
            }

            public bool IsSLXTKNull()
            {
                return base.IsNull(this.tablePRC_XNTKK.SLXTKColumn);
            }

            public bool IsTENVATTUNull()
            {
                return base.IsNull(this.tablePRC_XNTKK.TENVATTUColumn);
            }

            public bool IsTHANHTIENNTKNull()
            {
                return base.IsNull(this.tablePRC_XNTKK.THANHTIENNTKColumn);
            }

            public bool IsTHANHTIENTCKNull()
            {
                return base.IsNull(this.tablePRC_XNTKK.THANHTIENTCKColumn);
            }

            public bool IsTHANHTIENTDKNull()
            {
                return base.IsNull(this.tablePRC_XNTKK.THANHTIENTDKColumn);
            }

            public bool IsTHANHTIENXTKNull()
            {
                return base.IsNull(this.tablePRC_XNTKK.THANHTIENXTKColumn);
            }

            public void SetColumn1Null()
            {
                base[this.tablePRC_XNTKK.Column1Column] = Convert.DBNull;
            }

            public void SetColumn2Null()
            {
                base[this.tablePRC_XNTKK.Column2Column] = Convert.DBNull;
            }

            public void SetGIABANNull()
            {
                base[this.tablePRC_XNTKK.GIABANColumn] = Convert.DBNull;
            }

            public void SetQUICACHNull()
            {
                base[this.tablePRC_XNTKK.QUICACHColumn] = Convert.DBNull;
            }

            public void SetSLNTKNull()
            {
                base[this.tablePRC_XNTKK.SLNTKColumn] = Convert.DBNull;
            }

            public void SetSLTCKNull()
            {
                base[this.tablePRC_XNTKK.SLTCKColumn] = Convert.DBNull;
            }

            public void SetSLTDKNull()
            {
                base[this.tablePRC_XNTKK.SLTDKColumn] = Convert.DBNull;
            }

            public void SetSLXTKNull()
            {
                base[this.tablePRC_XNTKK.SLXTKColumn] = Convert.DBNull;
            }

            public void SetTENVATTUNull()
            {
                base[this.tablePRC_XNTKK.TENVATTUColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENNTKNull()
            {
                base[this.tablePRC_XNTKK.THANHTIENNTKColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENTCKNull()
            {
                base[this.tablePRC_XNTKK.THANHTIENTCKColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENTDKNull()
            {
                base[this.tablePRC_XNTKK.THANHTIENTDKColumn] = Convert.DBNull;
            }

            public void SetTHANHTIENXTKNull()
            {
                base[this.tablePRC_XNTKK.THANHTIENXTKColumn] = Convert.DBNull;
            }

            public DateTime Column1
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tablePRC_XNTKK.Column1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tablePRC_XNTKK.Column1Column] = value;
                }
            }

            public DateTime Column2
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tablePRC_XNTKK.Column2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tablePRC_XNTKK.Column2Column] = value;
                }
            }

            public double GIABAN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_XNTKK.GIABANColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_XNTKK.GIABANColumn] = value;
                }
            }

            public string MAVATTU
            {
                get
                {
                    return (string) base[this.tablePRC_XNTKK.MAVATTUColumn];
                }
                set
                {
                    base[this.tablePRC_XNTKK.MAVATTUColumn] = value;
                }
            }

            public string QUICACH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_XNTKK.QUICACHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_XNTKK.QUICACHColumn] = value;
                }
            }

            public int SLNTK
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_XNTKK.SLNTKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_XNTKK.SLNTKColumn] = value;
                }
            }

            public int SLTCK
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_XNTKK.SLTCKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_XNTKK.SLTCKColumn] = value;
                }
            }

            public int SLTDK
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_XNTKK.SLTDKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_XNTKK.SLTDKColumn] = value;
                }
            }

            public int SLXTK
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tablePRC_XNTKK.SLXTKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_XNTKK.SLXTKColumn] = value;
                }
            }

            public string TENVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tablePRC_XNTKK.TENVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tablePRC_XNTKK.TENVATTUColumn] = value;
                }
            }

            public double THANHTIENNTK
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_XNTKK.THANHTIENNTKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_XNTKK.THANHTIENNTKColumn] = value;
                }
            }

            public double THANHTIENTCK
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_XNTKK.THANHTIENTCKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_XNTKK.THANHTIENTCKColumn] = value;
                }
            }

            public double THANHTIENTDK
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_XNTKK.THANHTIENTDKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_XNTKK.THANHTIENTDKColumn] = value;
                }
            }

            public double THANHTIENXTK
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tablePRC_XNTKK.THANHTIENXTKColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tablePRC_XNTKK.THANHTIENXTKColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class PRC_XNTKKRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDataset.PRC_XNTKKRow eventRow;

            public PRC_XNTKKRowChangeEvent(dsDataset.PRC_XNTKKRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public dsDataset.PRC_XNTKKRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void PRC_XNTKKRowChangeEventHandler(object sender, dsDataset.PRC_XNTKKRowChangeEvent e);

        [DebuggerStepThrough]
        public class viewInPhieuNhapDataTable : DataTable, IEnumerable
        {
            private DataColumn columnDIACHI;
            private DataColumn columnDIENTHOAI;
            private DataColumn columnDOKINH;
            private DataColumn columnDONGIA;
            private DataColumn columnGHICHU;
            private DataColumn columnGIABAN;
            private DataColumn columnMALYDONHAPKINH;
            private DataColumn columnMANCC;
            private DataColumn columnMANVNHAP;
            private DataColumn columnMAPHIEUNHAP;
            private DataColumn columnMAPXNHAPTRA;
            private DataColumn columnMAVATTU;
            private DataColumn columnNGAYNHAP;
            private DataColumn columnQUICACH;
            private DataColumn columnSOLUONG;
            private DataColumn columnTENBN;
            private DataColumn columnTENLYDO;
            private DataColumn columnTENNCC;
            private DataColumn columnTENNHANVIEN;
            private DataColumn columnTENVATTU;

            public event dsDataset.viewInPhieuNhapRowChangeEventHandler viewInPhieuNhapRowChanged;

            public event dsDataset.viewInPhieuNhapRowChangeEventHandler viewInPhieuNhapRowChanging;

            public event dsDataset.viewInPhieuNhapRowChangeEventHandler viewInPhieuNhapRowDeleted;

            public event dsDataset.viewInPhieuNhapRowChangeEventHandler viewInPhieuNhapRowDeleting;

            internal viewInPhieuNhapDataTable() : base("viewInPhieuNhap")
            {
                this.InitClass();
            }

            internal viewInPhieuNhapDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
                base.DisplayExpression = table.DisplayExpression;
            }

            public void AddviewInPhieuNhapRow(dsDataset.viewInPhieuNhapRow row)
            {
                base.Rows.Add(row);
            }

            public dsDataset.viewInPhieuNhapRow AddviewInPhieuNhapRow(int MAPHIEUNHAP, string MAVATTU, int SOLUONG, double DONGIA, string TENNCC, string DIACHI, string DIENTHOAI, string MALYDONHAPKINH, DateTime NGAYNHAP, string GHICHU, string MAPXNHAPTRA, string TENBN, int MANCC, string MANVNHAP, string TENVATTU, string QUICACH, double GIABAN, string DOKINH, string TENLYDO, string TENNHANVIEN)
            {
                dsDataset.viewInPhieuNhapRow row = (dsDataset.viewInPhieuNhapRow) base.NewRow();
                row.ItemArray = new object[] { 
                    MAPHIEUNHAP, MAVATTU, SOLUONG, DONGIA, TENNCC, DIACHI, DIENTHOAI, MALYDONHAPKINH, NGAYNHAP, GHICHU, MAPXNHAPTRA, TENBN, MANCC, MANVNHAP, TENVATTU, QUICACH, 
                    GIABAN, DOKINH, TENLYDO, TENNHANVIEN
                 };
                base.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                dsDataset.viewInPhieuNhapDataTable table = (dsDataset.viewInPhieuNhapDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new dsDataset.viewInPhieuNhapDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(dsDataset.viewInPhieuNhapRow);
            }

            private void InitClass()
            {
                this.columnMAPHIEUNHAP = new DataColumn("MAPHIEUNHAP", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMAPHIEUNHAP);
                this.columnMAVATTU = new DataColumn("MAVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAVATTU);
                this.columnSOLUONG = new DataColumn("SOLUONG", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSOLUONG);
                this.columnDONGIA = new DataColumn("DONGIA", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnDONGIA);
                this.columnTENNCC = new DataColumn("TENNCC", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENNCC);
                this.columnDIACHI = new DataColumn("DIACHI", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDIACHI);
                this.columnDIENTHOAI = new DataColumn("DIENTHOAI", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDIENTHOAI);
                this.columnMALYDONHAPKINH = new DataColumn("MALYDONHAPKINH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMALYDONHAPKINH);
                this.columnNGAYNHAP = new DataColumn("NGAYNHAP", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnNGAYNHAP);
                this.columnGHICHU = new DataColumn("GHICHU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGHICHU);
                this.columnMAPXNHAPTRA = new DataColumn("MAPXNHAPTRA", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAPXNHAPTRA);
                this.columnTENBN = new DataColumn("TENBN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENBN);
                this.columnMANCC = new DataColumn("MANCC", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMANCC);
                this.columnMANVNHAP = new DataColumn("MANVNHAP", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMANVNHAP);
                this.columnTENVATTU = new DataColumn("TENVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENVATTU);
                this.columnQUICACH = new DataColumn("QUICACH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnQUICACH);
                this.columnGIABAN = new DataColumn("GIABAN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnGIABAN);
                this.columnDOKINH = new DataColumn("DOKINH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDOKINH);
                this.columnTENLYDO = new DataColumn("TENLYDO", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENLYDO);
                this.columnTENNHANVIEN = new DataColumn("TENNHANVIEN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENNHANVIEN);
                this.columnMAPHIEUNHAP.AllowDBNull = false;
                this.columnMAVATTU.AllowDBNull = false;
            }

            internal void InitVars()
            {
                this.columnMAPHIEUNHAP = base.Columns["MAPHIEUNHAP"];
                this.columnMAVATTU = base.Columns["MAVATTU"];
                this.columnSOLUONG = base.Columns["SOLUONG"];
                this.columnDONGIA = base.Columns["DONGIA"];
                this.columnTENNCC = base.Columns["TENNCC"];
                this.columnDIACHI = base.Columns["DIACHI"];
                this.columnDIENTHOAI = base.Columns["DIENTHOAI"];
                this.columnMALYDONHAPKINH = base.Columns["MALYDONHAPKINH"];
                this.columnNGAYNHAP = base.Columns["NGAYNHAP"];
                this.columnGHICHU = base.Columns["GHICHU"];
                this.columnMAPXNHAPTRA = base.Columns["MAPXNHAPTRA"];
                this.columnTENBN = base.Columns["TENBN"];
                this.columnMANCC = base.Columns["MANCC"];
                this.columnMANVNHAP = base.Columns["MANVNHAP"];
                this.columnTENVATTU = base.Columns["TENVATTU"];
                this.columnQUICACH = base.Columns["QUICACH"];
                this.columnGIABAN = base.Columns["GIABAN"];
                this.columnDOKINH = base.Columns["DOKINH"];
                this.columnTENLYDO = base.Columns["TENLYDO"];
                this.columnTENNHANVIEN = base.Columns["TENNHANVIEN"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDataset.viewInPhieuNhapRow(builder);
            }

            public dsDataset.viewInPhieuNhapRow NewviewInPhieuNhapRow()
            {
                return (dsDataset.viewInPhieuNhapRow) base.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.viewInPhieuNhapRowChanged != null)
                {
                    this.viewInPhieuNhapRowChanged(this, new dsDataset.viewInPhieuNhapRowChangeEvent((dsDataset.viewInPhieuNhapRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.viewInPhieuNhapRowChanging != null)
                {
                    this.viewInPhieuNhapRowChanging(this, new dsDataset.viewInPhieuNhapRowChangeEvent((dsDataset.viewInPhieuNhapRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.viewInPhieuNhapRowDeleted != null)
                {
                    this.viewInPhieuNhapRowDeleted(this, new dsDataset.viewInPhieuNhapRowChangeEvent((dsDataset.viewInPhieuNhapRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.viewInPhieuNhapRowDeleting != null)
                {
                    this.viewInPhieuNhapRowDeleting(this, new dsDataset.viewInPhieuNhapRowChangeEvent((dsDataset.viewInPhieuNhapRow) e.Row, e.Action));
                }
            }

            public void RemoveviewInPhieuNhapRow(dsDataset.viewInPhieuNhapRow row)
            {
                base.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            internal DataColumn DIACHIColumn
            {
                get
                {
                    return this.columnDIACHI;
                }
            }

            internal DataColumn DIENTHOAIColumn
            {
                get
                {
                    return this.columnDIENTHOAI;
                }
            }

            internal DataColumn DOKINHColumn
            {
                get
                {
                    return this.columnDOKINH;
                }
            }

            internal DataColumn DONGIAColumn
            {
                get
                {
                    return this.columnDONGIA;
                }
            }

            internal DataColumn GHICHUColumn
            {
                get
                {
                    return this.columnGHICHU;
                }
            }

            internal DataColumn GIABANColumn
            {
                get
                {
                    return this.columnGIABAN;
                }
            }

            public dsDataset.viewInPhieuNhapRow this[int index]
            {
                get
                {
                    return (dsDataset.viewInPhieuNhapRow) base.Rows[index];
                }
            }

            internal DataColumn MALYDONHAPKINHColumn
            {
                get
                {
                    return this.columnMALYDONHAPKINH;
                }
            }

            internal DataColumn MANCCColumn
            {
                get
                {
                    return this.columnMANCC;
                }
            }

            internal DataColumn MANVNHAPColumn
            {
                get
                {
                    return this.columnMANVNHAP;
                }
            }

            internal DataColumn MAPHIEUNHAPColumn
            {
                get
                {
                    return this.columnMAPHIEUNHAP;
                }
            }

            internal DataColumn MAPXNHAPTRAColumn
            {
                get
                {
                    return this.columnMAPXNHAPTRA;
                }
            }

            internal DataColumn MAVATTUColumn
            {
                get
                {
                    return this.columnMAVATTU;
                }
            }

            internal DataColumn NGAYNHAPColumn
            {
                get
                {
                    return this.columnNGAYNHAP;
                }
            }

            internal DataColumn QUICACHColumn
            {
                get
                {
                    return this.columnQUICACH;
                }
            }

            internal DataColumn SOLUONGColumn
            {
                get
                {
                    return this.columnSOLUONG;
                }
            }

            internal DataColumn TENBNColumn
            {
                get
                {
                    return this.columnTENBN;
                }
            }

            internal DataColumn TENLYDOColumn
            {
                get
                {
                    return this.columnTENLYDO;
                }
            }

            internal DataColumn TENNCCColumn
            {
                get
                {
                    return this.columnTENNCC;
                }
            }

            internal DataColumn TENNHANVIENColumn
            {
                get
                {
                    return this.columnTENNHANVIEN;
                }
            }

            internal DataColumn TENVATTUColumn
            {
                get
                {
                    return this.columnTENVATTU;
                }
            }
        }

        [DebuggerStepThrough]
        public class viewInPhieuNhapRow : DataRow
        {
            private dsDataset.viewInPhieuNhapDataTable tableviewInPhieuNhap;

            internal viewInPhieuNhapRow(DataRowBuilder rb) : base(rb)
            {
                this.tableviewInPhieuNhap = (dsDataset.viewInPhieuNhapDataTable) base.Table;
            }

            public bool IsDIACHINull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.DIACHIColumn);
            }

            public bool IsDIENTHOAINull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.DIENTHOAIColumn);
            }

            public bool IsDOKINHNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.DOKINHColumn);
            }

            public bool IsDONGIANull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.DONGIAColumn);
            }

            public bool IsGHICHUNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.GHICHUColumn);
            }

            public bool IsGIABANNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.GIABANColumn);
            }

            public bool IsMALYDONHAPKINHNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.MALYDONHAPKINHColumn);
            }

            public bool IsMANCCNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.MANCCColumn);
            }

            public bool IsMANVNHAPNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.MANVNHAPColumn);
            }

            public bool IsMAPXNHAPTRANull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.MAPXNHAPTRAColumn);
            }

            public bool IsNGAYNHAPNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.NGAYNHAPColumn);
            }

            public bool IsQUICACHNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.QUICACHColumn);
            }

            public bool IsSOLUONGNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.SOLUONGColumn);
            }

            public bool IsTENBNNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.TENBNColumn);
            }

            public bool IsTENLYDONull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.TENLYDOColumn);
            }

            public bool IsTENNCCNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.TENNCCColumn);
            }

            public bool IsTENNHANVIENNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.TENNHANVIENColumn);
            }

            public bool IsTENVATTUNull()
            {
                return base.IsNull(this.tableviewInPhieuNhap.TENVATTUColumn);
            }

            public void SetDIACHINull()
            {
                base[this.tableviewInPhieuNhap.DIACHIColumn] = Convert.DBNull;
            }

            public void SetDIENTHOAINull()
            {
                base[this.tableviewInPhieuNhap.DIENTHOAIColumn] = Convert.DBNull;
            }

            public void SetDOKINHNull()
            {
                base[this.tableviewInPhieuNhap.DOKINHColumn] = Convert.DBNull;
            }

            public void SetDONGIANull()
            {
                base[this.tableviewInPhieuNhap.DONGIAColumn] = Convert.DBNull;
            }

            public void SetGHICHUNull()
            {
                base[this.tableviewInPhieuNhap.GHICHUColumn] = Convert.DBNull;
            }

            public void SetGIABANNull()
            {
                base[this.tableviewInPhieuNhap.GIABANColumn] = Convert.DBNull;
            }

            public void SetMALYDONHAPKINHNull()
            {
                base[this.tableviewInPhieuNhap.MALYDONHAPKINHColumn] = Convert.DBNull;
            }

            public void SetMANCCNull()
            {
                base[this.tableviewInPhieuNhap.MANCCColumn] = Convert.DBNull;
            }

            public void SetMANVNHAPNull()
            {
                base[this.tableviewInPhieuNhap.MANVNHAPColumn] = Convert.DBNull;
            }

            public void SetMAPXNHAPTRANull()
            {
                base[this.tableviewInPhieuNhap.MAPXNHAPTRAColumn] = Convert.DBNull;
            }

            public void SetNGAYNHAPNull()
            {
                base[this.tableviewInPhieuNhap.NGAYNHAPColumn] = Convert.DBNull;
            }

            public void SetQUICACHNull()
            {
                base[this.tableviewInPhieuNhap.QUICACHColumn] = Convert.DBNull;
            }

            public void SetSOLUONGNull()
            {
                base[this.tableviewInPhieuNhap.SOLUONGColumn] = Convert.DBNull;
            }

            public void SetTENBNNull()
            {
                base[this.tableviewInPhieuNhap.TENBNColumn] = Convert.DBNull;
            }

            public void SetTENLYDONull()
            {
                base[this.tableviewInPhieuNhap.TENLYDOColumn] = Convert.DBNull;
            }

            public void SetTENNCCNull()
            {
                base[this.tableviewInPhieuNhap.TENNCCColumn] = Convert.DBNull;
            }

            public void SetTENNHANVIENNull()
            {
                base[this.tableviewInPhieuNhap.TENNHANVIENColumn] = Convert.DBNull;
            }

            public void SetTENVATTUNull()
            {
                base[this.tableviewInPhieuNhap.TENVATTUColumn] = Convert.DBNull;
            }

            public string DIACHI
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.DIACHIColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.DIACHIColumn] = value;
                }
            }

            public string DIENTHOAI
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.DIENTHOAIColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.DIENTHOAIColumn] = value;
                }
            }

            public string DOKINH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.DOKINHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.DOKINHColumn] = value;
                }
            }

            public double DONGIA
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tableviewInPhieuNhap.DONGIAColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.DONGIAColumn] = value;
                }
            }

            public string GHICHU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.GHICHUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.GHICHUColumn] = value;
                }
            }

            public double GIABAN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tableviewInPhieuNhap.GIABANColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.GIABANColumn] = value;
                }
            }

            public string MALYDONHAPKINH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.MALYDONHAPKINHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.MALYDONHAPKINHColumn] = value;
                }
            }

            public int MANCC
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableviewInPhieuNhap.MANCCColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.MANCCColumn] = value;
                }
            }

            public string MANVNHAP
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.MANVNHAPColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.MANVNHAPColumn] = value;
                }
            }

            public int MAPHIEUNHAP
            {
                get
                {
                    return (int) base[this.tableviewInPhieuNhap.MAPHIEUNHAPColumn];
                }
                set
                {
                    base[this.tableviewInPhieuNhap.MAPHIEUNHAPColumn] = value;
                }
            }

            public string MAPXNHAPTRA
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.MAPXNHAPTRAColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.MAPXNHAPTRAColumn] = value;
                }
            }

            public string MAVATTU
            {
                get
                {
                    return (string) base[this.tableviewInPhieuNhap.MAVATTUColumn];
                }
                set
                {
                    base[this.tableviewInPhieuNhap.MAVATTUColumn] = value;
                }
            }

            public DateTime NGAYNHAP
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tableviewInPhieuNhap.NGAYNHAPColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.NGAYNHAPColumn] = value;
                }
            }

            public string QUICACH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.QUICACHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.QUICACHColumn] = value;
                }
            }

            public int SOLUONG
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableviewInPhieuNhap.SOLUONGColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.SOLUONGColumn] = value;
                }
            }

            public string TENBN
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.TENBNColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.TENBNColumn] = value;
                }
            }

            public string TENLYDO
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.TENLYDOColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.TENLYDOColumn] = value;
                }
            }

            public string TENNCC
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.TENNCCColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.TENNCCColumn] = value;
                }
            }

            public string TENNHANVIEN
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.TENNHANVIENColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.TENNHANVIENColumn] = value;
                }
            }

            public string TENVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuNhap.TENVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuNhap.TENVATTUColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class viewInPhieuNhapRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDataset.viewInPhieuNhapRow eventRow;

            public viewInPhieuNhapRowChangeEvent(dsDataset.viewInPhieuNhapRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public dsDataset.viewInPhieuNhapRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void viewInPhieuNhapRowChangeEventHandler(object sender, dsDataset.viewInPhieuNhapRowChangeEvent e);

        [DebuggerStepThrough]
        public class viewInPhieuXuatDataTable : DataTable, IEnumerable
        {
            private DataColumn columnGhiChu;
            private DataColumn columnGIABAN;
            private DataColumn columnMALYDOXUATKINH;
            private DataColumn columnMANVXUAT;
            private DataColumn columnMAPHIEUXUAT;
            private DataColumn columnMAVATTU;
            private DataColumn columnMAYC;
            private DataColumn columnNGAYXUAT;
            private DataColumn columnQUICACH;
            private DataColumn columnSOLUONG;
            private DataColumn columnTENKHACHHANG;
            private DataColumn columnTENLOAIVATTU;
            private DataColumn columnTENLYDO;
            private DataColumn columnTENNHANVIEN;
            private DataColumn columnTENVATTU;
            private DataColumn columnThanhtien;

            public event dsDataset.viewInPhieuXuatRowChangeEventHandler viewInPhieuXuatRowChanged;

            public event dsDataset.viewInPhieuXuatRowChangeEventHandler viewInPhieuXuatRowChanging;

            public event dsDataset.viewInPhieuXuatRowChangeEventHandler viewInPhieuXuatRowDeleted;

            public event dsDataset.viewInPhieuXuatRowChangeEventHandler viewInPhieuXuatRowDeleting;

            internal viewInPhieuXuatDataTable() : base("viewInPhieuXuat")
            {
                this.InitClass();
            }

            internal viewInPhieuXuatDataTable(DataTable table) : base(table.TableName)
            {
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
                base.DisplayExpression = table.DisplayExpression;
            }

            public void AddviewInPhieuXuatRow(dsDataset.viewInPhieuXuatRow row)
            {
                base.Rows.Add(row);
            }

            public dsDataset.viewInPhieuXuatRow AddviewInPhieuXuatRow(int MAPHIEUXUAT, string MAVATTU, int SOLUONG, string MALYDOXUATKINH, DateTime NGAYXUAT, string GhiChu, string MANVXUAT, string TENKHACHHANG, string MAYC, string TENVATTU, double GIABAN, double Thanhtien, string TENLOAIVATTU, string TENNHANVIEN, string TENLYDO, string QUICACH)
            {
                dsDataset.viewInPhieuXuatRow row = (dsDataset.viewInPhieuXuatRow) base.NewRow();
                row.ItemArray = new object[] { MAPHIEUXUAT, MAVATTU, SOLUONG, MALYDOXUATKINH, NGAYXUAT, GhiChu, MANVXUAT, TENKHACHHANG, MAYC, TENVATTU, GIABAN, Thanhtien, TENLOAIVATTU, TENNHANVIEN, TENLYDO, QUICACH };
                base.Rows.Add(row);
                return row;
            }

            public override DataTable Clone()
            {
                dsDataset.viewInPhieuXuatDataTable table = (dsDataset.viewInPhieuXuatDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            protected override DataTable CreateInstance()
            {
                return new dsDataset.viewInPhieuXuatDataTable();
            }

            public IEnumerator GetEnumerator()
            {
                return base.Rows.GetEnumerator();
            }

            protected override Type GetRowType()
            {
                return typeof(dsDataset.viewInPhieuXuatRow);
            }

            private void InitClass()
            {
                this.columnMAPHIEUXUAT = new DataColumn("MAPHIEUXUAT", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMAPHIEUXUAT);
                this.columnMAVATTU = new DataColumn("MAVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAVATTU);
                this.columnSOLUONG = new DataColumn("SOLUONG", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSOLUONG);
                this.columnMALYDOXUATKINH = new DataColumn("MALYDOXUATKINH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMALYDOXUATKINH);
                this.columnNGAYXUAT = new DataColumn("NGAYXUAT", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnNGAYXUAT);
                this.columnGhiChu = new DataColumn("GhiChu", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGhiChu);
                this.columnMANVXUAT = new DataColumn("MANVXUAT", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMANVXUAT);
                this.columnTENKHACHHANG = new DataColumn("TENKHACHHANG", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENKHACHHANG);
                this.columnMAYC = new DataColumn("MAYC", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMAYC);
                this.columnTENVATTU = new DataColumn("TENVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENVATTU);
                this.columnGIABAN = new DataColumn("GIABAN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnGIABAN);
                this.columnThanhtien = new DataColumn("Thanhtien", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnThanhtien);
                this.columnTENLOAIVATTU = new DataColumn("TENLOAIVATTU", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENLOAIVATTU);
                this.columnTENNHANVIEN = new DataColumn("TENNHANVIEN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENNHANVIEN);
                this.columnTENLYDO = new DataColumn("TENLYDO", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTENLYDO);
                this.columnQUICACH = new DataColumn("QUICACH", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnQUICACH);
                this.columnMAPHIEUXUAT.AllowDBNull = false;
                this.columnMAVATTU.AllowDBNull = false;
                this.columnThanhtien.ReadOnly = true;
            }

            internal void InitVars()
            {
                this.columnMAPHIEUXUAT = base.Columns["MAPHIEUXUAT"];
                this.columnMAVATTU = base.Columns["MAVATTU"];
                this.columnSOLUONG = base.Columns["SOLUONG"];
                this.columnMALYDOXUATKINH = base.Columns["MALYDOXUATKINH"];
                this.columnNGAYXUAT = base.Columns["NGAYXUAT"];
                this.columnGhiChu = base.Columns["GhiChu"];
                this.columnMANVXUAT = base.Columns["MANVXUAT"];
                this.columnTENKHACHHANG = base.Columns["TENKHACHHANG"];
                this.columnMAYC = base.Columns["MAYC"];
                this.columnTENVATTU = base.Columns["TENVATTU"];
                this.columnGIABAN = base.Columns["GIABAN"];
                this.columnThanhtien = base.Columns["Thanhtien"];
                this.columnTENLOAIVATTU = base.Columns["TENLOAIVATTU"];
                this.columnTENNHANVIEN = base.Columns["TENNHANVIEN"];
                this.columnTENLYDO = base.Columns["TENLYDO"];
                this.columnQUICACH = base.Columns["QUICACH"];
            }

            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dsDataset.viewInPhieuXuatRow(builder);
            }

            public dsDataset.viewInPhieuXuatRow NewviewInPhieuXuatRow()
            {
                return (dsDataset.viewInPhieuXuatRow) base.NewRow();
            }

            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.viewInPhieuXuatRowChanged != null)
                {
                    this.viewInPhieuXuatRowChanged(this, new dsDataset.viewInPhieuXuatRowChangeEvent((dsDataset.viewInPhieuXuatRow) e.Row, e.Action));
                }
            }

            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.viewInPhieuXuatRowChanging != null)
                {
                    this.viewInPhieuXuatRowChanging(this, new dsDataset.viewInPhieuXuatRowChangeEvent((dsDataset.viewInPhieuXuatRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.viewInPhieuXuatRowDeleted != null)
                {
                    this.viewInPhieuXuatRowDeleted(this, new dsDataset.viewInPhieuXuatRowChangeEvent((dsDataset.viewInPhieuXuatRow) e.Row, e.Action));
                }
            }

            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.viewInPhieuXuatRowDeleting != null)
                {
                    this.viewInPhieuXuatRowDeleting(this, new dsDataset.viewInPhieuXuatRowChangeEvent((dsDataset.viewInPhieuXuatRow) e.Row, e.Action));
                }
            }

            public void RemoveviewInPhieuXuatRow(dsDataset.viewInPhieuXuatRow row)
            {
                base.Rows.Remove(row);
            }

            [Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            internal DataColumn GhiChuColumn
            {
                get
                {
                    return this.columnGhiChu;
                }
            }

            internal DataColumn GIABANColumn
            {
                get
                {
                    return this.columnGIABAN;
                }
            }

            public dsDataset.viewInPhieuXuatRow this[int index]
            {
                get
                {
                    return (dsDataset.viewInPhieuXuatRow) base.Rows[index];
                }
            }

            internal DataColumn MALYDOXUATKINHColumn
            {
                get
                {
                    return this.columnMALYDOXUATKINH;
                }
            }

            internal DataColumn MANVXUATColumn
            {
                get
                {
                    return this.columnMANVXUAT;
                }
            }

            internal DataColumn MAPHIEUXUATColumn
            {
                get
                {
                    return this.columnMAPHIEUXUAT;
                }
            }

            internal DataColumn MAVATTUColumn
            {
                get
                {
                    return this.columnMAVATTU;
                }
            }

            internal DataColumn MAYCColumn
            {
                get
                {
                    return this.columnMAYC;
                }
            }

            internal DataColumn NGAYXUATColumn
            {
                get
                {
                    return this.columnNGAYXUAT;
                }
            }

            internal DataColumn QUICACHColumn
            {
                get
                {
                    return this.columnQUICACH;
                }
            }

            internal DataColumn SOLUONGColumn
            {
                get
                {
                    return this.columnSOLUONG;
                }
            }

            internal DataColumn TENKHACHHANGColumn
            {
                get
                {
                    return this.columnTENKHACHHANG;
                }
            }

            internal DataColumn TENLOAIVATTUColumn
            {
                get
                {
                    return this.columnTENLOAIVATTU;
                }
            }

            internal DataColumn TENLYDOColumn
            {
                get
                {
                    return this.columnTENLYDO;
                }
            }

            internal DataColumn TENNHANVIENColumn
            {
                get
                {
                    return this.columnTENNHANVIEN;
                }
            }

            internal DataColumn TENVATTUColumn
            {
                get
                {
                    return this.columnTENVATTU;
                }
            }

            internal DataColumn ThanhtienColumn
            {
                get
                {
                    return this.columnThanhtien;
                }
            }
        }

        [DebuggerStepThrough]
        public class viewInPhieuXuatRow : DataRow
        {
            private dsDataset.viewInPhieuXuatDataTable tableviewInPhieuXuat;

            internal viewInPhieuXuatRow(DataRowBuilder rb) : base(rb)
            {
                this.tableviewInPhieuXuat = (dsDataset.viewInPhieuXuatDataTable) base.Table;
            }

            public bool IsGhiChuNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.GhiChuColumn);
            }

            public bool IsGIABANNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.GIABANColumn);
            }

            public bool IsMALYDOXUATKINHNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.MALYDOXUATKINHColumn);
            }

            public bool IsMANVXUATNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.MANVXUATColumn);
            }

            public bool IsMAYCNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.MAYCColumn);
            }

            public bool IsNGAYXUATNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.NGAYXUATColumn);
            }

            public bool IsQUICACHNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.QUICACHColumn);
            }

            public bool IsSOLUONGNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.SOLUONGColumn);
            }

            public bool IsTENKHACHHANGNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.TENKHACHHANGColumn);
            }

            public bool IsTENLOAIVATTUNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.TENLOAIVATTUColumn);
            }

            public bool IsTENLYDONull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.TENLYDOColumn);
            }

            public bool IsTENNHANVIENNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.TENNHANVIENColumn);
            }

            public bool IsTENVATTUNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.TENVATTUColumn);
            }

            public bool IsThanhtienNull()
            {
                return base.IsNull(this.tableviewInPhieuXuat.ThanhtienColumn);
            }

            public void SetGhiChuNull()
            {
                base[this.tableviewInPhieuXuat.GhiChuColumn] = Convert.DBNull;
            }

            public void SetGIABANNull()
            {
                base[this.tableviewInPhieuXuat.GIABANColumn] = Convert.DBNull;
            }

            public void SetMALYDOXUATKINHNull()
            {
                base[this.tableviewInPhieuXuat.MALYDOXUATKINHColumn] = Convert.DBNull;
            }

            public void SetMANVXUATNull()
            {
                base[this.tableviewInPhieuXuat.MANVXUATColumn] = Convert.DBNull;
            }

            public void SetMAYCNull()
            {
                base[this.tableviewInPhieuXuat.MAYCColumn] = Convert.DBNull;
            }

            public void SetNGAYXUATNull()
            {
                base[this.tableviewInPhieuXuat.NGAYXUATColumn] = Convert.DBNull;
            }

            public void SetQUICACHNull()
            {
                base[this.tableviewInPhieuXuat.QUICACHColumn] = Convert.DBNull;
            }

            public void SetSOLUONGNull()
            {
                base[this.tableviewInPhieuXuat.SOLUONGColumn] = Convert.DBNull;
            }

            public void SetTENKHACHHANGNull()
            {
                base[this.tableviewInPhieuXuat.TENKHACHHANGColumn] = Convert.DBNull;
            }

            public void SetTENLOAIVATTUNull()
            {
                base[this.tableviewInPhieuXuat.TENLOAIVATTUColumn] = Convert.DBNull;
            }

            public void SetTENLYDONull()
            {
                base[this.tableviewInPhieuXuat.TENLYDOColumn] = Convert.DBNull;
            }

            public void SetTENNHANVIENNull()
            {
                base[this.tableviewInPhieuXuat.TENNHANVIENColumn] = Convert.DBNull;
            }

            public void SetTENVATTUNull()
            {
                base[this.tableviewInPhieuXuat.TENVATTUColumn] = Convert.DBNull;
            }

            public void SetThanhtienNull()
            {
                base[this.tableviewInPhieuXuat.ThanhtienColumn] = Convert.DBNull;
            }

            public string GhiChu
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuXuat.GhiChuColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.GhiChuColumn] = value;
                }
            }

            public double GIABAN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tableviewInPhieuXuat.GIABANColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.GIABANColumn] = value;
                }
            }

            public string MALYDOXUATKINH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuXuat.MALYDOXUATKINHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.MALYDOXUATKINHColumn] = value;
                }
            }

            public string MANVXUAT
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuXuat.MANVXUATColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.MANVXUATColumn] = value;
                }
            }

            public int MAPHIEUXUAT
            {
                get
                {
                    return (int) base[this.tableviewInPhieuXuat.MAPHIEUXUATColumn];
                }
                set
                {
                    base[this.tableviewInPhieuXuat.MAPHIEUXUATColumn] = value;
                }
            }

            public string MAVATTU
            {
                get
                {
                    return (string) base[this.tableviewInPhieuXuat.MAVATTUColumn];
                }
                set
                {
                    base[this.tableviewInPhieuXuat.MAVATTUColumn] = value;
                }
            }

            public string MAYC
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuXuat.MAYCColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.MAYCColumn] = value;
                }
            }

            public DateTime NGAYXUAT
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tableviewInPhieuXuat.NGAYXUATColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.NGAYXUATColumn] = value;
                }
            }

            public string QUICACH
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuXuat.QUICACHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.QUICACHColumn] = value;
                }
            }

            public int SOLUONG
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableviewInPhieuXuat.SOLUONGColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.SOLUONGColumn] = value;
                }
            }

            public string TENKHACHHANG
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuXuat.TENKHACHHANGColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.TENKHACHHANGColumn] = value;
                }
            }

            public string TENLOAIVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuXuat.TENLOAIVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.TENLOAIVATTUColumn] = value;
                }
            }

            public string TENLYDO
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuXuat.TENLYDOColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.TENLYDOColumn] = value;
                }
            }

            public string TENNHANVIEN
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuXuat.TENNHANVIENColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.TENNHANVIENColumn] = value;
                }
            }

            public string TENVATTU
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableviewInPhieuXuat.TENVATTUColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.TENVATTUColumn] = value;
                }
            }

            public double Thanhtien
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tableviewInPhieuXuat.ThanhtienColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableviewInPhieuXuat.ThanhtienColumn] = value;
                }
            }
        }

        [DebuggerStepThrough]
        public class viewInPhieuXuatRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dsDataset.viewInPhieuXuatRow eventRow;

            public viewInPhieuXuatRowChangeEvent(dsDataset.viewInPhieuXuatRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            public dsDataset.viewInPhieuXuatRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void viewInPhieuXuatRowChangeEventHandler(object sender, dsDataset.viewInPhieuXuatRowChangeEvent e);
    }
}

