<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="_6930_Survey_Web_Application.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        SEARCH!</p>
    <table border="1" style="width: 100%; height: 100%">
        <tr style="background-color: #000000"; height: 20%;">
            <td colspan="2" style="color:#ffffff; width:100%; text-align:center">
                Header
                <br />

                Search <asp:TextBox ID="UserSearchText" runat="server"></asp:TextBox>
                <asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="SearchBtn_Click" />
            </td>
        </tr>
    

        <tr style="height:800px;">
            <td style="background-color: #C0C0C0; color: #000000">
                <a href="">User Search</a> 
                <br />
                <br />

                <a href="">Question Search</a>
                <br />
                <br />
                
            </td>
            <td>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server">Content</asp:PlaceHolder>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </td>
        </tr>

    </table>
</asp:Content>
