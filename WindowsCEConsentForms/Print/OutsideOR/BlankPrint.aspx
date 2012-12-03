<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" %>

<%@ Register TagPrefix="uc2" TagName="PageHeader" Src="~/PageHeader.ascx" %>
<%@ Register TagPrefix="uc3" TagName="printfooter" Src="~/PrintFooter.ascx" %>
<%@ Register TagPrefix="uc4" TagName="PrintSignatures" Src="~/PrintSignatures.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content print">
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
            <h4>
                PATIENT - PLEASE INITIAL the lines next to each paragraph of this consent to indicate
                your agreement with the statements therein.
            </h4>
        </li>
        <li>
            <div class="PrintsigBox">
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
            <div class="PrintsigBox">
            </div>
            <div class="right">
                In addition, the physician has explained to me that there are alternative ways of
                treating my condition but I have chosen this procedure.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
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
            <div class="PrintsigBox">
            </div>
            <div class="right">
                I permit and authorize the physician and such other physicians qualifeid medical
                persons as are needed to perform this operation on me.
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="PrintsigBox">
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
    <ul class="content">
        <li>
            <uc2:PageHeader ID="PageHeader1" runat="server" />
        </li>
    </ul>
    <uc4:PrintSignatures ID="PrintSignatures1" runat="server" ConsentType="None" />
    <uc3:printfooter ID="PrintFooter1" runat="server" ConsentType="OutsideOR" />
</asp:Content>