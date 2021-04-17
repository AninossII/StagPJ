<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="StagPj.Pages.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Sources/Css/Style.css"/>
    <link rel="stylesheet" href="Sources/Css/normalize.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/milligram/1.4.1/milligram.css">
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
        <p>
            <asp:Button ID="btnhomePage" runat="server" Text="Home" Style="margin-right: 10px" OnClick="btnhomePage_Click"/>
            <asp:Button ID="btneventPage" runat="server" Text="Event" Style="margin-right: 10px" OnClick="btneventPage_Click"/>
            <asp:Button ID="btnaccountPage" runat="server" Text="Accounts" Style="margin-right: 10px" OnClick="btnaccountPage_Click"/>
            <asp:Button ID="btnprofilgPage" runat="server" Text="Profil" Style="margin-right: 10px" OnClick="btnprofilgPage_Click"/>
        </p>
    </form>
</body>
</html>
