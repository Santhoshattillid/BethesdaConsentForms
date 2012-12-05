<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoctorsAndProceduresPrint.ascx.cs"
    Inherits="WindowsCEConsentForms.DoctorsAndProceduresPrint" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="WindowsCEConsentForms" %>
<ul class="content">
    <% List<DocAndProcPrint> outPut = (List<DocAndProcPrint>)ViewState["DocAndProcDetails"]; %>
    <% foreach (DocAndProcPrint doctorAndProcedure in outPut)
       { %>
    <li>I here by authorize Doctor(s) <span class="errorInfo">
        <%= doctorAndProcedure.Doctor %></span> to perform upon <span class="errorInfo">
            <%= doctorAndProcedure.PatientName %></span> the following procedure or operation:
        <br />
        <span class="errorInfo">
            <%= doctorAndProcedure.Procedures %></span> </li>
    <% } %>
</ul>