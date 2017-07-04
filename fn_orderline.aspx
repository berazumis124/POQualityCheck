<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fn_orderline.aspx.cs" Inherits="POQualityCheck.fn_orderline" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="ph_orderlines" runat="server" />
        </div>
        <div>
            <asp:Button ID="btn_finish" class="navbutton" runat="server" OnClick="btn_finish_Click" Text="Finish" />
        </div>
    </form>
</body>
</html>
