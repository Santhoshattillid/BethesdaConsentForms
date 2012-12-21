<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.OutsideOR.OutsideORConsentPrintV1" %>

<%@ Register TagPrefix="uc1" TagName="doctorsandproceduresprint" Src="~/DoctorsAndProceduresPrint.ascx" %>
<%@ Register TagPrefix="uc3" TagName="printfooter" Src="~/PrintFooter.ascx" %>
<%@ Register TagPrefix="uc4" TagName="PrintSignatures" Src="~/PrintSignatures.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:doctorsandproceduresprint ID="DoctorsAndProceduresPrint1" runat="server" consenttype="OutsideOR" />
    <ul class="content">
        <li>
            <h4>
                PATIENT - PLEASE INITIAL the lines next to each paragraph of this consent to indicate
                your agreement with the statements therein.
            </h4>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature1" />
            </div>
            <div class="right">
                The physician has explained to me the nature of this operation and how it is carried
                out. I understand that all surgeries and procedures involve general risks such as
                severe loss of blood, infection, heart stoppage, and in rare cases death. The physician
                has discussed with me the specific risks, benefits and possible side effects of
                this procedure and I understand them.
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
                I consent to the administration of sedation with or without anesthesia by or under
                the direction of above physician and to the use of such medications as may be deemed
                advisable. When an anesthesiologist or nurse anesthetist is involved, an evaluation
                will be performed by them and the administration of sedation will be directed by
                them. I consent to the administration of blood and blood products; to the disposal
                by authorities of Bethesda Memorial Hospital of any tissue or parts which may be
                removed; to the taking and publication of photographs or video taping in the course
                of the operation; and to the admittance of observers to the procedure room for the
                purpose of advancement of medical education.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature4" />
            </div>
            <div class="right">
                I permit and authorize the physician and such other physicians or qualified medical
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
                The physician has explained to me that sometimes during surgery, it is discovered
                that additional surgery is needed. If such additional surgery is deemed necessary
                by the physician, I permit the physician to proceed.
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
    <uc3:printfooter ID="PrintFooter2" runat="server" ConsentType="OutsideOR" />
    <uc4:PrintSignatures ID="PrintSignatures1" runat="server" ConsentType="OutsideOR" />
    <uc3:printfooter ID="PrintFooter1" runat="server" ConsentType="OutsideOR" />
</asp:Content>