<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeclarationSignatures.ascx.cs"
    Inherits="WindowsCEConsentForms.DeclarationSignatures" %>
<%@ Import Namespace="WindowsCEConsentForms.FormHandlerService" %>
<ul class="content">
    <% if (ConsentType != ConsentType.PICC && ConsentType != ConsentType.BloodConsentOrRefusal)
       { %>
    <li>
        <p>
            I understand that no guarantees have been made to me that this operation will improve
            my condition.
        </p>
    </li>
    <% } %>
    <li>
        <div class="checkboxleft">
            <asp:CheckBox runat="server" ID="ChkPatientisUnableToSign" Text="Patient is unable to sign?"
                AutoPostBack="True" OnCheckedChanged="ChkPatientisUnableToSign_CheckedChanged" />
        </div>
    </li>
    <li>
        <div class="checkboxleft">
            <asp:CheckBox runat="server" ID="ChkTelephoneConsent" Text="Telephone Consent" AutoPostBack="True"
                OnCheckedChanged="ChkTelephoneConsent_CheckedChanged" />
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
    <li>
        <asp:Panel runat="server" ID="PnlPatientReason3">
            <div class="small-content">
                Authorised person name
            </div>
            <div>
                <asp:TextBox runat="server" ID="TxtAuthorizedPersonName"></asp:TextBox>
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
            Witness to Signature or Telephone Consent Only</div>
        <div class="sig14 sigWrapper">
            <canvas class="pad" width="198" height="55"></canvas>
            <input type="hidden" class="HdnImage14" name="<%= SignatureType.WitnessSignature1.ToString() %>"
                value='<%= ViewState[SignatureType.WitnessSignature1.ToString()].ToString() %>' />
        </div>
        <div class="clear">
        </div>
    </li>
    <li>
        <div class="small-content">
            Witness name
        </div>
        <div>
            <asp:TextBox runat="server" ID="TxtWitnessSignature1Name"></asp:TextBox>
        </div>
    </li>
    <li>
        <asp:Panel runat="server" ID="PnlAdditionalwitness">
            <div>
                Second Witness to Telephone Consent Only
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
        <asp:Panel runat="server" ID="PnlAdditionalwitness2">
            <div class="small-content">
                Second witness name
            </div>
            <div>
                <asp:TextBox runat="server" ID="TxtSecondWitnessName"></asp:TextBox>
            </div>
        </asp:Panel>
    </li>
    <li>
        <div>
            Interpreted by
        </div>
        <div>
            <asp:TextBox runat="server" ID="TxtTranslatedBy" CssClass="textbox"></asp:TextBox>
        </div>
        <div class="clear">
        </div>
    </li>
    <% if (ConsentType == ConsentType.PICC)
       { %>
    <li>
        <div>
            PICC Nurse
        </div>
        <div class="sig16 sigWrapper">
            <canvas class="pad" width="198" height="55"></canvas>
            <input type="hidden" class="HdnImage16" name="<%= SignatureType.PICCSignature.ToString() %>"
                value='<%= ViewState[SignatureType.PICCSignature.ToString()].ToString() %>' />
        </div>
        <div class="clear">
        </div>
    </li>
    <li>
        <div class="small-content">
            PICC Nurse Name
        </div>
        <div>
            <asp:TextBox runat="server" ID="TxtPICCNurseName"></asp:TextBox>
        </div>
    </li>
    <% } %>
    <li>
        <asp:Label runat="server" ID="LblError" CssClass="errorInfo"></asp:Label>
    </li>
    <li class="center">
        <asp:Button runat="server" ID="BtnCompleted" CssClass="btn" Text="Complete" OnClientClick="javascript: return confirm('Are you sure that do you want to complete the form?');" />
        <asp:Button runat="server" ID="BtnReset" Text="Reset" CssClass="btn1" />
        <asp:Button runat="server" ID="btnSkip" Text="Skip" CssClass="btn1" OnClick="btnSkip_Click" />
        <asp:Button runat="server" ID="btnHmme" Text="Home" CssClass="btn1" OnClick="btnHmme_Click" />
    </li>
</ul>