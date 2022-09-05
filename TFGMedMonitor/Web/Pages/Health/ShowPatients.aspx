<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ShowPatients.aspx.cs" Inherits="Web.Pages.Health.ShowPatients" meta:resourcekey="Page"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">  
    <p>
        <asp:Button ID="btnCreatePatient" CssClass="button" runat="server" CausesValidation="false" Visible="false"
                meta:resourcekey="btnCreatePatient" OnClick="BtnCreatePatientClick"/>
    </p>
    <p>
        <asp:Label ID="lblNoPatients" meta:resourcekey="lblNoPatients" runat="server"></asp:Label>
    </p>     
    <br />
        <asp:GridView ID="GVPatients" runat="server" GridLines="Both" HorizontalAlign="Center"
            AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="FullName" HeaderText="<%$ Resources:, FullName %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="BirthDate" HeaderText="<%$ Resources:, BirthDate %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="Info" HeaderText="<%$ Resources:, Info %>"
                    ItemStyle-Width="300px" ItemStyle-Height="60px"/>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnDetails" runat="server" CausesValidation="false" CommandName="Details"
                            Text="<%$ Resources:, Details %>" OnClick="BtnSeePatient" Visible='<%# Eval("loggedIn") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
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

