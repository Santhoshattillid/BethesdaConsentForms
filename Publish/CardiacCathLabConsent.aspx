<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="CardiacCathLabConsent.aspx.cs" Inherits="WindowsCEConsentForms.CardiacCathLabConsent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>
        <ul>
            <li>
                <h3>
                    Cardiac Cath Lab Consent Form</h3>
            </li>
            <li>
                <p>
                    CONSENT FOR DIAGNOSTIC PROCEDURE OR OPERATION
                </p>
            </li>
            <li>
                <table>
                    <tr>
                        <td>
                            MR # :
                        </td>
                        <td>
                            <asp:Label ID="LblPatientId" runat="server"></asp:Label>
                        </td>
                        <td>
                            Name :
                        </td>
                        <td>
                            <asp:Label runat="server" ID="LblPatientName"></asp:Label>
                        </td>
                        <td>
                            Date :
                        </td>
                        <td>
                            <asp:Label runat="server" ID="LblDate"></asp:Label>
                        </td>
                        <td>
                            Time :
                        </td>
                        <td>
                            <asp:Label runat="server" ID="LblTime"></asp:Label>
                        </td>
                    </tr>
                </table>
            </li>
            <li>
                <p>
                    I here by authorize Doctor(s)
                    <asp:Label runat="server" ID="LbldoctorName"></asp:Label>
                    to perform upon
                    <asp:Label runat="server" ID="LnlPatientName"></asp:Label>
                    the following procedure or operation : Cardiac Cath Lab Consent
                </p>
            </li>
            <li>
                <div id="TxtSignature1" class="signature" hdfld="HdnImage1"></div>
                <asp:HiddenField runat="server" ID="HdnImage1"  />
                The Physician has explained to me the nature of this operation it is generally carried out. I understand that all procedures surgeries involve general risks such as severe loss of blood, infection, heart stoppage or death. The physician has discussed with me the specific risks, benefits and possible side effects of this procedure and I understand them.</li>
            <li>
                <div id="TxtSignature2" class="signature" hdfld="HdnImage2"></div>
                <asp:HiddenField runat="server" ID="HdnImage2"  />
                In addition, the physician has explained to me that there are alternative ways of treating my condition but I have chosen this procedure.
            </li>
            <li>
                <div id="TxtSignature3" class="signature" hdfld="HdnImage3"></div>
                <asp:HiddenField runat="server" ID="HdnImage3"  />
                I consent to the administration of anesthesia by or under the direction of a fully qualified anesthestist and to the use of such anesthetics as may be deemed advisable. I consent to the administration of blood and blood products, to the disposal by authorities of Bethesda Memorial Hospital of any tissue or parts which may be removed; to the taking and publication of photographs or video taping in the course of operation; and to the admittance of observers to the operating room for the purpose of advancement and medical education.
            </li>
            <li>
                <div id="TxtSignature4" class="signature" hdfld="HdnImage4"></div>
                <asp:HiddenField runat="server" ID="HdnImage4"  />
                I permit and authorize the physician and such other physicians qualifeid medical persons as are needed to perform this operation on me.
            </li>
            <li>
                <div id="TxtSignature5" class="signature" hdfld="HdnImage5"></div>
                <asp:HiddenField runat="server" ID="HdnImage5"  />
                The Physician has explained to me that sometimes during surgery, it is discovered that additional surgery is needed. If such additional surgery is deemed necessary by the Physician, I permit the Physician to proceed.
            </li>
            <li>
                <asp:Button runat="server" ID="BtnPrevious" Text="Prev" OnClick="BtnPrevious_Click" />
                <asp:Button runat="server" ID="BtnNext" Text="Next" OnClick="BtnNext_Click" />
            </li>
        </ul>
    </div>
    </form>
</asp:Content>