<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="BlankForm.aspx.cs" Inherits="WindowsCEConsentForms.BlankForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li>
            <h3>
                Blank consent forms
            </h3>
        </li>
        <li>
            <ul class="content">
                <li><a href="Print/Surgical/Surgical.pdf">CONSENT TO DIAGNOSTIC PROCEDURE OR OPERATION</a></li>
                <li><a href="Print/Cardiovascular/Cardiovascular.pdf">CARDIOVASCULAR LABORATORY CONSENT</a></li>
                <li><a href="Print/OutsideOR/OutsideOR.pdf">CONSENT FOR PROCEDURES OUTSIDE OF THE OPERATING
                    ROOM</a></li>
                <li><a href="Print/Endoscopy/Endoscopy.pdf">ENDOSCOPY CONSENT</a></li>
                <li><a href="Print/BloodConsentOrRefusal/BloodConsentOrRefusal.pdf">CONSENT FOR TRANSFUSION
                    OF BLOOD OR BLOOD PRODUCTS</a></li>
            </ul>
        </li>
    </ul>
</asp:Content>
