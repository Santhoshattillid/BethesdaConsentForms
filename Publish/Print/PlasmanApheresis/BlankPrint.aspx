<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">
            <%--<h3>
                PLASMA APHERESIS FORM
            </h3>--%>
        </li>
        <li class="center">
            <h3>
                CONSENT FOR THERAPEUTIC APHERESIS
            </h3>
        </li>
        <li>PATIENT:</li>
        <li>I here by authorize Doctor(s)
            <br />
            <br />
            to perform upon
            <br />
            <br />
            the following procedure or operation:
            <br />
            <br />
            <br />
        </li>
        <li>
            <div class="small-content">
                The nature and purpose of the procedure necessary to treat my condition, possible
                alternative methods of treatment, the risks involved, the possible consequences
                and the possibility of complications have been explained to me by phyname and I
                understand the nature of the procedure to be as follows:
            </div>
        </li>
        <li>
            <div class="small-content">
                Therapeutic Apheresis involves the separation, removal and replacement of specific
                blood cells or plasma components from my blood. This involves the passage of my
                blood from my circulatory system into a machine, where it is circulated through
                a device which acts to remove the specific blood cells or plasma components from
                the blood.
            </div>
        </li>
        <li>
            <div class="small-content">
                I have been made aware of certain risks, benefits or alternatives that may be associated
                with the procedure herein described. Possible risks are, but not limited to:
            </div>
        </li>
        <li>
            <div class="small-content">
                • The possibility of contamination of the blood with various bacteria or germs,
                which can result in bloodstream infection.<br />
                • The possibility of excess bleeding occurring within the body as a result of clotting
                problems of the blood, or externally due to disconnection of the bloodline.<br />
                • The possibility of contracting infections of the puncture site of catheter which
                allows access to the bloodstream.<br />
                • The potential hazard of air embolism forming in which air enters the machine and
                thereby gets into the patient’s bloodstream, leading to severe complications, which
                may include death or paralysis.<br />
                • The possibility of irregular heartbeats, tingling or numbness of the fingers,
                chest, mouth or face, nausea, bruising at the site of needle insertion, or decrease
                in blood pressure resulting from certain chemical shifts within the patient’s system.<br />
                • The possibility of a reaction to medications and/or replacement fluids given during
                the treatment which may result in adverse effects ranging from mild to (rarely)
                fatal shock or cardiac arrest.<br />
                • The possibility of excess fluid in the bloodstream, causing shortness of breath
                and/or changes in the heart rate and blood pressure.
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
                I acknowledge that no guarantee or assurance has been given to me by anyone as to
                the results that may be obtained.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
                I acknowledge that all blank spaces on this document have been either completed
                or crossed off prior to my signing.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
                I acknowledge that I have read and understand the foregoing, and that I have asked
                and been afforded the opportunity to ask whatever questions I have regarding the
                treatment.
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
    <br />
    <br />
    <ul class="content">
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
                I hereby release Bethesda Memorial Hospital, its employees, and physicians from
                any and all liability that may result from this treatment.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <asp:Panel runat="server" ID="PnlPatientSignature">
                <div class="PrintsigBox">
                </div>
                <div class="right">
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
                <br />
                <br />
                <br />
            </asp:Panel>
        </li>
        <li>
            <asp:Panel runat="server" ID="PnlAuthorizedSignature">
                <div class="PrintsigBox">
                </div>
                <div class="right">
                </div>
                <div class="clear">
                </div>
                <div>
                    (If patient unable to sign, person authorized to sign.)
                </div>
            </asp:Panel>
        </li>
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
            </div>
            <div class="clear">
            </div>
            <div>
                (Witness to Signature or Telephone Consent Only)
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
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
            <div class="PrintsigBox">
            </div>
            <div class="right">
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
                        CARDIOVASCULAR Form
                    </td>
                    <td>
                        MR#:
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        PATIENT:
                    </td>
                    <td>
                    </td>
                    <td>
                        DOB:
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        PATIENT#:
                    </td>
                    <td>
                    </td>
                    <td>
                        AGE:
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        GENDER:
                    </td>
                    <td>
                    </td>
                    <td>
                        DATE:
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        ADMIT DATE:
                    </td>
                    <td>
                    </td>
                    <td>
                        TIME:
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </li>
    </ul>
</asp:Content>