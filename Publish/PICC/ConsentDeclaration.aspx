<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.PICC.PICCConsentDeclaration" %>

<%@ Register Src="../DoctorsAndProcedures.ascx" TagName="DoctorsAndProcedures" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="PatientDetails" Src="~/PatientDetails.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">
            <h3>
                PICC Consent Form</h3>
        </li>
        <li class="center">
            <p>
                CONSENT FOR DIAGNOSTIC PROCEDURE OR OPERATION
            </p>
        </li>
    </ul>
    <uc1:PatientDetails ID="PatientDetails1" runat="server" />
    <uc1:DoctorsAndProcedures ID="DoctorsAndProcedures1" runat="server" />
    <ul class="content">
        <li>
            <div class="center">
                <h3>
                    AUTHORIZATION FOR PERIPHERALLY INSERTED CENTRAL CATHETER (PICC)</h3>
            </div>
        </li>
        <li>
            <div class="small-content">
                <span class="small-header">A PICC</span> is long, small flexible plastic tube that
                is put in your arm and threaded so that the tip rests in a big vein in the chest.
                The catheter can be used for all types of fluids and medications that need to be
                given into your vein. A nurse has been specially trained and qualified to insert
                this catheter will be putting it in. This catheter can stay in your arm for one
                year or more as long as there are no complications needing it to be removed. After
                insertion of the catheter, a chest x-ray will be taken to make sure it is in the
                correct place before it is used.
                <br />
            </div>
        </li>
        <li>
            <div class="small-content">
                <span class="small-header">BENEFITS:</span> Having a <span class="small-header">PICC</span>
                line would eliminate the need for peripheral blood draws or starting an IV (intravenous
                catheter). Certain medications or nutritional solutions that are given via an IV
                can irritate small veins. A <span class="small-header">PICC</span> line helps to
                decrease vein irritation should you receive antibiotics for more than a week, IV
                pain medications or IV cancer drugs. A <span class="small-header">PICC</span> line
                can be left in place when you go home. If you go home with a <span class="small-header">
                    PICC</span> line in place, home care can be set up to help you.
            </div>
        </li>
        <li>
            <div class="small-content">
                <span class="small-header">RISKS:</span> Include, but are not limited to bruising,
                swelling, infection, malpositioned catheter (catheter tip in wrong place), occlusion
                (blocked catheter), mechanical phlebitis (vein irritation) and thrombosis (clot).
                Your doctor is the person you should talk to if you have questions about what would
                happen if you do not choose to have a <span class="small-header">PICC</span> line
                put in. Your doctor is also the one to talk to you about other choices you may have.
                <br />
            </div>
        </li>
        <li>
            <div class="small-content">
                <span class="small-header">ALTERNATIVES:</span> The <span class="small-header">PICC</span>
                team nurse has explained the procedure, risks and complications and has answered
                all my questions to my satisfaction. I have been fully informed of and understand
                the associated risks, benefits and medically acceptable alternatives to this procedure
                including the option to refuse. I hereby give consent for the insertion of a <span
                    class="small-header">PICC</span> catheter by the certified <span class="small-header">
                        PICC</span> nurse. I understand that an interventional Radiologist will
                place the <span class="small-header">PICC</span> line with ultrasound or fluoroscopic
                <span class="small-header">(X-RAY)</span> guidance if the <span class="small-header">
                    PICC</span> nurse is unable to successfully put in the catheter or the catheter
                needs to be redirected.
            </div>
        </li>
        <li>
            <p>
                I Understand and that no guarantee have been made to me that this operation will
                improve my condition.
            </p>
        </li>
        <li>
            <div class="boxLeft">
                <asp:CheckBox runat="server" ID="ChkPatientisUnableToSign" Text="Patient is unable to sign?"
                    AutoPostBack="True" OnCheckedChanged="ChkPatientisUnableToSign_CheckedChanged" />
            </div>
            <!--
            <div id="TxtSignature1" class="signature" hdfld="HdnImage1">
            </div>
            <div class="clear">
            </div>
            <asp:HiddenField runat="server" ID="HdnImage1" /> -->
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
                <div class="sig1 sigWrapper">
                    <canvas class="pad" width="198" height="55"></canvas>
                    <input type="hidden" name="HdnImage1" class="HdnImage1" value='<%= ViewState["Signature1"].ToString() %>' />
                </div>
                <div class="clear">
                </div>
            </asp:Panel>
        </li>
        <li class="PatientSign">
            <asp:Panel runat="server" ID="PnlPatientSign">
                <div>
                    Patient Signature</div>
                <div class="sig2 sigWrapper">
                    <canvas class="pad" width="198" height="55"></canvas>
                    <input type="hidden" name="HdnImage2" class="HdnImage2" value='<%= ViewState["Signature2"].ToString() %>' />
                </div>
                <div class="clear">
                </div>
            </asp:Panel>
        </li>
        <li>
            <div>
                Witness To Signature Only</div>
            <div class="sig4 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" name="HdnImage4" class="HdnImage4" value='<%= ViewState["Signature4"].ToString() %>' />
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <asp:Panel runat="server" ID="PnlAdditionalwitness">
                <div>
                    Witness To signature
                </div>
                <div class="sig5 sigWrapper">
                    <canvas class="pad" width="198" height="55"></canvas>
                    <input type="hidden" name="HdnImage5" class="HdnImage5" value='<%= ViewState["Signature5"].ToString() %>' />
                </div>
                <div class="clear">
                </div>
            </asp:Panel>
        </li>
        <li>
            <div>
                PICC Nurse
            </div>
            <div class="sig3 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" name="HdnImage3" class="HdnImage3" value='<%= ViewState["Signature3"].ToString() %>' />
            </div>
            <div class="clear">
            </div>
        </li>
        <!--
        <li>
            <div>
                I declare that I or my associates doctors
                <asp:Label runat="server" ID="LblAssociateDoctors" CssClass="errorInfo"></asp:Label>
                Personally explained the above information to the patient or the patient's representative.</div>
        </li>
        <li>
            <div class="sig5 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" name="HdnImage5" class="HdnImage5" value='<%= ViewState["Signature5"].ToString() %>' />
            </div>
            <div class="clear">
            </div>
        </li>
-->
        <li>
            <asp:Label runat="server" ID="LblError" CssClass="errorInfo"></asp:Label>
        </li>
        <li class="center">
            <asp:Button runat="server" ID="BtnCompleted" Text="Complete" OnClick="BtnCompleted_Click"
                OnClientClick="javascript: return confirm('Are you sure that do you want to complete the form?');" />
        </li>
    </ul>
</asp:Content>