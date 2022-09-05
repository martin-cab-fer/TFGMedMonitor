<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="DoctorAssignation.aspx.cs" Inherits="Web.Pages.Admin.DoctorAssignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">    
    <p>
        <asp:Label ID="lblNoDoctors" meta:resourcekey="lblNoDoctors" runat="server"></asp:Label>
    </p>     
        <asp:GridView ID="GVDoctors" runat="server" GridLines="Both" HorizontalAlign="Center"
            AutoGenerateColumns="False" >
            <Columns>
                <asp:HyperLinkField DataTextField="userName" DataNavigateUrlFields="userName"
                    HeaderText="<%$ Resources:, userName %>" ItemStyle-Width="150px"
                    DataNavigateUrlFormatString="~/Pages/User/Profile.aspx?userName={0}"/>
                <asp:BoundField DataField="FirstName" HeaderText="<%$ Resources:, FirstName %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="Status" HeaderText="<%$ Resources:, Status %>"
                    ItemStyle-Width="100px"/>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnToggle" runat="server" CausesValidation="false" CommandName="Toggle"
                            CommandArgument='<%#Eval("userName") %>' Text="<%$ Resources:, Toggle %>" OnClick="BtnToggleClick"/>
                    </ItemTemplate>
                </asp:TemplateField>
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
