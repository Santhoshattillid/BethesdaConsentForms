<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.PICC.PICCConsentPrintV1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content print">
        <li>
            <div class="center">
                <h3>
                    CONSENT FOR TRANSFUSION OF BLOOD OR BLOOD PRODUCTS</h3>
            </div>
        </li>
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
        <ul class="content noBorder">
            <li>
                <div class="small-content">
                    In the course of your treatment, your physician has determined that it is necessary
                    to administer a transfusion of blood or blood products. This form provides basic
                    information concerning this procedure, and if signed by you, authorizes its performance
                    by qualified medical personnel.
                </div>
                <div class="small-content">
                    <br />
                    <span class="small-header">DESCRIPTION OF PROCEDURE</span><br />
                    Blood is introduced into one of your veins, commonly in the arm, using a sterilized
                    disposable needle. The amount of blood transfused and whether the transfusion will
                    be of blood, blood components or blood products, such as plasma, is a judgment the
                    physician will make based on your particular needs.
                </div>
            </li>
            <li>
                <div class="small-content">
                    <span class="small-header">RISKS:</span>
                    <br />
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
                    <span class="small-header">BENEFITS/ALTERNATIVES</span>
                    <div class="small-content">
                        • The loss of blood can pose serious threats during the course of treatment for
                        which there is no effective alternative to blood transfusion. If you have any further
                        questions on this matter, your physician or his/her colleagues will explain the
                        alternatives to you if this has not already been done.
                    </div>
                </div>
            </li>
            <li>
                <div class="small-content">
                    <span class="small-header">BENEFITS/ALTERNATIVES</span>
                    <div class="small-content">
                        • The loss of blood can pose serious threats during the course of treatment for
                        which there is no effective alternative to blood transfusion. If you have any further
                        questions on this matter, your physician or his/her colleagues will explain the
                        alternatives to you if this has not already been done.</div>
                </div>
            </li>
            <ul class="content print">
                <li class="center">
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
            </li>
            <ul class="content print">
                <li class="center">
                    <h3>
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
        </ul>
</asp:Content>
