<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintSignatures.ascx.cs"
    Inherits="WindowsCEConsentForms.PrintSignatures" %>
<ul class="content">
    <li><span class="content-heading">I UNDERSTAND that no guarantees have been made to
        me that this operation will improve my condition. </span></li>
    <li>
        <asp:Panel runat="server" ID="PnlPatientSignature">
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgPatientSignature" />
            </div>
            <div class="printBox">
                <div class="floatLeft large">
                    Name:<asp:Label runat="server" ID="LblPatientName" CssClass="DateTime"></asp:Label>
                </div>
                <div class="floatLeft small">
                    Date:<asp:Label runat="server" ID="LblPatientSignatureDate" CssClass="DateTime"></asp:Label>
                </div>
                <div class="floatLeft small">
                    Time:<asp:Label runat="server" ID="LblPatientSignatureTime" CssClass="DateTime"></asp:Label>
                </div>
            </div>
            <div class="clear">
            </div>
            <div>
                (PATIENT SIGNATURE)
            </div>
        </asp:Panel>
    </li>
    <li>
        <asp:Panel runat="server" ID="PnlPatientUnableToSignBecause">
            <div class="patientReasonBox">
                Patient is unable to sign because:
                <asp:Label runat="server" ID="LblPatientUnableToSignBecause" CssClass="DateTime"></asp:Label>
            </div>
        </asp:Panel>
    </li>
    <li>
        <asp:Panel runat="server" ID="PnlAuthorizedSignature">
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgAuthorizedSignature" />
            </div>
            <div class="printBox">
                <div class="floatLeft large">
                    Name:<asp:Label runat="server" ID="LblAuthorizePersonName" CssClass="DateTime"></asp:Label>
                </div>
                <div class="floatLeft small">
                    Date:<asp:Label runat="server" ID="LblAuthorizedSignDate" CssClass="DateTime"></asp:Label>
                </div>
                <div class="floatLeft small">
                    Time:<asp:Label runat="server" ID="LblAuthorizedSignTime" CssClass="DateTime"></asp:Label>
                </div>
            </div>
            <div class="clear">
            </div>
            <div>
                (If patient unable to sign, person authorized to sign.)
            </div>
        </asp:Panel>
    </li>
    <li>
        <div class="sigBox">
            <asp:Image runat="server" ID="ImgWitnessSignature1" />
        </div>
        <div class="printBox">
            <div class="floatLeft large">
                Name:<asp:Label runat="server" ID="LblWitnessName1" CssClass="DateTime"></asp:Label>
            </div>
            <div class="floatLeft small">
                Date:<asp:Label runat="server" ID="LblWitnessSignature1Date" CssClass="DateTime"></asp:Label>
            </div>
            <div class="floatLeft small">
                Time:<asp:Label runat="server" ID="LblWitnessSignature1Time" CssClass="DateTime"></asp:Label>
            </div>
        </div>
        <div class="clear">
        </div>
        <div>
            (Witness to Signature or Telephone Consent Only)
        </div>
    </li>
    <li>
        <div class="sigBox">
            <asp:Image runat="server" ID="ImgWitnessSignature2" />
        </div>
        <div class="printBox">
            <div class="floatLeft large">
                Name:<asp:Label runat="server" ID="LblWitnessName2" CssClass="DateTime"></asp:Label>
            </div>
            <div class="floatLeft small">
                Date:<asp:Label runat="server" ID="LblWitnessSignature2Date" CssClass="DateTime"></asp:Label>
            </div>
            <div class="floatLeft small">
                Time:<asp:Label runat="server" ID="LblWitnessSignature2Time" CssClass="DateTime"></asp:Label>
            </div>
        </div>
        <div class="clear">
        </div>
        <div>
            (Second Witness to Telephone Consent Only)
        </div>
    </li>
    <li>
        <div class="leftBox">
            Interpreted By:
            <asp:Label runat="server" ID="LblTranslatedBy"></asp:Label>
        </div>
        <div class="printBox">
            <div class="floatLeft large">
                <span></span>
            </div>
            <div class="floatLeft small">
                Date:<asp:Label runat="server" ID="LblTranslatedDate" CssClass="DateTime"></asp:Label>
            </div>
            <div class="floatLeft small">
                Time:<asp:Label runat="server" ID="LblTranslatedTime" CssClass="DateTime"></asp:Label>
            </div>
        </div>
        <div class="clear">
        </div>
        <div>
            (Interpreted By)
        </div>
    </li>
</ul>