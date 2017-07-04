<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fn_addOrder.aspx.cs" Inherits="POQualityCheck.fn_addOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="lbl_orderNo" runat="server" Text="Order No:"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txt_orderNo" runat="server" CssClass="inputTextbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txt_orderNoValidator" runat="server" ControlToValidate="txt_orderNo" ErrorMessage="Order No is a required field!" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="lbl_invoiceNo" runat="server" Text="Invoice No:"></asp:Label>
            
        </div>
        <div>
            <asp:TextBox ID="txt_invoiceNo" runat="server" CssClass="inputTextbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txt_invoiceNoValidator" runat="server" ControlToValidate="txt_invoiceNo" ErrorMessage="Invoice No is a required field!" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="lbl_date" runat="server" Text="Order Date:"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="txt_date" runat="server" CssClass="inputTextbox"></asp:TextBox><asp:Button ID="btn_getDate" runat="server" Text="Get Date" CssClass="navbutton" OnClick="btn_getDate_Click" />
            <asp:CompareValidator ID="txt_dateValidator" runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="txt_date" ErrorMessage="Date is not valid!" ForeColor="Red"></asp:CompareValidator>
        </div>
        <div>
            <asp:Label ID="lbl_supplier" runat="server" Text="Supplier:"></asp:Label>
        </div>
        <div>
            <asp:DropDownList ID="drb_supplier" runat="server" CssClass="inputTextbox"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="lbl_file" runat="server" Text="Select file to upload: "></asp:Label>
        </div>
        <div>
            <asp:FileUpload ID="fu_upload" runat="server" />
        </div>
        <div>
            <asp:Button ID="btn_save" class="navbutton" runat="server" Text="Save" />
        </div>
    </div>
    </form>
</body>
</html>
