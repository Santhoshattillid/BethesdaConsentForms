<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrintV2.aspx.cs" Inherits="WindowsCEConsentForms.Surgical.SurgicalConsentPrintV2" %>

<%@ Register Src="/PrintHeader.ascx" TagName="PrintHeader" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content print">
        <uc1:PrintHeader ID="PrintHeader1" runat="server" />
        <li>I here by authorize Doctor(s)
            <asp:Label runat="server" ID="LblAuthoriseDoctors" CssClass="errorInfo"></asp:Label>
            to perform upon
            <asp:Label runat="server" ID="LblPatientName2" CssClass="errorInfo"></asp:Label>
            the following procedure or operation
            <br />
            <asp:Label runat="server" ID="LblProcedureName" CssClass="errorInfo"></asp:Label>
        </li>
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
    <ul class="content print">
        <uc1:PrintHeader ID="PrintHeader2" runat="server" />
        <li>I UNDERSTAND that no guarantees have been made to me that this operation will improve
            my condition. </li>
        <li>
            <label>
                Pt. is unable to sign because
            </label>
        </li>
        <li>
            <asp:Label runat="server" ID="LblReason" CssClass="errorInfo"></asp:Label>
        </li>
        <li>
            <label>
                If patient is unable to sign/Person Authorized to sign consent/Relationship to patient</label>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature7" />
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <label>
                Patient Signature</label></li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature8" />
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <label>
                Interpreted by</label>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature9" />
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <label>
                Witness to signature only</label>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature10" />
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <label>
                I decalre that I or my associate Dr.</label>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature11" />
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <label>
                personally explained the above information to the patient or the patients's representative</label>
        </li>
    </ul>
</asp:Content>