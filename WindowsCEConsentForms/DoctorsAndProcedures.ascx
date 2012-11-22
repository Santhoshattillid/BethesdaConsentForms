<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoctorsAndProcedures.ascx.cs"
    Inherits="WindowsCEConsentForms.DoctorsAndProcedures" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="WindowsCEConsentForms" %>
<ul class="content">
    <%
        DoctorsProceduresState doctorsProcedures = (DoctorsProceduresState)ViewState["DoctorsProceduresState"];
        int index = -1;
        foreach (string doctorSelectedIndex in doctorsProcedures.SelectedDoctorsIndex)
        {
            var associatedDoctors = Utilities.GetAssociatedDoctors(doctorSelectedIndex);
            index += 1;

    %>
    <li class="LiDoctorsAndProcedures">I here by authorize Doctor(s)
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
            <%= associatedDoctors %></label>
        to perform upon &nbsp;
        <asp:Label runat="server" ID="LnlPatientName" CssClass="errorInfo"></asp:Label>
        the procedure or operation : &nbsp;
        <% if (!IsStaticTextBoxForPrecedures)
           {%>
        <asp:DropDownList ID="DdLProcedures" runat="server" Width="400px">
        </asp:DropDownList>
        <asp:HiddenField runat="server" ID="HdnSelectedProcedures" EnableViewState="True" />
        <div id="DivOtherProcedure">
            <label>
                Specify procedure</label>
            &nbsp;
            <asp:TextBox runat="server" ID="TxtOtherProcedure"></asp:TextBox>
        </div>
        <% }
           else
           { %>
        <div>
            <input type="text" id="TxtProcedures" name="TxtProcedures" class="TxtProcedures"
                value="<%= doctorsProcedures.Procedures[index] %>" />
        </div>
        <% } %>
    </li>
    <%    }%>
    <li>
        <div class="addNewBox">
            <a href="#" id="AddNewProcedure">Add new procedure</a>
        </div>
    </li>
</ul>
<script language="javascript" type="text/javascript">
    $(function () {
        var emptyCloneDocProc = $('.LiDoctorsAndProcedures').eq(0).clone();
        $('#AddNewProcedure').click(function () {
            var liClone = $(this).parents('li');
            var cloneData = emptyCloneDocProc.clone();
            cloneData.find('.LblAssociatedDoctors').empty();
            cloneData.find('.TxtProcedures').empty();
            cloneData.find('.TxtProcedures').val('');
            cloneData.find('.DdlPrimaryDoctors').val('0');
            liClone.eq(0).before(cloneData);
            return false;
        });
        $(".DdlPrimaryDoctors").live('change', function () {
            var This = $(this);
            var value = $(this).val();
            $.ajax({
                type: 'POST',
                url: '/AjaxMethods.asmx/GetAssociatedDoctors',
                data: "{'primaryPhysicianId':'" + value + "'}",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                before: function () {

                },
                success: function (data) {
                    This.parent('li').find(".LblAssociatedDoctors").html(data.d);
                },
                error: function (e) {

                }
            });
            return false;
        });
    });
</script>