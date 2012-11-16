<%@  Control Language="C#" AutoEventWireup="true" CodeBehind="ConsentDeclaration.aspx.cs"
    Inherits="WindowsCEConsentForms.Consent" %>
<%@ Register Src="PatientDetails.ascx" TagName="PatientDetails" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="DoctorsAndProcedures" Src="~/DoctorsAndProcedures.ascx" %>
<ul class="content">
    <li class="center">
        <h3>
            <%= Heading%></h3>
    </li>
    <li class="center">Endoscopy Procedure Consent Form</li>
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
            THE PHYSICIAN HAS EXPLAINED TO ME the nature of this procedure and how it is carried
            out. I UNDERSTAND that all surgeries and procedures involve general risks, such
            as severe loss of blood, infection, heart stoppage and in rare cases death. The
            physician has discussed with me the specific risks, benefits and possible side effects
            of this procedure and I understand them.
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
            IN ADDITION, the physician has explained to me that there are alternative ways of
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
            I CONSENT TO THE ADMINISTRATION OF SEDATION with or without analgesia by or under
            the direction of the above physician and to the use of such medications as may be
            deemed advisable. When an anesthesiologist or nurse anesthetist is involved, an
            evaluation will be performed by them and the administration of sedation will be
            directed by them. I consent to the administration of blood and blood products; to
            the disposal by authorities of Bethesda Memorial Hospital of any tissue or parts
            which may be removed; to the taking and publication of photographs or videotaping;
            and to the admittance of observers to the procedure room for the purpose of advancement
            of medical education.
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
            I PERMIT AND AUTHORIZE the physician and such other physicians or qualified medical
            persons as are needed to perform this procedure on me.
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
            THE PHYSICIAN HAS EXPLAINED TO ME that sometimes during the procedure it is discovered
            that additional surgery is needed. If such additional surgery is deemed necessary
            by the physician, I permit the physician to proceed.
        </div>
        <div class="clear">
        </div>
    </li>

    <li>
    I UNDERSTAND THAT NO GUARANTEES HAVE BEEN MADE TO ME that this procedure will improve my
    Condition.                
    </li>
     <li class="PatientReason">
            <asp:Panel runat="server" ID="PnlPatientReason2">
                <div>
                    If patient is unable to sign/person authorized to sign consent / relationship to
                    patient.</div>
                <div class="sig1 sigWrapper">
                    <canvas class="pad" width="198" height="55"></canvas>
                    <input type="hidden" name="HdnImage1" class="HdnImage1" value='<%= ViewState["Signature1"].ToString() %>' />
                </div>
                <div class="clear">
                </div>
            </asp:Panel>
        </li>
        <li class="PatientReason">
            <asp:Panel runat="server" ID="PnlPatientReason1">
                Please specify reason
                <br />
                <asp:TextBox runat="server" ID="TxtPatientNotSignedBecause"></asp:TextBox>
            </asp:Panel>
        </li>
        <li class="PatientSign">
            <asp:Panel runat="server" ID="PnlPatientSign">
                <div>
                    Patient Signature</div>
                <div class="sig2 sigWrapper">
                    <canvas class="pad" width="198" height="55"></canvas>
                    <input type="hidden" name="HdnImage2" class="HdnImage2" value='<%= ViewState["Signature2"].ToString() %>' />
                </div>
                <div class="clear">
                </div>
            </asp:Panel>
        </li>
        <li>
            <div>
                Witness To Signature Only</div>
            <div class="sig4 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" name="HdnImage4" class="HdnImage4" value='<%= ViewState["Signature4"].ToString() %>' />
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <asp:Panel runat="server" ID="PnlAdditionalwitness">
                <div>
                    Witness To signature
                </div>
                <div class="sig5 sigWrapper">
                    <canvas class="pad" width="198" height="55"></canvas>
                    <input type="hidden" name="HdnImage5" class="HdnImage5" value='<%= ViewState["Signature5"].ToString() %>' />
                </div>
                <div class="clear">
                </div>
            </asp:Panel>
        </li>
        <li>
            <asp:Label runat="server" ID="LblError" CssClass="errorInfo"></asp:Label>
        </li>
        <li class="center">
            <asp:Button runat="server" ID="BtnCompleted" Text="Complete" OnClick="BtnCompleted_Click"
                OnClientClick="javascript: return confirm('Are you sure that do you want to complete the form?');" />
        </li>
    <li>
        <asp:label runat="server" id="LblError" cssclass="errorInfo"></asp:label>
    </li>
    <li class="center">
        <asp:button runat="server" id="BtnPrevious" text="Prev" onclick="BtnPrevious_Click" />
        <asp:button runat="server" id="BtnNext" text="Next" onclick="BtnNext_Click" />
    </li>
</ul>
