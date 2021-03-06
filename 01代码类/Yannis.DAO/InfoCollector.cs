using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace Yannis.DAO
{
	/// <summary>
	/// Strongly-typed collection for the InfoCollector class.
	/// </summary>
    [Serializable]
	public partial class InfoCollectorCollection : ActiveList<InfoCollector, InfoCollectorCollection>
	{	   
		public InfoCollectorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>InfoCollectorCollection</returns>
		public InfoCollectorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                InfoCollector o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the info_collector table.
	/// </summary>
	[Serializable]
	public partial class InfoCollector : ActiveRecord<InfoCollector>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public InfoCollector()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public InfoCollector(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public InfoCollector(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public InfoCollector(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("info_collector", TableType.Table, DataService.GetInstance("Yannis_DAO"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarCollectorid = new TableSchema.TableColumn(schema);
				colvarCollectorid.ColumnName = "collectorid";
				colvarCollectorid.DataType = DbType.Int32;
				colvarCollectorid.MaxLength = 0;
				colvarCollectorid.AutoIncrement = false;
				colvarCollectorid.IsNullable = true;
				colvarCollectorid.IsPrimaryKey = false;
				colvarCollectorid.IsForeignKey = false;
				colvarCollectorid.IsReadOnly = false;
				colvarCollectorid.DefaultSetting = @"";
				colvarCollectorid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCollectorid);
				
				TableSchema.TableColumn colvarCollectorname = new TableSchema.TableColumn(schema);
				colvarCollectorname.ColumnName = "collectorname";
				colvarCollectorname.DataType = DbType.String;
				colvarCollectorname.MaxLength = 50;
				colvarCollectorname.AutoIncrement = false;
				colvarCollectorname.IsNullable = true;
				colvarCollectorname.IsPrimaryKey = false;
				colvarCollectorname.IsForeignKey = false;
				colvarCollectorname.IsReadOnly = false;
				colvarCollectorname.DefaultSetting = @"";
				colvarCollectorname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCollectorname);
				
				TableSchema.TableColumn colvarProjcode = new TableSchema.TableColumn(schema);
				colvarProjcode.ColumnName = "projcode";
				colvarProjcode.DataType = DbType.String;
				colvarProjcode.MaxLength = 50;
				colvarProjcode.AutoIncrement = false;
				colvarProjcode.IsNullable = true;
				colvarProjcode.IsPrimaryKey = false;
				colvarProjcode.IsForeignKey = false;
				colvarProjcode.IsReadOnly = false;
				colvarProjcode.DefaultSetting = @"";
				colvarProjcode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProjcode);
				
				TableSchema.TableColumn colvarAdddate = new TableSchema.TableColumn(schema);
				colvarAdddate.ColumnName = "adddate";
				colvarAdddate.DataType = DbType.DateTime;
				colvarAdddate.MaxLength = 0;
				colvarAdddate.AutoIncrement = false;
				colvarAdddate.IsNullable = true;
				colvarAdddate.IsPrimaryKey = false;
				colvarAdddate.IsForeignKey = false;
				colvarAdddate.IsReadOnly = false;
				colvarAdddate.DefaultSetting = @"";
				colvarAdddate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdddate);
				
				TableSchema.TableColumn colvarDepartcode = new TableSchema.TableColumn(schema);
				colvarDepartcode.ColumnName = "departcode";
				colvarDepartcode.DataType = DbType.Int32;
				colvarDepartcode.MaxLength = 0;
				colvarDepartcode.AutoIncrement = false;
				colvarDepartcode.IsNullable = true;
				colvarDepartcode.IsPrimaryKey = false;
				colvarDepartcode.IsForeignKey = false;
				colvarDepartcode.IsReadOnly = false;
				colvarDepartcode.DefaultSetting = @"";
				colvarDepartcode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDepartcode);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Yannis_DAO"].AddSchema("info_collector",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("Collectorid")]
		[Bindable(true)]
		public int? Collectorid 
		{
			get { return GetColumnValue<int?>(Columns.Collectorid); }
			set { SetColumnValue(Columns.Collectorid, value); }
		}
		  
		[XmlAttribute("Collectorname")]
		[Bindable(true)]
		public string Collectorname 
		{
			get { return GetColumnValue<string>(Columns.Collectorname); }
			set { SetColumnValue(Columns.Collectorname, value); }
		}
		  
		[XmlAttribute("Projcode")]
		[Bindable(true)]
		public string Projcode 
		{
			get { return GetColumnValue<string>(Columns.Projcode); }
			set { SetColumnValue(Columns.Projcode, value); }
		}
		  
		[XmlAttribute("Adddate")]
		[Bindable(true)]
		public DateTime? Adddate 
		{
			get { return GetColumnValue<DateTime?>(Columns.Adddate); }
			set { SetColumnValue(Columns.Adddate, value); }
		}
		  
		[XmlAttribute("Departcode")]
		[Bindable(true)]
		public int? Departcode 
		{
			get { return GetColumnValue<int?>(Columns.Departcode); }
			set { SetColumnValue(Columns.Departcode, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varCollectorid,string varCollectorname,string varProjcode,DateTime? varAdddate,int? varDepartcode)
		{
			InfoCollector item = new InfoCollector();
			
			item.Collectorid = varCollectorid;
			
			item.Collectorname = varCollectorname;
			
			item.Projcode = varProjcode;
			
			item.Adddate = varAdddate;
			
			item.Departcode = varDepartcode;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varCollectorid,string varCollectorname,string varProjcode,DateTime? varAdddate,int? varDepartcode)
		{
			InfoCollector item = new InfoCollector();
			
				item.Id = varId;
			
				item.Collectorid = varCollectorid;
			
				item.Collectorname = varCollectorname;
			
				item.Projcode = varProjcode;
			
				item.Adddate = varAdddate;
			
				item.Departcode = varDepartcode;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CollectoridColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CollectornameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ProjcodeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AdddateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DepartcodeColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Collectorid = @"collectorid";
			 public static string Collectorname = @"collectorname";
			 public static string Projcode = @"projcode";
			 public static string Adddate = @"adddate";
			 public static string Departcode = @"departcode";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
