<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.PlasmanApheresis.ConsentPrint" %>

<%@ Register TagPrefix="uc1" TagName="DoctorsAndProceduresPrint" Src="~/DoctorsAndProceduresPrint.ascx" %>
<%@ Register TagPrefix="uc2" TagName="PageHeader" Src="~/PageHeader.ascx" %>
<%@ Register TagPrefix="uc3" TagName="printfooter" Src="~/PrintFooter.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">
            <h3>
                CONSENT FOR THERAPEUTIC APHERESIS
            </h3>
        </li>
    </ul>
    <uc1:DoctorsAndProceduresPrint ID="DoctorsAndProceduresPrint1" runat="server" ConsentType="PlasmanApheresis" />
    <ul class="content print">
        <li>
            <div class="small-content">
                The nature and purpose of the procedure necessary to treat my condition, possible
                alternative methods of treatment, the risks involved, the possible consequences
                and the possibility of complications have been explained to me by phyname and I
                understand the nature of the procedure to be as follows:
            </div>
        </li>
        <li>
            <div class="small-content">
                Therapeutic Apheresis involves the separation, removal and replacement of specific
                blood cells or plasma components from my blood. This involves the passage of my
                blood from my circulatory system into a machine, where it is circulated through
                a device which acts to remove the specific blood cells or plasma components from
                the blood.
            </div>
        </li>
        <li>
            <div class="small-content">
                I have been made aware of certain risks, benefits or alternatives that may be associated
                with the procedure herein described. Possible risks are, but not limited to:
            </div>
        </li>
        <li>
            <ul class="content">
                <li>
                    <div class="small-content">
                        • The possibility of contamination of the blood with various bacteria or germs,
                        which can result in bloodstream infection.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        • The possibility of excess bleeding occurring within the body as a result of clotting
                        problems of the blood, or externally due to disconnection of the bloodline.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        • The possibility of contracting infections of the puncture site of catheter which
                        allows access to the bloodstream.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        • The potential hazard of air embolism forming in which air enters the machine and
                        thereby gets into the patient’s bloodstream, leading to severe complications, which
                        may include death or paralysis.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        • The possibility of irregular heartbeats, tingling or numbness of the fingers,
                        chest, mouth or face, nausea, bruising at the site of needle insertion, or decrease
                        in blood pressure resulting from certain chemical shifts within the patient’s system.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        • The possibility of a reaction to medications and/or replacement fluids given during
                        the treatment which may result in adverse effects ranging from mild to (rarely)
                        fatal shock or cardiac arrest.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        • The possibility of excess fluid in the bloodstream, causing shortness of breath
                        and/or changes in the heart rate and blood pressure.
                    </div>
                </li>
            </ul>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature1" />
            </div>
            <div class="right">
                I acknowledge that no guarantee or assurance has been given to me by anyone as to
                the results that may be obtained.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature2" />
            </div>
            <div class="right">
                I acknowledge that all blank spaces on this document have been either completed
                or crossed off prior to my signing.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature3" />
            </div>
            <div class="right">
                I acknowledge that I have read and understand the foregoing, and that I have asked
                and been afforded the opportunity to ask whatever questions I have regarding the
                treatment.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgSignature4" />
            </div>
            <div class="right">
                I hereby release Bethesda Memorial Hospital, its employees, and physicians from
                any and all liability that may result from this treatment.
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
    <ul class="content">
        <li>
            <uc2:PageHeader ID="PageHeader1" runat="server" />
        </li>
        <li class="noBorder">
            <asp:Panel runat="server" ID="PnlPatientSignature">
                <div class="sigBox">
                    <asp:Image runat="server" ID="ImgPatientSignature" />
                </div>
                <div class="right">
                    <asp:Label runat="server" ID="LblPatientSignatureDateTime"></asp:Label>
                </div>
                <div class="clear">
                </div>
                <div>
                    (PATIENT SIGNATURE)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    __________________ Date:__<asp:Label runat="server" ID="LblPatientSignatureDate"
                        CssClass="DateTimeUnderline">___</asp:Label>____ Time:__<asp:Label runat="server"
                            ID="LblPatientSignatureTime" CssClass="DateTimeUnderline"></asp:Label>__
                </div>
            </asp:Panel>
        </li>
        <li>
            <asp:Panel runat="server" ID="PnlPatientUnableToSignBecause">
                Patient is unable to sign because:
                <div>
                    <asp:Label runat="server" ID="LblPatientUnableToSignBecause" CssClass="DateTimeUnderline"></asp:Label>
                </div>
            </asp:Panel>
        </li>
        <li>
            <asp:Panel runat="server" ID="PnlAuthorizedSignature">
                <div class="sigBox">
                    <asp:Image runat="server" ID="ImgAuthorizedSignature" />
                </div>
                <div class="clear">
                </div>
                <div>
                    (If patient unable to sign, person authorized to sign.)&nbsp;&nbsp;&nbsp;__________________
                    Date:__<asp:Label runat="server" ID="LblAuthorizedSignDate" CssClass="DateTimeUnderline">___</asp:Label>__
                    Time:__<asp:Label runat="server" ID="LblAuthorizedSignTime" CssClass="DateTimeUnderline"></asp:Label>_
                </div>
            </asp:Panel>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgWitnessSignature1" />
            </div>
            <div class="right">
                <asp:Label runat="server" ID="LblWitnessSignature1DateTime"></asp:Label>
            </div>
            <div class="clear">
            </div>
            <div>
                (Witness to Signature or Telephone Consent Only)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;__________________
                Date:__<asp:Label runat="server" ID="LblWitnessSignature1Date" CssClass="DateTimeUnderline">___</asp:Label>__
                Time:__<asp:Label runat="server" ID="LblWitnessSignature1Time" CssClass="DateTimeUnderline"></asp:Label>_
            </div>
        </li>
        <li>
            <div class="sigBox">
                <asp:Image runat="server" ID="ImgWitnessSignature2" />
            </div>
            <div class="clear">
            </div>
            <div>
                (Second Witness to Telephone Consent Only)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;__________________
                Date:__<asp:Label runat="server" ID="LblWitnessSignature2Date" CssClass="DateTimeUnderline">___</asp:Label>__
                Time:__<asp:Label runat="server" ID="LblWitnessSignature2Time" CssClass="DateTimeUnderline"></asp:Label>_
            </div>
        </li>
        <li>
            <div>
                <br />
                Interpreted By:
            </div>
            <div>
                <asp:Label runat="server" ID="LblTranslatedBy" CssClass="errorInfo"></asp:Label>
            </div>
            <div class="clear">
            </div>
            <br />
            <br />
            (Interpreted By)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;__________________
            Date:__<asp:Label runat="server" ID="LblTranslatedDate" CssClass="DateTimeUnderline">___</asp:Label>__
            Time:__<asp:Label runat="server" ID="LblTranslatedTime" CssClass="DateTimeUnderline"></asp:Label>__
        </li>
    </ul>
    <uc3:printfooter ID="PrintFooter1" runat="server" ConsentType="PlasmanApheresis" />
</asp:Content>