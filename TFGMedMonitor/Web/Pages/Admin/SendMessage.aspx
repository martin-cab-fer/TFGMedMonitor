<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="Web.Pages.Admin.SendMessage" %>


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
        <form id="SendMessageForm" method="post" runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclAdressee" runat="server" meta:resourcekey="lclAdressee" /></span>
                    <span class="entry">
                        <asp:Label ID="txtAdressee" runat="server" Width="200px" Height="20px"
                            meta:resourcekey="txtAdresseeResource1"/>
                </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclTitle" runat="server" meta:resourcekey="lclTitle" /></span><span
                        class="entry">
                        <asp:TextBox ID="txtTitle" runat="server"
                            Width="200px" Height="20px" Columns="16" meta:resourcekey="txtTitleResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvTitleResource1"></asp:RequiredFieldValidator></span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclMessage" runat="server" meta:resourcekey="lclMessage" /></span><span
                        class="entry">
                        <asp:TextBox TextMode="MultiLine" ID="txtMessage" runat="server"
                            Width="300px" Height="100px" Columns="16" Rows="5" meta:resourcekey="txtMessageResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage"
                            Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>"
                            meta:resourcekey="rfvMessageResource1"></asp:RequiredFieldValidator></span>
            </div>        
            <div class="button">
                <asp:Button ID="btnSend" CssClass="button" runat="server" OnClick="BtnSendClick" meta:resourcekey="btnSend" />
            </div>
        </form>
    </div>
</asp:Content>
