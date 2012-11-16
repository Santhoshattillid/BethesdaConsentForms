<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Consent.aspx.cs" Inherits="WindowsCEConsentForms.Surgical.SurgicalConsent" %>

<%@ Register Src="../Consent.ascx" TagName="Consent" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Consent ID="Consent1" runat="server" ConsentType="Surgical" ConsentFolder="Surgical"
        Heading="Surgical Consent Form" SubHeading="CONSENT FOR DIAGNOSTIC PROCEDURE OR OPERATION" />
</asp:Content>