<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="ShowMessages.aspx.cs" Inherits="Web.Pages.Admin.ShowMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">    
    <p>
        <asp:Label ID="lblNoMessages" meta:resourcekey="lblNoMessages" runat="server"></asp:Label>
    </p>     
        <asp:GridView ID="GVMessages" runat="server" GridLines="Both" HorizontalAlign="Center"
            AutoGenerateColumns="False" >
            <Columns>
                <asp:HyperLinkField DataTextField="sender" DataNavigateUrlFields="userName"
                    HeaderText="<%$ Resources:, user %>" ItemStyle-Width="100px"
                    DataNavigateUrlFormatString="~/Pages/User/Profile.aspx?userName={0}"/>
                <asp:HyperLinkField DataTextField="adressee" DataNavigateUrlFields="userName"
                    HeaderText="<%$ Resources:, user %>" ItemStyle-Width="100px"
                    DataNavigateUrlFormatString="~/Pages/User/Profile.aspx?userName={0}"/>
                <asp:BoundField DataField="title" HeaderText="<%$ Resources:, title %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="message" HeaderText="<%$ Resources:, message %>"
                    ItemStyle-Width="100px"/>
            </Columns>
        </asp:GridView>
    </form>
    <br />
    <!-- "Previous" and "Next" links. -->
    <div class="previousNextLinks">
        <span class="previousLink">
            <asp:HyperLink ID="lnkPrevious" Text="<%$ Resources:Common, Previous %>" runat="server"
                Visible="False"></asp:HyperLink>
        </span><span class="nextLink">
            <asp:HyperLink ID="lnkNext" Text="<%$ Resources:Common, Next %>" runat="server" Visible="False"></asp:HyperLink>
        </span>
    </div>
    <br />
    <br />
</asp:Content>
