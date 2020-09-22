<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RejestracjaControl.ascx.cs" Inherits="WST.Controls.RejestracjaControl" %>
<div class="form-group">
    <label class="control-label col-sm-2">Email:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Hasło:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtHaslo" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <label class="control-label col-sm-2">Powtórz hasło:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtHaslo2" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <label class="control-label col-sm-2">Imie:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtImie" class="form-control" runat="server"></asp:TextBox>
    </div>
    <label class="control-label col-sm-2">Nazwisko:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtNazwisko" class="form-control" runat="server"></asp:TextBox>
    </div>
    <label class="control-label col-sm-2">Adres:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtAdres" class="form-control" runat="server"></asp:TextBox>
    </div>
    <label class="control-label col-sm-2">Telefon:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtTelefon" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>

