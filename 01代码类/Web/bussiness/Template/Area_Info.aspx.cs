using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using Bussiness.Common;
using TX_Bussiness.Web.Comm;

namespace TX_Bussiness.Web.bussiness.Template
{
    public partial class Area_Info :Comm.BasePage
    {
        protected int pagesize = 10;
        protected int pageindex = 1;
        protected int totalcount;
        protected string txt_area, txt_street, txt_commnuity, txt_startdate
              , txt_enddate, txt_infotype;
        protected List<SArea> arealist = new List<SArea>();
        protected List<SStreet> streetlist = new List<SStreet>();
        protected List<SCommunity> commnuitylist = new List<SCommunity>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            txt_area = Utility.GetParameter("txt_area");
            txt_street = Utility.GetParameter("txt_street");
            txt_commnuity = Utility.GetParameter("txt_commnuity");
            txt_startdate = Utility.GetParameter("txt_startdate");
            txt_enddate = Utility.GetParameter("txt_enddate");
            txt_infotype = !string.IsNullOrEmpty(Utility.GetParameter("txt_infotype")) ? Utility.GetParameter("txt_infotype") : "1";
            if (int.Parse(txt_infotype) == (int)Enums.AreaCountType.Area)
            {
                SqlQuery query = new Select().From(SArea.Schema);
                query.Where("1=1");
                if (txt_area != "0" && !string.IsNullOrEmpty(txt_area))
                    query.And(SArea.AreacodeColumn).IsEqualTo(txt_area);
                totalcount = query.GetRecordCount();
                query.Paged(pageindex, pagesize);
                arealist = query.ExecuteTypedList<SArea>();
            }
            if (int.Parse(txt_infotype) == (int)Enums.AreaCountType.Street)
            {
                SqlQuery query = new Select().From(SStreet.Schema);
                query.Where("1=1");
                if (!string.IsNullOrEmpty(txt_area)&&txt_area != "0"  )
                    query.And(SStreet.AreacodeColumn).IsEqualTo(txt_area);
                if (!string.IsNullOrEmpty(txt_street) && txt_street != "0")
                    query.And(SStreet.StreetcodeColumn).IsEqualTo(txt_street);
                totalcount = query.GetRecordCount();
                query.Paged(pageindex, pagesize);
                streetlist = query.ExecuteTypedList<SStreet>();
            }
            if (int.Parse(txt_infotype) == (int)Enums.AreaCountType.Commnuity)
            {
                SqlQuery query = new Select().From(SCommunity.Schema);
                query.Where("1=1");
                if (!string.IsNullOrEmpty(txt_street) && txt_street != "0")
                    query.And(SCommunity.StreetcodeColumn).IsEqualTo(txt_street);
                if (!string.IsNullOrEmpty(txt_commnuity) && txt_commnuity != "0")
                    query.And(SCommunity.CommcodeColumn).IsEqualTo(txt_commnuity);
                totalcount = query.GetRecordCount();
                query.Paged(pageindex, pagesize);
                commnuitylist = query.ExecuteTypedList<SCommunity>();
            }
            string pageUrl = "/bussiness/template/area_info.aspx?txt_area={0}&txt_street={1}&txt_commnuity={2}&txt_startdate={3}&txt_enddate={4}&txt_infotype={5}&page=__id__";
            pageUrl = string.Format(pageUrl, txt_area, txt_street, txt_commnuity, txt_startdate, txt_enddate, txt_infotype);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
        protected int GetAreacount(object code,Enums.AreaCountType type)
        {
            SqlQuery query = new Select().From(InfoArea.Schema);
            List<Aggregate> list = new List<Aggregate>();
            list.Add(new Aggregate(InfoArea.Columns.Projcode,"listcount",AggregateFunction.Count));
            query.Aggregates = list;
            query.Where("1=1");
            if (!string.IsNullOrEmpty(txt_startdate))
            {
                query.And(InfoArea.AdddateColumn).IsGreaterThanOrEqualTo(txt_startdate);
            }
            if (!string.IsNullOrEmpty(txt_enddate))
            {
                query.And(InfoArea.AdddateColumn).IsLessThanOrEqualTo(txt_enddate);
            }
            if(type==Enums.AreaCountType.Area)
                query.And(InfoArea.AreacodeColumn).IsEqualTo(code);
            if (type == Enums.AreaCountType.Street)
                query.And(InfoArea.StreetcodeColumn).IsEqualTo(code);
            if (type == Enums.AreaCountType.Commnuity)
                query.And(InfoArea.CommnuitycodeColumn).IsEqualTo(code);
            object o=query.ExecuteScalar();
            if (o != null)
                return Convert.ToInt32(o);
            return 0;
        }
    }
}