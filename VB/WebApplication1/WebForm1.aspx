<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication1.WebForm1" %>

<%@ Register assembly="DevExpress.XtraReports.v16.2.Web, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function Init(s, e) {
            var previewModel = s.GetPreviewModel();
            var reportPreview = previewModel && previewModel.reportPreview;
            reportPreview.customProcessBrickClick = function (pageIndex, brick) {
                if (brick && brick.navigation && brick.navigation.url && ["#back", "#detail1", "#detail2"].indexOf(brick.navigation.url) >= 0) {
                    reportPreview.drillThrough(brick.navigation.url);
                    return true;
                } 
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server">
            <ClientSideEvents Init="Init" />
        </dx:ASPxWebDocumentViewer>

    </div>
    </form>
</body>
</html>