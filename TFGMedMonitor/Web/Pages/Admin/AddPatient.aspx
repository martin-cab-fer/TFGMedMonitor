<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="Web.Pages.Admin.AddPatient" %>

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
        <form id="AddPatientForm" method="post" runat="server">

            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclPatientName" runat="server" meta:resourcekey="lclPatientName" />
                </span><span
                        class="entry">
                        <asp:TextBox ID="txtPatientName" runat="server" Width="100px" Columns="16"
                            meta:resourcekey="txtPatientNameResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPatientName" runat="server" ControlToValidate="txtPatientName"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvPatientResource1"></asp:RequiredFieldValidator></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclBirthDate" runat="server" meta:resourcekey="lclBirthDate" /></span><span
                        class="entry">
                        <asp:TextBox TextMode="Date" ID="txtDate" runat="server"
                            Width="100px" Columns="16" meta:resourcekey="txtDateResource1"></asp:TextBox></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclPatientInfo" runat="server" meta:resourcekey="lclPatientInfo" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtPatientInfo" runat="server" Width="300px" Height="100px"
                            Columns="16" meta:resourcekey="txtPatientInfoResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPatientInfo" runat="server" ControlToValidate="txtPatientInfo"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvPatientInfoResource1"></asp:RequiredFieldValidator></span>
            </div>           
            <div class="button">
                <asp:Button ID="btnAdd" runat="server" OnClick="BtnAddClick" meta:resourcekey="btnAdd"/>
            </div>
        </form>
    </div>
</asp:Content>
