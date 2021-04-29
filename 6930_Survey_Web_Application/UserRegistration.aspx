<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="_6930_Survey_Web_Application.UserRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <asp:TextBox ID="userNameTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="lastNameTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="dateOfBirthTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:TextBox ID="contactNumberTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </p>
</asp:Content>
