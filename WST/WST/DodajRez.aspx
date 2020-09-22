<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.Master" CodeBehind="DodajRez.aspx.cs" Inherits="WST.DodajRez" Title="DodajRez" %>
<%@ Register TagPrefix="dodajRez" TagName="DodajRezControl" Src="~/Controls/DodajRezControl.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <h4>Rezerwuj</h4>
    <asp:Panel ID="panelInfo" runat="server">
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
    </asp:Panel>
        <div class="bodyForm">
            <dodajRez:DodajRezControl ID="crtlDodajRez" runat="server" />
            <div class="form-group">
                <asp:Button ID="btnSave" CssClass="btn-primary" runat="server" Text="Zapisz" OnClick="btnSave_Click" />
            </div>
        </div>
</asp:Content>
