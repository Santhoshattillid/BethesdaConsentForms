<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="SetupPdfConfiguration.aspx.cs" Inherits="WindowsCEConsentForms.Administration.SetupPdfConfiguration" %>

<%@ Import Namespace="WindowsCEConsentForms" %>
<%@ Import Namespace="WindowsCEConsentForms.ConsentFormSvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <ul class="content">
            <li>
                <h3>
                    Exports Path</h3>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.Surgical) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtSurgicalExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.Cardiovascular) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtCardiovascularExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.OutsideOR) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtOutsideORExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.Endoscopy) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtEndoscopyExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.BloodConsentOrRefusal) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtBloodConsentOrRefusalExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.PlasmanApheresis) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtPlasmanApheresisExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.PICC) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtPICCExportPath"></asp:TextBox>
                </div>
            </li>
        </ul>
    </ul>
    <ul class="content">
        <li>
            <h3>
                Credentials for export path</h3>
        </li>
        <li>
            <div class="adminHeading leftBox content-heading">
                Domain
            </div>
            <div class="leftBox">
                <asp:TextBox runat="server" ID="TxtDomain"></asp:TextBox>
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="adminHeading leftBox content-heading">
                Username
            </div>
            <div class="leftBox">
                <asp:TextBox runat="server" ID="TxtUsernameExports"></asp:TextBox>
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="adminHeading leftBox content-heading">
                Password
            </div>
            <div class="leftBox">
                <asp:TextBox runat="server" ID="TxtPasswordExports" TextMode="Password"></asp:TextBox>
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
    <ul class="content">
        <li>
            <asp:Label runat="server" ID="LblError" CssClass="errorInfomodified adminErroInfo"></asp:Label>
        </li>
        <li class="center">
            <asp:Button runat="server" ID="BtnCompleted" CssClass="btn" Text="Complete" OnClick="BtnCompleted_Click" />
            <asp:Button runat="server" ID="BtnReset" Text="Reset" CssClass="btn1" OnClick="BtnReset_Click" />
        </li>
    </ul>
</asp:Content>