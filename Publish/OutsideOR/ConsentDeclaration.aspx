<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.OutsideOR.Declaration" %>

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
                CONSENT FOR PROCEDURES OUTSIDE OPERATING ROOM
            </p>
        </li>
    </ul>
    <uc1:PatientDetails ID="PatientDetails1" runat="server" />
    <uc1:DoctorsAndProcedures ID="DoctorsAndProcedures1" runat="server" ConsentType="OutsideOR"
        IsStaticTextBoxForPrecedures="True" />
    <uc1:ConsentSignatures ID="ConsentSignatures1" runat="server" />
    <uc1:DeclarationSignatures ID="DeclarationSignatures1" runat="server" ConsentType="OutsideOR" />
</asp:Content>