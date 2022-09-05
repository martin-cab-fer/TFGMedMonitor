<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ShowMedicines.aspx.cs" Inherits="Web.Pages.Admin.ShowMedicines" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">
    <form runat="server">    
    <p>
        <asp:Label ID="lblNoMedicines" meta:resourcekey="lblNoMedicines" runat="server"></asp:Label>
    </p>   
    <p>
        <asp:Label ID="lblPrescripting" runat="server" meta:resourcekey="lblPrescripting"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnCreate" CssClass="button" runat="server" CausesValidation="false" Visible="false"
            meta:resourcekey="btnCreate" OnClick="BtnCreateClick"/>
    </p>     
        <asp:GridView ID="GVMedicines" runat="server" GridLines="Both" HorizontalAlign="Center"
            AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="regNum" HeaderText="<%$ Resources:, regNum %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="medName" HeaderText="<%$ Resources:, medName %>"
                    ItemStyle-Width="100px"/>
                <asp:BoundField DataField="labName" HeaderText="<%$ Resources:, labName %>"
                    ItemStyle-Width="100px"/>
                <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" CommandArgument='<%#Eval("medName") %>'  OnClick="BtnSelectClick"
                                Visible='<%# Eval("prescripting") %>' text="<%$ Resources:, select %>" CausesValidation="false"/> 
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
