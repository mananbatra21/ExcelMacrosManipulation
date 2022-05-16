<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRegister.aspx.cs" Inherits="ExcelMacrosManipulation.FrmRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Head
        {
            width:100%;
			height:10%;
			text-align:center;
			color:white;
			font-size:60px;
            font-weight:bold;
			background-color:black;
        }
        .FrmDiv
        {
            width:50%;
            margin-left:25%;
            margin-top:3%;
            border:solid;
            border-color:black;
            background-color:aliceblue;
            text-align:center;
            padding:1%;
        }
        .FrmTbl
        {
            width:96%;
            height:100%;
        }
        .EleStyle
        {
            width:auto;
            height:80%;
            color:black;
            border:solid;
            border-block-color:dimgrey;
        }
        .lblNamePass
        {
            width:100%;
            height:80%;
            color:black;
            font-weight:bolder;
            font-size:larger;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Head">
            <a>Register Now</a>
        </div>
        <div class="FrmDiv">
            <table class="FrmTbl">
                <tr >
                    <td>
                        <asp:Label runat="server" ID="lblUsername" CssClass="lblNamePass" Text="Username"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUsername" CssClass="EleStyle"></asp:TextBox>
                    </td>
                </tr>
                 <tr >
                    <td>
                        <asp:Label runat="server" ID="lblPassword" CssClass="lblNamePass" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword" CssClass="EleStyle"></asp:TextBox>
                    </td>
                </tr>
                 <tr >
                    <td>
                        <asp:Label runat="server" ID="lblConfirmPass" CssClass="lblNamePass" Text="Confirm Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtConfirmPass" CssClass="EleStyle"></asp:TextBox>
                    </td>
                </tr>
                <tr >
                    <td>
                        <asp:Button runat="server" ID="btnSubmit" CssClass="EleStyle" Text="Register" OnClick="btnSubmit_Click"/>
                    </td >
                    <td>
                        <asp:Button runat="server" ID="btnCancel" CssClass="EleStyle" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
