<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.Surgical.SurgicalConsentDeclaration" %>

<%@ Register TagPrefix="uc1" TagName="DeclarationSignatures" Src="~/DeclarationSignatures.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ConsentSignatures" Src="~/ConsentSignatures.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PatientDetails" Src="~/PatientDetails.ascx" %>
<%@ Register Src="../DoctorsAndProcedures.ascx" TagName="DoctorsAndProcedures" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">
            <p>
                CONSENT FOR DIAGNOSTIC PROCEDURES OR OPERATION</p>
        </li>
    </ul>
    <uc1:PatientDetails ID="PatientDetails1" runat="server" ConsentType="Surgical" />
    <uc2:DoctorsAndProcedures ID="DoctorsAndProcedures1" runat="server" IsStaticTextBoxForPrecedures="True" />
    <uc1:ConsentSignatures ID="ConsentSignatures" runat="server" />
    <uc1:DeclarationSignatures ID="DeclarationSignatures" runat="server"  />
</asp:Content>