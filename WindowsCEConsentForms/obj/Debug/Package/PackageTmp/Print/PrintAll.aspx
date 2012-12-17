<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="PrintAll.aspx.cs" Inherits="WindowsCEConsentForms.Print.PrintAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li><a href="/Print/Surgical/BlankPrint.aspx">CONSENT TO DIAGNOSTIC PROCEDURE OR OPERATION</a></li>
        <li><a href="/Print/Cardiovascular/BlankPrint.aspx">CARDIOVASCULAR LABORATORY CONSENT</a></li>
        <li><a href="/Print/OutsideOR/BlankPrint.aspx">CONSENT FOR PROCEDURES OUTSIDE OF THE
            OPERATING ROOM</a></li>
        <li><a href="/Print/Endoscopy/BlankPrint.aspx">ENDOSCOPY CONSENT</a></li>
        <li><a href="/Print/BloodConsentOrRefusal/BlankPrint.aspx">CONSENT FOR TRANSFUSION OF
            BLOOD OR BLOOD PRODUCTS</a></li>
        <li><a href="/Print/PlasmanApheresis/BlankPrint.aspx">CONSENT FOR THERAPEUTIC APHERESIS</a></li>
        <li><a href="/Print/PICC/BlankPrint.aspx">AUTHORIZATION FOR PERIPHERALLY INSERTED CENTRAL
            CATHETER (PICC)</a></li>
    </ul>
</asp:Content>