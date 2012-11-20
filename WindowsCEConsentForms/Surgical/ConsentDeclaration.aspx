<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.Surgical.SurgicalConsentDeclaration" %>

<%@ Register TagPrefix="uc1" TagName="DeclarationSignatures" Src="~/DeclarationSignatures.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ConsentSignatures" Src="~/ConsentSignatures.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PatientDetails" Src="~/PatientDetails.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">
            <%-- <h3>
                SURGICAL CONSENT FORM</h3>--%>
        </li>
        <li class="center">
            <p>
                CONSENT FOR DIAGNOSTIC PROCEDURES OR OPERATION</p>
        </li>
    </ul>
    <uc1:PatientDetails ID="PatientDetails1" runat="server" ConsentType="Surgical" />
    <ul class="content">
        <li>I here by authorize Doctor(s)
            <asp:DropDownList ID="DdlPrimaryDoctors" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlPrimaryDoctors_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;
            <asp:Label ID="LblAssociatedDoctors" runat="server" CssClass="errorInfo"></asp:Label>
            to perform upon &nbsp;
            <asp:Label runat="server" ID="LnlPatientName" CssClass="errorInfo"></asp:Label>
            the procedure or operation : &nbsp;
            <asp:TextBox runat="server" ID="TxtProcedure"></asp:TextBox>
        </li>
    </ul>
    <uc1:ConsentSignatures ID="ConsentSignatures" runat="server" />
    <uc1:DeclarationSignatures ID="DeclarationSignatures" runat="server" />
</asp:Content>