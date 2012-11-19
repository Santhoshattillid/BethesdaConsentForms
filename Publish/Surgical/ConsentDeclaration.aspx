<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.Surgical.SurgicalConsentDeclaration" %>

<%@ Register Src="../Declaration.ascx" TagName="Declaration" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Declaration ID="Declaration1" runat="server" ConsentFolder="Surgical" ConsentType="Surgical"
        Heading="Surgical Consent Form" SubHeading="CONSENT FOR DIAGNOSTIC PROCEDURE OR OPERATION" />
</asp:Content>