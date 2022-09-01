<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="AddDose.aspx.cs" Inherits="Web.Pages.Health.AddDose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation"
    runat="server">
    -
    <asp:Localize ID="lclMenuExplanation" runat="server" meta:resourcekey="lclMenuExplanation" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    <div id="form">
        <form id="DoseForm" method="post" runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclMedicine" runat="server" meta:resourcekey="lclMedicine" /></span>
                    <span class="entry">
                        <asp:Label ID="txtMedicine" runat="server" Width="100px" Height="20px"
                            meta:resourcekey="txtMedicineResource1"/>
                </span>
            </div>                      
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclNotes" runat="server" meta:resourcekey="lclNotes" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtNotes" runat="server" Height="60px" TextMode="MultiLine"
                            Width="300px" Columns="16" Rows="3" meta:resourcekey="txtNotesResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNotes" runat="server" ControlToValidate="txtNotes"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvNotesResource1"></asp:RequiredFieldValidator></span>
            </div>   
            <div class="button">
                <asp:Button ID="btnSend" runat="server" OnClick="BtnSendClick" meta:resourcekey="btnSend" />
            </div>
        </form>
    </div>
</asp:Content>
