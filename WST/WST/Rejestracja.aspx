<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.Master" CodeBehind="Rejestracja.aspx.cs" Inherits="WST.Rejestracja" Title="Rejestracja" %>
<%@ Register TagPrefix="rejestracja" TagName="RejestracjaControl" Src="~/Controls/RejestracjaControl.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <h4>Zarejestruj</h4>
    <asp:Panel ID="panelInfo" runat="server">
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
    </asp:Panel>
        <div class="bodyForm">
            <rejestracja:RejestracjaControl ID="crtlRejestracja" runat="server" />
            <div class="form-group">
                <asp:Button ID="btnSave" CssClass="btn-primary" runat="server" Text="Zarejestruj" OnClick="btnSave_Click" />
            </div>
        </div>
    Masz już konto ? Zaloguj się <a href="Logowanie.aspx">tutaj</a>.
</asp:Content>
