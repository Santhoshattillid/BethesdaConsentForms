<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="/BloodConsentOrRefusal/ConsentPrint.aspx.cs" Inherits="WindowsCEConsentForms.BloodConsentOrRefusal.PICCConsentPrint" %>

<%@ Register TagPrefix="uc3" TagName="printfooter" Src="~/PrintFooter.ascx" %>
<%@ Register TagPrefix="uc4" TagName="PrintSignatures" Src="~/PrintSignatures.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li>
            <h3 class="center">
                CONSENT FOR TRANSFUSION OF BLOOD OR BLOOD PRODUCTS
            </h3>
        </li>
    </ul>
    <ul class="content print">
        <li>PATIENT:
            <asp:Label runat="server" ID="LblPatientName3" CssClass="errorInfo"></asp:Label>
        </li>
        <li>I here by authorize Doctor(s)
            <asp:Label runat="server" ID="LblAuthoriseDoctors" CssClass="errorInfo"></asp:Label>
            to perform upon
            <asp:Label runat="server" ID="LblPatientName2" CssClass="errorInfo"></asp:Label>
            the following procedure or operation:
            <br />
            <asp:Label runat="server" ID="LblProcedureName" CssClass="errorInfo"></asp:Label>
        </li>
        <li>
            <div class="small-content">
                In the course of your treatment, your physician has determined that it is necessary
                to administer a transfusion of blood or blood products. This form provides basic
                information concerning this procedure, and if signed by you, authorizes its performance
                by qualified medical personnel.
            </div>
        </li>
        <li>
            <div class="small-content">
                <span class="content-heading">DESCRIPTION OF PROCEDURE</span><br />
                Blood is introduced into one of your veins, commonly in the arm, using a sterilized
                disposable needle. The amount of blood transfused and whether the transfusion will
                be of blood, blood components or blood products, such as plasma, is a judgment the
                physician will make based on your particular needs.
            </div>
        </li>
        <li>
            <div class="small-content">
                <span class="content-heading">RISKS</span>
            </div>
        </li>
        <li>
            <ul class="content">
                <li>
                    <div class="small-content">
                        • A transfusion is a common procedure of low risk.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        • Minor and temporary reactions are not uncommon, including bruising, or local reaction
                        in the area where the needle pierces your skin or a non serious reaction to the
                        transfused material itself, including headache, fever or mild reaction such as skin
                        rash.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        • A serious reaction is possible, but unlikely since all blood is carefully matched
                        prior to transfusion, except in life-threatening emergencies.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        • Infectious diseases, which are known to be transmittable by blood, include Transfusion
                        Associated Viral Hepatitis (TAVH), a viral infection of the liver and Acquired Immunodeficiency
                        Syndrome (AIDS). The risk of acquiring an Infectious Disease from transfused blood
                        is relatively low and blood units are tested to avoid TAVH and HIV as required by
                        state and feral standards. However, these laboratory tests are not foolproof.
                    </div>
                </li>
            </ul>
        </li>
        <li>
            <div class="small-content">
                <span class="content-heading">BENEFITS/ALTERNATIVES</span>
            </div>
        </li>
        <li>
            <ul class="content">
                <li>
                    <div class="small-content">
                        • The loss of blood can pose serious threats during the course of treatment for
                        which there is no effective alternative to blood transfusion. If you have any further
                        questions on this matter, your physician or his/her colleagues will explain the
                        alternatives to you if this has not already been done.
                    </div>
                </li>
            </ul>
        </li>
    </ul>
    <ul class="content">
        <li>
            <% if (IsStatementOfConsent)
               {%>
            <ul class="content noBorder">
                <li>
                    <h3 class="center">
                        STATEMENT OF CONSENT</h3>
                </li>
                <li>
                    <div class="small-content">
                        I have read or had read to me, the above. I do not have any questions, which have
                        not been answered to my full satisfaction. I hereby consent to such transfusion,
                        as my physician may deem necessary or advisable in the course of my treatment.<br />
                        <table class="noBorder">
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="ChkDirectedUnits" Text="I have Directed Units" CssClass="leftPush" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" ID="ChkAutologousUnits" Text="I have Autologous Units"
                                        CssClass="leftPush" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ul>
            <%
               }
               else
               {%>
            <ul class="content noBorder">
                <li>
                    <h3 class="center">
                        STATEMENT OF REFUSAL</h3>
                </li>
                <li>
                    <div class="small-content">
                        I request that no blood or blood component be administered to me during the course
                        of this hospitalization. I hereby release my physician(s), the hospital and its
                        personnel from any responsibility whatsoever for unfavorable reactions, untoward
                        results or death due to my refusal to permit the use of blood or blood components.
                        The possible consequences of such refusal on my part have been fully explained to
                        me by a physician and I fully understand that such consequences may occur as a result
                        of my refusal.
                    </div>
                </li>
            </ul>
            <%
               }%>
        </li>
    </ul>
    <uc4:PrintSignatures ID="PrintSignatures1" runat="server" ConsentType="BloodConsentOrRefusal" />
    <uc3:printfooter ID="PrintFooter1" runat="server" ConsentType="BloodConsentOrRefusal" />
</asp:Content>