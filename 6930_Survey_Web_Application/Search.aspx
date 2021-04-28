<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="_6930_Survey_Web_Application.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        SEARCH!</p>

<asp:TextBox ID="UserSearchText" runat="server"></asp:TextBox>
                <asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="SearchBtn_Click" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">Content</asp:PlaceHolder>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
    
    
</asp:Content>
