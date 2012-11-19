<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.Endoscopy.ConsentPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content print">
        <li>
            <div class="center">
                <li>
                    <h3>
                        ENDOSCOPY CONSENT FORM
                    </h3>
                </li>
                <li>
                    <h3>
                        CONSENT FOR PROCEDURES OUTSIDE OF THE OPERATING ROOM
                    </h3>
                </li>
            </div>
        </li>
        <li>
            <table class="bigfont">
                <tr>
                    <td>
                        FORM:
                    </td>
                    <td>
                        ENDOSCOPY CONSENT FORM
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
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature1" />
            </div>
            <div class="right">
                THE PHYSICIAN HAS EXPLAINED TO ME the nature of this procedure and how it is carried
                out. I UNDERSTAND that all surgeries and procedures involve general risks, such
                as severe loss of blood, infection, heart stoppage and in rare cases death. The
                physician has discussed with me the specific risks, benefits and possible side effects
                of this procedure and I understand them.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature2" />
            </div>
            <div class="right">
                IN ADDITION, the physician has explained to me that there are alternative ways of
                treating my condition but I have chosen this procedure.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature3" />
            </div>
            <div class="right">
                I CONSENT TO THE ADMINISTRATION OF SEDATION with or without analgesia by or under
                the direction of the above physician and to the use of such medications as may be
                deemed advisable. When an anesthesiologist or nurse anesthetist is involved, an
                evaluation will be performed by them and the administration of sedation will be
                directed by them. I consent to the administration of blood and blood products; to
                the disposal by authorities of Bethesda Memorial Hospital of any tissue or parts
                which may be removed; to the taking and publication of photographs or videotaping;
                and to the admittance of observers to the procedure room for the purpose of advancement
                of medical education.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature4" />
            </div>
            <div class="right">
                I PERMIT AND AUTHORIZE the physician and such other physicians or qualified medical
                persons as are needed to perform this procedure on me.
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
                THE PHYSICIAN HAS EXPLAINED TO ME that sometimes during the procedure it is discovered
                that additional surgery is needed. If such additional surgery is deemed necessary
                by the physician, I permit the physician to proceed.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>I UNDERSTAND THAT NO GUARANTEES HAVE BEEN MADE TO ME that this procedure will improve
            my Condition. </li>
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
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="PnlPatientSignature">
                            <div class="sigBox">
                                <asp:Image runat="server" ID="ImgPatientSignature" />
                            </div>
                            <div class="clear">
                            </div>
                            Patient Signature / Legal Guardian
                        </asp:Panel>
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
                            <asp:Label runat="server" ID="LblTranslatedBySignature"></asp:Label>
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
        <!--
        <li>
            <div class="leftBox">
                I declare that my associate, Dr.
                <asp:Label runat="server" ID="LblAssociatedDoctor" CssClass="errorInfo"></asp:Label>
                , or I personally explained the above information to the patient or the patient's
                representative.
            </div>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature9" />
            </div>
            <asp:Label runat="server" ID="LblAssociatedDoctorTimeStamp"></asp:Label>
            <div class="clear">
            </div>
        </li>
        -->
    </ul>
</asp:Content>