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
    public partial class CategoryDetailReportsViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //clear
                this.ReportViewer1.Reset();
                this.ReportViewer1.LocalReport.DataSources.Clear();
                //load report
                this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/CategoryReports.rdlc");
                //catch report data
                List<CategoryViewModel> items = Session["ReportData"] as List<CategoryViewModel>;
                //load data to datasource
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "CategoryDataSet";
                reportDataSource.Value = items;

                //load datasource to report
                this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.ReportViewer1.LocalReport.Refresh();
                Session["ReportData"] = null;
            }

        }
    }
}