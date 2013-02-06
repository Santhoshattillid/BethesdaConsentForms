<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginBox.aspx.cs" Inherits="WindowsCEConsentForms.LoginBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Stylesheets/ConsentForm.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.6.1.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            var val = $('input[type="hidden"][id$="HdnField"]').val();
            if (val == "True")
                window.parent.$.fancybox.close();
        });
    </script>
</head>
<body>
    <div class="Container LoginBox">
        <form id="form1" runat="server">
        <table>
            <tbody>
                <tr>
                    <td colspan="2">
                        <h3>
                            Reset your session</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="TxtEmployeeID"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="BtnLogin" Text="Login" OnClick="BtnLogin_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" ID="LblError" CssClass="errorInfomodified"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
        <asp:HiddenField runat="server" ID="HdnField" />
        </form>
    </div>
</body>
</html>