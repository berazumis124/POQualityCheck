<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fn_addOrder.aspx.cs" Inherits="POQualityCheck.fn_addOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="lbl_orderNo" runat="server" Text="Order No:"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txt_orderNo" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbl_date" runat="server" Text="Order Date:"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txt_date" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lbl_supplier" runat="server" Text="Supplier:"></asp:Label>
        </div>
        <div>
            <asp:DropDownList ID="drb_supplier" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="lbl_file" runat="server" Text="Select file to upload: "></asp:Label>
        </div>
        <div>
            <asp:FileUpload ID="fu_upload" runat="server" /><asp:Button ID="btn_upload" runat="server" Text="Upload" />
        </div>
        <div>
            <asp:Button ID="btn_save" runat="server" Text="Save" />
        </div>
    </div>
    </form>
</body>
</html>
