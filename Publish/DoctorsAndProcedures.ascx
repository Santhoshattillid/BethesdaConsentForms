<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoctorsAndProcedures.ascx.cs"
    Inherits="WindowsCEConsentForms.DoctorsAndProcedures" %>
<ul class="content">
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
        <asp:HiddenField runat="server" ID="HdnSelectedProcedures" EnableViewState="True" />
        <div id="DivOtherProcedure">
            <label>
                Specify procedure</label>
            &nbsp;
            <asp:TextBox runat="server" ID="TxtOtherProcedure"></asp:TextBox>
        </div>
    </li>
</ul>