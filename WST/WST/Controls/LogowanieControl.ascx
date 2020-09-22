<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LogowanieControl.ascx.cs" Inherits="WST.Controls.LogowanieControl" %>
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
</div>

