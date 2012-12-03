<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.Cardiovascular.ConsentDeclaration1" %>
<%@ Import Namespace="WindowsCEConsentForms" %>
<%@ Register TagPrefix="uc1" TagName="PatientDetails" Src="~/PatientDetails.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DoctorsAndProcedures" Src="~/DoctorsAndProcedures.ascx" %>
<%@ Register tagprefix="uc2" src="../DeclarationSignatures.ascx" tagname="DeclarationSignatures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">Cardiovascular Laboratory Consent Form</li>
    </ul>
    <uc1:PatientDetails ID="PatientDetails1" runat="server" />
    <uc1:DoctorsAndProcedures ID="DoctorsAndProcedures1" runat="server" ConsentType="Cardiovascular" />
    <ul class="content">
        <li>
            <div class="sig1 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" class="HdnImage1" name="<%= SignatureType.DoctorSign1.ToString() %>"
                    value='<%= ViewState[SignatureType.DoctorSign1.ToString()].ToString() %>' />
            </div>
            <div class="right">
                The nature of my conditions; the purposes and techniques of the proposed procedure(s);
                and the risks have been explained to me by my physician. In addition, the physician
                has explained to me that there are alternative ways of treating my condition but
                I have chosen this procedure.
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
                I understand that this procedure is done under local anesthesia. Small tubes (catheters)
                are placed into blood vessels of the groin by means of a small incision or vessel
                puncture with needles. The tube is then passed through the blood vessels until it
                enters and traverses the proper chambers of the heart. Through this catheter, I
                will receive x-ray contrast material for the purpose of enhancing the coronary arteries
                and coronary structures, for a more complete diagnostic and/or interventional study.
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
                There are certain risks, hazards, complications and consequences associated with
                these procedures that may occur even when the procedure is performed flawlessly
                and with the greatest care. These risks or complications include fainting, very
                slow or fast heartbeat, infection, loss of blood requiring transfusion, tamponade,
                perforation of blood vessels, allergic reactions, blockage of a groin blood vessel
                requiring emergency surgical procedure to restore circulation, heart attack, heart
                failure, rarely loss of limb, stroke, brain death, blood clots or death. I understand
                and accept all such risks or complications.
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
                I consent to the administration of moderate sedation. I understand that the expected
                result of moderate sedation is reduced anxiety and/or pain, partial or total amnesia.
                The drug is injected unconscious state and depressed breathing possibly requiring
                intubation.
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
                Although this procedure and its complications have been explained to me, I acknowledge
                that I have given no guarantee against complications or assurance of success by
                <asp:Label runat="server" ID="LblPhysiciannames"></asp:Label>
                who has explained them. I know I have been given free choice to accept or reject
                any an/or all of the procedures to be performed on myself. In the event any complications
                should arise. I permit the above physicians to seek consultation with other specialists
                and permit the performance of any surgical or other procedures that may be required
                on an emergency basis correct such complications.
                
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
    <uc2:DeclarationSignatures ID="DeclarationSignatures" runat="server" ConsentType="Cardiovascular" />
</asp:Content>