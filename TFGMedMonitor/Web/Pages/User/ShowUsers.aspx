<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="ShowUsers.aspx.cs" Inherits="Web.Pages.User.ShowUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">
    <p>
        <asp:Label ID="lblNoUsers" meta:resourcekey="lblNoUsers" runat="server"></asp:Label>
    </p>     
    <br />
        <asp:GridView ID="GVUsers" runat="server" GridLines="Both" HorizontalAlign="Center"
            AutoGenerateColumns="False" >
            <Columns>
                <asp:HyperLinkField DataTextField="LoginName" DataNavigateUrlFields="LoginName"
                    HeaderText="<%$ Resources:, LoginName %>" ItemStyle-Width="150px"
                    DataNavigateUrlFormatString="~/Pages/User/Profile.aspx?userName={0}"/>
                <asp:BoundField DataField="FirstName" HeaderText="<%$ Resources:, FirstName %>"
                    ItemStyle-Width="150px"/>
                <asp:BoundField DataField="Surname" HeaderText="<%$ Resources:, Surname %>"
                    ItemStyle-Width="150px"/>
            </Columns>
        </asp:GridView>
        <br />
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
