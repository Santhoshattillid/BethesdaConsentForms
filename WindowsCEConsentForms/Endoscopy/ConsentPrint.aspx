<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.Endoscopy.ConsentPrint" %>

<%@ Register TagPrefix="uc1" TagName="consentprint" Src="~/ConsentPrint.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li>
                <li>
                    <div class="center">
                    <h3>
                        ENDOSCOPY CONSENT FORM
                    </h3>
                    </div>
                </li>
                <li>
                    <div class="center">
                    <h3>
                        CONSENT FOR PROCEDURES OUTSIDE OF THE OPERATING ROOM
                    </h3>
                    </div>
                </li>
        </li>
    </ul>
    <uc1:consentprint ID="ConsentPrint1" runat="server" consenttype="Endoscopy" />
</asp:Content>