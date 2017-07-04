<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fn_processQty.aspx.cs" Inherits="POQualityCheck.fn_processQty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="orderSelect">
            <asp:Label ID="lbl_qty" runat="server" Text="Quantity Checked" />

            <asp:TextBox ID="txt_qty" runat="server" />
            <asp:RangeValidator runat="server" Type="Integer" MinimumValue="1" MaximumValue="2000" ControlToValidate="txt_qty" ErrorMessage="Value must be between 1 and 2000!" />
            <asp:Button ID="btn_next" class="navbutton" runat="server" OnClick="btn_next_Click" Text="Next" />
        </div>
    </form>
</body>
</html>
