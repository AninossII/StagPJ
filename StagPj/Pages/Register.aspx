<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StagPj.Register" %>

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
            <asp:Label ID="nom" runat="server" Text="Nom"></asp:Label>
            <asp:TextBox ID="tnom" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="Prenom" runat="server" Text="Prenom"></asp:Label>
        <asp:TextBox ID="tprenom" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="temal" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="paswored" runat="server" Text="Paswored"></asp:Label>
            <asp:TextBox ID="tpswrd" runat="server" type="password"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="conpasswrd" runat="server" Text="Converm Password"></asp:Label>
            <asp:TextBox ID="tconpsswrd" runat="server" type="password"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="datenis" runat="server" Text="Date ness"></asp:Label>
            <asp:TextBox ID="t_date_nes" runat="server" type="date"></asp:TextBox>
        </p>
        <asp:RadioButtonList ID="Genre" runat="server">
            <asp:ListItem Value="Famle">Famle</asp:ListItem>
            <asp:ListItem Value="Male">Male</asp:ListItem>
        </asp:RadioButtonList>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
    </form>
</body>
</html>
