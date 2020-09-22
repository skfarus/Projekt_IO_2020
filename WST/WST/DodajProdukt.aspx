<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.Master" CodeBehind="DodajProdukt.aspx.cs" Inherits="WST.DodajProdukt" Title="DodajProdukt" %>
<%@ Register TagPrefix="dodajProdukt" TagName="DodajProduktControl" Src="~/Controls/DodajProduktControl.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <h4>Dodaj produkt</h4>
    <asp:Panel ID="panelInfo" runat="server">
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
    </asp:Panel>
        <div class="bodyForm">
            <dodajProdukt:DodajProduktControl ID="crtlDodajProdukt" runat="server" />
            <div class="form-group">
                <asp:Button ID="btnSave" CssClass="btn-primary" runat="server" Text="Dodaj" OnClick="btnSave_Click" />
            </div>
        </div>
</asp:Content>
