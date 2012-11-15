<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Consent.aspx.cs" Inherits="WindowsCEConsentForms.OutsideOR.Consent" %>

<%@ Register Src="../Consent.ascx" TagName="Consent" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Consent ID="Consent1" runat="server" ConsentFolder="OutsideOR" ConsentType="OutsideOR"
        Heading="Outside OR Consent Form" />
</asp:Content>