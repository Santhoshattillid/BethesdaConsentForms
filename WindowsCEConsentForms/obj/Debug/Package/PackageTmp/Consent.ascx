<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Consent.ascx.cs" Inherits="WindowsCEConsentForms.Consent" %>
<%@ Register Src="PatientDetails.ascx" TagName="PatientDetails" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="DoctorsAndProcedures" Src="~/DoctorsAndProcedures.ascx" %>
<ul class="content">
    <li class="center">
        <h3>
            <%= Heading%></h3>
    </li>
    <li class="center">CONSENT FOR DIAGNOSTIC PROCEDURE OR OPERATION </li>
</ul>
<uc1:PatientDetails ID="PatientDetails1" runat="server" />
<uc1:DoctorsAndProcedures ID="DoctorsAndProcedures1" runat="server" />
<ul class="content">
    <li>
        <div class="sig1 sigWrapper">
            <canvas class="pad" width="198" height="55"></canvas>
            <input type="hidden" name="HdnImage1" class="HdnImage1" value='<%= ViewState["Signature1"].ToString() %>' />
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
        <div class="sig2 sigWrapper">
            <canvas class="pad" width="198" height="55"></canvas>
            <input type="hidden" name="HdnImage2" class="HdnImage2" value='<%= ViewState["Signature2"].ToString() %>' />
        </div>
        <div class="right">
            In addition, the physician has explained to me that there are alternative ways of
            treating my condition but I have chosen this procedure.
        </div>
        <div class="clear">
        </div>
    </li>
    <li>
        <div class="sig3 sigWrapper">
            <canvas class="pad" width="198" height="55"></canvas>
            <input type="hidden" name="HdnImage3" class="HdnImage3" value='<%= ViewState["Signature3"].ToString() %>' />
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
        <div class="sig4 sigWrapper">
            <canvas class="pad" width="198" height="55"></canvas>
            <input type="hidden" name="HdnImage4" class="HdnImage4" value='<%= ViewState["Signature4"].ToString() %>' />
        </div>
        <div class="right">
            I permit and authorize the physician and such other physicians qualifeid medical
            persons as are needed to perform this operation on me.
        </div>
        <div class="clear">
        </div>
    </li>
    <li>
        <div class="sig5 sigWrapper">
            <canvas class="pad" width="198" height="55"></canvas>
            <input type="hidden" name="HdnImage5" class="HdnImage5" value='<%= ViewState["Signature5"].ToString() %>' />
        </div>
        <div class="right">
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