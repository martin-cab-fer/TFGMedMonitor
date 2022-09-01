<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="ShowPatients.aspx.cs" Inherits="Web.Pages.Health.ShowPatients" meta:resourcekey="Page"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">    
    <p>
        <asp:Label ID="lblNoPatients" meta:resourcekey="lblNoPatients" runat="server"></asp:Label>
    </p>     
        <asp:GridView ID="GVPatients" runat="server" GridLines="Both" HorizontalAlign="Center"
            AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="<%$ Resources:, FullName %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="BirthDate" HeaderText="<%$ Resources:, BirthDate %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="Info" HeaderText="<%$ Resources:, Info %>"
                    ItemStyle-Width="100px"/>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnDetails" runat="server" CausesValidation="false" CommandName="Details"
                            Text="<%$ Resources:, Details %>" OnClick="BtnSeePatient"/>
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

