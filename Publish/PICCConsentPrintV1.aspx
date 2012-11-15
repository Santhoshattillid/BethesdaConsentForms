<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="PICCConsentPrintV1.aspx.cs" Inherits="WindowsCEConsentForms.PICCConsentPrintV1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <ul class="content print">
        <li>
            <img src="Images/logo.png" alt="logo" />
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
            <div class="center">
                <h3>
                    AUTHORIZATION FOR PERIPHERALLY INSERTED CENTRAL CATHETER (PICC)</h3>
            </div>
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
        <li>
            <table class="noBorder">
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
                            <asp:Image runat="server" ID="ImgPICCNurse" />
                        </div>
                        <div class="clear">
                        </div>
                        PICC Nurse
                    </td>
                    <td>
                        <div class="timeBox">
                            <asp:Label runat="server" ID="LblImgPICCNurseDateTime"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                        Date Time
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div>
                            <asp:Label runat="server" ID="LblPatientName"></asp:Label>
                        </div>
                        <div class="clear">
                        </div>
                    </td>
                </tr>
            </table>
        </li>
    </ul>
    </form>
</asp:Content>