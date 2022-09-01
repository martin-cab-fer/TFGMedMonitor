<%@ Page Title="" Language="C#" MasterPageFile="~/TFGMedMonitor.Master" AutoEventWireup="true" CodeBehind="FindMedicine.aspx.cs" Inherits="Web.Pages.Admin.FindMedicine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_MenuExplanation"
    runat="server">
    -
    <asp:Localize ID="lclMenuExplanation" runat="server" meta:resourcekey="lclMenuExplanation" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MenuLinks" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    <div id="form">
        <form id="FindMedicineForm" method="post" runat="server">
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclName" runat="server" meta:resourcekey="lclName" /></span>
                    <span class="entry">
                        <asp:TextBox ID="txtName" runat="server" Width="100px" Height="20px"
                            meta:resourcekey="txtNameResource1"/>
                </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclActivePrin" runat="server" meta:resourcekey="lclActivePrin" /></span>
                    <span class="entry">
                        <asp:Label ID="txtActivePrin" runat="server" Width="100px" Height="20px"
                            meta:resourcekey="txtActivePrinResource1"/>
                        <asp:Button ID="btnRemovePrin" runat="server" OnClick="BtnRemovePrinClick" meta:resourcekey="btnRemovePrin" />
                </span>
            </div>
            <div class="field">
                <span class="label">
                    <asp:Localize ID="lclNewActPrin" runat="server" meta:resourcekey="lclNewActPrin" /></span>
                    <span class="entry">
                        <asp:TextBox ID="txtNewActPrin" runat="server"
                            Width="100px" Columns="16" meta:resourcekey="txtNewActPrinResource1"></asp:TextBox> 
                        <asp:Button ID="btnAddPrin" runat="server" OnClick="BtnAddPrinClick" meta:resourcekey="btnAddPrin" />
                    </span>
            </div>              
            <div class="button">
                <asp:Button ID="btnSearch" runat="server" OnClick="BtnSearchClick" meta:resourcekey="btnSearch" />
            </div>
        </form>
    </div>
</asp:Content>
