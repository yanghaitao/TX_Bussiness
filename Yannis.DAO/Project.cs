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
	/// Strongly-typed collection for the Project class.
	/// </summary>
    [Serializable]
	public partial class ProjectCollection : ActiveList<Project, ProjectCollection>
	{	   
		public ProjectCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProjectCollection</returns>
		public ProjectCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Project o = this[i];
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
	/// This is an ActiveRecord class which wraps the project table.
	/// </summary>
	[Serializable]
	public partial class Project : ActiveRecord<Project>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Project()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Project(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Project(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Project(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("project", TableType.Table, DataService.GetInstance("Yannis_DAO"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarProjcode = new TableSchema.TableColumn(schema);
				colvarProjcode.ColumnName = "projcode";
				colvarProjcode.DataType = DbType.Int32;
				colvarProjcode.MaxLength = 0;
				colvarProjcode.AutoIncrement = true;
				colvarProjcode.IsNullable = false;
				colvarProjcode.IsPrimaryKey = true;
				colvarProjcode.IsForeignKey = false;
				colvarProjcode.IsReadOnly = false;
				colvarProjcode.DefaultSetting = @"";
				colvarProjcode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProjcode);
				
				TableSchema.TableColumn colvarAreacode = new TableSchema.TableColumn(schema);
				colvarAreacode.ColumnName = "areacode";
				colvarAreacode.DataType = DbType.String;
				colvarAreacode.MaxLength = 10;
				colvarAreacode.AutoIncrement = false;
				colvarAreacode.IsNullable = true;
				colvarAreacode.IsPrimaryKey = false;
				colvarAreacode.IsForeignKey = false;
				colvarAreacode.IsReadOnly = false;
				colvarAreacode.DefaultSetting = @"";
				colvarAreacode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAreacode);
				
				TableSchema.TableColumn colvarStreetcode = new TableSchema.TableColumn(schema);
				colvarStreetcode.ColumnName = "streetcode";
				colvarStreetcode.DataType = DbType.String;
				colvarStreetcode.MaxLength = 10;
				colvarStreetcode.AutoIncrement = false;
				colvarStreetcode.IsNullable = true;
				colvarStreetcode.IsPrimaryKey = false;
				colvarStreetcode.IsForeignKey = false;
				colvarStreetcode.IsReadOnly = false;
				colvarStreetcode.DefaultSetting = @"";
				colvarStreetcode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStreetcode);
				
				TableSchema.TableColumn colvarCommunitycode = new TableSchema.TableColumn(schema);
				colvarCommunitycode.ColumnName = "communitycode";
				colvarCommunitycode.DataType = DbType.String;
				colvarCommunitycode.MaxLength = 20;
				colvarCommunitycode.AutoIncrement = false;
				colvarCommunitycode.IsNullable = true;
				colvarCommunitycode.IsPrimaryKey = false;
				colvarCommunitycode.IsForeignKey = false;
				colvarCommunitycode.IsReadOnly = false;
				colvarCommunitycode.DefaultSetting = @"";
				colvarCommunitycode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCommunitycode);
				
				TableSchema.TableColumn colvarProjectType = new TableSchema.TableColumn(schema);
				colvarProjectType.ColumnName = "project_type";
				colvarProjectType.DataType = DbType.Int32;
				colvarProjectType.MaxLength = 0;
				colvarProjectType.AutoIncrement = false;
				colvarProjectType.IsNullable = true;
				colvarProjectType.IsPrimaryKey = false;
				colvarProjectType.IsForeignKey = false;
				colvarProjectType.IsReadOnly = false;
				colvarProjectType.DefaultSetting = @"";
				colvarProjectType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProjectType);
				
				TableSchema.TableColumn colvarProjectImgurl = new TableSchema.TableColumn(schema);
				colvarProjectImgurl.ColumnName = "project_imgurl";
				colvarProjectImgurl.DataType = DbType.String;
				colvarProjectImgurl.MaxLength = 200;
				colvarProjectImgurl.AutoIncrement = false;
				colvarProjectImgurl.IsNullable = true;
				colvarProjectImgurl.IsPrimaryKey = false;
				colvarProjectImgurl.IsForeignKey = false;
				colvarProjectImgurl.IsReadOnly = false;
				colvarProjectImgurl.DefaultSetting = @"";
				colvarProjectImgurl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProjectImgurl);
				
				TableSchema.TableColumn colvarNodeid = new TableSchema.TableColumn(schema);
				colvarNodeid.ColumnName = "nodeid";
				colvarNodeid.DataType = DbType.Int32;
				colvarNodeid.MaxLength = 0;
				colvarNodeid.AutoIncrement = false;
				colvarNodeid.IsNullable = true;
				colvarNodeid.IsPrimaryKey = false;
				colvarNodeid.IsForeignKey = false;
				colvarNodeid.IsReadOnly = false;
				colvarNodeid.DefaultSetting = @"";
				colvarNodeid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNodeid);
				
				TableSchema.TableColumn colvarDispatcherid = new TableSchema.TableColumn(schema);
				colvarDispatcherid.ColumnName = "dispatcherid";
				colvarDispatcherid.DataType = DbType.Int32;
				colvarDispatcherid.MaxLength = 0;
				colvarDispatcherid.AutoIncrement = false;
				colvarDispatcherid.IsNullable = true;
				colvarDispatcherid.IsPrimaryKey = false;
				colvarDispatcherid.IsForeignKey = false;
				colvarDispatcherid.IsReadOnly = false;
				colvarDispatcherid.DefaultSetting = @"";
				colvarDispatcherid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDispatcherid);
				
				TableSchema.TableColumn colvarDispatchername = new TableSchema.TableColumn(schema);
				colvarDispatchername.ColumnName = "dispatchername";
				colvarDispatchername.DataType = DbType.String;
				colvarDispatchername.MaxLength = 50;
				colvarDispatchername.AutoIncrement = false;
				colvarDispatchername.IsNullable = true;
				colvarDispatchername.IsPrimaryKey = false;
				colvarDispatchername.IsForeignKey = false;
				colvarDispatchername.IsReadOnly = false;
				colvarDispatchername.DefaultSetting = @"";
				colvarDispatchername.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDispatchername);
				
				TableSchema.TableColumn colvarHandlerid = new TableSchema.TableColumn(schema);
				colvarHandlerid.ColumnName = "handlerid";
				colvarHandlerid.DataType = DbType.Int32;
				colvarHandlerid.MaxLength = 0;
				colvarHandlerid.AutoIncrement = false;
				colvarHandlerid.IsNullable = true;
				colvarHandlerid.IsPrimaryKey = false;
				colvarHandlerid.IsForeignKey = false;
				colvarHandlerid.IsReadOnly = false;
				colvarHandlerid.DefaultSetting = @"";
				colvarHandlerid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHandlerid);
				
				TableSchema.TableColumn colvarProjectstate = new TableSchema.TableColumn(schema);
				colvarProjectstate.ColumnName = "projectstate";
				colvarProjectstate.DataType = DbType.Int32;
				colvarProjectstate.MaxLength = 0;
				colvarProjectstate.AutoIncrement = false;
				colvarProjectstate.IsNullable = true;
				colvarProjectstate.IsPrimaryKey = false;
				colvarProjectstate.IsForeignKey = false;
				colvarProjectstate.IsReadOnly = false;
				colvarProjectstate.DefaultSetting = @"";
				colvarProjectstate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProjectstate);
				
				TableSchema.TableColumn colvarDescribe = new TableSchema.TableColumn(schema);
				colvarDescribe.ColumnName = "describe";
				colvarDescribe.DataType = DbType.String;
				colvarDescribe.MaxLength = 1000;
				colvarDescribe.AutoIncrement = false;
				colvarDescribe.IsNullable = true;
				colvarDescribe.IsPrimaryKey = false;
				colvarDescribe.IsForeignKey = false;
				colvarDescribe.IsReadOnly = false;
				colvarDescribe.DefaultSetting = @"";
				colvarDescribe.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescribe);
				
				TableSchema.TableColumn colvarBigclassid = new TableSchema.TableColumn(schema);
				colvarBigclassid.ColumnName = "bigclassid";
				colvarBigclassid.DataType = DbType.Int32;
				colvarBigclassid.MaxLength = 0;
				colvarBigclassid.AutoIncrement = false;
				colvarBigclassid.IsNullable = true;
				colvarBigclassid.IsPrimaryKey = false;
				colvarBigclassid.IsForeignKey = false;
				colvarBigclassid.IsReadOnly = false;
				colvarBigclassid.DefaultSetting = @"";
				colvarBigclassid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBigclassid);
				
				TableSchema.TableColumn colvarSmallclassid = new TableSchema.TableColumn(schema);
				colvarSmallclassid.ColumnName = "smallclassid";
				colvarSmallclassid.DataType = DbType.Int32;
				colvarSmallclassid.MaxLength = 0;
				colvarSmallclassid.AutoIncrement = false;
				colvarSmallclassid.IsNullable = true;
				colvarSmallclassid.IsPrimaryKey = false;
				colvarSmallclassid.IsForeignKey = false;
				colvarSmallclassid.IsReadOnly = false;
				colvarSmallclassid.DefaultSetting = @"";
				colvarSmallclassid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSmallclassid);
				
				TableSchema.TableColumn colvarBigclassname = new TableSchema.TableColumn(schema);
				colvarBigclassname.ColumnName = "bigclassname";
				colvarBigclassname.DataType = DbType.String;
				colvarBigclassname.MaxLength = 50;
				colvarBigclassname.AutoIncrement = false;
				colvarBigclassname.IsNullable = true;
				colvarBigclassname.IsPrimaryKey = false;
				colvarBigclassname.IsForeignKey = false;
				colvarBigclassname.IsReadOnly = false;
				colvarBigclassname.DefaultSetting = @"";
				colvarBigclassname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBigclassname);
				
				TableSchema.TableColumn colvarSmallclassname = new TableSchema.TableColumn(schema);
				colvarSmallclassname.ColumnName = "smallclassname";
				colvarSmallclassname.DataType = DbType.String;
				colvarSmallclassname.MaxLength = 50;
				colvarSmallclassname.AutoIncrement = false;
				colvarSmallclassname.IsNullable = true;
				colvarSmallclassname.IsPrimaryKey = false;
				colvarSmallclassname.IsForeignKey = false;
				colvarSmallclassname.IsReadOnly = false;
				colvarSmallclassname.DefaultSetting = @"";
				colvarSmallclassname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSmallclassname);
				
				TableSchema.TableColumn colvarHandlername = new TableSchema.TableColumn(schema);
				colvarHandlername.ColumnName = "handlername";
				colvarHandlername.DataType = DbType.String;
				colvarHandlername.MaxLength = 50;
				colvarHandlername.AutoIncrement = false;
				colvarHandlername.IsNullable = true;
				colvarHandlername.IsPrimaryKey = false;
				colvarHandlername.IsForeignKey = false;
				colvarHandlername.IsReadOnly = false;
				colvarHandlername.DefaultSetting = @"";
				colvarHandlername.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHandlername);
				
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
				
				TableSchema.TableColumn colvarLoacation = new TableSchema.TableColumn(schema);
				colvarLoacation.ColumnName = "loacation";
				colvarLoacation.DataType = DbType.String;
				colvarLoacation.MaxLength = 200;
				colvarLoacation.AutoIncrement = false;
				colvarLoacation.IsNullable = true;
				colvarLoacation.IsPrimaryKey = false;
				colvarLoacation.IsForeignKey = false;
				colvarLoacation.IsReadOnly = false;
				colvarLoacation.DefaultSetting = @"";
				colvarLoacation.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLoacation);
				
				TableSchema.TableColumn colvarStartdate = new TableSchema.TableColumn(schema);
				colvarStartdate.ColumnName = "startdate";
				colvarStartdate.DataType = DbType.DateTime;
				colvarStartdate.MaxLength = 0;
				colvarStartdate.AutoIncrement = false;
				colvarStartdate.IsNullable = true;
				colvarStartdate.IsPrimaryKey = false;
				colvarStartdate.IsForeignKey = false;
				colvarStartdate.IsReadOnly = false;
				colvarStartdate.DefaultSetting = @"";
				colvarStartdate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartdate);
				
				TableSchema.TableColumn colvarProjectname = new TableSchema.TableColumn(schema);
				colvarProjectname.ColumnName = "projectname";
				colvarProjectname.DataType = DbType.String;
				colvarProjectname.MaxLength = 200;
				colvarProjectname.AutoIncrement = false;
				colvarProjectname.IsNullable = true;
				colvarProjectname.IsPrimaryKey = false;
				colvarProjectname.IsForeignKey = false;
				colvarProjectname.IsReadOnly = false;
				colvarProjectname.DefaultSetting = @"";
				colvarProjectname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProjectname);
				
				TableSchema.TableColumn colvarDetails = new TableSchema.TableColumn(schema);
				colvarDetails.ColumnName = "details";
				colvarDetails.DataType = DbType.String;
				colvarDetails.MaxLength = 500;
				colvarDetails.AutoIncrement = false;
				colvarDetails.IsNullable = true;
				colvarDetails.IsPrimaryKey = false;
				colvarDetails.IsForeignKey = false;
				colvarDetails.IsReadOnly = false;
				colvarDetails.DefaultSetting = @"";
				colvarDetails.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDetails);
				
				TableSchema.TableColumn colvarDepartcode = new TableSchema.TableColumn(schema);
				colvarDepartcode.ColumnName = "departcode";
				colvarDepartcode.DataType = DbType.String;
				colvarDepartcode.MaxLength = 50;
				colvarDepartcode.AutoIncrement = false;
				colvarDepartcode.IsNullable = true;
				colvarDepartcode.IsPrimaryKey = false;
				colvarDepartcode.IsForeignKey = false;
				colvarDepartcode.IsReadOnly = false;
				colvarDepartcode.DefaultSetting = @"";
				colvarDepartcode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDepartcode);
				
				TableSchema.TableColumn colvarReportpersonid = new TableSchema.TableColumn(schema);
				colvarReportpersonid.ColumnName = "reportpersonid";
				colvarReportpersonid.DataType = DbType.Int32;
				colvarReportpersonid.MaxLength = 0;
				colvarReportpersonid.AutoIncrement = false;
				colvarReportpersonid.IsNullable = true;
				colvarReportpersonid.IsPrimaryKey = false;
				colvarReportpersonid.IsForeignKey = false;
				colvarReportpersonid.IsReadOnly = false;
				colvarReportpersonid.DefaultSetting = @"";
				colvarReportpersonid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReportpersonid);
				
				TableSchema.TableColumn colvarReportpersonname = new TableSchema.TableColumn(schema);
				colvarReportpersonname.ColumnName = "reportpersonname";
				colvarReportpersonname.DataType = DbType.String;
				colvarReportpersonname.MaxLength = 50;
				colvarReportpersonname.AutoIncrement = false;
				colvarReportpersonname.IsNullable = true;
				colvarReportpersonname.IsPrimaryKey = false;
				colvarReportpersonname.IsForeignKey = false;
				colvarReportpersonname.IsReadOnly = false;
				colvarReportpersonname.DefaultSetting = @"";
				colvarReportpersonname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReportpersonname);
				
				TableSchema.TableColumn colvarLeadmessage = new TableSchema.TableColumn(schema);
				colvarLeadmessage.ColumnName = "leadmessage";
				colvarLeadmessage.DataType = DbType.String;
				colvarLeadmessage.MaxLength = 200;
				colvarLeadmessage.AutoIncrement = false;
				colvarLeadmessage.IsNullable = true;
				colvarLeadmessage.IsPrimaryKey = false;
				colvarLeadmessage.IsForeignKey = false;
				colvarLeadmessage.IsReadOnly = false;
				colvarLeadmessage.DefaultSetting = @"";
				colvarLeadmessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLeadmessage);
				
				TableSchema.TableColumn colvarMessage = new TableSchema.TableColumn(schema);
				colvarMessage.ColumnName = "message";
				colvarMessage.DataType = DbType.String;
				colvarMessage.MaxLength = 200;
				colvarMessage.AutoIncrement = false;
				colvarMessage.IsNullable = true;
				colvarMessage.IsPrimaryKey = false;
				colvarMessage.IsForeignKey = false;
				colvarMessage.IsReadOnly = false;
				colvarMessage.DefaultSetting = @"";
				colvarMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMessage);
				
				TableSchema.TableColumn colvarHandlermessge = new TableSchema.TableColumn(schema);
				colvarHandlermessge.ColumnName = "handlermessge";
				colvarHandlermessge.DataType = DbType.String;
				colvarHandlermessge.MaxLength = 200;
				colvarHandlermessge.AutoIncrement = false;
				colvarHandlermessge.IsNullable = true;
				colvarHandlermessge.IsPrimaryKey = false;
				colvarHandlermessge.IsForeignKey = false;
				colvarHandlermessge.IsReadOnly = false;
				colvarHandlermessge.DefaultSetting = @"";
				colvarHandlermessge.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHandlermessge);
				
				TableSchema.TableColumn colvarIsdel = new TableSchema.TableColumn(schema);
				colvarIsdel.ColumnName = "isdel";
				colvarIsdel.DataType = DbType.Boolean;
				colvarIsdel.MaxLength = 0;
				colvarIsdel.AutoIncrement = false;
				colvarIsdel.IsNullable = true;
				colvarIsdel.IsPrimaryKey = false;
				colvarIsdel.IsForeignKey = false;
				colvarIsdel.IsReadOnly = false;
				colvarIsdel.DefaultSetting = @"";
				colvarIsdel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsdel);
				
				TableSchema.TableColumn colvarAddress = new TableSchema.TableColumn(schema);
				colvarAddress.ColumnName = "address";
				colvarAddress.DataType = DbType.String;
				colvarAddress.MaxLength = 200;
				colvarAddress.AutoIncrement = false;
				colvarAddress.IsNullable = true;
				colvarAddress.IsPrimaryKey = false;
				colvarAddress.IsForeignKey = false;
				colvarAddress.IsReadOnly = false;
				colvarAddress.DefaultSetting = @"";
				colvarAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddress);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Yannis_DAO"].AddSchema("project",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Projcode")]
		[Bindable(true)]
		public int Projcode 
		{
			get { return GetColumnValue<int>(Columns.Projcode); }
			set { SetColumnValue(Columns.Projcode, value); }
		}
		  
		[XmlAttribute("Areacode")]
		[Bindable(true)]
		public string Areacode 
		{
			get { return GetColumnValue<string>(Columns.Areacode); }
			set { SetColumnValue(Columns.Areacode, value); }
		}
		  
		[XmlAttribute("Streetcode")]
		[Bindable(true)]
		public string Streetcode 
		{
			get { return GetColumnValue<string>(Columns.Streetcode); }
			set { SetColumnValue(Columns.Streetcode, value); }
		}
		  
		[XmlAttribute("Communitycode")]
		[Bindable(true)]
		public string Communitycode 
		{
			get { return GetColumnValue<string>(Columns.Communitycode); }
			set { SetColumnValue(Columns.Communitycode, value); }
		}
		  
		[XmlAttribute("ProjectType")]
		[Bindable(true)]
		public int? ProjectType 
		{
			get { return GetColumnValue<int?>(Columns.ProjectType); }
			set { SetColumnValue(Columns.ProjectType, value); }
		}
		  
		[XmlAttribute("ProjectImgurl")]
		[Bindable(true)]
		public string ProjectImgurl 
		{
			get { return GetColumnValue<string>(Columns.ProjectImgurl); }
			set { SetColumnValue(Columns.ProjectImgurl, value); }
		}
		  
		[XmlAttribute("Nodeid")]
		[Bindable(true)]
		public int? Nodeid 
		{
			get { return GetColumnValue<int?>(Columns.Nodeid); }
			set { SetColumnValue(Columns.Nodeid, value); }
		}
		  
		[XmlAttribute("Dispatcherid")]
		[Bindable(true)]
		public int? Dispatcherid 
		{
			get { return GetColumnValue<int?>(Columns.Dispatcherid); }
			set { SetColumnValue(Columns.Dispatcherid, value); }
		}
		  
		[XmlAttribute("Dispatchername")]
		[Bindable(true)]
		public string Dispatchername 
		{
			get { return GetColumnValue<string>(Columns.Dispatchername); }
			set { SetColumnValue(Columns.Dispatchername, value); }
		}
		  
		[XmlAttribute("Handlerid")]
		[Bindable(true)]
		public int? Handlerid 
		{
			get { return GetColumnValue<int?>(Columns.Handlerid); }
			set { SetColumnValue(Columns.Handlerid, value); }
		}
		  
		[XmlAttribute("Projectstate")]
		[Bindable(true)]
		public int? Projectstate 
		{
			get { return GetColumnValue<int?>(Columns.Projectstate); }
			set { SetColumnValue(Columns.Projectstate, value); }
		}
		  
		[XmlAttribute("Describe")]
		[Bindable(true)]
		public string Describe 
		{
			get { return GetColumnValue<string>(Columns.Describe); }
			set { SetColumnValue(Columns.Describe, value); }
		}
		  
		[XmlAttribute("Bigclassid")]
		[Bindable(true)]
		public int? Bigclassid 
		{
			get { return GetColumnValue<int?>(Columns.Bigclassid); }
			set { SetColumnValue(Columns.Bigclassid, value); }
		}
		  
		[XmlAttribute("Smallclassid")]
		[Bindable(true)]
		public int? Smallclassid 
		{
			get { return GetColumnValue<int?>(Columns.Smallclassid); }
			set { SetColumnValue(Columns.Smallclassid, value); }
		}
		  
		[XmlAttribute("Bigclassname")]
		[Bindable(true)]
		public string Bigclassname 
		{
			get { return GetColumnValue<string>(Columns.Bigclassname); }
			set { SetColumnValue(Columns.Bigclassname, value); }
		}
		  
		[XmlAttribute("Smallclassname")]
		[Bindable(true)]
		public string Smallclassname 
		{
			get { return GetColumnValue<string>(Columns.Smallclassname); }
			set { SetColumnValue(Columns.Smallclassname, value); }
		}
		  
		[XmlAttribute("Handlername")]
		[Bindable(true)]
		public string Handlername 
		{
			get { return GetColumnValue<string>(Columns.Handlername); }
			set { SetColumnValue(Columns.Handlername, value); }
		}
		  
		[XmlAttribute("Adddate")]
		[Bindable(true)]
		public DateTime? Adddate 
		{
			get { return GetColumnValue<DateTime?>(Columns.Adddate); }
			set { SetColumnValue(Columns.Adddate, value); }
		}
		  
		[XmlAttribute("Loacation")]
		[Bindable(true)]
		public string Loacation 
		{
			get { return GetColumnValue<string>(Columns.Loacation); }
			set { SetColumnValue(Columns.Loacation, value); }
		}
		  
		[XmlAttribute("Startdate")]
		[Bindable(true)]
		public DateTime? Startdate 
		{
			get { return GetColumnValue<DateTime?>(Columns.Startdate); }
			set { SetColumnValue(Columns.Startdate, value); }
		}
		  
		[XmlAttribute("Projectname")]
		[Bindable(true)]
		public string Projectname 
		{
			get { return GetColumnValue<string>(Columns.Projectname); }
			set { SetColumnValue(Columns.Projectname, value); }
		}
		  
		[XmlAttribute("Details")]
		[Bindable(true)]
		public string Details 
		{
			get { return GetColumnValue<string>(Columns.Details); }
			set { SetColumnValue(Columns.Details, value); }
		}
		  
		[XmlAttribute("Departcode")]
		[Bindable(true)]
		public string Departcode 
		{
			get { return GetColumnValue<string>(Columns.Departcode); }
			set { SetColumnValue(Columns.Departcode, value); }
		}
		  
		[XmlAttribute("Reportpersonid")]
		[Bindable(true)]
		public int? Reportpersonid 
		{
			get { return GetColumnValue<int?>(Columns.Reportpersonid); }
			set { SetColumnValue(Columns.Reportpersonid, value); }
		}
		  
		[XmlAttribute("Reportpersonname")]
		[Bindable(true)]
		public string Reportpersonname 
		{
			get { return GetColumnValue<string>(Columns.Reportpersonname); }
			set { SetColumnValue(Columns.Reportpersonname, value); }
		}
		  
		[XmlAttribute("Leadmessage")]
		[Bindable(true)]
		public string Leadmessage 
		{
			get { return GetColumnValue<string>(Columns.Leadmessage); }
			set { SetColumnValue(Columns.Leadmessage, value); }
		}
		  
		[XmlAttribute("Message")]
		[Bindable(true)]
		public string Message 
		{
			get { return GetColumnValue<string>(Columns.Message); }
			set { SetColumnValue(Columns.Message, value); }
		}
		  
		[XmlAttribute("Handlermessge")]
		[Bindable(true)]
		public string Handlermessge 
		{
			get { return GetColumnValue<string>(Columns.Handlermessge); }
			set { SetColumnValue(Columns.Handlermessge, value); }
		}
		  
		[XmlAttribute("Isdel")]
		[Bindable(true)]
		public bool? Isdel 
		{
			get { return GetColumnValue<bool?>(Columns.Isdel); }
			set { SetColumnValue(Columns.Isdel, value); }
		}
		  
		[XmlAttribute("Address")]
		[Bindable(true)]
		public string Address 
		{
			get { return GetColumnValue<string>(Columns.Address); }
			set { SetColumnValue(Columns.Address, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varAreacode,string varStreetcode,string varCommunitycode,int? varProjectType,string varProjectImgurl,int? varNodeid,int? varDispatcherid,string varDispatchername,int? varHandlerid,int? varProjectstate,string varDescribe,int? varBigclassid,int? varSmallclassid,string varBigclassname,string varSmallclassname,string varHandlername,DateTime? varAdddate,string varLoacation,DateTime? varStartdate,string varProjectname,string varDetails,string varDepartcode,int? varReportpersonid,string varReportpersonname,string varLeadmessage,string varMessage,string varHandlermessge,bool? varIsdel,string varAddress)
		{
			Project item = new Project();
			
			item.Areacode = varAreacode;
			
			item.Streetcode = varStreetcode;
			
			item.Communitycode = varCommunitycode;
			
			item.ProjectType = varProjectType;
			
			item.ProjectImgurl = varProjectImgurl;
			
			item.Nodeid = varNodeid;
			
			item.Dispatcherid = varDispatcherid;
			
			item.Dispatchername = varDispatchername;
			
			item.Handlerid = varHandlerid;
			
			item.Projectstate = varProjectstate;
			
			item.Describe = varDescribe;
			
			item.Bigclassid = varBigclassid;
			
			item.Smallclassid = varSmallclassid;
			
			item.Bigclassname = varBigclassname;
			
			item.Smallclassname = varSmallclassname;
			
			item.Handlername = varHandlername;
			
			item.Adddate = varAdddate;
			
			item.Loacation = varLoacation;
			
			item.Startdate = varStartdate;
			
			item.Projectname = varProjectname;
			
			item.Details = varDetails;
			
			item.Departcode = varDepartcode;
			
			item.Reportpersonid = varReportpersonid;
			
			item.Reportpersonname = varReportpersonname;
			
			item.Leadmessage = varLeadmessage;
			
			item.Message = varMessage;
			
			item.Handlermessge = varHandlermessge;
			
			item.Isdel = varIsdel;
			
			item.Address = varAddress;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProjcode,string varAreacode,string varStreetcode,string varCommunitycode,int? varProjectType,string varProjectImgurl,int? varNodeid,int? varDispatcherid,string varDispatchername,int? varHandlerid,int? varProjectstate,string varDescribe,int? varBigclassid,int? varSmallclassid,string varBigclassname,string varSmallclassname,string varHandlername,DateTime? varAdddate,string varLoacation,DateTime? varStartdate,string varProjectname,string varDetails,string varDepartcode,int? varReportpersonid,string varReportpersonname,string varLeadmessage,string varMessage,string varHandlermessge,bool? varIsdel,string varAddress)
		{
			Project item = new Project();
			
				item.Projcode = varProjcode;
			
				item.Areacode = varAreacode;
			
				item.Streetcode = varStreetcode;
			
				item.Communitycode = varCommunitycode;
			
				item.ProjectType = varProjectType;
			
				item.ProjectImgurl = varProjectImgurl;
			
				item.Nodeid = varNodeid;
			
				item.Dispatcherid = varDispatcherid;
			
				item.Dispatchername = varDispatchername;
			
				item.Handlerid = varHandlerid;
			
				item.Projectstate = varProjectstate;
			
				item.Describe = varDescribe;
			
				item.Bigclassid = varBigclassid;
			
				item.Smallclassid = varSmallclassid;
			
				item.Bigclassname = varBigclassname;
			
				item.Smallclassname = varSmallclassname;
			
				item.Handlername = varHandlername;
			
				item.Adddate = varAdddate;
			
				item.Loacation = varLoacation;
			
				item.Startdate = varStartdate;
			
				item.Projectname = varProjectname;
			
				item.Details = varDetails;
			
				item.Departcode = varDepartcode;
			
				item.Reportpersonid = varReportpersonid;
			
				item.Reportpersonname = varReportpersonname;
			
				item.Leadmessage = varLeadmessage;
			
				item.Message = varMessage;
			
				item.Handlermessge = varHandlermessge;
			
				item.Isdel = varIsdel;
			
				item.Address = varAddress;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ProjcodeColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn AreacodeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn StreetcodeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CommunitycodeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ProjectTypeColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ProjectImgurlColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn NodeidColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DispatcheridColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DispatchernameColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn HandleridColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ProjectstateColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn DescribeColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn BigclassidColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn SmallclassidColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn BigclassnameColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn SmallclassnameColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn HandlernameColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn AdddateColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn LoacationColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn StartdateColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn ProjectnameColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn DetailsColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn DepartcodeColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn ReportpersonidColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn ReportpersonnameColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn LeadmessageColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn MessageColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        public static TableSchema.TableColumn HandlermessgeColumn
        {
            get { return Schema.Columns[27]; }
        }
        
        
        
        public static TableSchema.TableColumn IsdelColumn
        {
            get { return Schema.Columns[28]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressColumn
        {
            get { return Schema.Columns[29]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Projcode = @"projcode";
			 public static string Areacode = @"areacode";
			 public static string Streetcode = @"streetcode";
			 public static string Communitycode = @"communitycode";
			 public static string ProjectType = @"project_type";
			 public static string ProjectImgurl = @"project_imgurl";
			 public static string Nodeid = @"nodeid";
			 public static string Dispatcherid = @"dispatcherid";
			 public static string Dispatchername = @"dispatchername";
			 public static string Handlerid = @"handlerid";
			 public static string Projectstate = @"projectstate";
			 public static string Describe = @"describe";
			 public static string Bigclassid = @"bigclassid";
			 public static string Smallclassid = @"smallclassid";
			 public static string Bigclassname = @"bigclassname";
			 public static string Smallclassname = @"smallclassname";
			 public static string Handlername = @"handlername";
			 public static string Adddate = @"adddate";
			 public static string Loacation = @"loacation";
			 public static string Startdate = @"startdate";
			 public static string Projectname = @"projectname";
			 public static string Details = @"details";
			 public static string Departcode = @"departcode";
			 public static string Reportpersonid = @"reportpersonid";
			 public static string Reportpersonname = @"reportpersonname";
			 public static string Leadmessage = @"leadmessage";
			 public static string Message = @"message";
			 public static string Handlermessge = @"handlermessge";
			 public static string Isdel = @"isdel";
			 public static string Address = @"address";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}