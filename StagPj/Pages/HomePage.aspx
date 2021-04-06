<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="StagPj.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        div.Event {
            border: solid 3px gold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
    
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    
    </div>
        <asp:Label ID="dayText" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="monthText" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        
        
            <asp:Label ID="timeText" runat="server" Text="Label"></asp:Label>
        
        
        <p>
        
        <asp:Button ID="tbnNewevent" runat="server" Text="Add Event" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
