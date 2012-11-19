<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.Cardiovascular.ConsentPrint" %>

<%@ Register TagPrefix="uc1" TagName="ConsentPrint" Src="~/ConsentPrint.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <div class="center">
            <li>
                <h3>
                    CARDIOVASCULAR LABORATORY CONSENT
                </h3>
            </li>
        </div>
    </ul>
    <uc1:ConsentPrint ID="ConsentPrint1" runat="server" ConsentType="Cardiovascular" />
</asp:Content>