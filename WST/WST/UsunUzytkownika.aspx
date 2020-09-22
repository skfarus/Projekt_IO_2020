<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.Master" CodeBehind="UsunUzytkownika.aspx.cs" Inherits="WST.UsunUzytkownika" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBody" runat="server">
    <h4>Użytkownicy</h4>
    <div style="margin: 0 auto; width:90%">
        <asp:GridView ID="gvOpis" runat="server" AutoGenerateColumns="false" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:BoundField DataField="Opis" HeaderText="Opis"/>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvUzytkownicy" runat="server" AutoGenerateColumns="false" CssClass="Grid" AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id"/>
                <asp:BoundField DataField="Imie" HeaderText="Imie"/>
                <asp:BoundField DataField="Nazwisko" HeaderText="Nazwisko"/>
                <asp:BoundField DataField="Email" HeaderText="Email"/>
                <asp:BoundField DataField="Telefon" HeaderText="Telefon"/>
                <asp:BoundField DataField="Adres" HeaderText="Adres"/>
                <asp:BoundField DataField="Admin" HeaderText="Admin"/>

                <asp:TemplateField>
                    <ItemTemplate>

                        <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Eval("Id")%>' OnCommand="lnkDelete" Text="Usuń">

                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>