using InsuranceApp.ViewModels;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InsuranceApp.Reports.Viewer
{
    public partial class PolicyReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //clear
                this.ReportViewer1.Reset();
                this.ReportViewer1.LocalReport.DataSources.Clear();
                //load report
                this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/PolicyReports.rdlc");
                //catch report data
                List<PolicyViewModel> items = Session["ReportData"] as List<PolicyViewModel>;
                //load data to datasource
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "PolicyDataSet";
                reportDataSource.Value = items;

                //load datasource to report
                this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.ReportViewer1.LocalReport.Refresh();
                Session["ReportData"] = null;
            }

        }
    }
}