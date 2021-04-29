<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="_6930_Survey_Web_Application.UserRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Resgister User</p>
    <p>
        If you want to register in the website, please fill out the following: </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
        <br />
        <asp:TextBox ID="userNameTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="lastNameTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Date of Birth"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="dateOfBirthTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Contact Number"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="contactNumberTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="messageLabel" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="registerButton" runat="server" Text="Register" OnClick="registerButton_Click" />
    </p>
</asp:Content>
