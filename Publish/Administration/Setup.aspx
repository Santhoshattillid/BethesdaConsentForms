<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Setup.aspx.cs" Inherits="WindowsCEConsentForms.Administration.Setup" %>

<%@ Import Namespace="WindowsCEConsentForms" %>
<%@ Import Namespace="WindowsCEConsentForms.ConsentFormSvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li>
            <h3>
                WCF Service Configuration</h3>
        </li>
        <li>
            <div class="content-heading">
                Service URL
            </div>
            <div>
                <asp:TextBox runat="server" ID="TxtServiceURL"></asp:TextBox>
            </div>
        </li>
    </ul>
    <asp:Panel runat="server" ID="PnlDBConfiguration">
        <ul class="content">
            <li class="center">
                <h3>
                    Consent Administration</h3>
            </li>
            <li>
                <h3>
                    Internal Database Information</h3>
            </li>
            <li>
                <div class="adminHeading leftBox content-heading">
                    SQL Server
                </div>
                <div class="leftBox">
                    <asp:TextBox runat="server" ID="TxtServerName"></asp:TextBox>
                </div>
                <div class="clear">
                </div>
            </li>
            <li>
                <div class="adminHeading leftBox content-heading">
                    Database name
                </div>
                <div class="leftBox">
                    <asp:TextBox runat="server" ID="TxtDatabasename"></asp:TextBox>
                </div>
                <div class="clear">
                </div>
            </li>
            <li>
                <div class="adminHeading leftBox content-heading">
                    Authentication Mode
                </div>
                <div class="leftBox">
                    <asp:RadioButton runat="server" ID="RdoSqlServerAuthentication" Text="Sql Server Authentication"
                        GroupName="authentication" OnCheckedChanged="RdoSqlServerAuthentication_CheckedChanged"
                        AutoPostBack="True" />
                    <asp:RadioButton runat="server" ID="RdoWindowsAuthentication" Text="Windows Authentication"
                        GroupName="authentication" OnCheckedChanged="RdoWindowsAuthentication_CheckedChanged"
                        AutoPostBack="True" />
                </div>
                <div class="clear">
                </div>
            </li>
            <li>
                <asp:Panel runat="server" ID="PnlCredentials1">
                    <div class="adminHeading leftBox content-heading">
                        Username
                    </div>
                    <div class="leftBox">
                        <asp:TextBox runat="server" ID="TxtUsername"></asp:TextBox>
                    </div>
                    <div class="clear">
                    </div>
                </asp:Panel>
            </li>
            <li>
                <asp:Panel runat="server" ID="PnlCredentials2">
                    <div class="adminHeading leftBox content-heading">
                        Password
                    </div>
                    <div class="leftBox">
                        <asp:TextBox runat="server" ID="TxtPassword" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="clear">
                    </div>
                </asp:Panel>
            </li>
            <!--start-->
            <li>
                <h3>
                    External Database Information</h3>
            </li>
            <li>
                <div class="adminHeading leftBox content-heading">
                    SQL Server
                </div>
                <div class="leftBox">
                    <asp:TextBox runat="server" ID="TxtServerNameExternal"></asp:TextBox>
                </div>
                <div class="clear">
                </div>
            </li>
            <li>
                <div class="adminHeading leftBox content-heading">
                    Database name
                </div>
                <div class="leftBox">
                    <asp:TextBox runat="server" ID="TxtDatabasenameExternal"></asp:TextBox>
                </div>
                <div class="clear">
                </div>
            </li>
            <li>
                <div class="adminHeading leftBox content-heading">
                    Authentication Mode
                </div>
                <div class="leftBox">
                    <asp:RadioButton runat="server" ID="RdoSqlServerAuthenticationExternal" Text="Sql Server Authentication"
                        GroupName="authenticationExternal" OnCheckedChanged="RdoWindowsAuthenticationExternal_CheckedChanged"
                        AutoPostBack="True" />
                    <asp:RadioButton runat="server" ID="RdoWindowsAuthenticationExternal" Text="Windows Authentication"
                        GroupName="authenticationExternal" OnCheckedChanged="RdoWindowsAuthenticationExternal_CheckedChanged"
                        AutoPostBack="True" />
                </div>
                <div class="clear">
                </div>
            </li>
            <li>
                <asp:Panel runat="server" ID="PnlCredentialsExternal1">
                    <div class="adminHeading leftBox content-heading">
                        Username
                    </div>
                    <div class="leftBox">
                        <asp:TextBox runat="server" ID="TxtUsernameExternal"></asp:TextBox>
                    </div>
                    <div class="clear">
                    </div>
                </asp:Panel>
            </li>
            <li>
                <asp:Panel runat="server" ID="PnlCredentialsExternal2">
                    <div class="adminHeading leftBox content-heading">
                        Password
                    </div>
                    <div class="leftBox">
                        <asp:TextBox runat="server" ID="TxtPasswordExternal" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="clear">
                    </div>
                </asp:Panel>
            </li>
            <!--end-->
        </ul>
    </asp:Panel>
    <asp:Panel runat="server" ID="PnlFolderConfiguration">
        <ul class="content">
            <li>
                <h3>
                    Exports Path</h3>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.Surgical) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtSurgicalExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.Cardiovascular) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtCardiovascularExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.OutsideOR) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtOutsideORExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.Endoscopy) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtEndoscopyExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.BloodConsentOrRefusal) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtBloodConsentOrRefusalExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.PlasmanApheresis) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtPlasmanApheresisExportPath"></asp:TextBox>
                </div>
            </li>
            <li>
                <div class="content-heading">
                    <%= Utilities.GetConsentHeader(ConsentType.PICC) %>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="TxtPICCExportPath"></asp:TextBox>
                </div>
            </li>
        </ul>
        <ul class="content">
            <li>
                <h3>
                    Credentials for export path</h3>
            </li>
            <li>
                <div class="adminHeading leftBox content-heading">
                    Domain
                </div>
                <div class="leftBox">
                    <asp:TextBox runat="server" ID="TxtDomain"></asp:TextBox>
                </div>
                <div class="clear">
                </div>
            </li>
            <li>
                <div class="adminHeading leftBox content-heading">
                    Username
                </div>
                <div class="leftBox">
                    <asp:TextBox runat="server" ID="TxtUsernameExports"></asp:TextBox>
                </div>
                <div class="clear">
                </div>
            </li>
            <li>
                <div class="adminHeading leftBox content-heading">
                    Password
                </div>
                <div class="leftBox">
                    <asp:TextBox runat="server" ID="TxtPasswordExports" TextMode="Password"></asp:TextBox>
                </div>
                <div class="clear">
                </div>
            </li>
        </ul>
    </asp:Panel>
    <ul class="content">
        <li>
            <asp:Label runat="server" ID="LblError" CssClass="errorInfomodified adminErroInfo"></asp:Label>
        </li>
        <li class="center">
            <asp:Button runat="server" ID="BtnCompleted" CssClass="btn" Text="Complete" OnClientClick="return validate()"
                OnClick="BtnCompleted_Click" />
            <asp:Button runat="server" ID="BtnReset" Text="Reset" CssClass="btn1" OnClick="BtnReset_Click" />
        </li>
    </ul>
    <script type="text/javascript">

        function validate() {
            var dataSourceElement = $("#" + "<%=TxtServerName.ClientID%>");
            var databaseNameElement = $("#" + "<%= TxtDatabasename.ClientID%>");
            var usernameElement = $("#" + "<%= TxtUsername.ClientID%>");
            var passwordElement = $("#" + "<%= TxtPassword.ClientID%>");
            var serviceUrlElement = $("#" + "<%= TxtServiceURL.ClientID%>");
            var errorInfoElement = $("#" + "<%= LblError.ClientID%>");
            if (dataSourceElement.size()> 0 && $.trim(dataSourceElement.val()) == "") {
                errorInfoElement.html("Datasource Field can not be blank");
                dataSourceElement.focus();
                return false;
            }
            if (databaseNameElement.size()> 0 && $.trim(databaseNameElement.val()) == "") {
                errorInfoElement.html("Database Field can not be blank");
                databaseNameElement.focus();
                return false;
            }
            if (usernameElement.size()> 0 && $.trim(usernameElement.val()) == "") {
                errorInfoElement.html("User Name can not be blank");
                usernameElement.focus();
                return false;
            }
            if (passwordElement.size()> 0 && $.trim(passwordElement.val()) == "") {
                errorInfoElement.html("Password can not be blank");
                passwordElement.focus();
                return false;
            }
            if (serviceUrlElement.size()> 0 && $.trim(serviceUrlElement.val()) == "") {
                serviceUrlElement.html("WCF Service URL can not be blank");
                serviceUrlElement.focus();
                return false;
            }
            return true;
        }
    </script>
</asp:Content>