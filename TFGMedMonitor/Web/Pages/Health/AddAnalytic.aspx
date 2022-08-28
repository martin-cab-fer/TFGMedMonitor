<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="AddAnalytic.aspx.cs" Inherits="Web.Pages.Health.AddAnalytic" %>

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
        <form id="AnalyticForm" method="post" runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclPatient" runat="server" meta:resourcekey="lclPatient" /></span>
                    <span class="entry">
                        <asp:Label ID="txtPatient" runat="server" Width="100px" Height="20px"
                            meta:resourcekey="txtPatientResource1"/>
                </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclAttendant" runat="server" meta:resourcekey="lclAttendant" /></span>
                    <span class="entry">
                        <asp:Label ID="txtAttendant" runat="server" Width="100px" Height="20px"
                            meta:resourcekey="txtAttendantResource1"/>
                </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclWeight" runat="server" meta:resourcekey="lclWeight" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtWeight" runat="server"
                            Width="100px" Columns="16" meta:resourcekey="txtWeightResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtWeight"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvWeightResource1"></asp:RequiredFieldValidator></span>
                        <asp:RegularExpressionValidator ID="typeValidator1" runat="server"
                            ControlToValidate="txtWeight" ValidationExpression="(\d)*"
                            Text="<%$ Resources: Common, typeError %>" Display="Dynamic"
                            CssClass="errorMessage" />
                        <asp:Label CssClass="errorMessage" ID="lblIdentifierError1"
                            runat="server" meta:resourcekey="lblIdentifierError" />
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclProcedure" runat="server" meta:resourcekey="lclProcedureS" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtProcedure" runat="server"
                            Width="100px" Columns="16" meta:resourcekey="txtProcedureResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvProcedure" runat="server" ControlToValidate="txtProcedure"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvProcedureResource1"></asp:RequiredFieldValidator></span>
            </div>     
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclObservations" runat="server" meta:resourcekey="lclObservations" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtObservations" runat="server"
                            Width="100px" Columns="16" meta:resourcekey="txtObservationsResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvObservations" runat="server" ControlToValidate="txtObservations"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvObservationsResource1"></asp:RequiredFieldValidator></span>
            </div>   
            <div class="button">
                <asp:Button ID="btnSend" runat="server" OnClick="BtnSendClick" meta:resourcekey="btnSend" />
            </div>
        </form>
    </div>
</asp:Content>
