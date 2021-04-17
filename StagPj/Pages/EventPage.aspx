<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventPage.aspx.cs" Inherits="StagPj.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        div.Event {
            border: solid 3px gold;
        }
    </style>
    <link rel="stylesheet" href="Sources/Css/Style.css"/>
    <link rel="stylesheet" href="Sources/Css/normalize.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/milligram/1.4.1/milligram.css">
</head>
<body>
    <form id="form1" runat="server" >
    <div>
    
        <asp:Calendar ID="calDay" runat="server" OnSelectionChanged="calDay_SelectionChanged"></asp:Calendar>
    
    </div>
        <asp:Label ID="dayText" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="monthText" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        
        
            <asp:Label ID="timeText" runat="server" Text="Label"></asp:Label>
        
        
        <p>
        
        <asp:Button ID="tbnNewevent" runat="server" Text="Add Event" OnClick="Button1_Click" />
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
