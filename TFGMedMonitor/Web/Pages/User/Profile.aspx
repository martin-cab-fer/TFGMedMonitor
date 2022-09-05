<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Web.Pages.User.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">          
        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclUserName" runat="server" meta:resourcekey="lclUserName" /></span>
                    <span class="entry">
                        <asp:Label ID="txtUserName" runat="server"
                            meta:resourcekey="txtUserNameResource1"/>
                </span>
        </div>
        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclFirstName" runat="server" meta:resourcekey="lclFirstName" /></span>
                    <span class="entry">
                        <asp:Label ID="txtFirstName" runat="server"
                            meta:resourcekey="txtFirstNameResource1"/>
                </span>
        </div>
        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclSurname" runat="server" meta:resourcekey="lclSurname" /></span>
                    <span class="entry">
                        <asp:Label ID="txtSurname" runat="server"
                            meta:resourcekey="txtSurnameResource1"/>
                </span>
        </div>
        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclUserType" runat="server" meta:resourcekey="lclUserType" /></span>
                    <span class="entry">
                        <asp:Label ID="txtUserType" runat="server"
                            meta:resourcekey="txtUserTypeResource1"/>
                </span>
        </div>
        <br/>
        <br/>
        <asp:Button ID="btnMessage" CssClass="button" runat="server" CausesValidation="false" Visible="false"
            meta:resourcekey="btnMessage" OnClick="BtnMessageClick"/>
        <br/>
    </form>
</asp:Content>

