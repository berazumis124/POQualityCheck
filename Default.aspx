<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="POQualityCheck.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <div class="topMenu">
        <a href="fn_addOrder.aspx">Order Import</a>
    </div>
    <div class="topMenu">
        <a href="fn_supplier.aspx">Add Supplier</a>
    </div>
    <div class="topMenu">
        <a href="fn_defects.aspx">Add Defect</a>
    </div>
    <form id="form1" runat="server">
    <div class="orderSelect">
        <asp:Label ID="lbl_orderno" runat="server" Text="Enter Order No: " />
        <asp:TextBox ID="txt_orderno" runat="server" />

        <asp:Button ID="btn_orderlines" class="navbutton" runat="server" Text="Next" onclick="btn_orderlines_Click" />
    </div>
    </form>
</body>
</html>
