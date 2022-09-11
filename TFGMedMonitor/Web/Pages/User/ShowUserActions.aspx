<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="ShowUserActions.aspx.cs" Inherits="Web.Pages.User.ShowUserActions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">
    <p>
        <asp:Label ID="lblNoActions" meta:resourcekey="lblNoActions" runat="server"></asp:Label>
    </p>     
    <br />
        <asp:GridView ID="GVActions" runat="server" GridLines="Both" HorizontalAlign="Center"
            AutoGenerateColumns="False" >
            <Columns>
                <asp:HyperLinkField DataTextField="LoginName" DataNavigateUrlFields="LoginName"
                    HeaderText="<%$ Resources:, LoginName %>" ItemStyle-Width="150px"
                    DataNavigateUrlFormatString="~/Pages/User/Profile.aspx?userName={0}"/>
                <asp:BoundField DataField="Date" HeaderText="<%$ Resources:, Date %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="Action" HeaderText="<%$ Resources:, Action %>"
                    ItemStyle-Width="400px"/>
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
