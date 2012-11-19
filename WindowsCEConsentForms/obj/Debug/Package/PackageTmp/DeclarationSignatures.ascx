<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeclarationSignatures.ascx.cs"
    Inherits="WindowsCEConsentForms.DeclarationSignatures" %>
<%@ Import Namespace="WindowsCEConsentForms" %>
<ul class="content">
    <li>
        <p>
            I Understand and that no guarantee have been made to me that this operation will
            improve my condition.
        </p>
    </li>
    <li>
        <div>
            <asp:CheckBox runat="server" ID="ChkPatientisUnableToSign" Text="Patient is unable to sign?"
                AutoPostBack="True" OnCheckedChanged="ChkPatientisUnableToSign_CheckedChanged" />
        </div>
    </li>
    <li class="PatientReason">
        <asp:Panel runat="server" ID="PnlPatientReason1">
            Please specify reason
            <br />
            <asp:TextBox runat="server" ID="TxtPatientNotSignedBecause"></asp:TextBox>
        </asp:Panel>
    </li>
    <li class="PatientReason">
        <asp:Panel runat="server" ID="PnlPatientReason2">
            <div>
                If patient is unable to sign/person authorized to sign consent / relationship to
                patient.</div>
            <div class="sig11 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" class="HdnImage11" name="<%= SignatureType.PatientAuthorizeSign.ToString() %>"
                    value='<%= ViewState[SignatureType.PatientAuthorizeSign.ToString()].ToString() %>' />
            </div>
            <div class="clear">
            </div>
        </asp:Panel>
    </li>
    <li class="PatientSign">
        <asp:Panel runat="server" ID="PnlPatientSign">
            <div>
                Patient Signature</div>
            <div class="sig12 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" class="HdnImage12" name="<%= SignatureType.PatientSign.ToString() %>"
                    value='<%= ViewState[SignatureType.PatientSign.ToString()].ToString() %>' />
            </div>
            <div class="clear">
            </div>
        </asp:Panel>
    </li>
    <li>
        <div>
            Translated by (name & empl.#)</div>
        <div class="sig13 sigWrapper">
            <canvas class="pad" width="198" height="55"></canvas>
            <input type="hidden" class="HdnImage13" name="<%= SignatureType.TranslatedBySign.ToString() %>"
                value='<%= ViewState[SignatureType.TranslatedBySign.ToString()].ToString() %>' />
        </div>
        <div class="clear">
        </div>
    </li>
    <li>
        <div>
            Witness To Signature Only</div>
        <div class="sig14 sigWrapper">
            <canvas class="pad" width="198" height="55"></canvas>
            <input type="hidden" class="HdnImage14" name="<%= SignatureType.WitnessSignature1.ToString() %>"
                value='<%= ViewState[SignatureType.WitnessSignature1.ToString()].ToString() %>' />
        </div>
        <div class="clear">
        </div>
    </li>
    <li>
        <asp:Panel runat="server" ID="PnlAdditionalwitness">
            <div>
                Witness To signature
            </div>
            <div class="sig15 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" class="HdnImage15" name="<%= SignatureType.WitnessSignature2.ToString() %>"
                    value='<%= ViewState[SignatureType.WitnessSignature2.ToString()].ToString() %>' />
            </div>
            <div class="clear">
            </div>
        </asp:Panel>
    </li>
    <li>
        <asp:Label runat="server" ID="LblError" CssClass="errorInfo"></asp:Label>
    </li>
    <li class="center">
        <asp:Button runat="server" ID="BtnCompleted" Text="Complete" OnClientClick="javascript: return confirm('Are you sure that do you want to complete the form?');" />
    </li>
</ul>