<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoctorsAndProcedures.ascx.cs"
    Inherits="WindowsCEConsentForms.DoctorsAndProcedures" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="WindowsCEConsentForms" %>
<%@ Import Namespace="WindowsCEConsentForms.FormHandlerService" %>
<ul class="content">
    <%
        List<string> listOfProcedures = (List<string>)ViewState["ListOfProcedures"];

        DoctorsProceduresState doctorsProcedures = (DoctorsProceduresState)ViewState["DoctorsProceduresState"];
        int index = -1;
        foreach (string doctorSelectedIndex in doctorsProcedures.SelectedDoctorsIndex)
        {
            var associatedDoctors = Utilities.GetAssociatedDoctors(Convert.ToInt32(doctorSelectedIndex));
            index += 1;

    %>
    <li class="LiDoctorsAndProcedures">
        <div class="leftBox">
            <% if (ConsentType == ConsentType.Cardiovascular)
               { %>
            I authorize Doctor(s)
            <% }
               else
               { %>
            I hereby authorize Doctor(s)
            <% } %>
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
            <% if (ConsentType == ConsentType.Cardiovascular)
               { %>
            and such designee or assistants as he/she may designate to
            <% } %>
            perform upon
            <asp:Label runat="server" ID="LblPatientName"></asp:Label>
            <% if (ConsentType == ConsentType.Cardiovascular)
               { %>
            the following procedures
            <% }
               else
               { %>
            the following procedure or operation:
            <% } %>
            <% if (!IsStaticTextBoxForPrecedures)
               {%>
            <select multiple="multiple" class="DdLProcedures" style="width: 400px;">
                <% foreach (string procedure in listOfProcedures)
                   { %>
                <option value="<%= procedure %>">
                    <%= procedure %></option>
                <% } %>
            </select>
            <a href="#" class="RemoveDocAndProc extraMargin">Remove<img src="/Images/index.jpg"
                alt="" /></a>
            <input type="hidden" class="HdnSelectedProcedures" name="HdnSelectedProcedures" value="<%= doctorsProcedures.SelectedProcedures[index] %>" />
            <div id="DivOtherProcedure" class="DivOtherProcedure">
                <label>
                    Specify procedure</label>
                &nbsp;
                <input type="text" name="TxtOtherProcedure" value="<%= doctorsProcedures.OtherProcedures[index] %>" />
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
            <a href="#" id="AddNewProcedure">Add a physician</a>
        </div>
    </li>
</ul>