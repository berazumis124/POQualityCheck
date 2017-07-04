<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fn_defects.aspx.cs" Inherits="POQualityCheck.fn_defects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <div>Defect List</div>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grd_defects" runat="server" AutoGenerateColumns="false" AllowPaging="true" ShowFooter="true" OnPageIndexChanging="OnPaging" OnRowEditing="EditDefects" OnRowUpdating="UpdateDefects" OnRowCancelingEdit="CancelEdit" PageSize="50">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ID" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt_ID" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DefectName">
                    <ItemTemplate>
                        <asp:Label ID="lbl_defect" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_defect" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt_defect" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:Label ID="lbl_type" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_type" runat="server" Text='<%# Eval("Type") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt_type" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <FooterTemplate>
                        <asp:Button ID="btn_Add" class="navbutton" runat="server" Text="Add" OnClick="addDefect"/>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
