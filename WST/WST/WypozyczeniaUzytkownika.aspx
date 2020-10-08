<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.Master" CodeBehind="WypozyczeniaUzytkownika.aspx.cs" Inherits="WST.WypozyczeniaUzytkownika" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <h4>Wypożyczenia użytkownika</h4>
    <div style="margin: 0 auto; width:90%">
        <asp:GridView ID="gvOpis" runat="server" AutoGenerateColumns="false" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:BoundField DataField="Opis" HeaderText="Opis"/>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvWypozyczenia" runat="server" AutoGenerateColumns="false" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id"/>
                <asp:BoundField DataField="Produkt_id" HeaderText="Produkt"/>
                <asp:BoundField DataField="Ilosc" HeaderText="Ilość"/>
                <asp:BoundField DataField="Data_od" HeaderText="Data od"/>
                <asp:BoundField DataField="Data_do" HeaderText="Data do"/>
                <asp:BoundField DataField="Ilosc_dni" HeaderText="Ilość dni"/>


            </Columns>
        </asp:GridView>
    </div>
</asp:Content>