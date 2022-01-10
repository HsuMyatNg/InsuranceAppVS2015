﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerReportViewer.aspx.cs" Inherits="InsuranceApp.Reports.Viewer.CustomerReportViewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"  EnablePartialRendering="true"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="600px" Width="100%"></rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
