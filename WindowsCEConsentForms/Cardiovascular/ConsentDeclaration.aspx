<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.Cardiovascular.ConsentDeclaration1" %>

<%@ Import Namespace="WindowsCEConsentForms.FormHandlerService" %>
<%@ Register TagPrefix="uc1" TagName="PatientDetails" Src="~/PatientDetails.ascx" %>
<%@ Register TagPrefix="uc2" Src="../DeclarationSignatures.ascx" TagName="DeclarationSignatures" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">Cardiovascular Laboratory Consent Form</li>
    </ul>
    <uc1:PatientDetails ID="PatientDetails1" runat="server" />
    <ul class="content">
        <li>
            <div class="small-content">
                <span class="small-header">Cardiac/Peripheral Catheterization and Angiography;</span>this
                procedure involves the passage of catheters through blood vessels in the groin/arm.
                Pressure measurements are recorded and contrast (dye), are injected to look at the
                arteries for blockage.
            </div>
        </li>
        <li>
            <div class="small-content">
                Based upon the diagnostic findings, the following procedures may also be performed:
            </div>
        </li>
        <li>
            <table>
                <tr>
                    <td>
                        <span class="small-header">Coronary Peripheral Angioplasty </span>involves the opening
                        or dilating the passageway of a narrow artery.
                    </td>
                    <td>
                        <span class="small-header">Percutaneous Transluminal Coronary/Peripheral Angioplasty
                        </span>involves using a catheter with a small balloon at the tip that is inflated
                        at the blocked area of artery stretching the artery and flattening the plaque against
                        the artery wall.
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="small-header">Stent Implantation </span>involves placing a balloon
                        catheter with a wire mesh scaffold (stent) over it into the artery to support the
                        wall and assist to reduce the amount of blockage. The balloon is removed and the
                        stent remains permanently within the artery.
                    </td>
                    <td>
                        <span class="small-header">Rotational Arthrectomy </span>involves passing a catheter
                        with a football shaped tip coated with microscopic diamond crystals into the artery.
                        The tip is driven by a turbine at very high speed. The plaque particles that are
                        removed are typically smaller than red blood cells and therefore move downstream
                        and are picked up by the body’s waste system.
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="small-header">Intravascular Ultrasound </span>involves passing an ultrasound
                        catheter into the artery for the purpose of studying details of the interior of
                        the artery.
                    </td>
                    <td>
                        <span class="small-header">Hemolytic Thrombectomy </span>involves the passage of
                        ultrasound catheter that removes fresh clot in an artery by the vacuum produced
                        by a high-speed saline flush.
                    </td>
                </tr>
            </table>
        </li>
        <li>
            <div class="sig1 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" class="HdnImage1" name="<%= SignatureType.DoctorSign1.ToString() %>"
                    value='<%= ViewState[SignatureType.DoctorSign1.ToString()].ToString() %>' />
            </div>
            <div class="right">
                I understand that this procedure is done under local anesthesia. Small tubes (catheters)
                are placed into blood vessels of the groin/arm by means of a small incision or vessel
                puncture with needles. The tube is then passed through the blood vessels until it
                enters and crosses the proper chambers of the heart. Through this catheter, I will
                receive x-ray contrast material for the purpose of enhancing the blood vessels and
                heart structures, for a more complete diagnostic and/or interventional study.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sig2 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" class="HdnImage2" name="<%= SignatureType.DoctorSign2.ToString() %>"
                    value='<%= ViewState[SignatureType.DoctorSign2.ToString()].ToString() %>' />
            </div>
            <div class="right">
                There are certain risks, hazards, complications and consequences associated with
                these procedures that may occur even when the procedure is performed flawlessly
                and with the greatest care. These risks or complications include fainting, very
                slow or fast heartbeat, infection, loss of blood requiring transfusion; or Perforation
                of the blood vessels, or other damage to the arteries requiring emergency surgical
                procedure to restore circulation. A very small percentage of patients who have the
                above procedures develop more serious complications such as heart attack, heart
                failure, rarely loss of limb, stroke, brain death, blood clots or death. I understand
                and accept all such risks or complications.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sig3 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" class="HdnImage3" name="<%= SignatureType.DoctorSign3.ToString() %>"
                    value='<%= ViewState[SignatureType.DoctorSign3.ToString()].ToString() %>' />
            </div>
            <div class="right">
                This procedure usually requires moderate sedation. I understand that the expected
                result of moderate sedation is reduced anxiety and/or pain, partial or total amnesia.
                The drug is injected into the blood stream. I understand that the risks associated
                with moderate sedation are unconscious state and depressed breathing, possibly requiring
                intubation. I consent to the administration of moderate sedation.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sig4 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" class="HdnImage4" name="<%= SignatureType.DoctorSign4.ToString() %>"
                    value='<%= ViewState[SignatureType.DoctorSign4.ToString()].ToString() %>' />
            </div>
            <div class="right">
                This procedure and its complications have been explained to me, I acknowledge that
                I have been given no guarantee against complications or assurance of success by
                the physician who has explained them. I know I have been given free choice to accept
                or reject any and/or all of the procedures to be performed on myself. In the event
                any complications should arise, I permit the above physicians to seek consultation
                with other specialties and permit the performance of any surgical or other procedures
                that may be required on an emergency basis to correct such complications.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sig5 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" class="HdnImage5" name="<%= SignatureType.DoctorSign5.ToString() %>"
                    value='<%= ViewState[SignatureType.DoctorSign5.ToString()].ToString() %>' />
            </div>
            <div class="right">
                The nature of my conditions; the purposes and techniques of the proposed procedure(s);
                and the risks have been explained to me by my physician. In addition, the physician
                has explained to me that there are alternative ways of treating my condition. .
                I understand that I have the right to refuse this procedure. I have chosen to go
                forward with this procedure.
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
    <uc2:DeclarationSignatures ID="DeclarationSignatures" runat="server" ConsentType="Cardiovascular" />
</asp:Content>