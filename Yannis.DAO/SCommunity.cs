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
	/// Strongly-typed collection for the SCommunity class.
	/// </summary>
    [Serializable]
	public partial class SCommunityCollection : ActiveList<SCommunity, SCommunityCollection>
	{	   
		public SCommunityCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SCommunityCollection</returns>
		public SCommunityCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SCommunity o = this[i];
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
	/// This is an ActiveRecord class which wraps the s_community table.
	/// </summary>
	[Serializable]
	public partial class SCommunity : ActiveRecord<SCommunity>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SCommunity()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SCommunity(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SCommunity(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SCommunity(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("s_community", TableType.Table, DataService.GetInstance("Yannis_DAO"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = false;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarCommcode = new TableSchema.TableColumn(schema);
				colvarCommcode.ColumnName = "commcode";
				colvarCommcode.DataType = DbType.AnsiString;
				colvarCommcode.MaxLength = 12;
				colvarCommcode.AutoIncrement = false;
				colvarCommcode.IsNullable = false;
				colvarCommcode.IsPrimaryKey = true;
				colvarCommcode.IsForeignKey = false;
				colvarCommcode.IsReadOnly = false;
				colvarCommcode.DefaultSetting = @"";
				colvarCommcode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCommcode);
				
				TableSchema.TableColumn colvarStreetcode = new TableSchema.TableColumn(schema);
				colvarStreetcode.ColumnName = "streetcode";
				colvarStreetcode.DataType = DbType.Int32;
				colvarStreetcode.MaxLength = 0;
				colvarStreetcode.AutoIncrement = false;
				colvarStreetcode.IsNullable = true;
				colvarStreetcode.IsPrimaryKey = false;
				colvarStreetcode.IsForeignKey = false;
				colvarStreetcode.IsReadOnly = false;
				colvarStreetcode.DefaultSetting = @"";
				colvarStreetcode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStreetcode);
				
				TableSchema.TableColumn colvarCommname = new TableSchema.TableColumn(schema);
				colvarCommname.ColumnName = "commname";
				colvarCommname.DataType = DbType.AnsiString;
				colvarCommname.MaxLength = 100;
				colvarCommname.AutoIncrement = false;
				colvarCommname.IsNullable = true;
				colvarCommname.IsPrimaryKey = false;
				colvarCommname.IsForeignKey = false;
				colvarCommname.IsReadOnly = false;
				colvarCommname.DefaultSetting = @"";
				colvarCommname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCommname);
				
				TableSchema.TableColumn colvarPopulation = new TableSchema.TableColumn(schema);
				colvarPopulation.ColumnName = "population";
				colvarPopulation.DataType = DbType.Decimal;
				colvarPopulation.MaxLength = 0;
				colvarPopulation.AutoIncrement = false;
				colvarPopulation.IsNullable = true;
				colvarPopulation.IsPrimaryKey = false;
				colvarPopulation.IsForeignKey = false;
				colvarPopulation.IsReadOnly = false;
				colvarPopulation.DefaultSetting = @"";
				colvarPopulation.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPopulation);
				
				TableSchema.TableColumn colvarArea = new TableSchema.TableColumn(schema);
				colvarArea.ColumnName = "area";
				colvarArea.DataType = DbType.Decimal;
				colvarArea.MaxLength = 0;
				colvarArea.AutoIncrement = false;
				colvarArea.IsNullable = true;
				colvarArea.IsPrimaryKey = false;
				colvarArea.IsForeignKey = false;
				colvarArea.IsReadOnly = false;
				colvarArea.DefaultSetting = @"";
				colvarArea.ForeignKeyTableName = "";
				schema.Columns.Add(colvarArea);
				
				TableSchema.TableColumn colvarMemo = new TableSchema.TableColumn(schema);
				colvarMemo.ColumnName = "memo";
				colvarMemo.DataType = DbType.AnsiString;
				colvarMemo.MaxLength = 512;
				colvarMemo.AutoIncrement = false;
				colvarMemo.IsNullable = true;
				colvarMemo.IsPrimaryKey = false;
				colvarMemo.IsForeignKey = false;
				colvarMemo.IsReadOnly = false;
				colvarMemo.DefaultSetting = @"";
				colvarMemo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMemo);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Yannis_DAO"].AddSchema("s_community",schema);
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
		  
		[XmlAttribute("Commcode")]
		[Bindable(true)]
		public string Commcode 
		{
			get { return GetColumnValue<string>(Columns.Commcode); }
			set { SetColumnValue(Columns.Commcode, value); }
		}
		  
		[XmlAttribute("Streetcode")]
		[Bindable(true)]
		public int? Streetcode 
		{
			get { return GetColumnValue<int?>(Columns.Streetcode); }
			set { SetColumnValue(Columns.Streetcode, value); }
		}
		  
		[XmlAttribute("Commname")]
		[Bindable(true)]
		public string Commname 
		{
			get { return GetColumnValue<string>(Columns.Commname); }
			set { SetColumnValue(Columns.Commname, value); }
		}
		  
		[XmlAttribute("Population")]
		[Bindable(true)]
		public decimal? Population 
		{
			get { return GetColumnValue<decimal?>(Columns.Population); }
			set { SetColumnValue(Columns.Population, value); }
		}
		  
		[XmlAttribute("Area")]
		[Bindable(true)]
		public decimal? Area 
		{
			get { return GetColumnValue<decimal?>(Columns.Area); }
			set { SetColumnValue(Columns.Area, value); }
		}
		  
		[XmlAttribute("Memo")]
		[Bindable(true)]
		public string Memo 
		{
			get { return GetColumnValue<string>(Columns.Memo); }
			set { SetColumnValue(Columns.Memo, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCommcode,int? varStreetcode,string varCommname,decimal? varPopulation,decimal? varArea,string varMemo)
		{
			SCommunity item = new SCommunity();
			
			item.Commcode = varCommcode;
			
			item.Streetcode = varStreetcode;
			
			item.Commname = varCommname;
			
			item.Population = varPopulation;
			
			item.Area = varArea;
			
			item.Memo = varMemo;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,string varCommcode,int? varStreetcode,string varCommname,decimal? varPopulation,decimal? varArea,string varMemo)
		{
			SCommunity item = new SCommunity();
			
				item.Id = varId;
			
				item.Commcode = varCommcode;
			
				item.Streetcode = varStreetcode;
			
				item.Commname = varCommname;
			
				item.Population = varPopulation;
			
				item.Area = varArea;
			
				item.Memo = varMemo;
			
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
        
        
        
        public static TableSchema.TableColumn CommcodeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn StreetcodeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CommnameColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PopulationColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn AreaColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn MemoColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Commcode = @"commcode";
			 public static string Streetcode = @"streetcode";
			 public static string Commname = @"commname";
			 public static string Population = @"population";
			 public static string Area = @"area";
			 public static string Memo = @"memo";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}