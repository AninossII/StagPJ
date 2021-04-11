<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="StagPj.Pages.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .comptsBox {
            border: solid 2px gray;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lbCompt" runat="server" Text="Label"></asp:Label>
    
    </div>
        <asp:Label ID="lbMont" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:Button ID="btnWid" runat="server" Text="-" Style="margin-right: 10px"/>
            <asp:Button ID="btnAdd" runat="server" Text="+" />
        </p>
    </form>
</body>
</html>
