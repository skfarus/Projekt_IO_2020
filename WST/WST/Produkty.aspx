<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.Master" CodeBehind="Produkty.aspx.cs" Inherits="WST.Produkty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <h5 style="text-indent:20px; margin-top:10px;">Produkty</h5>
    <div>
        <asp:GridView ID="gvOpis" runat="server" AutoGenerateColumns="false" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:BoundField DataField="Opis" HeaderText="Opis"/>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvProdukty" runat="server" AutoGenerateColumns="false" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id"/>
                <asp:BoundField DataField="Marka" HeaderText="Marka"/>
                <asp:BoundField DataField="Model" HeaderText="Model"/>
                <asp:BoundField DataField="Opis" HeaderText="Opis"/>
                <asp:BoundField DataField="Ilosc" HeaderText="Ilość"/>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>