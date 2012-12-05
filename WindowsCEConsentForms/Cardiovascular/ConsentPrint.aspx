<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.Cardiovascular.ConsentPrint" %>

<%@ Register TagPrefix="uc1" TagName="DoctorsAndProceduresPrint" Src="~/DoctorsAndProceduresPrint.ascx" %>
<%@ Register TagPrefix="uc3" TagName="printfooter" Src="~/PrintFooter.ascx" %>
<%@ Register TagPrefix="uc4" TagName="PrintSignatures" Src="~/PrintSignatures.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">
            <h3>
                CARDIOVASCULAR LABORATORY CONSENT
            </h3>
        </li>
    </ul>
    <uc1:DoctorsAndProceduresPrint ID="DoctorsAndProceduresPrint1" runat="server" ConsentType="Cardiovascular" />
    <ul class="content print">
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature1" />
            </div>
            <div class="right">
                The nature of my conditions, the purposes and techniques of the proposed procedure(s);
                and the risks have been explained to me by my physician. In addition, the physician
                has explained to me that there are alternative ways of treating my condition but
                I have chosen this procedure.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature2" />
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
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature3" />
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
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature4" />
            </div>
            <div class="right">
                I consent to the administration of moderate sedation. I understand that the expected
                result of moderate sedation is reduced anxiety and/or pain, partial or total amnesia.
                The drug is injected into the blood stream. I understand that the risks associated
                with moderate sedation are unconscious state and depressed breathing possibly requiring
                intubation.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature5" />
            </div>
            <div class="right">
                Although this procedure and its complications have been explained to me, I acknowledge
                that I have been given no guarantee against complications or assurance of success
                by the physician who has explained them. I know I have been given free choice to
                accept or reject any an/or all of the procedures to be performed on myself. In the
                event any complications should arise. I permit the above physicians to seek consultation
                with other specialists and permit the performance of any surgical or other procedures
                that may be required on an emergency basis to correct such complications.
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
    <uc4:PrintSignatures ID="PrintSignatures1" runat="server" ConsentType="Cardiovascular" />
    <uc3:printfooter ID="PrintFooter1" runat="server" ConsentType="Cardiovascular" />
</asp:Content>