<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" %>

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
        <li>PATIENT:</li>
        <li>I here by authorize Doctor(s)
            <br />
            <br />
            to perform upon
            <br />
            <br />
            the following procedure or operation:
            <br />
            <br />
            <br />
        </li>
        <li>
            <div class="small-content">
                <span class="small-header">Cardiac/Peripheral Catheterization and Angiography;</span>this
                procedure involves the passage of catheters through blood vessels in the groin/arm.
                Pressure measurements are recorded and contrast (dye), are injected to look at the
                arteries for blockage.
            </div>
        </li>
        <li>
            <div class="small-content">
                Based upon the diagnostic findings, the following procedures may also be performed:
            </div>
        </li>
        <li>
            <table>
                <tr>
                    <td>
                        <span class="small-header">Coronary Peripheral Angioplasty </span>involves the opening
                        or dilating the passageway of a narrow artery.
                    </td>
                    <td>
                        <span class="small-header">Percutaneous Transluminal Coronary/Peripheral Angioplasty
                        </span>involves using a catheter with a small balloon at the tip that is inflated
                        at the blocked area of artery stretching the artery and flattening the plaque against
                        the artery wall.
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="small-header">Stent Implantation </span>involves placing a balloon
                        catheter with a wire mesh scaffold (stent) over it into the artery to support the
                        wall and assist to reduce the amount of blockage. The balloon is removed and the
                        stent remains permanently within the artery.
                    </td>
                    <td>
                        <span class="small-header">Rotational Arthrectomy </span>involves passing a catheter
                        with a football shaped tip coated with microscopic diamond crystals into the artery.
                        The tip is driven by a turbine at very high speed. The plaque particles that are
                        removed are typically smaller than red blood cells and therefore move downstream
                        and are picked up by the body’s waste system.
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="small-header">Intravascular Ultrasound </span>involves passing an ultrasound
                        catheter into the artery for the purpose of studying details of the interior of
                        the artery.
                    </td>
                    <td>
                        <span class="small-header">Hemolytic Thrombectomy </span>involves the passage of
                        ultrasound catheter that removes fresh clot in an artery by the vacuum produced
                        by a high-speed saline flush.
                    </td>
                </tr>
            </table>
        </li>
        <li>
            <div class="PrintsigBox">
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
            <div class="PrintsigBox">
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
    </ul>
    <uc3:printfooter ID="PrintFooter2" runat="server" ConsentType="Cardiovascular" />
    <ul class="pageHeader">
    </ul>
    <ul class="content">
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
                This procedure usually requires moderate sedation. I understand that the expected
                result of moderate sedation is reduced anxiety and/or pain, partial or total amnesia.
                The drug is injected into the blood stream. I understand that the risks associated
                with moderate sedation are unconscious state and depressed breathing, possibly requiring
                intubation. I consent to the administration of moderate sedation.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
                This procedure and its complications have been explained to me, I acknowledge that
                I have been given no guarantee against complications or assurance of success by
                the physician who has explained them. I know I have been given free choice to accept
                or reject any and/or all of the procedures to be performed on myself. In the event
                any complications should arise. I permit the above physicians to seek consultation
                with other specialties and permit the performance of any surgical or other procedures
                that may be required on an emergency basis to correct such complications.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
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
    </ul>
    <uc4:PrintSignatures ID="PrintSignatures1" runat="server" ConsentType="None" />
    <uc3:printfooter ID="PrintFooter1" runat="server" ConsentType="Cardiovascular" />
</asp:Content>