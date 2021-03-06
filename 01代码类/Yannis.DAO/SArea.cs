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
	/// Strongly-typed collection for the SArea class.
	/// </summary>
    [Serializable]
	public partial class SAreaCollection : ActiveList<SArea, SAreaCollection>
	{	   
		public SAreaCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SAreaCollection</returns>
		public SAreaCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SArea o = this[i];
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
	/// This is an ActiveRecord class which wraps the s_area table.
	/// </summary>
	[Serializable]
	public partial class SArea : ActiveRecord<SArea>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SArea()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SArea(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SArea(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SArea(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("s_area", TableType.Table, DataService.GetInstance("Yannis_DAO"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarAreacode = new TableSchema.TableColumn(schema);
				colvarAreacode.ColumnName = "areacode";
				colvarAreacode.DataType = DbType.Int32;
				colvarAreacode.MaxLength = 0;
				colvarAreacode.AutoIncrement = false;
				colvarAreacode.IsNullable = false;
				colvarAreacode.IsPrimaryKey = true;
				colvarAreacode.IsForeignKey = false;
				colvarAreacode.IsReadOnly = false;
				colvarAreacode.DefaultSetting = @"";
				colvarAreacode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAreacode);
				
				TableSchema.TableColumn colvarAreaname = new TableSchema.TableColumn(schema);
				colvarAreaname.ColumnName = "areaname";
				colvarAreaname.DataType = DbType.AnsiString;
				colvarAreaname.MaxLength = 18;
				colvarAreaname.AutoIncrement = false;
				colvarAreaname.IsNullable = true;
				colvarAreaname.IsPrimaryKey = false;
				colvarAreaname.IsForeignKey = false;
				colvarAreaname.IsReadOnly = false;
				colvarAreaname.DefaultSetting = @"";
				colvarAreaname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAreaname);
				
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
				DataService.Providers["Yannis_DAO"].AddSchema("s_area",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Areacode")]
		[Bindable(true)]
		public int Areacode 
		{
			get { return GetColumnValue<int>(Columns.Areacode); }
			set { SetColumnValue(Columns.Areacode, value); }
		}
		  
		[XmlAttribute("Areaname")]
		[Bindable(true)]
		public string Areaname 
		{
			get { return GetColumnValue<string>(Columns.Areaname); }
			set { SetColumnValue(Columns.Areaname, value); }
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
		public static void Insert(int varAreacode,string varAreaname,decimal? varPopulation,decimal? varArea,string varMemo)
		{
			SArea item = new SArea();
			
			item.Areacode = varAreacode;
			
			item.Areaname = varAreaname;
			
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
		public static void Update(int varAreacode,string varAreaname,decimal? varPopulation,decimal? varArea,string varMemo)
		{
			SArea item = new SArea();
			
				item.Areacode = varAreacode;
			
				item.Areaname = varAreaname;
			
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
        
        
        public static TableSchema.TableColumn AreacodeColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn AreanameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PopulationColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AreaColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn MemoColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Areacode = @"areacode";
			 public static string Areaname = @"areaname";
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
