<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fn_supplier.aspx.cs" Inherits="POQualityCheck.fn_supplier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <div>Supplier List</div>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grd_supplier" runat="server" AutoGenerateColumns="false" AllowPaging="true" ShowFooter="true" PageSize="50" OnPageIndexChanging="OnPaging" OnRowEditing="EditSupplier" OnRowUpdating="UpdateSupplier" OnRowCancelingEdit="CancelEdit" >
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt_id" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText ="Supplier">
                    <ItemTemplate>
                        <asp:Label ID="lbl_supplier" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_supplier" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt_supplier" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <FooterTemplate>
                        <asp:Button ID="btn_add" class="navbutton" runat="server" Text="Add" OnClick="addSupplier" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="true" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
