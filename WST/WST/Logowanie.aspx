<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.Master" CodeBehind="Logowanie.aspx.cs" Inherits="WST.Logowanie" Title="Logowanie" %>
<%@ Register TagPrefix="logowanie" TagName="LogowanieControl" Src="~/Controls/LogowanieControl.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <h4>Zaloguj</h4>
    <asp:Panel ID="panelInfo" runat="server">
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
    </asp:Panel>
        <div class="bodyForm">
            <logowanie:LogowanieControl ID="crtlLogowanie" runat="server" />
            <div class="form-group">
                <asp:Button ID="btnSave" CssClass="btn-primary" runat="server" Text="Zaloguj" OnClick="btnSave_Click" />
            </div>
        </div>
    Nie masz konta ? Zarejestruj się <a href="Rejestracja.aspx">tutaj</a>.
</asp:Content>
