<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Consent.aspx.cs" Inherits="WindowsCEConsentForms.PICCConsent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <ul class="content">
        <li>
            <img src="Images/logo.png" alt="" />
        </li>
        <li>
            <table class="noBorder">
                <tr>
                    <td class="edgeColumn">
                        <h3>
                            Bethesda Hospital East
                            <br />
                            2815 S. Seacrest Blvd
                            <br />
                            Boynton Beach,FL 33435
                            <br />
                            (561) 737-7733
                        </h3>
                    </td>
                    <td class="middleColumn">
                    </td>
                    <td class="edgeColumn">
                        <h3>
                            Bethesda Hospital West
                            <br />
                            9655 Boynton Beach Blvd,
                            <br />
                            Boynton Beach, FL 33472
                            <br />
                            (561) 336-7000
                        </h3>
                    </td>
                </tr>
            </table>
        </li>
        <li class="center">
            <h3>
                PICC Consent Form</h3>
        </li>
        <li class="center">CONSENT FOR DIAGNOSTIC PROCEDURE OR OPERATION</li>
        <li>
            <div class="right smallest">
                MR # :</div>
            <div class="right small">
                <asp:Label ID="LblPatientMRId" runat="server" CssClass="errorInfo"></asp:Label></div>
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
            <asp:DropDownList ID="DdlPrimaryDoctors" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlPrimaryDoctors_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;
            <asp:Label ID="LblAssociatedDoctors" runat="server" CssClass="errorInfo"></asp:Label>
            to perform upon &nbsp;
            <asp:Label runat="server" ID="LnlPatientName" CssClass="errorInfo"></asp:Label>
            the procedure or operation : &nbsp;
            <asp:DropDownList ID="DdLProcedures" runat="server" Width="400px">
            </asp:DropDownList>
            <asp:HiddenField runat="server" ID="HdnSelectedProcedures" />
            <div id="DivOtherProcedure">
                <label>
                    Specify procedure</label>
                &nbsp;
                <asp:TextBox runat="server" ID="TxtOtherProcedure"></asp:TextBox>
            </div>
        </li>
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
    </form>
</asp:Content>