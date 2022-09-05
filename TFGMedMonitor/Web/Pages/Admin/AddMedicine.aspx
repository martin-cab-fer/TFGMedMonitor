<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="AddMedicine.aspx.cs" Inherits="Web.Pages.Admin.AddMedicine" %>

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
        <form id="AddMedicineForm" method="post" runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclRegNum" runat="server" meta:resourcekey="lclRegNum" />
                </span><span
                        class="entry">
                        <asp:TextBox ID="txtRegNum" runat="server" Width="100px" Columns="16" TextMode="Number"
                            meta:resourcekey="txtRegNumResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvRegNum" runat="server" ControlToValidate="txtRegNum"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvRegNumResource1"></asp:RequiredFieldValidator>
                       </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclMedName" runat="server" meta:resourcekey="lclMedName" />
                </span><span
                        class="entry">
                        <asp:TextBox ID="txtMedName" runat="server" Width="100px" Columns="16"
                            meta:resourcekey="txtMedNameResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMedName" runat="server" ControlToValidate="txtMedName"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvMedNameResource1"></asp:RequiredFieldValidator></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclLabName" runat="server" meta:resourcekey="lclLabName" />
                </span><span
                        class="entry">
                        <asp:TextBox ID="txtLabName" runat="server" Width="100px" Columns="16"
                            meta:resourcekey="txtLabNameResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLabName" runat="server" ControlToValidate="txtLabName"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvLabNameResource1"></asp:RequiredFieldValidator></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclAuthDate" runat="server" meta:resourcekey="lclAuthDate" /></span><span
                        class="entry">
                        <asp:TextBox TextMode="Date" ID="txtAuthDate" runat="server"
                            Width="100px" Columns="16" meta:resourcekey="txtAuthDateResource1"></asp:TextBox></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclMedStatus" runat="server" meta:resourcekey="lclMedStatus" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtMedStatus" runat="server" Width="100px"
                            Columns="16" meta:resourcekey="txtMedStatusResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMedStatus" runat="server" ControlToValidate="txtMedStatus"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvMedStatusResource1"></asp:RequiredFieldValidator></span>
            </div>   
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclStatusDate" runat="server" meta:resourcekey="lclStatusDate" /></span><span
                        class="entry">
                        <asp:TextBox TextMode="Date" ID="txtStatusDate" runat="server"
                            Width="100px" Columns="16" meta:resourcekey="txtStatusDateResource1"></asp:TextBox></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclATCCode" runat="server" meta:resourcekey="lclATCCode" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtATCCode" runat="server" Width="100px" MaxLength="7"
                            Columns="16" meta:resourcekey="txtATCCodeResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvATCCode" runat="server" ControlToValidate="txtATCCode"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvATCCodeResource1"></asp:RequiredFieldValidator></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclActivePrin" runat="server" meta:resourcekey="lclActivePrin" /></span>
                    <span class="entry">
                        <asp:Label ID="txtActivePrin" runat="server" Width="100px" Height="20px"
                            meta:resourcekey="txtActivePrinResource1"/>
                        <asp:Button ID="btnRemovePrin" runat="server" OnClick="BtnRemovePrinClick"
                            CausesValidation="false" meta:resourcekey="btnRemovePrin" />
                </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclNewActPrin" runat="server" meta:resourcekey="lclNewActPrin" /></span>
                    <span class="entry">
                        <asp:TextBox ID="txtNewActPrin" runat="server"
                            Width="100px" Columns="16" meta:resourcekey="txtNewActPrinResource1"></asp:TextBox> 
                        <asp:Button ID="btnAddPrin" runat="server" OnClick="BtnAddPrinClick"
                            CausesValidation="false" meta:resourcekey="btnAddPrin" />
                    </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCommerc" runat="server" meta:resourcekey="lclCommerc" />
                </span><span
                        class="entry">
                        <asp:CheckBox ID="txtCommerc" runat="server" meta:resourcekey="txtCommercResource1"></asp:CheckBox></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclYellowT" runat="server" meta:resourcekey="lclYellowT" />
                </span><span
                        class="entry">
                        <asp:CheckBox ID="txtYellowT" runat="server" meta:resourcekey="txtYellowTResource1"></asp:CheckBox></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclObservations" runat="server" meta:resourcekey="lclObservations" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtObservations" runat="server" Width="100px"
                            Columns="16" meta:resourcekey="txtObservationsResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvObservations" runat="server" ControlToValidate="txtObservations"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvObservationsResource1"></asp:RequiredFieldValidator></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclSubst" runat="server" meta:resourcekey="lclSubst" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtSubst" runat="server" Width="100px"
                            Columns="16" meta:resourcekey="txtSubstResource1"></asp:TextBox></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclAffectsC" runat="server" meta:resourcekey="lclAffectsC" />
                </span><span
                        class="entry">
                        <asp:CheckBox ID="txtAffectsC" runat="server" meta:resourcekey="txtAffectsCResource1"></asp:CheckBox></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclSupplyI" runat="server" meta:resourcekey="lclSupplyI" />
                </span><span
                        class="entry">
                        <asp:CheckBox ID="txtSupplyI" runat="server" meta:resourcekey="txtSupplyIResource1"></asp:CheckBox></span>
            </div>
            <div class="button">
                <asp:Button ID="btnAdd" CssClass="button" runat="server" OnClick="BtnAddClick" meta:resourcekey="btnAdd"/>
            </div>
        </form>
    </div>
</asp:Content>
