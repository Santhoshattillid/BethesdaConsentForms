<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConsentPrint.ascx.cs"
    Inherits="WindowsCEConsentForms.ConsentPrint" %>
<%@ Register Src="DoctorsAndProceduresPrint.ascx" TagName="DoctorsAndProceduresPrint"
    TagPrefix="uc1" %>
<%@ Register Src="PrintFooter.ascx" TagName="PrintFooter" TagPrefix="uc3" %>
<%@ Register Src="PrintSignatures.ascx" TagName="PrintSignatures" TagPrefix="uc2" %>
<ul class="content">
    <li>PATIENT:
        <asp:Label runat="server" ID="LblPatientName3" CssClass="errorInfo"></asp:Label>
    </li>
</ul>
<uc1:DoctorsAndProceduresPrint ID="DoctorsAndProceduresPrint1" runat="server" />
<ul class="content print">
    <li>
        <div class="sigBox">
            <asp:Image runat="server" ID="ImgSignature1" />
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
        <div class="sigBox">
            <asp:Image runat="server" ID="ImgSignature2" />
        </div>
        <div class="right">
            In addition, the physician has explained to me that there are alternative ways of
            treating my condition but I have chosen this procedure.
        </div>
        <div class="clear">
        </div>
    </li>
    <li>
        <div class="sigBox">
            <asp:Image runat="server" ID="ImgSignature3" />
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
        <div class="sigBox">
            <asp:Image runat="server" ID="ImgSignature4" />
        </div>
        <div class="right">
            I permit and authorize the physician and such other physicians qualifeid medical
            persons as are needed to perform this operation on me.
        </div>
        <div class="clear">
        </div>
    </li>
    <li>
        <div class="sigBox">
            <asp:Image runat="server" ID="ImgSignature5" />
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
<uc2:PrintSignatures ID="PrintSignatures1" runat="server" />
<uc3:PrintFooter ID="PrintFooter1" runat="server" />