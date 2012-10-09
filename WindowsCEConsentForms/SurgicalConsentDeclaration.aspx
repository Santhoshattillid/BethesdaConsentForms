<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="SurgicalConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.SurgicalConsentDeclaration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <ul class="content">
        <li class="center">
            <h3>
                Surgical Consent Form</h3>
        </li>
        <li class="center">
            <p>
                CONSENT FOR DIAGNOSTIC PROCEDURE OR OPERATION
            </p>
        </li>
        <li>
            <div class="right smallest">
                MR # :</div>
            <div class="right small">
                <asp:Label ID="LblPatientId" runat="server" CssClass="errorInfo"></asp:Label></div>
            <div class="right smallest">
                Name :
            </div>
            <div class="right small">
                <asp:Label runat="server" ID="LblPatientName" CssClass="errorInfo"></asp:Label></div>
            <div class="right smallest">
                Date :
            </div>
            <div class="right small">
                <asp:Label runat="server" ID="LblDate" CssClass="errorInfo"></asp:Label></div>
            <div class="right smallest">
                Time :</div>
            <div class="right small">
                <asp:Label runat="server" ID="LblTime" CssClass="errorInfo"></asp:Label></div>
            <div class="clear">
            </div>
        </li>
        <li>
            <p>
                I here by authorize Doctor(s)
                <asp:Label runat="server" ID="LbldoctorName" CssClass="errorInfo"></asp:Label>
                to perform upon
                <asp:Label runat="server" ID="LnlPatientName" CssClass="errorInfo"></asp:Label>
                the following procedure or operation : Surgical Consent
            </p>
        </li>
        <li>
            <p>
                I Understand and that no guarantee have been made to me that this operation will
                improve my condition.
            </p>
        </li>
        <li>
            <div>
                Patient is unable to sign because</div>
            <asp:TextBox runat="server" ID="TxtPatientNotSignedBecause"></asp:TextBox>
            <div class="clear">
            </div>
            <!--
            <div id="TxtSignature1" class="signature" hdfld="HdnImage1">
            </div>
            <div class="clear">
            </div>
            <asp:HiddenField runat="server" ID="HdnImage1" /> -->
        </li>
        <li>
            <div>
                If patient is unable to sing/person authorized to sign consent / relationship to
                patient.</div>
            <div id="TxtSignature2" class="signature large" hdfld="HdnImage2">
            </div>
            <div class="clear">
            </div>
            <asp:HiddenField runat="server" ID="HdnImage2" />
        </li>
        <li>
            <div>
                Patient Signature</div>
            <div id="TxtSignature3" class="signature large" hdfld="HdnImage3">
            </div>
            <div class="clear">
            </div>
            <asp:HiddenField runat="server" ID="HdnImage3" />
        </li>
        <li>
            <div>
                Translated by (name & empl.#)</div>
            <div id="TxtSignature4" class="signature large" hdfld="HdnImage4">
            </div>
            <div class="clear">
            </div>
            <asp:HiddenField runat="server" ID="HdnImage4" />
        </li>
        <li>
            <div>
                Witness To Signature Only</div>
            <div id="TxtSignature5" class="signature large" hdfld="HdnImage5">
            </div>
            <div class="clear">
            </div>
            <asp:HiddenField runat="server" ID="HdnImage5" />
        </li>
        <li>
            <div>
                I declare that I or my associate Dr.</div>
            <div id="TxtSignature6" class="signature large" hdfld="HdnImage6">
            </div>
            <div class="clear">
            </div>
            <asp:HiddenField runat="server" ID="HdnImage6" />
        </li>
        <li>Personally explained the above information to the patient or the patient's representative.
        </li>
        <li>
            <asp:Label runat="server" ID="LblError" CssClass="errorInfo"></asp:Label>
        </li>
        <li class="center">
            <asp:Button runat="server" ID="BtnPrevious" Text="Prev" OnClick="BtnPrevious_Click1" />
            <asp:Button runat="server" ID="BtnCompleted" Text="Complete" OnClick="BtnCompleted_Click" />
        </li>
    </ul>
    </form>
</asp:Content>