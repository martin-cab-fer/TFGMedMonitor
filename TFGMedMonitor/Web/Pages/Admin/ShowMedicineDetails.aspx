<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="ShowMedicineDetails.aspx.cs" Inherits="Web.Pages.Admin.ShowMedicineDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation"
    runat="server">
    -
    <asp:Localize ID="lclMenuExplanation" runat="server" meta:resourcekey="lclMenuExplanation" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    <form runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclRegNum" runat="server" meta:resourcekey="lclRegNum" />
                </span><span
                        class="entry">
                        <asp:Label ID="txtRegNum" runat="server" Width="100px" Columns="16" TextMode="Number"
                            meta:resourcekey="txtRegNumResource1"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclMedName" runat="server" meta:resourcekey="lclMedName" />
                </span><span
                        class="entry">
                        <asp:Label ID="txtMedName" runat="server" Width="200px" Columns="16"
                            meta:resourcekey="txtMedNameResource1"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclLabName" runat="server" meta:resourcekey="lclLabName" />
                </span><span
                        class="entry">
                        <asp:Label ID="txtLabName" runat="server" Width="200px" Columns="16"
                            meta:resourcekey="txtLabNameResource1"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclAuthDate" runat="server" meta:resourcekey="lclAuthDate" /></span><span
                        class="entry">
                        <asp:Label ID="txtAuthDate" runat="server"
                            Width="200px" Columns="16" meta:resourcekey="txtAuthDateResource1"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclMedStatus" runat="server" meta:resourcekey="lclMedStatus" /></span><span
                        class="entry">
                        <asp:Label ID="txtMedStatus" runat="server" Width="100px"
                            Columns="16" meta:resourcekey="txtMedStatusResource1"></asp:Label></span>
            </div>   
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclStatusDate" runat="server" meta:resourcekey="lclStatusDate" /></span><span
                        class="entry">
                        <asp:Label ID="txtStatusDate" runat="server"
                            Width="200px" Columns="16" meta:resourcekey="txtStatusDateResource1"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclATCCode" runat="server" meta:resourcekey="lclATCCode" /></span><span
                        class="entry">
                        <asp:Label ID="txtATCCode" runat="server" Width="100px" MaxLength="7"
                            Columns="16" meta:resourcekey="txtATCCodeResource1"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclActivePrin" runat="server" meta:resourcekey="lclActivePrin" /></span>
                    <span class="entry">
                        <asp:Label ID="txtActivePrin" runat="server" Width="200px" Height="20px"
                            meta:resourcekey="txtActivePrinResource1"/></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclCommerc" runat="server" meta:resourcekey="lclCommerc" />
                </span><span
                        class="entry">
                        <asp:Label ID="txtCommerc" runat="server" meta:resourcekey="txtCommercResource1"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclYellowT" runat="server" meta:resourcekey="lclYellowT" />
                </span><span
                        class="entry">
                        <asp:Label ID="txtYellowT" runat="server" meta:resourcekey="txtYellowTResource1"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclObservations" runat="server" meta:resourcekey="lclObservations" /></span><span
                        class="entry">
                        <asp:Label ID="txtObservations" runat="server" Width="300px"
                            Columns="16" meta:resourcekey="txtObservationsResource1"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclSubst" runat="server" meta:resourcekey="lclSubst" /></span><span
                        class="entry">
                        <asp:Label ID="txtSubst" runat="server" Width="300px"
                            Columns="16" meta:resourcekey="txtSubstResource1"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclAffectsC" runat="server" meta:resourcekey="lclAffectsC" />
                </span><span
                        class="entry">
                        <asp:Label ID="txtAffectsC" runat="server" meta:resourcekey="txtAffectsCResource1"></asp:Label></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclSupplyI" runat="server" meta:resourcekey="lclSupplyI" />
                </span><span
                        class="entry">
                        <asp:Label ID="txtSupplyI" runat="server" meta:resourcekey="txtSupplyIResource1"></asp:Label></span>
            </div>
        </form>
</asp:Content>
