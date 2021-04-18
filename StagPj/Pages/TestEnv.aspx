<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestEnv.aspx.cs" Inherits="StagPj.Pages.TestForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #tags {
            width: 161px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        </input>
        
        &nbsp;<div>
           
            <div class="bootstrap-tagsinput"> 
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        

        <p>
            <input id="tags" runat="server" size="1" type="text" data-role="tagsinput" list="catyList" /></p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
