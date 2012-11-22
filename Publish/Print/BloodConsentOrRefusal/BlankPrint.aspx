<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li>
            <h3 class="center">
                CONSENT FOR TRANSFUSION OF BLOOD OR BLOOD PRODUCTS
            </h3>
        </li>
    </ul>
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
            <div class="small-content">
                In the course of your treatment, your physician has determined that it is necessary
                to administer a transfusion of blood or blood products. This form provides basic
                information concerning this procedure, and if signed by you, authorizes its performance
                by qualified medical personnel.
            </div>
        </li>
        <li>
            <div class="small-content">
                <span class="content-heading">DESCRIPTION OF PROCEDURE</span><br />
                Blood is introduced into one of your veins, commonly in the arm, using a sterilized
                disposable needle. The amount of blood transfused and whether the transfusion will
                be of blood, blood components or blood products, such as plasma, is a judgment the
                physician will make based on your particular needs.
            </div>
        </li>
        <li>
            <div class="small-content">
                <span class="content-heading">RISKS</span>
            </div>
        </li>
        <li>
            <div class="small-content">
                • A transfusion is a common procedure of low risk.<br />
                • Minor and temporary reactions are not uncommon, including bruising, or local reaction
                in the area where the needle pierces your skin or a non serious reaction to the
                transfused material itself, including headache, fever or mild reaction such as skin
                rash.<br />
                • A serious reaction is possible, but unlikely since all blood is carefully matched
                prior to transfusion, except in life-threatening emergencies.<br />
                • Infectious diseases, which are known to be transmittable by blood, include Transfusion
                Associated Viral Hepatitis (TAVH), a viral infection of the liver and Acquired Immunodeficiency
                Syndrome (AIDS). The risk of acquiring an Infectious Disease from transfused blood
                is relatively low and blood units are tested to avoid TAVH and HIV as required by
                state and feral standards. However, these laboratory tests are not foolproof.<br />
            </div>
        </li>
        <li>
            <div class="small-content">
                <span class="content-header">BENEFITS/ALTERNATIVES</span>
            </div>
        </li>
        <li>
            <div class="small-content">
                • The loss of blood can pose serious threats during the course of treatment for
                which there is no effective alternative to blood transfusion. If you have any further
                questions on this matter, your physician or his/her colleagues will explain the
                alternatives to you if this has not already been done.
            </div>
        </li>
    </ul>
    <ul class="content print">
        <li>
            <ul class="content">
                <li>
                    <h3>
                        STATEMENT OF CONSENT</h3>
                </li>
                <li>
                    <div class="small-content">
                        I have read or had read to me, the above. I do not have any questions, which have
                        not been answered to my full satisfaction. I hereby consent to such transfusion,
                        as my physician may deem necessary or advisable in the course of my treatment.<br />
                        <table class="noBorder">
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="Chk1" Text="I have Directed Units" CssClass="leftPush" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="CheckBox1" Text="I have Autologous Units" CssClass="leftPush" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ul>
            <ul class="content">
                <li>
                    <h3 class="center">
                        STATEMENT OF REFUSAL</h3>
                </li>
                <li>
                    <div class="small-content">
                        I request that no blood or blood component be administered to me during the course
                        of this hospitalization. I hereby release my physician(s), the hospital and its
                        personnel from any responsibility whatsoever for unfavorable reactions, untoward
                        results or death due to my refusal to permit the use of blood or blood components.
                        The possible consequences of such refusal on my part have been fully explained to
                        me by a physician and I fully understand that such consequences may occur as a result
                        of my refusal.
                    </div>
                </li>
            </ul>
        </li>
        <li><span class="content-heading">I UNDERSTAND that no guarantees have been made to
            me that this operation will improve my condition. </span></li>
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
                Patient is unable to sign because:<br />
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
                        Blood Transfusion Consent Form
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