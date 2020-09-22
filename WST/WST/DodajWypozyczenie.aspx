<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.Master" CodeBehind="DodajWypozyczenie.aspx.cs" Inherits="WST.DodajWypozyczenie" Title="DodajWypozyczenie" %>
<%@ Register TagPrefix="dodajWypozyczenie" TagName="DodajWypozyczenieControl" Src="~/Controls/DodajWypozyczenieControl.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <h4>Dodaj wypożyczenie</h4>
    <asp:Panel ID="panelInfo" runat="server">
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
    </asp:Panel>
        <div class="bodyForm">
            <dodajWypozyczenie:DodajWypozyczenieControl ID="crtlDodajWypozyczenie" runat="server" />
            <div class="form-group">
                <asp:Button ID="btnSave" CssClass="btn-primary" runat="server" Text="Dodaj" OnClick="btnSave_Click" />
            </div>
        </div>
</asp:Content>
