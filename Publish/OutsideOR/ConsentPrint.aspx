<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.OutsideOR.OutsideORConsentPrintV1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content print">
        <li>I here by authorize Doctor(s)
            <asp:Label runat="server" ID="LblAuthoriseDoctors" CssClass="errorInfo"></asp:Label>
            to perform upon
            <asp:Label runat="server" ID="LblPatientName2" CssClass="errorInfo"></asp:Label>
            (state name of patient or "myself") the following procedure or operation
            <br />
            <asp:Label runat="server" ID="LblProcedureName" CssClass="errorInfo"></asp:Label>
        </li>
        <li>
            <h4>
                PATIENT - PLEASE INITIAL the lines next to each paragraph of this consent to indicate
                your agreement with the statements therein.
            </h4>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature1" />
            </div>
            <div class="right">
                The Physician has explained to me the nature of this operation it is generally carried
                out. I understand that all procedures surgeries involve general risks such as severe
                loss of blood, infection, heart stoppage or death. The physician has discussed with
                me the specific risks, benefits and possible side effects of this procedure and
                I understand them.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature2" />
            </div>
            <div class="right">
                In addition, the physician has explained to me that there are alternative ways of
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
                I consent to the administration of anesthesia by or under the direction of a fully
                qualified anesthestist and to the use of such anesthetics as may be deemed advisable.
                I consent to the administration of blood and blood products, to the disposal by
                authorities of Bethesda Memorial Hospital of any tissue or parts which may be removed;
                to the taking and publication of photographs or video taping in the course of operation;
                and to the admittance of observers to the operating room for the purpose of advancement
                and medical education.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature4" />
            </div>
            <div class="right">
                I permit and authorize the physician and such other physicians qualifeid medical
                persons as are needed to perform this operation on me.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature5" />
            </div>
            <div class="right">
                The Physician has explained to me that sometimes during surgery, it is discovered
                that additional surgery is needed. If such additional surgery is deemed necessary
                by the Physician, I permit the Physician to proceed.
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
        <li>I UNDERSTAND that no guarantees have been made to me that this operation will improve
            my condition. </li>
        <li class="noBorder">
            <table border="0">
                <tr>
                    <td>
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
                                (PATIENT SIGNATURE)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                __________________ Date:__<asp:Label runat="server" ID="LblPatientSignatureDate"
                                    CssClass="DateTimeUnderline">___</asp:Label>____ Time:__<asp:Label runat="server"
                                        ID="LblPatientSignatureTime" CssClass="DateTimeUnderline"></asp:Label>__
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="PnlPatientUnableToSignBecause">
                            Patient is unable to sign because:
                            <div>
                                <asp:Label runat="server" ID="LblPatientUnableToSignBecause" CssClass="DateTimeUnderline"></asp:Label>
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel runat="server" ID="PnlAuthorizedSignature">
                            <div class="sigBox">
                                <asp:Image runat="server" ID="ImgAuthorizedSignature" />
                            </div>
                            <div class="clear">
                            </div>
                            <div>
                                (If patient unable to sign, person authorized to sign.)&nbsp;&nbsp;&nbsp;__________________
                                Date:__<asp:Label runat="server" ID="LblAuthorizedSignDate" CssClass="DateTimeUnderline">___</asp:Label>__
                                Time:__<asp:Label runat="server" ID="LblAuthorizedSignTime" CssClass="DateTimeUnderline"></asp:Label>_
                            </div>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="sigBox">
                            <asp:Image runat="server" ID="ImgWitnessSignature1" />
                        </div>
                        <div class="right">
                            <asp:Label runat="server" ID="LblWitnessSignature1DateTime"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            (Witness to Signature or Telephone Consent Only)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;__________________
                            Date:__<asp:Label runat="server" ID="LblWitnessSignature1Date" CssClass="DateTimeUnderline">___</asp:Label>__
                            Time:__<asp:Label runat="server" ID="LblWitnessSignature1Time" CssClass="DateTimeUnderline"></asp:Label>_
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="sigBox">
                            <asp:Image runat="server" ID="ImgWitnessSignature2" />
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            (Second Witness to Telephone Consent Only)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;__________________
                            Date:__<asp:Label runat="server" ID="LblWitnessSignature2Date" CssClass="DateTimeUnderline">___</asp:Label>__
                            Time:__<asp:Label runat="server" ID="LblWitnessSignature2Time" CssClass="DateTimeUnderline"></asp:Label>_
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <br />
                            Interpreted By:
                        </div>
                        <div>
                            <asp:Label runat="server" ID="LblTranslatedBy" CssClass="errorInfo"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                        <br /><br />(Interpreted By)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;__________________
                        Date:__<asp:Label runat="server" ID="LblTranslatedDate" CssClass="DateTimeUnderline">___</asp:Label>__
                        Time:__<asp:Label runat="server" ID="LblTranslatedTime" CssClass="DateTimeUnderline"></asp:Label>__
                    </td>
                </tr>
            </table>
        </li>
        <%--<li>
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
        </li>--%>
        <li>
            <table class="bigfont">
                <tr>
                    <td>
                        FORM:
                    </td>
                    <td>
                        Outside OR Consent Form
                    </td>
                    <td>
                        MRIN#:
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
    </ul>
</asp:Content>
