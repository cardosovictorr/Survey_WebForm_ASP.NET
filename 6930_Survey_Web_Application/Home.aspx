<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="_6930_Survey_Web_Application.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    HOME PAGE!! DO THE SURVEY HERE</p>
<p>
    &nbsp;</p>
<p>
    <asp:Label ID="QuestionText" runat="server" Text="Question Text"></asp:Label>
</p>
<p>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</p>
<p>
    <asp:Button ID="NextQuestionButton" runat="server" Text="Next" />
</p>
</asp:Content>
