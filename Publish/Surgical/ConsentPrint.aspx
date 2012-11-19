<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.Surgical.SurgicalConsentPrintV3" %>

<%@ Register Src="../ConsentPrint.ascx" TagName="ConsentPrint" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li>
            <h3 class="center">
                CONSENT TO DIAGNOSTIC PROCEDURE OR OPERATION
            </h3>
        </li>
    </ul>
    <uc1:ConsentPrint ID="ConsentPrint1" runat="server" ConsentType="Surgical" />
</asp:Content>