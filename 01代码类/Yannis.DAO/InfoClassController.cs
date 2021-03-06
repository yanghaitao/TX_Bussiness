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
    /// Controller class for info_class
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class InfoClassController
    {
        // Preload our schema..
        InfoClass thisSchemaLoad = new InfoClass();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public InfoClassCollection FetchAll()
        {
            InfoClassCollection coll = new InfoClassCollection();
            Query qry = new Query(InfoClass.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public InfoClassCollection FetchByID(object Id)
        {
            InfoClassCollection coll = new InfoClassCollection().Where("id", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public InfoClassCollection FetchByQuery(Query qry)
        {
            InfoClassCollection coll = new InfoClassCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (InfoClass.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (InfoClass.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Projectcode,string Bigclasscode,string Bigclassname,string Smallclasscode,string Smallclassanme,DateTime? Adddate,string Baseclasscode,string Baseclassname)
	    {
		    InfoClass item = new InfoClass();
		    
            item.Projectcode = Projectcode;
            
            item.Bigclasscode = Bigclasscode;
            
            item.Bigclassname = Bigclassname;
            
            item.Smallclasscode = Smallclasscode;
            
            item.Smallclassanme = Smallclassanme;
            
            item.Adddate = Adddate;
            
            item.Baseclasscode = Baseclasscode;
            
            item.Baseclassname = Baseclassname;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Projectcode,string Bigclasscode,string Bigclassname,string Smallclasscode,string Smallclassanme,DateTime? Adddate,string Baseclasscode,string Baseclassname)
	    {
		    InfoClass item = new InfoClass();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Projectcode = Projectcode;
				
			item.Bigclasscode = Bigclasscode;
				
			item.Bigclassname = Bigclassname;
				
			item.Smallclasscode = Smallclasscode;
				
			item.Smallclassanme = Smallclassanme;
				
			item.Adddate = Adddate;
				
			item.Baseclasscode = Baseclasscode;
				
			item.Baseclassname = Baseclassname;
				
	        item.Save(UserName);
	    }
    }
}
