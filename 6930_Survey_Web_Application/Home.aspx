<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="_6930_Survey_Web_Application.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div>
    <h3>
        &nbsp;</h3>
    <asp:Label ID="QuestionText" runat="server" Text="Question Text" style="font-size: x-large"></asp:Label>
</div>
<p>
    <asp:Image ID="Image2" runat="server" Height="37px" ImageUrl="~/images/question_mark.png" Width="50px" />
</p>
    <p>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="errorMessageLabel" runat="server"></asp:Label>
</p>
<p>
    <asp:Button ID="NextQuestionButton" runat="server" Text="Next" OnClick="NextQuestionButton_Click" />
</p>
</asp:Content>
