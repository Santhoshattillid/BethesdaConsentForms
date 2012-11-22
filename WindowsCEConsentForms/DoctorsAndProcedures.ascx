<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoctorsAndProcedures.ascx.cs"
    Inherits="WindowsCEConsentForms.DoctorsAndProcedures" %>
<ul class="content">
    <li class="LiDoctorsAndProcedures">I here by authorize Doctor(s)
        <asp:DropDownList ID="DdlPrimaryDoctors" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlPrimaryDoctors_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;
        <asp:Label ID="LblAssociatedDoctors" runat="server" CssClass="errorInfo"></asp:Label>
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
            <asp:TextBox runat="server" ID="TxtProcedures"></asp:TextBox>
        </div>
        <% } %>
    </li>
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
            liClone.eq(0).before(emptyCloneDocProc.clone());
            return false;
        });
    });
</script>