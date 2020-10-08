<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.Master" CodeBehind="Default.aspx.cs" Inherits="WST.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">

    <h4 class="hello_text">
        <p>Witamy w wypożyczalni sprzętu turystycznego,<br /> 
        aby dokonać rezerwacji należy się zalogować.</p>

    </h4>
    <br />

    <h5 style="text-indent:20px;">Produkty</h5>
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
