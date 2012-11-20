<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.PICC.PICCConsentPrintV1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content print">
        <li>
            <div class="center">
                <h3>
                    AUTHORIZATION FOR PERIPHERALLY INSERTED CENTRAL CATHETER (PICC)</h3>
            </div>
        </li>
        <li>PATIENT:
            <asp:Label runat="server" ID="LblPatientName3" CssClass="errorInfo"></asp:Label>
        </li>
        <li>I here by authorize Doctor(s)
            <asp:Label runat="server" ID="LblAuthoriseDoctors" CssClass="errorInfo"></asp:Label>
            to perform upon
            <asp:Label runat="server" ID="LblPatientName2" CssClass="errorInfo"></asp:Label>
            the following procedure or operation:
            <br />
            <asp:Label runat="server" ID="LblProcedureName" CssClass="errorInfo"></asp:Label>
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
        <li><span class="content-heading">I UNDERSTAND that no guarantees have been made to
            me that this operation will improve my condition. </span></li>
        <li>
            <asp:Panel runat="server" ID="PnlPatientSignature">
                <div class="sigBox">
                    <asp:Image runat="server" ID="ImgPatientSignature" />
                </div>
                <div class="right">
                    <asp:Label runat="server" ID="LblPatientSignatureDateTime"></asp:Label>
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
                Patient is unable to sign because:
                <asp:Label runat="server" ID="LblPatientUnableToSignBecause" CssClass="errorInfo"></asp:Label>
            </asp:Panel>
        </li>
        <li>
            <asp:Panel runat="server" ID="PnlAuthorizedSignature">
                <div class="sigBox">
                    <asp:Image runat="server" ID="ImgAuthorizedSignature" />
                </div>
                <div class="right">
                    <asp:Label runat="server" ID="LblAuthorizedSignDateTime"></asp:Label>
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
            <div class="right">
                <asp:Label runat="server" ID="LblWitnessSignature1DateTime"></asp:Label>
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
            <div class="right">
                <asp:Label runat="server" ID="LblWitnessSignature2DateTime"></asp:Label>
            </div>
            <div class="clear">
            </div>
            <div>
                (Second Witness to Telephone Consent Only)
            </div>
        </li>
        <li>
            <div>
                Interpreted By:
            </div>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgTranslatedBy" />
            </div>
            <div class="right">
                <asp:Label runat="server" ID="LblTranslatedDateTime"></asp:Label>
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div>
                PICC Nurse
            </div>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgPICCNurse" />
            </div>
            <div class="right">
                <asp:Label runat="server" ID="LblPICCNurseDateTime"></asp:Label>
            </div>
            <div class="clear">
            </div>
        </li>
        <li></li>
        <li>
            <table class="bigfont">
                <tr>
                    <td>
                        FORM:
                    </td>
                    <td>
                        Blood Transfusion Consent Form
                    </td>
                    <td>
                        MR#:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LblPatientMrHash"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        PATIENT:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="Label1"></asp:Label>
                    </td>
                    <td>
                        DOB:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LblDOB"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        PATIENT#:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LblPatientId"></asp:Label>
                    </td>
                    <td>
                        AGE:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LblAge"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        GENDER:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LblGender"></asp:Label>
                    </td>
                    <td>
                        DATE:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LblDate"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        ADMIT DATE:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LblPatientAdminDate"></asp:Label>
                    </td>
                    <td>
                        TIME:
                    </td>
                    <td>
                        <asp:Label runat="server" ID="LblPatientAdminTime"></asp:Label>
                    </td>
                </tr>
            </table>
        </li>
    </ul>
</asp:Content>