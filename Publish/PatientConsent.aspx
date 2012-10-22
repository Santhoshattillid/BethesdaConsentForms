<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="PatientConsent.aspx.cs" Inherits="WindowsCEConsentForms.ConsentForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <ul class="content">
        <li>
            <img src="Images/logo.png" />
        </li>
        <li>
            <table class="noBorder">
                <tr>
                    <td class="edgeColumn">
                        <h3>
                            Bethesda Hospital East
                            <br />
                            2815 S. Seacrest Blvd
                            <br />
                            Boynton Beach,FL 33435
                            <br />
                            (561) 737-7733
                        </h3>
                    </td>
                    <td class="middleColumn">
                    </td>
                    <td class="edgeColumn">
                        <h3>
                            Bethesda Hospital West
                            <br />
                            9655 Boynton Beach Blvd,
                            <br />
                            Boynton Beach, FL 33472
                            <br />
                            (561) 336-7000
                        </h3>
                    </td>
                </tr>
            </table>
        </li>
        <li>
            <table>
                <tbody>
                    <tr>
                        <td colspan="5">
                            <h3>
                                Patient Consent Form</h3>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Patient
                        </td>
                        <td colspan="4">
                            <asp:DropDownList ID="DdlPatientIds" runat="server" OnSelectedIndexChanged="DdlPatientIds_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Name
                        </td>
                        <td>
                            <asp:Label ID="LblName" runat="server" Enabled="false"></asp:Label>
                        </td>
                        <td>
                            Patient#
                        </td>
                        <td>
                            <asp:Label ID="LblId" runat="server" Enabled="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Age
                        </td>
                        <td>
                            <asp:Label runat="server" ID="LblAge" Enabled="false"></asp:Label>
                        </td>
                        <td>
                            Gender
                        </td>
                        <td colspan="2">
                            <asp:Label runat="server" ID="LblGender" Enabled="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            MR #
                        </td>
                        <td colspan="4">
                            <asp:Label runat="server" ID="LblSalutation" Enabled="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Att Dr.
                        </td>
                        <td colspan="4">
                            <asp:Label runat="server" ID="LblAttDr" Enabled="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Adm Date
                        </td>
                        <td colspan="4">
                            <asp:Label runat="server" ID="LblAdmDate" Enabled="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="noBorder">
                        </td>
                        <td colspan="4" class="noBorder">
                            <asp:DropDownList ID="DdlFormList" runat="server" Enabled="false" AutoPostBack="True"
                                OnSelectedIndexChanged="DdlFormList_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="noBorder">
                        </td>
                        <td colspan="4">
                            <ul>
                                <li>
                                    <asp:CheckBox runat="server" ID="ChkSurgicalConcent" Text="Surgical Consent" Enabled="false" />
                                </li>
                                <li>
                                    <asp:CheckBox runat="server" ID="ChkCCLC" Text="Cardiac Cath Lab Consent" Enabled="false" />
                                </li>
                                <li>
                                    <asp:CheckBox runat="server" ID="ChkEC" Text="Endoscopy Consent" Enabled="false" />
                                </li>
                                <li>
                                    <asp:CheckBox runat="server" ID="ChkBCOrR" Text="Blood  Consent/Refusal" Enabled="false" />
                                </li>
                            </ul>
                        </td>
                    </tr>
                    <% if (!string.IsNullOrEmpty(LblError.Text))
                       {%>
                    <tr>
                        <td colspan="5" class="center">
                            <asp:Label runat="server" ID="LblError" CssClass="errorInfo"></asp:Label>
                        </td>
                    </tr>
                    <%
                       }%>
                    <tr>
                        <td colspan="5" class="center">
                            <asp:Button runat="server" ID="BtnSign" Text="Sign" OnClick="BtnSign_Click" />
                            <asp:Button runat="server" ID="BtnReset" Text="Reset" OnClick="BtnReset_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </li>
    </ul>
    </form>
</asp:Content>