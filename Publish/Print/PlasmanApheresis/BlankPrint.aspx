<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" %>

<%@ Register TagPrefix="uc3" TagName="printfooter" Src="~/PrintFooter.ascx" %>
<%@ Register TagPrefix="uc4" TagName="PrintSignatures" Src="~/PrintSignatures.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">
            <h3>
                CONSENT FOR THERAPEUTIC APHERESIS
            </h3>
        </li>
        <li>PATIENT:</li>
        <li>I authorize the performance of therapeutic apheresis on
            <br />
            <br />
            of therapeutic apheresis to be performed by or under the direction of
            <br />
            <br />
            <br />
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
            <div class="PrintsigBox">
            </div>
            <div class="right">
                I acknowledge that no guarantee or assurance has been given to me by anyone as to
                the results that may be obtained.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
                I acknowledge that all blank spaces on this document have been either completed
                or crossed off prior to my signing.
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
    <uc3:printfooter ID="PrintFooter2" runat="server" ConsentType="PlasmanApheresis" />
    <ul class=" content pageHeader">
        <li>
            <div class="PrintsigBox">
            </div>
            <div class="right">
                I acknowledge that I have read and understand the foregoing, and that I have asked
                and been afforded the opportunity to ask whatever questions I have regarding the
                treatment.
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
    <uc4:PrintSignatures ID="PrintSignatures1" runat="server" ConsentType="PlasmanApheresis" />
    <uc3:printfooter ID="PrintFooter1" runat="server" ConsentType="PlasmanApheresis" />
</asp:Content>