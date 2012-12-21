<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoctorsAndProceduresPrint.ascx.cs"
    Inherits="WindowsCEConsentForms.DoctorsAndProceduresPrint" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="WindowsCEConsentForms" %>
<%@ Import Namespace="WindowsCEConsentForms.FormHandlerService" %>
<ul class="content">
    <% List<DocAndProcPrint> outPut = (List<DocAndProcPrint>)ViewState["DocAndProcDetails"]; %>
    <% foreach (DocAndProcPrint doctorAndProcedure in outPut)
       { %>
    <li>
        <% if (ConsentType == ConsentType.PlasmanApheresis)
           { %>
        I authorize the performance of therapeutic apheresis on
        <asp:Label runat="server" ID="LblPatientName"></asp:Label>
        of therapeutic apheresis to be performed by or under the direction of <span class="errorInfo">
            <%= doctorAndProcedure.Doctor %></span>
        <% }
           else if (ConsentType == ConsentType.Cardiovascular)
           { %>
        I authorize Doctor(s) <span class="errorInfo">
            <%= doctorAndProcedure.Doctor %></span> and such designee or assistant as he/she
        may designate to perform upon <span class="errorInfo">
            <%= doctorAndProcedure.PatientName %></span> the following procedure: <span class="errorInfo">
                <%= doctorAndProcedure.Procedures %></span>
        <% }
           else
           { %>
        I hereby authorize Doctor(s) <span class="errorInfo">
            <%= doctorAndProcedure.Doctor %></span> to perform upon <span class="errorInfo">
                <%= doctorAndProcedure.PatientName %></span> the following procedure or
        operation:
        <br />
        <span class="errorInfo">
            <%= doctorAndProcedure.Procedures %></span>
        <% } %>
    </li>
    <%   } %>
</ul>