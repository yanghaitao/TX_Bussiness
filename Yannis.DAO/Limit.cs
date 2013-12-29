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
	/// Strongly-typed collection for the Limit class.
	/// </summary>
    [Serializable]
	public partial class LimitCollection : ActiveList<Limit, LimitCollection>
	{	   
		public LimitCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LimitCollection</returns>
		public LimitCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Limit o = this[i];
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
	/// This is an ActiveRecord class which wraps the limit table.
	/// </summary>
	[Serializable]
	public partial class Limit : ActiveRecord<Limit>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Limit()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Limit(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Limit(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Limit(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("limit", TableType.Table, DataService.GetInstance("Yannis_DAO"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarLimitid = new TableSchema.TableColumn(schema);
				colvarLimitid.ColumnName = "limitid";
				colvarLimitid.DataType = DbType.Int32;
				colvarLimitid.MaxLength = 0;
				colvarLimitid.AutoIncrement = false;
				colvarLimitid.IsNullable = false;
				colvarLimitid.IsPrimaryKey = false;
				colvarLimitid.IsForeignKey = false;
				colvarLimitid.IsReadOnly = false;
				colvarLimitid.DefaultSetting = @"";
				colvarLimitid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLimitid);
				
				TableSchema.TableColumn colvarLimitname = new TableSchema.TableColumn(schema);
				colvarLimitname.ColumnName = "limitname";
				colvarLimitname.DataType = DbType.String;
				colvarLimitname.MaxLength = 50;
				colvarLimitname.AutoIncrement = false;
				colvarLimitname.IsNullable = true;
				colvarLimitname.IsPrimaryKey = false;
				colvarLimitname.IsForeignKey = false;
				colvarLimitname.IsReadOnly = false;
				colvarLimitname.DefaultSetting = @"";
				colvarLimitname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLimitname);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Yannis_DAO"].AddSchema("limit",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Limitid")]
		[Bindable(true)]
		public int Limitid 
		{
			get { return GetColumnValue<int>(Columns.Limitid); }
			set { SetColumnValue(Columns.Limitid, value); }
		}
		  
		[XmlAttribute("Limitname")]
		[Bindable(true)]
		public string Limitname 
		{
			get { return GetColumnValue<string>(Columns.Limitname); }
			set { SetColumnValue(Columns.Limitname, value); }
		}
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varLimitid,string varLimitname)
		{
			Limit item = new Limit();
			
			item.Limitid = varLimitid;
			
			item.Limitname = varLimitname;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varLimitid,string varLimitname,int varId)
		{
			Limit item = new Limit();
			
				item.Limitid = varLimitid;
			
				item.Limitname = varLimitname;
			
				item.Id = varId;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn LimitidColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn LimitnameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Limitid = @"limitid";
			 public static string Limitname = @"limitname";
			 public static string Id = @"id";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
