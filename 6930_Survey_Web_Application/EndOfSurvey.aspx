<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EndOfSurvey.aspx.cs" Inherits="_6930_Survey_Web_Application.EndOfSurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Table ID="quastionAnswerDisplayTable" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">QuestionId</asp:TableCell>
                <asp:TableCell runat="server">Answer Text</asp:TableCell>
                <asp:TableCell runat="server">Option Id</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </p>
    <p>
        <asp:Label ID="LabelMessage" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>
