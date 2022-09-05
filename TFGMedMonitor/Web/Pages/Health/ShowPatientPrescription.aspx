<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ShowPatientPrescription.aspx.cs" Inherits="Web.Pages.Health.ShowPatientPrescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">    
    <p>
        <asp:Label ID="lblNoPrescriptions" meta:resourcekey="lblNoPrescriptions" runat="server"></asp:Label>
    </p>     
    <p>
        <asp:Button ID="btnCreate" CssClass="button" runat="server" CausesValidation="false" Visible="false"
            meta:resourcekey="btnCreate" OnClick="BtnCreateClick"/>
    </p> 
        <asp:GridView ID="GVPrescriptions" runat="server" GridLines="Both" HorizontalAlign="Center"
            AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="medName" HeaderText="<%$ Resources:, medicineName %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="frequency" HeaderText="<%$ Resources:, frequency %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="creationDate" HeaderText="<%$ Resources:, creationDate %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="admin" HeaderText="<%$ Resources:, admin %>"
                    ItemStyle-Width="150px"/>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnDoses" runat="server" CausesValidation="false" CommandName="Doses"
                            Text="<%$ Resources:, Doses %>" OnClick="BtnSeeDoses"/>
                    </ItemTemplate>
                </asp:TemplateField>
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
