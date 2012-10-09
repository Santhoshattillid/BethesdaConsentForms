<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="SurgicalConsent.aspx.cs" Inherits="WindowsCEConsentForms.SurgicalConsent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <ul class="content">
        <li class="center">
            <h3>
                Surgical Consent Form</h3>
        </li>
        <li class="center">CONSENT FOR DIAGNOSTIC PROCEDURE OR OPERATION</li>
        <li>
            <div class="right smallest">
                MR # :</div>
            <div class="right small">
                <asp:Label ID="LblPatientId" runat="server" CssClass="errorInfo"></asp:Label></div>
            <div class="right smallest">
                Name :
            </div>
            <div class="right small">
                <asp:Label runat="server" ID="LblPatientName" CssClass="errorInfo"></asp:Label></div>
            <div class="right smallest">
                Date :
            </div>
            <div class="right small">
                <asp:Label runat="server" ID="LblDate" CssClass="errorInfo"></asp:Label></div>
            <div class="right smallest">
                Time :</div>
            <div class="right small">
                <asp:Label runat="server" ID="LblTime" CssClass="errorInfo"></asp:Label></div>
            <div class="clear">
            </div>
        </li>
        <li>I here by authorize Doctor(s)
            <asp:Label runat="server" ID="LbldoctorName" CssClass="errorInfo"></asp:Label>
            to perform upon
            <asp:Label runat="server" ID="LnlPatientName" CssClass="errorInfo"></asp:Label>
            the following procedure or operation : Surgical Consent</li>
        <li>
            <div id="TxtSignature1" class="signature" hdfld="HdnImage1">
            </div>
            <div class="right">
                <asp:HiddenField runat="server" ID="HdnImage1" />
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
            <div id="TxtSignature2" class="signature" hdfld="HdnImage2">
            </div>
            <div class="right">
                <asp:HiddenField runat="server" ID="HdnImage2" />
                In addition, the physician has explained to me that there are alternative ways of
                treating my condition but I have chosen this procedure.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div id="TxtSignature3" class="signature" hdfld="HdnImage3">
            </div>
            <div class="right">
                <asp:HiddenField runat="server" ID="HdnImage3" />
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
            <div id="TxtSignature4" class="signature" hdfld="HdnImage4">
            </div>
            <div class="right">
                <asp:HiddenField runat="server" ID="HdnImage4" />
                I permit and authorize the physician and such other physicians qualifeid medical
                persons as are needed to perform this operation on me.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div id="TxtSignature5" class="signature" hdfld="HdnImage5">
            </div>
            <div class="right">
                <asp:HiddenField runat="server" ID="HdnImage5" />
                The Physician has explained to me that sometimes during surgery, it is discovered
                that additional surgery is needed. If such additional surgery is deemed necessary
                by the Physician, I permit the Physician to proceed.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <asp:Label runat="server" ID="LblError" CssClass="errorInfo"></asp:Label>
        </li>
        <li class="center">
            <asp:Button runat="server" ID="BtnPrevious" Text="Prev" OnClick="BtnPrevious_Click" />
            <asp:Button runat="server" ID="BtnNext" Text="Next" OnClick="BtnNext_Click" />
        </li>
    </ul>
    </form>
</asp:Content>