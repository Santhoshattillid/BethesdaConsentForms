<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintHeader.ascx.cs" Inherits="WindowsCEConsentForms.PrintHeader" %>

    <li>
            <img src="Images/logo.png" alt="logo" />
        </li>
        <li>
            <h3>
                BOYNTON BEACH, FLORIDA <br />
                (561) 737-7733 <br />
                CONSENT FOR DIAGNOSTIC PROCEDURE OR OPERATION           
            </h3>
        </li>
        <li>
            <label>MR #</label>
                <asp:Label ID="LblPatientMRID" runat="server" CssClass="errorInfo"></asp:Label>
        </li>
        <li><label>
                Patient :</label>
                <asp:Label runat="server" ID="LblPatientName" CssClass="errorInfo"></asp:Label>
        </li>
        <li>
            <label>Date :</label>
            <asp:Label runat="server" ID="LblDate" CssClass="errorInfo"></asp:Label>
        </li>
        <li>
            <label>Time :</label>
            <asp:Label runat="server" ID="LblTime" CssClass="errorInfo"></asp:Label>
        </li>
        
        