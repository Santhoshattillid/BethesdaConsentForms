<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConsentSignatures.ascx.cs"
    Inherits="WindowsCEConsentForms.ConsentSignatures" %>
<%@ Import Namespace="WindowsCEConsentForms.FormHandlerService" %>
<ul class="content">
    <li>
        <div class="sig1 sigWrapper">
            <canvas class="pad" width="198" height="55"></canvas>
            <input type="hidden" class="HdnImage1" name="<%= SignatureType.DoctorSign1.ToString() %>"
                value='<%= ViewState[SignatureType.DoctorSign1.ToString()].ToString() %>' />
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
            <input type="hidden" class="HdnImage2" name="<%= SignatureType.DoctorSign2.ToString() %>"
                value='<%= ViewState[SignatureType.DoctorSign2.ToString()].ToString() %>' />
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
            <input type="hidden" class="HdnImage3" name="<%= SignatureType.DoctorSign3.ToString() %>"
                value='<%= ViewState[SignatureType.DoctorSign3.ToString()].ToString() %>' />
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
            <input type="hidden" class="HdnImage4" name="<%= SignatureType.DoctorSign4.ToString() %>"
                value='<%= ViewState[SignatureType.DoctorSign4.ToString()].ToString() %>' />
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
            <input type="hidden" class="HdnImage5" name="<%= SignatureType.DoctorSign5.ToString() %>"
                value='<%= ViewState[SignatureType.DoctorSign5.ToString()].ToString() %>' />
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