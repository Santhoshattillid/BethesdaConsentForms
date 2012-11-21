<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="PatientConsent.aspx.cs" Inherits="WindowsCEConsentForms.ConsentForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
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
                            <h4>
                                Select Location</h4>
                        </td>
                        <td>
                            <asp:RadioButton runat="server" ID="RdoBHE" Text="BHE" OnCheckedChanged="RdoBHE_CheckedChanged"
                                AutoPostBack="True" />
                        </td>
                        <td colspan="3">
                            <asp:RadioButton runat="server" ID="RdoBMH" Text="BHW" OnCheckedChanged="RdoBMH_CheckedChanged"
                                AutoPostBack="True" />
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
                            MRIN#
                        </td>
                        <td colspan="4">
                            <asp:Label runat="server" ID="LblSalutation" Enabled="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Attending Physician
                        </td>
                        <td colspan="4">
                            <asp:Label runat="server" ID="LblAttDr" Enabled="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Admission Date
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
                                OnSelectedIndexChanged="DdlFormList_SelectedIndexChanged" EnableViewState="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="noBorder">
                        </td>
                        <td colspan="4">
                            <asp:Panel runat="server" ID="PnlConsentChkboxes">
                                <ul>
                                    <li>
                                        <asp:CheckBox runat="server" ID="ChkSurgicalConcent" Text="CONSENT TO DIAGNOSTIC PROCEDURE OR OPERATION"
                                            Enabled="false" />
                                    </li>
                                    <li>
                                        <asp:CheckBox runat="server" ID="ChkCCLC" Text="CARDIOVASCULAR LABORATORY CONSENT"
                                            Enabled="false" />
                                    </li>
                                    <li>
                                        <asp:CheckBox runat="server" ID="ChkORConsent" Text="CONSENT FOR PROCEDURES OUTSIDE OF THE OPERATING ROOM"
                                            Enabled="false" />
                                    </li>
                                    <li>
                                        <asp:CheckBox runat="server" ID="ChkEC" Text="ENDOSCOPY CONSENT" Enabled="false" />
                                    </li>
                                    <li>
                                        <asp:CheckBox runat="server" ID="ChkBCOrR" Text="CONSENT FOR TRANSFUSION OF BLOOD OR BLOOD PRODUCTS"
                                            Enabled="false" />
                                    </li>
                                    <li>
                                        <asp:CheckBox runat="server" ID="ChkPA" Text="CONSENT FOR THERAPEUTIC APHERESIS"
                                            Enabled="false" />
                                    </li>
                                    <li>
                                        <asp:CheckBox runat="server" ID="ChkPICCConsent" Text="AUTHORIZATION FOR PERIPHERALLY INSERTED CENTRAL CATHETER (PICC)"
                                            Enabled="false" />
                                    </li>
                                </ul>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="PnlPrintLinks" Visible="False">
                                <ul>
                                    <li><a href="Print/Surgical/Surgical.pdf">PDF for CONSENT TO DIAGNOSTIC PROCEDURE OR
                                        OPERATION</a></li>
                                    <li><a href="Print/Cardiovascular/Cardiovascular.pdf">PDF for CARDIOVASCULAR LABORATORY
                                        CONSENT</a></li>
                                    <li><a href="Print/OutsideOR/OutsideOR.pdf">PDF for CONSENT FOR PROCEDURES OUTSIDE OF
                                        THE OPERATING ROOM</a></li>
                                    <li><a href="Print/Endoscopy/Endoscopy.pdf">PDF for ENDOSCOPY CONSENT</a></li>
                                    <li><a href="Print/BloodConsentOrRefusal/BloodConsentOfRefusal.pdf">PDF for CONSENT
                                        FOR TRANSFUSION OF BLOOD OR BLOOD PRODUCTS</a></li>
                                    <li><a href="Print/PlasmanApheresis/PlasmanApheresis.pdf">PDF forCONSENT FOR THERAPEUTIC APHERESIS</a></li>
                                    <li><a href="Print/PICC/PICC.pdf">PDF for AUTHORIZATION FOR PERIPHERALLY INSERTED CENTRAL
                                        CATHETER (PICC)</a></li>
                                </ul>
                            </asp:Panel>
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
</asp:Content>