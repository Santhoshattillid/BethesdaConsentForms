<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content print">
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
            <div class="PrintsigBox">
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
            <div class="PrintsigBox">
            </div>
            <div class="right">
                In addition, the physician has explained to me that there are alternative ways of
                treating my condition but I have chosen this procedure.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
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
            <div class="PrintsigBox">
            </div>
            <div class="right">
                I permit and authorize the physician and such other physicians qualifeid medical
                persons as are needed to perform this operation on me.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
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
        <li></li>
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
        <li><span class="content-heading">I UNDERSTAND that no guarantees have been made to
            me that this operation will improve my condition. </span></li>
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
            </div>
            <div class="clear">
            </div>
            <div>
                (PATIENT SIGNATURE)
            </div>
        </li>
        <li>Patient is unable to sign because:
            <br />
            <br />
            <br />
        </li>
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
            </div>
            <div class="clear">
            </div>
            <div>
                (If patient unable to sign, person authorized to sign.)
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
                (Witness to Signature or Telephone Consent Only)
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
                <br />
                <br />
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
                <br />
                <br />
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
                    </td>
                    <td>
                        MRIN#:
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