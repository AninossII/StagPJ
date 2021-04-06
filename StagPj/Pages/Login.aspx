<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StagPj.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Sources/Css/StyleSheet_Login.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div>
                <button><</button>
            </div>


            <div class="bk_login">
                <center>
                    <asp:Label ID="Label2" runat="server" Text="Sing In"></asp:Label>
                </center>
                <ul class="Litm_page">
                    <li>
                        <asp:TextBox ID="tbEmail" runat="server" value="Ayoub@gmail.com"></asp:TextBox>
                    </li>
                    <li>
                        <asp:TextBox ID="tbPass" runat="server">team</asp:TextBox>
                    </li>
                    <li>
                        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
                    </li>
                    <li>
                        <asp:CheckBox ID="CheckBox1" runat="server" text="Remember me"/>
                        <asp:Label ID="Label1" runat="server" Text="Forgot Password"></asp:Label>
                    </li>
                    <li></li>
                    <li></li>
                    <li>
                        <h3>
                            By cliking "
                            <span>
                                <a href="#">Sing Up</a>
                            </span>" to create acount.
                        </h3>
                    </li>
                </ul>

            </div>

        </div>
    </form>
</body>
</html>
