﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yannis.DAO;
using Bussiness.Common;
using SubSonic;

namespace TX_Bussiness.Web.bussiness.Template
{
    public partial class projectdetail : Comm.BasePage
    {
        string projectcode;
        protected Project model = new Project();
        protected List<Projectimg> imglist = new List<Projectimg>();
        protected ProjectTrace tracemodel = new ProjectTrace();
        protected void Page_Load(object sender, EventArgs e)
        { 
            projectcode = Utility.GetParameter("projcode");
            SqlQuery query = new Select().From(Project.Schema).Where(Project.ProjcodeColumn).IsEqualTo(projectcode);
            model = query.ExecuteSingle<Project>();
            tracemodel = new Select().From(ProjectTrace.Schema).Where(ProjectTrace.ProjcodeColumn).IsEqualTo(model.Projcode)
                .And(ProjectTrace.CurrentnodeidColumn).IsEqualTo(model.Nodeid).ExecuteSingle<ProjectTrace>();
            imglist = new Select().From(Projectimg.Schema).Where(Projectimg.ProjcodeColumn).IsEqualTo(projectcode).ExecuteTypedList<Projectimg>();

        }
    }
}