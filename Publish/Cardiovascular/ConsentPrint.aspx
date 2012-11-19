<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.Cardiovascular.ConsentPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content print">
        <div class="center">
            <li>
                <h3>
                    CARDIOVASCULAR LABORATORY CONSENT
                </h3>
            </li>
        </div>
        <li>
            <table class="bigfont">
                <tr>
                    <td>
                        FORM:
                    </td>
                    <td>
                        CARDIOVASCULAR LABORATORY CONSENT FORM
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
                        <asp:Label runat="server" ID="LblPatientName"></asp:Label>
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
        <li>I here by authorize Doctor(s)
            <asp:Label runat="server" ID="LblAuthoriseDoctors" CssClass="errorInfo"></asp:Label>
            to perform upon
            <asp:Label runat="server" ID="LblPatientName2" CssClass="errorInfo"></asp:Label>
            (state name of patient or "myself") the following procedure or operation
            <br />
            <asp:Label runat="server" ID="LblProcedureName" CssClass="errorInfo"></asp:Label>
            and such designee or assistants as he may designate to perform:<br />
            <ul>
                <table class="noBorder">
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="Chk1" Text="Left Heart Catheterization, which may include coronary angioplasty"
                                CssClass="leftPush" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="Chk2" Text="Right Heart Catheterization" CssClass="leftPush" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="Chk3" Text="Temporary pacemaker Insertion" CssClass="leftPush" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="Chk4" Text="Insertion of Intra Aortic Balloon Pump"
                                CssClass="leftPush" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="Chk5" Text="Moderate Sedation" CssClass="leftPush" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="Chk6" Text="Percutaneous Transluminal Coronary Angioplasty"
                                CssClass="leftPush" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="Chk7" Text="Stent Placement" CssClass="leftPush" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="Chk8" Text="Percutaneous Transluminal Coronary Rotational Angioplasty"
                                CssClass="leftPush" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="Chk9" Text="Intravasular Ultrasound" CssClass="leftPush" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox runat="server" ID="Chk10" Text="Angiojet" CssClass="leftPush" />
                        </td>
                    </tr>
                </table>
            </ul>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature1" />
            </div>
            <div class="right">
                The nature of my conditions; the purposes and techniques of the proposed procedure(s);
                and the risks have been explained to me by my physician. In addition, the physician
                has explained to me that there are alternative ways of treating my condition but
                I have chosen this procedure.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature2" />
            </div>
            <div class="right">
                I understand that this procedure is done under local anesthesia. Small tubes (catheters)
                are placed into blood vessels of the groin by means of a small incision or vessel
                puncture with needles. The tube is then passed through the blood vessels until it
                enters and traverses the proper chambers of the heart. Through this catheter, I
                will receive x-ray contrast material for the purpose of enhancing the coronary arteries
                and coronary structures, for a more complete diagnostic and/or interventional study.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature3" />
            </div>
            <div class="right">
                There are certain risks, hazards, complications and consequences associated with
                these procedures that may occur even when the procedure is performed flawlessly
                and with the greatest care. These risks or complications include fainting, very
                slow or fast heartbeat, infection, loss of blood requiring transfusion, tamponade,
                perforation of blood vessels, allergic reactions, blockage of a groin blood vessel
                requiring emergency surgical procedure to restore circulation, heart attack, heart
                failure, rarely loss of limb, stroke, brain death, blood clots or death. I understand
                and accept all such risks or complications.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature4" />
            </div>
            <div class="right">
                I consent to the administration of moderate sedation. I understand that the expected
                result of moderate sedation is reduced anxiety and/or pain, partial or total amnesia.
                The drug is injected unconscious state and depressed breathing possibly requiring
                intubation.
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
    <ul class="content print">
        <li>
            <img src="/Images/logo.png" alt="logo" />
        </li>
        <li>
            <table class="noBorder">
                <tr>
                    <td class="edgeColumn">
                        <h3>
                            Bethesda Hospital East
                            <br />
                            2815 S. Seacrest Blvd
                            <br />
                            Boynton Beach,FL 33435
                            <br />
                            (561) 737-7733
                        </h3>
                    </td>
                    <td class="middleColumn">
                    </td>
                    <td class="edgeColumn">
                        <h3>
                            Bethesda Hospital West
                            <br />
                            9655 Boynton Beach Blvd,
                            <br />
                            Boynton Beach, FL 33472
                            <br />
                            (561) 336-7000
                        </h3>
                    </td>
                </tr>
            </table>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature5" />
            </div>
            <div class="right">
                Although this procedure and its complications have been explained to me, I acknowledge
                that I have given no guarantee against complications or assurance of success by
                <asp:Label runat="server" ID="LblDoctornames"></asp:Label>
                who has explained them. I know I have been given free choice to accept or reject
                any an/or all of the procedures to be performed on myself. In the event any complications
                should arise. I permit the above physicians to seek consultation with other specialists
                and permit the performance of any surgical or other procedures that may be required
                on an emergency basis correct such complications.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <table class="noBorder">
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="PnlPatientUnableToSignBecause">
                            Pt. is unable to sign because:
                            <asp:Label runat="server" ID="LblPatientUnableToSignBecause" CssClass="errorInfo"></asp:Label>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel runat="server" ID="PnlAuthorizedSignature">
                            <div class="sigBox">
                                <asp:Image runat="server" ID="ImgSignature6" />
                            </div>
                            <asp:Label runat="server" ID="LblAuthorizedSignDateTime"></asp:Label>
                            <div class="clear">
                            </div>
                            IF PATIENT UNABLE TO SIGN, PERSON TO SIGN CONSENT/RELATIONSHIP TO PATIENT
                        </asp:Panel>
                    </td>
                </tr>
                <asp:Panel runat="server" ID="PnlPatientSignature">
                    <tr>
                        <td>
                            <div class="sigBox">
                                <asp:Image runat="server" ID="ImgPatientSignature" />
                            </div>
                            <div class="clear">
                            </div>
                            Patient Signature / Legal Guardian
                        </td>
                        <td>
                            <div class="timeBox">
                                <asp:Label runat="server" ID="LblSignature1DateTime"></asp:Label>
                            </div>
                            <div class="clear">
                            </div>
                            Date Time
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td>
                        <div class="sigBox">
                            <asp:Image runat="server" ID="ImgTranslatedBySignature" />
                        </div>
                        <div class="clear">
                        </div>
                        Translated By
                    </td>
                    <td>
                        <div class="timeBox">
                            <asp:Label runat="server" ID="LblTranslatedByDateTime"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                        Date Time
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="sigBox">
                            <asp:Image runat="server" ID="ImgWitnessSignature" />
                        </div>
                        <div class="clear">
                        </div>
                        Witness to signature
                    </td>
                    <td>
                        <div class="timeBox">
                            <asp:Label runat="server" ID="LblWitnessDateTime"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                        Date Time
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="sigBox">
                            <asp:Image runat="server" ID="ImgWitnessSignature2" />
                        </div>
                        <div class="clear">
                        </div>
                        Witness to signature
                    </td>
                    <td>
                        <div class="timeBox">
                            <asp:Label runat="server" ID="LblWitnessDateTime2"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                        Date Time
                    </td>
                </tr>
            </table>
        </li>
    </ul>
</asp:Content>