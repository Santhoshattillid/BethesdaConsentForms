<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoctorsAndProcedures.ascx.cs"
    Inherits="WindowsCEConsentForms.DoctorsAndProcedures" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="WindowsCEConsentForms" %>
<ul class="content">
    <%
        List<string> listOfProcedures = (List<string>)ViewState["ListOfProcedures"];

        DoctorsProceduresState doctorsProcedures = (DoctorsProceduresState)ViewState["DoctorsProceduresState"];
        int index = -1;
        foreach (string doctorSelectedIndex in doctorsProcedures.SelectedDoctorsIndex)
        {
            var associatedDoctors = Utilities.GetAssociatedDoctors(doctorSelectedIndex);
            index += 1;

    %>
    <li class="LiDoctorsAndProcedures">
        <div class="leftBox">
            I authorize Doctor(s)
            <select class="DdlPrimaryDoctors" name="DdlPrimaryDoctors">
                <% List<PrimaryDoctor> collection = (List<PrimaryDoctor>)ViewState["PrimaryDoctors"];
                   foreach (PrimaryDoctor listItem in collection)
                   {
                       if (listItem.Id.ToString(CultureInfo.InvariantCulture) == doctorSelectedIndex)
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
            and such designee or assistant as he may designate to perform:
            <% if (!IsStaticTextBoxForPrecedures)
               {%>
            <select multiple="multiple" class="DdLProcedures" style="width: 400px;">
                <% foreach (string procedure in listOfProcedures)
                   { %>
                <option value="<%= procedure %>">
                    <%= procedure %></option>
                <% } %>
            </select>
            <a href="#" class="RemoveDocAndProc extraMargin">Remove
                <img src="/Images/index.jpg" alt="" /></a>
            <input type="hidden" class="HdnSelectedProcedures" name="HdnSelectedProcedures" value="<%= doctorsProcedures.SelectedProcedures[index] %>" />
            <div id="DivOtherProcedure" class="DivOtherProcedure">
                <label>
                    Specify procedure</label>
                &nbsp;
                <input type="text" name="TxtOtherProcedure" />
            </div>
            <% }
               else
               { %>
            <div>
                <input type="text" id="TxtProcedures" name="TxtProcedures" class="TxtProcedures"
                    value="<%= doctorsProcedures.SelectedProcedures[index] %>" />
                <a href="#" class="RemoveDocAndProc">Remove
                    <img src="/Images/index.jpg" alt="" /></a>
            </div>
            <% } %>
        </div>
        <div class="clear">
        </div>
    </li>
    <%    }%>
    <li>
        <div class="addNewBox">
            <a href="#" id="AddNewProcedure">Add a Physician</a>
        </div>
    </li>
</ul>