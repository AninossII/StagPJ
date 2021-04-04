<<<<<<< HEAD
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEventPage.aspx.cs" Inherits="StagPj.NewEventPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/milligram/1.4.1/milligram.css">

</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button2" runat="server" Text="<<" OnClick="Button2_Click" />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

        <asp:TextBox ID="TextBox1" runat="server" placeholder="Price..." Width="170px" value="20"></asp:TextBox>
        
        <p>
            <asp:TextBox ID="TextBox2" runat="server" Height="85px" TextMode="MultiLine" placeholder="Note..." Width="170px" >Sandwich</asp:TextBox>
        </p>
        
        <asp:DropDownList ID="DropDownList1" runat="server" Height="41px" Width="171px">
            
            </asp:DropDownList>

        <p>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Ajoute "/>
        </p>

        <asp:Button ID="Button1" runat="server" Text="Create Event" OnClick="Button1_Click" />
    </form>
</body>
</html>
=======
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEventPage.aspx.cs" Inherits="StagPj.NewEventPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/milligram/1.4.1/milligram.css">

</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button2" runat="server" Text="<<" OnClick="Button2_Click" />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

        <asp:TextBox ID="TextBox1" runat="server" placeholder="Price..." Width="170px" value="20"></asp:TextBox>
        
        <p>
            <asp:TextBox ID="TextBox2" runat="server" Height="85px" TextMode="MultiLine" placeholder="Note..." Width="170px" >Sandwich</asp:TextBox>
        </p>
        
        <asp:DropDownList ID="DropDownList1" runat="server" Height="41px" Width="171px">
            
            </asp:DropDownList>

        <p>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Ajoute "/>
        </p>

        <asp:Button ID="Button1" runat="server" Text="Create Event" OnClick="Button1_Click" />
    </form>
</body>
</html>
>>>>>>> 1469bfff1b6108f8ac1ea9a1d0122f6c974317ec
