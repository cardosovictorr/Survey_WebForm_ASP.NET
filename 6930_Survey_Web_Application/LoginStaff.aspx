<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoginStaff.aspx.cs" Inherits="_6930_Survey_Web_Application.LoginStaff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
    </p>
    <asp:TextBox ID="passwordTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="errorStaffLabel" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="enterButton" runat="server" BorderStyle="None" OnClick="enterButton_Click" Text="Enter" />
</asp:Content>
