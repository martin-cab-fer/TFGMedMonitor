<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="AddPrescription.aspx.cs" Inherits="Web.Pages.Health.AddPrescription" %>

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
        <form id="PrescriptionForm" method="post" runat="server">
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
                    <asp:Localize ID="lclFrequency" runat="server" meta:resourcekey="lclFrequency" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtFrequency" TextMode="Number" runat="server"
                            Width="100px" Columns="16" meta:resourcekey="txtFrequencyResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFrequency" runat="server" ControlToValidate="txtFrequency"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvFrequencyResource1"></asp:RequiredFieldValidator></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclAdmin" runat="server" meta:resourcekey="lclAdmin" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtAdmin" runat="server"
                            Width="100px" Columns="16" meta:resourcekey="txtAdminResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNotes" runat="server" ControlToValidate="txtAdmin"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvAdminResource1"></asp:RequiredFieldValidator></span>
            </div>   
            <div class="button">
                <asp:Button ID="btnSend" runat="server" OnClick="BtnSendClick" meta:resourcekey="btnSend" />
            </div>
        </form>
    </div>
</asp:Content>
