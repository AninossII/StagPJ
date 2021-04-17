<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAccount.aspx.cs" Inherits="StagPj.Pages.NewAccount" %>

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
    <asp:Button ID="btnback" runat="server" Text="<<" OnClick="btnback_Click" />
    <div>
    </div>

    <p class="auto-style1">
        <asp:TextBox ID="tbNom" runat="server" placeholder="Nom compte" Width="170px" ></asp:TextBox>
    </p>
        
    <p class="auto-style1">

        <asp:TextBox ID="tbMontant" runat="server" placeholder="Price..." Width="170px"></asp:TextBox>
    </p>
    <p class="auto-style1">

        <asp:Button ID="btnAccount" runat="server" Text="Create Compte" OnClick="btnAccount_Click" />
    </p>
    <div>
    </div>
</form>
</body>
</html>
