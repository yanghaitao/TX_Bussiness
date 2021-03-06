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
    /// Controller class for s_area
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SAreaController
    {
        // Preload our schema..
        SArea thisSchemaLoad = new SArea();
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
        public SAreaCollection FetchAll()
        {
            SAreaCollection coll = new SAreaCollection();
            Query qry = new Query(SArea.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SAreaCollection FetchByID(object Areacode)
        {
            SAreaCollection coll = new SAreaCollection().Where("areacode", Areacode).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SAreaCollection FetchByQuery(Query qry)
        {
            SAreaCollection coll = new SAreaCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Areacode)
        {
            return (SArea.Delete(Areacode) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Areacode)
        {
            return (SArea.Destroy(Areacode) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int Areacode,string Areaname,decimal? Population,decimal? Area,string Memo)
	    {
		    SArea item = new SArea();
		    
            item.Areacode = Areacode;
            
            item.Areaname = Areaname;
            
            item.Population = Population;
            
            item.Area = Area;
            
            item.Memo = Memo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Areacode,string Areaname,decimal? Population,decimal? Area,string Memo)
	    {
		    SArea item = new SArea();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Areacode = Areacode;
				
			item.Areaname = Areaname;
				
			item.Population = Population;
				
			item.Area = Area;
				
			item.Memo = Memo;
				
	        item.Save(UserName);
	    }
    }
}
