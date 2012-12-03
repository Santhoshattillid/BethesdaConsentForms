<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Setup.aspx.cs" Inherits="WindowsCEConsentForms.Administration.Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="content">
        <li class="center">
            <h3>
                Consent Administration</h3>
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
                Username
            </div>
            <div class="leftBox">
                <asp:TextBox runat="server" ID="TxtUsername"></asp:TextBox>
            </div>
            <div class="clear">
            </div>
        </li>
        <li>
            <div class="adminHeading leftBox content-heading">
                Password
            </div>
            <div class="leftBox">
                <asp:TextBox runat="server" ID="TxtPassword" TextMode="Password"></asp:TextBox>
            </div>
            <div class="clear">
            </div>
        </li>
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
            var errorInfoElement = $("#" + "<%= LblError.ClientID%>");
            if ($.trim(dataSourceElement.val()) == "") {
                errorInfoElement.html("Datasource Field can not be blank");
                dataSourceElement.focus();
                return false;
            }
            if ($.trim(databaseNameElement.val()) == "") {
                errorInfoElement.html("Database Field can not be blank");
                databaseNameElement.focus();
                return false;
            }
            if ($.trim(usernameElement.val()) == "") {
                errorInfoElement.html("User Name can not be blank");
                usernameElement.focus();
                return false;
            }
            if ($.trim(passwordElement.val()) == "") {
                errorInfoElement.html("Password can not be blank");
                passwordElement.focus();
                return false;
            }
            return true;
        }
    </script>
</asp:Content>