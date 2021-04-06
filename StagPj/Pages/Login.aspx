<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StagPj.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Sing In
                

        </div>
        <asp:TextBox ID="TextBox1" runat="server" value="Ayoub@gmail.com"></asp:TextBox>
        <div><asp:TextBox ID="TextBox2" runat="server" value="team"></asp:TextBox></div>
        

        <p>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />       
        </p>
        

    </form>
</body>
</html>
