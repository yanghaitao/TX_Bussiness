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
    /// Controller class for s_community
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SCommunityController
    {
        // Preload our schema..
        SCommunity thisSchemaLoad = new SCommunity();
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
        public SCommunityCollection FetchAll()
        {
            SCommunityCollection coll = new SCommunityCollection();
            Query qry = new Query(SCommunity.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SCommunityCollection FetchByID(object Commcode)
        {
            SCommunityCollection coll = new SCommunityCollection().Where("commcode", Commcode).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SCommunityCollection FetchByQuery(Query qry)
        {
            SCommunityCollection coll = new SCommunityCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Commcode)
        {
            return (SCommunity.Delete(Commcode) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Commcode)
        {
            return (SCommunity.Destroy(Commcode) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Commcode,int? Streetcode,string Commname,decimal? Population,decimal? Area,string Memo)
	    {
		    SCommunity item = new SCommunity();
		    
            item.Commcode = Commcode;
            
            item.Streetcode = Streetcode;
            
            item.Commname = Commname;
            
            item.Population = Population;
            
            item.Area = Area;
            
            item.Memo = Memo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int Id,string Commcode,int? Streetcode,string Commname,decimal? Population,decimal? Area,string Memo)
	    {
		    SCommunity item = new SCommunity();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.Commcode = Commcode;
				
			item.Streetcode = Streetcode;
				
			item.Commname = Commname;
				
			item.Population = Population;
				
			item.Area = Area;
				
			item.Memo = Memo;
				
	        item.Save(UserName);
	    }
    }
}
