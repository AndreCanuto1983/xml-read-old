<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExemploWebSite1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="FrmAgenda" runat="server">
        <div>
            <asp:Label ID="lblTitulo" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>
        <br />
        <div>
            <asp:ListBox ID="lbxContatos" runat="server" Font-Bold="False" Font-Size="Medium" Rows="6" Width="250px"></asp:ListBox>
        </div>
        <br />
        <div>
            <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
        </div>
    </form>
</body>
</html>
