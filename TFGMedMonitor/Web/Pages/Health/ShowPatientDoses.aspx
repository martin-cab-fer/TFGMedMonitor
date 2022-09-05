<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="ShowPatientDoses.aspx.cs" Inherits="Web.Pages.Health.ShowPatientDoses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">    
    <p>
        <asp:Label ID="lblNoDoses" meta:resourcekey="lblNoDoses" runat="server"></asp:Label>
    </p>   
    <p>
        <asp:Button ID="btnCreate" CssClass="button" runat="server" CausesValidation="false" Visible="false"
            meta:resourcekey="btnCreate" OnClick="BtnCreateClick"/>
    </p> 
        <asp:GridView ID="GVDoses" runat="server" GridLines="Both" HorizontalAlign="Center"
            AutoGenerateColumns="False" >
            <Columns>
                <asp:HyperLinkField DataTextField="administrator" DataNavigateUrlFields="administrator"
                    HeaderText="<%$ Resources:, administrator %>" ItemStyle-Width="150px"
                    DataNavigateUrlFormatString="~/Pages/User/Profile.aspx?userName={0}"/>
                <asp:BoundField DataField="date" HeaderText="<%$ Resources:, date %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="notes" HeaderText="<%$ Resources:, notes %>"
                    ItemStyle-Width="200px"/>
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
