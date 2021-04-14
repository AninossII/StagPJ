<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="StagPj.Pages.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .comptsBox {
            border: solid 2px gray;
        }
        .smoney{
            border: solid 2px gold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lbCompt" runat="server" Text="Label"></asp:Label>
    
    </div>
        <br/>
        <div class="smoney">
            <asp:Label ID="lbMont" runat="server" Text="Depense : "></asp:Label>
            <asp:Label ID="lbDep" runat="server" Text="Label"></asp:Label>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Ressource : "></asp:Label>
                <asp:Label ID="lbRess" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

        <br/>
        <p>
            <asp:Button ID="btnWid" runat="server" Text="-" Style="margin-right: 10px" OnClick="btnWid_Click"/>
            <asp:Button ID="btnAdd" runat="server" Text="+" OnClick="btnAdd_Click" />
        </p>
    </form>
</body>
</html>
