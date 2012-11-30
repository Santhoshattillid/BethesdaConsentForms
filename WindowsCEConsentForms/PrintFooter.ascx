<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintFooter.ascx.cs"
    Inherits="WindowsCEConsentForms.PrintFooter" %>
<%@ Import Namespace="WindowsCEConsentForms" %>
<ul class="content">
    <li>
        <table class="bigfont printFooter">
            <tr>
                <td>
                    FORM:
                </td>
                <td>
                    <%= Utilities.GetConsentHeader(ConsentType)%>
                </td>
                <td>
                    MR#:
                </td>
                <td>
                    <asp:Label runat="server" ID="LblPatientMrHash"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    PATIENT:
                </td>
                <td>
                    <asp:Label runat="server" ID="LblPatientName"></asp:Label>
                </td>
                <td>
                    DOB:
                </td>
                <td>
                    <asp:Label runat="server" ID="LblDOB"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    PATIENT#:
                </td>
                <td>
                    <asp:Label runat="server" ID="LblPatientId"></asp:Label>
                </td>
                <td>
                    AGE:
                </td>
                <td>
                    <asp:Label runat="server" ID="LblAge"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    GENDER:
                </td>
                <td>
                    <asp:Label runat="server" ID="LblGender"></asp:Label>
                </td>
                <td>
                    DATE:
                </td>
                <td>
                    <asp:Label runat="server" ID="LblDate"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    ADMIT DATE:
                </td>
                <td>
                    <asp:Label runat="server" ID="LblPatientAdminDate"></asp:Label>
                </td>
                <td>
                    TIME:
                </td>
                <td>
                    <asp:Label runat="server" ID="LblPatientAdminTime"></asp:Label>
                </td>
            </tr>
        </table>
    </li>
</ul>