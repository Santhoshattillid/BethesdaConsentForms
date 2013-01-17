<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.Endoscopy.ConsentDeclaration1" %>

<%@ Register TagPrefix="uc1" TagName="DeclarationSignatures" Src="~/DeclarationSignatures.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ConsentSignatures" Src="~/ConsentSignatures.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PatientDetails" Src="~/PatientDetails.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DoctorsAndProcedures" Src="~/DoctorsAndProcedures.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">
            <p>
                CONSENT FOR ENDOSCOPY</p>
        </li>
    </ul>
    <uc1:PatientDetails ID="PatientDetails1" runat="server" />
    <uc1:DoctorsAndProcedures ID="DoctorsAndProcedures1" runat="server" ConsentType="Endoscopy"
        IsStaticTextBoxForPrecedures="False" />
    <uc1:ConsentSignatures ID="ConsentSignatures" runat="server" />
    <uc1:DeclarationSignatures ID="DeclarationSignatures" runat="server" ConsentType="Endoscopy" />
</asp:Content>