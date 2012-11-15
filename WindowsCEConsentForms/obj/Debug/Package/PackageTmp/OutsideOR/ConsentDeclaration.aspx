<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.OutsideOR.Declaration" %>

<%@ Register Src="../Declaration.ascx" TagName="Declaration" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Declaration ID="Declaration1" runat="server" ConsentFolder="OutsideOR" ConsentType="OutsideOR"
        Heading="Outside OR Consent Form" />
</asp:Content>