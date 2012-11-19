<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ConsentDeclaration.aspx.cs" Inherits="WindowsCEConsentForms.PlasmanApheresis.ConsentDeclaration" %>
<%@ Import Namespace="WindowsCEConsentForms" %>
<%@ Register TagPrefix="uc1" TagName="DeclarationSignatures" Src="~/DeclarationSignatures.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ConsentSignatures" Src="~/ConsentSignatures.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PatientDetails" Src="~/PatientDetails.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DoctorsAndProcedures" Src="~/DoctorsAndProcedures.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<ul class="content">
        <li class="center">
            <h3>
                PLASMAN APHERESIS FORM</h3>
        </li>
        <li class="center">
            <p>
                CONSENT FOR THERAPEUTIC APHERESIS</p>
        </li>
    </ul>
    <uc1:PatientDetails ID="PatientDetails1" runat="server"  />
    <uc1:DoctorsAndProcedures ID="DoctorsAndProcedures1" runat="server" ConsentType="Surgical"  />
<ul>
    <li>
        <asp:Label ID="LblPatientName" runat="server"/> of therapeutic apheresis to be performed by or under the direction of 
        <asp:DropDownList ID="DdlPhysicainList" runat="server"/>
    </li>
    <li>
        The nature and purpose of the procedure  necessary to treat my condition, possible alternative methods of treatment, the risks involved, the possible consequences, and the possibility of complications have been explained to me by <asp:Label ID="LblPhysicianName" runat="server"></asp:Label> and I understand the nature of the procedure to be as follows.
    </li>
    <li>
        Therapeutic Apheresis involves the separation, removal and replacement of specific blood cells or plasma components from my blood. This involves the passage of my blood from my circulatory system into a machine, where it is circulated through a device which acts to remove the specific blood cells or plasma.
    </li>
    <li>
        I have been made aware of certain risks and consequences that may be associated with the procedure heren described. Among others there are:
    </li>
    <li>
        <ul>
            <li>
                The possibility of contamination of the blood with various bacteria or germs, which can result in bloodstream infection.
            </li>
            <li>
                The possiblity of excess bleeding occuring within the body as a result of clotting problems of the blood, or externally due to disconnection of the bloodline.
            </li>
            <li>
                The possibility of contracting infection of the puncture site of catherer which allows access to the bloodsteam.
            </li>
            <li>
                The potential hazard of air heartbeats, tingling or numbness of the fingers chest, mouth of face, nausea, bruising at the site of neede insertion, or decrease blood pressure resulting from certain chemical shifts within the patient's system. 
            </li>
            <li>
                The possibility of a re-action to medication and/or replacement fluids given during the treatment which may result in adverse effects ranging from mid to (rarely) fatal shock ot cardiac arrest.
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
                I acknowledge the no guarantee or assurance has been given to me by anyone as to the results that may be obtained.
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
                I acknowledge that all blank spaces on this document have been either completed or crassed off prior to my signing.
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
                I acknowledge that I have read and understand the foregoing, and that I have asked and been afforded the opportunity to ask whatever questions I have regarding the treatment.
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
                I hearby release Bethesda Memorian Hospial, its employees, and physicians from any and all liability that may result from this treatment.
            </div>
            <div class="clear">
            </div>
     </li>
</ul>
</asp:Content>
