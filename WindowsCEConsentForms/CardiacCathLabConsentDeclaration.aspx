<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="CardiacCathLabConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.CardiacCathLabConsent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>
        <ul>
            <li>
                <h3>
                    Cardiac Cath LabConsent Form</h3>
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
                <p>
                    I Understand and that no guarantee have been made to me that this operation will improve my condition.
                </p>
            </li>
            <li>
                Patient is unable to sign because
                <div id="TxtSignature1" class="signature" hdfld="HdnImage1"></div>
                <asp:HiddenField runat="server" ID="HdnImage1"  />
                </li>
            <li>
                If patient is unable to sing/person authorized to sign consent / relationship to patient.
                <div id="TxtSignature2" class="signature" hdfld="HdnImage2"></div>
                <asp:HiddenField runat="server" ID="HdnImage2"  />
            </li>
            <li>
                Patient Signature
                <div id="TxtSignature3" class="signature" hdfld="HdnImage3"></div>
                <asp:HiddenField runat="server" ID="HdnImage3"  />
            </li>
            <li>
                Translated by (name & empl.#)
                <div id="TxtSignature4" class="signature" hdfld="HdnImage4"></div>
                <asp:HiddenField runat="server" ID="HdnImage4"  />
            </li>
            <li>
                Witness To Signature Only
                <div id="TxtSignature5" class="signature" hdfld="HdnImage5"></div>
                <asp:HiddenField runat="server" ID="HdnImage5"  />
            </li>
            <li>
                I declare that I or my associate Dr. 
                <div id="TxtSignature6" class="signature" hdfld="HdnImage6"></div>
                <asp:HiddenField runat="server" ID="HdnImage6"  />
            </li>
            <li>
                Personally explained the above information to the patient or the patient's representative.
            </li>
            <li>
                <asp:Button runat="server" ID="BtnPrevious" Text="Prev" OnClick="BtnPrevious_Click1" />
                <asp:Button runat="server" ID="BtnCompleted" Text="Complete" OnClick="BtnCompleted_Click" />
            </li>
        </ul>
    </div>
    </form>
</asp:Content>