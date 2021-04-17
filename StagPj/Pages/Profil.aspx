<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="StagPj.Pages.Profil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Sources/Css/StyleSheet_Profil.css" rel="stylesheet" />
    <link rel="stylesheet" href="Sources/Css/Style.css"/>
    <link rel="stylesheet" href="Sources/Css/normalize.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/milligram/1.4.1/milligram.css">
</head>
<body>
   <form id="form1" runat="server">
        <div>
           <div class="image-ptofil">
               <asp:Image ID="Image1" runat="server" />
               <asp:Label ID="lbuserName" runat="server" Text="Label"></asp:Label>
           </div>
           <div class="info_profil">
               <h4>info</h4>
               <table class="auto-style2" align="center">
                   <tr>
                       <td>
                           <img src="#" alt="Alternate Text" />
                           <h4>Date Inscri</h4>
                           <asp:Label ID="lbdateInsc" runat="server" Text="Label"></asp:Label>
                       </td>
                       <td>
                           <img src="#" alt="Alternate Text" />
                           <h4>Comptes</h4>
                           <asp:Label ID="lbcomptNum" runat="server" Text="Label"></asp:Label>

                       </td>
                       </tr>

                   <tr>
                       <td>
                           <img src="#" alt="Alternate Text" />
                           <h4>Last Transaction </h4>
                           <asp:Label ID="lblastTrans" runat="server" Text="Label"></asp:Label>
                       </td>
                       <td>
                           <img src="#" alt="Alternate Text" />
                           <h4>Price</h4>
                           <asp:Label ID="lbtotal" runat="server" Text="Label"></asp:Label>
                       </td>
                       </tr>
               </table>
           </div>

           <div class="last_Transaction">
               <h4>last Transaction</h4>
               <div class="transaction">
                   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                   <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
               </div>
              
           </div>    
        </div>
        <div>
        <%--<ul class="bar_bas" >
            <li class="op_item"><img src="#" alt="Raya" /></li>
            <li class="op_item"><img src="#" alt="bola" /></li>
            <li class="op_item"><img src="#" alt="Add" /></li>
            <li class="op_item"><img src="#" alt="profil" /></li>
            <li class="op_item"><img src="#" alt="para" /></li>
        </ul>--%>
        </div>
    </form>
</body>
</html>
