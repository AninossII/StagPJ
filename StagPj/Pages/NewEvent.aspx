<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEvent.aspx.cs" Inherits="StagPj.NewEventPage" %>

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
        <asp:Button ID="Button2" runat="server" Text="<<" OnClick="Button2_Click" />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>

        <asp:TextBox ID="tbPrix" runat="server" placeholder="Price..." Width="170px"></asp:TextBox>
        
        <p>
            <asp:TextBox ID="tbDes" runat="server" Height="85px" TextMode="MultiLine" placeholder="Note..." Width="170px" ></asp:TextBox>
        </p>
        
        <p>

        <asp:DropDownList ID="dlCompts" runat="server" Height="41px" Width="171px" >
            
        </asp:DropDownList>

            <asp:CheckBox ID="cbAjout" TextAlign="Left" runat="server" Text="Ajout: " CssClass="chkListStyle"  OnCheckedChanged="CheckBox1_CheckedChanged" />
        </p>
                
        <p>
            <input id="tags" runat="server" type="text" data-role="tagsinput" list="catyList"/>
        </p>

        <p>
            <asp:Button ID="btnEvent" runat="server" Text="Create Event" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
