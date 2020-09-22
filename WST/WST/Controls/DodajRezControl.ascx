<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DodajRezControl.ascx.cs" Inherits="WST.Controls.DodajRezControl" %>

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
