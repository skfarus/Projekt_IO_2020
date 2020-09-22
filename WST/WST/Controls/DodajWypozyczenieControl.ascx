<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DodajWypozyczenieControl.ascx.cs" Inherits="WST.Controls.DodajWypozyczenieControl" %>

<div class="form-group">
    <label class="control-label col-sm-2">Produkt:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtProdukt_id" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Użytkownik:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtUzytkownik_id" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Ilosc:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtIlosc" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Data od:</label>
    <div class="col-sm-10">
        <asp:Calendar ID="txtData_od" class="form-control" runat="server"></asp:Calendar>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Ilosc dni:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtIlosc_dni" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
