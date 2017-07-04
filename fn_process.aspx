<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fn_process.aspx.cs" Inherits="POQualityCheck.fn_processZero" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <script type="text/javascript">
            function getButton(id, lid) {
                PageMethods.storePress(id, lid);
                //alert("ffffff");
                counter(id);
            }
            function onSuccess() {
                alert("pavyko!");
            }
            function onFailure() {
                alert("nepavyko :(");
            }
            function counter(id) {
                document.getElementById("s_" + id).innerHTML = parseInt(document.getElementById("s_" + id).innerHTML) + 1;
            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"/>
            <asp:PlaceHolder ID="ph_defButtons" runat="server" />
        </div>
        <div class="nav">
            <div class="navBtn">
                <asp:Button ID="btn_back" class="navbutton" runat="server" Text="Back" OnClick="btn_back_Click" />
            </div>
            <div class="navBtn">
                <asp:Button ID="btn_next" class="navbutton" runat="server" Text="Next" OnClick="btn_next_Click" />
            </div>
            <div class="navBtn">
                <asp:Button ID="btn_finish" class="navbutton" runat="server" Text="Finish" OnClick="btn_finish_Click" />
            </div>
        </div>
        
    </form>
</body>
</html>
