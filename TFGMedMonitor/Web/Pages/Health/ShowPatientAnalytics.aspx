<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="ShowPatientAnalytics.aspx.cs" Inherits="Web.Pages.Health.ShowPatientAnalytics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">    
    <p>
        <asp:Label ID="lblNoAnalytics" meta:resourcekey="lblNoAnalytics" runat="server"></asp:Label>
    </p> 
    <p>
        <asp:Button ID="btnCreate" CssClass="button" runat="server" CausesValidation="false" Visible="false"
            meta:resourcekey="btnCreate" OnClick="BtnCreateClick"/>
    </p> 
        <asp:GridView ID="GVAnalytics" runat="server" GridLines="Both" HorizontalAlign="Center"
            AutoGenerateColumns="False" >
            <Columns>
                <asp:HyperLinkField DataTextField="attendant" DataNavigateUrlFields="attendant"
                    HeaderText="<%$ Resources:, attendant %>" ItemStyle-Width="150px"
                    DataNavigateUrlFormatString="~/Pages/User/Profile.aspx?userName={0}"/>
                <asp:BoundField DataField="time" HeaderText="<%$ Resources:, time %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="procedure" HeaderText="<%$ Resources:, procedure %>"
                    ItemStyle-Width="200px"/>
                <asp:BoundField DataField="observations" HeaderText="<%$ Resources:, observations %>"
                    ItemStyle-Width="300px" ItemStyle-Height="60px"/>
            </Columns>
        </asp:GridView>
        <br/>
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

