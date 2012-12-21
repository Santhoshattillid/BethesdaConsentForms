<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.PlasmanApheresis.ConsentDeclaration" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="WindowsCEConsentForms" %>
<%@ Import Namespace="WindowsCEConsentForms.FormHandlerService" %>
<%@ Register TagPrefix="uc1" TagName="DeclarationSignatures" Src="~/DeclarationSignatures.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PatientDetails" Src="~/PatientDetails.ascx" %>
<%@ Register Src="../DoctorsAndProcedures.ascx" TagName="DoctorsAndProcedures" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">
            <p>
                CONSENT FOR THERAPEUTIC APHERESIS</p>
        </li>
    </ul>
    <uc1:PatientDetails ID="PatientDetails1" runat="server" />
    <ul class="content">
        <li>
            <div class="small-content">
                I authorize the performance of therapeutic apheresis on
                <asp:Label ID="LblPatientName" runat="server" CssClass="errorInfo" />
                of therapeutic apheresis to be performed by or under the direction of
                <select class="DdlPrimaryDoctors" name="DdlPrimaryDoctors">
                    <% List<PrimaryDoctor> collection = (List<PrimaryDoctor>)ViewState["PrimaryDoctors"];
                       int doctorSelectedIndex = Convert.ToInt32(ViewState["doctorSelectedIndex"]);
                       var associatedDoctors = Utilities.GetAssociatedDoctors(Convert.ToInt32(doctorSelectedIndex));
                       foreach (PrimaryDoctor listItem in collection)
                       {
                           if (listItem.Id == doctorSelectedIndex)
                           {
                    %>
                    <option value="<%= listItem.Id %>" selected="selected">
                        <%= listItem.Name %></option>
                    <% }
                           else
                           { %>
                    <option value="<%= listItem.Id %>">
                        <%= listItem.Name %></option>
                    <% } %>
                    <%
                       }
                    %>
                </select>
                <label class="errorInfo LblAssociatedDoctors">
                    <%= associatedDoctors  %></label>
            </div>
        </li>
    </ul>
    <ul class="content">
        <li>
            <div class="small-content">
                Therapeutic Apheresis involves the separation, removal and replacement of specific
                blood cells or plasma components from my blood. This involves the passage of my
                blood from my circulatory system into a machine, where it is circulated through
                a device which acts to remove the specific blood cells or plasma.
            </div>
        </li>
        <li>
            <div class="small-content">
                This involves the passage of my blood from my circulatory system into a machine,
                where it is circulated through a device which acts to remove the specific blood
                cells or plasma components from the blood.
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
                        The possibility of contamination of the blood with various bacteria or germs, which
                        can result in bloodstream infection.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        The possiblity of excess bleeding occuring within the body as a result of clotting
                        problems of the blood, or externally due to disconnection of the bloodline.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        The possibility of contracting infections of the puncture site of catherer which
                        allows access to the bloodsteam.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        The potential hazard of air embolism forming in which air enters the machine and
                        thereby gets into the patient's bloodstream, leading to severe complications, which
                        may include death or paralysis.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        The possibility of irregular heartbeats, tingling or numbness of the fingers, chest,
                        mouth of or face, nausea, bruising at the site of needle insertion, or decrease
                        blood pressure resulting from certain chemical shifts within the patient's system.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        The possibility of a reaction to medications and/or replacement fluids given during
                        the treatment which may result in adverse effects ranging from mild to (rarely)
                        fatal shock or cardiac arrest.
                    </div>
                </li>
                <li>
                    <div class="small-content">
                        The possibility of excess fluid in the bloodstream, causing shortness of breath
                        and/or changes in the heart rate and blood pressure.
                    </div>
                </li>
            </ul>
        </li>
        <li>
            <div class="sig1 sigWrapper">
                <canvas class="pad" width="198" height="55"></canvas>
                <input type="hidden" class="HdnImage1" name="<%= SignatureType.DoctorSign1.ToString() %>"
                    value='<%= ViewState[SignatureType.DoctorSign1.ToString()].ToString() %>' />
            </div>
            <div class="right">
                I acknowledge that no guarantee or assurance has been given to me by anyone as to
                the results that may be obtained.
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
                I acknowledge that all blank spaces on this document have been either completed
                or crossed off prior to my signing.
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
                I acknowledge that I have read and understand the foregoing, and that I have asked
                and been afforded the opportunity to ask whatever questions I have regarding the
                treatment.
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
                I hearby release Bethesda Memorian Hospial, its employees, and physicians from any
                and all liability that may result from this treatment.
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
    <uc1:DeclarationSignatures ID="DeclarationSignatures" runat="server" ConsentType="PlasmanApheresis" />
</asp:Content>