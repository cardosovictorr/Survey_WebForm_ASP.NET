<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="_6930_Survey_Web_Application.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        SEARCH!</p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Search for a Question:"></asp:Label>
    </p>

<asp:TextBox ID="UserSearchText" runat="server"></asp:TextBox>
                <asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="SearchBtn_Click" />
    &nbsp;<asp:Button ID="allQuestionButton" runat="server" OnClick="allQuestionButton_Click" Text="See All" />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Search by name in Answers"></asp:Label>
    :<br />
    <!--<asp:PlaceHolder ID="PlaceHolder1" runat="server">Content</asp:PlaceHolder>-->
                <asp:TextBox ID="byResponsesTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="searchInResponsesButton" runat="server" OnClick="searchInResponsesButton_Click" Text="Search" />
    &nbsp;<asp:Button ID="seeAllAnswersButton" runat="server" OnClick="seeAllAnswersButton_Click" Text="See All" />
    <br />
    <br />
    Search by State in Answers:<br />
    <asp:TextBox ID="byStatesTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="searchByStateButton" runat="server" OnClick="searchByStateButton_Click" Text="Search" />
    <br />
    <br />
    Search by name in Registered Users:<br />
    <asp:TextBox ID="byRegisterTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="byRegisteredButton" runat="server" OnClick="byRegisteredButton_Click" Text="Search" />
&nbsp;<asp:Button ID="seeAllRegisteredButton" runat="server" OnClick="seeAllRegisteredButton_Click" Text="See All" />
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="typeTableLabel" runat="server"></asp:Label>
    <br />
    <br />
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
    
    
</asp:Content>
