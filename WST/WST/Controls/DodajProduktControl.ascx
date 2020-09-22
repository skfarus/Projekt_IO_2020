<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DodajProduktControl.ascx.cs" Inherits="WST.Controls.DodajProduktControl" %>

<div class="form-group">
    <label class="control-label col-sm-2">Marka:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtMarka" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Model:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtModel" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Opis:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtOpis" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Ilość:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtIlosc" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>