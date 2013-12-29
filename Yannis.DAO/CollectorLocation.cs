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
	/// Strongly-typed collection for the CollectorLocation class.
	/// </summary>
    [Serializable]
	public partial class CollectorLocationCollection : ActiveList<CollectorLocation, CollectorLocationCollection>
	{	   
		public CollectorLocationCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>CollectorLocationCollection</returns>
		public CollectorLocationCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                CollectorLocation o = this[i];
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
	/// This is an ActiveRecord class which wraps the collector_location table.
	/// </summary>
	[Serializable]
	public partial class CollectorLocation : ActiveRecord<CollectorLocation>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public CollectorLocation()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public CollectorLocation(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public CollectorLocation(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public CollectorLocation(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("collector_location", TableType.Table, DataService.GetInstance("Yannis_DAO"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "id";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = false;
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
				
				TableSchema.TableColumn colvarLongitude = new TableSchema.TableColumn(schema);
				colvarLongitude.ColumnName = "longitude";
				colvarLongitude.DataType = DbType.String;
				colvarLongitude.MaxLength = 200;
				colvarLongitude.AutoIncrement = false;
				colvarLongitude.IsNullable = true;
				colvarLongitude.IsPrimaryKey = false;
				colvarLongitude.IsForeignKey = false;
				colvarLongitude.IsReadOnly = false;
				colvarLongitude.DefaultSetting = @"";
				colvarLongitude.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLongitude);
				
				TableSchema.TableColumn colvarAtitude = new TableSchema.TableColumn(schema);
				colvarAtitude.ColumnName = "atitude";
				colvarAtitude.DataType = DbType.String;
				colvarAtitude.MaxLength = 200;
				colvarAtitude.AutoIncrement = false;
				colvarAtitude.IsNullable = true;
				colvarAtitude.IsPrimaryKey = false;
				colvarAtitude.IsForeignKey = false;
				colvarAtitude.IsReadOnly = false;
				colvarAtitude.DefaultSetting = @"";
				colvarAtitude.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAtitude);
				
				TableSchema.TableColumn colvarLocaltionupdate = new TableSchema.TableColumn(schema);
				colvarLocaltionupdate.ColumnName = "localtionupdate";
				colvarLocaltionupdate.DataType = DbType.DateTime;
				colvarLocaltionupdate.MaxLength = 0;
				colvarLocaltionupdate.AutoIncrement = false;
				colvarLocaltionupdate.IsNullable = true;
				colvarLocaltionupdate.IsPrimaryKey = false;
				colvarLocaltionupdate.IsForeignKey = false;
				colvarLocaltionupdate.IsReadOnly = false;
				colvarLocaltionupdate.DefaultSetting = @"";
				colvarLocaltionupdate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocaltionupdate);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Yannis_DAO"].AddSchema("collector_location",schema);
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
		  
		[XmlAttribute("Longitude")]
		[Bindable(true)]
		public string Longitude 
		{
			get { return GetColumnValue<string>(Columns.Longitude); }
			set { SetColumnValue(Columns.Longitude, value); }
		}
		  
		[XmlAttribute("Atitude")]
		[Bindable(true)]
		public string Atitude 
		{
			get { return GetColumnValue<string>(Columns.Atitude); }
			set { SetColumnValue(Columns.Atitude, value); }
		}
		  
		[XmlAttribute("Localtionupdate")]
		[Bindable(true)]
		public DateTime? Localtionupdate 
		{
			get { return GetColumnValue<DateTime?>(Columns.Localtionupdate); }
			set { SetColumnValue(Columns.Localtionupdate, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varId,int? varCollectorid,string varLongitude,string varAtitude,DateTime? varLocaltionupdate)
		{
			CollectorLocation item = new CollectorLocation();
			
			item.Id = varId;
			
			item.Collectorid = varCollectorid;
			
			item.Longitude = varLongitude;
			
			item.Atitude = varAtitude;
			
			item.Localtionupdate = varLocaltionupdate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varCollectorid,string varLongitude,string varAtitude,DateTime? varLocaltionupdate)
		{
			CollectorLocation item = new CollectorLocation();
			
				item.Id = varId;
			
				item.Collectorid = varCollectorid;
			
				item.Longitude = varLongitude;
			
				item.Atitude = varAtitude;
			
				item.Localtionupdate = varLocaltionupdate;
			
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
        
        
        
        public static TableSchema.TableColumn LongitudeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AtitudeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn LocaltionupdateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"id";
			 public static string Collectorid = @"collectorid";
			 public static string Longitude = @"longitude";
			 public static string Atitude = @"atitude";
			 public static string Localtionupdate = @"localtionupdate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}