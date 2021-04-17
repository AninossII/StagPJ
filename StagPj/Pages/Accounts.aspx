<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="StagPj.Accounts" %>

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
            <asp:Label ID="lbtitle" runat="server" Text="Accounts"></asp:Label>
            <p>
            <asp:Label ID="lbaccountNum" runat="server" Text="Label"></asp:Label>
            </p>
            <asp:Label ID="timeText" runat="server" Text="Label"></asp:Label>
            <p>
                <asp:Button ID="btnAdd" runat="server" Text="Add new Account" OnClick="btnAdd_Click" />
            </p>

        </div>
    </form>
</body>
</html>
