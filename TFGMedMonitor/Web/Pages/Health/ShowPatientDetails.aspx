<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="ShowPatientDetails.aspx.cs" Inherits="Web.Pages.Health.ShowPatientDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">    
        
        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclFullName" runat="server" meta:resourcekey="lclFullName" /></span>
                    <span class="entry">
                        <asp:Label ID="txtFullName" runat="server"
                            meta:resourcekey="txtFullNameResource1"/>
                </span>
        </div>
        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclBirthDate" runat="server" meta:resourcekey="lclBirthDate" /></span>
                    <span class="entry">
                        <asp:Label ID="txtBirthDate" runat="server"
                            meta:resourcekey="txtBirthDateResource1"/>
                </span>
        </div>
        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclInfo" runat="server" meta:resourcekey="lclInfo" /></span>
                    <span class="entry">
                        <asp:Label ID="txtInfo" runat="server"
                            meta:resourcekey="txtInfoResource1"/>
                </span>
        </div>
        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclAssEmployees" runat="server" meta:resourcekey="lclAssEmployees" /></span>
                    <asp:Repeater id="empLinks" runat="server">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" NavigateUrl='<%# "~/Pages/User/Profile.aspx?userName=" + Container.DataItem.ToString() %>'
                                Text="empLinks" />
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Button ID="btnManageEmps" runat="server" OnClick="BtnManageEmpsClick" Visible="false" meta:resourcekey="btnManageEmps" />
        </div>
        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclAssDoctors" runat="server" meta:resourcekey="lclAssDoctors" /></span>
                    <asp:Repeater id="docLinks" runat="server">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" NavigateUrl='<%# "~/Pages/User/Profile.aspx?userName=" + Container.DataItem.ToString() %>'
                                Text="docLinks" />
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Button ID="btnManageDocs" runat="server" OnClick="BtnManageDocsClick" Visible="false" meta:resourcekey="btnManageDocs" />
        </div>
        <div class="button">
            <asp:Button ID="btnAnalytics" CssClass="button" runat="server" OnClick="BtnAnalyticsClick" meta:resourcekey="btnAnalytics" />
        </div>
        <div class="button">
            <asp:Button ID="btnPrescription" CssClass="button" runat="server" OnClick="BtnPrescriptionClick" meta:resourcekey="btnPrescription" />
        </div>
        <br/>
    </form>
</asp:Content>
