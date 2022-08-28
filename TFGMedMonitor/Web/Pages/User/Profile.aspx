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
        <br/>
    </form>
</asp:Content>

