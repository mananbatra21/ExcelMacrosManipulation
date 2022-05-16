<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelFunctionality.aspx.cs" Inherits="ExcelMacrosManipulation.ExcelFunctionality" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .grv
		{
			width:100%;
			height:auto;
			text-align:center;
			color:black;
		}
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
            width:30%;
            margin-left:35%;
            margin-top:3%;
            border:solid;
            border-color:black;
            background-color:aliceblue;
			text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
		<div class="Head">
            <a>Report</a>
        </div>
        
		<div class="FrmDiv">
            <table>
                <tr>
                    <td colspan="8">
                        <asp:GridView ID="dataGrv" runat="server" CssClass="grv" OnRowCommand="dataGrv_RowCommand" AutoGenerateColumns="false" >
							<Columns>
								<asp:BoundField DataField="Id" HeaderText="Employee Id"/>
								<asp:BoundField DataField="Name" HeaderText="Employee Name"/>
								<asp:BoundField DataField="City" HeaderText="City"/>
								<asp:BoundField DataField="Salary" HeaderText="Salary"/>
								<asp:TemplateField HeaderText="Edit">
								<ItemTemplate>
									<asp:Button ID="btnEdit" runat="server" CommandName="rowedit" Text="Edit" CommandArgument='<%# Eval("Id")%>' /> 
								</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Delete">
									<ItemTemplate>
										<asp:Button ID="btnDelete" runat="server" CommandName="rowdelete" Text="Delete"  CommandArgument='<%# Eval("Id")%>'/>
									</ItemTemplate>
								</asp:TemplateField>
							</Columns>
						</asp:GridView>
                    </td>
                </tr>
				<tr>
					<td colspan="4">
						<asp:Label runat="server" ID="lblEmpName" Text="Employee Name"></asp:Label>
					</td>
					<td colspan="4">
						<asp:TextBox runat="server" ID="txtEmpName"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:Label runat="server" ID="lblEmpCity" Text="City"></asp:Label>
					</td>
					<td colspan="4">
						<asp:TextBox runat="server" ID="txtEmpCity"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:Label runat="server" ID="lblEmpSal" Text="Salary"></asp:Label>
					</td>
					<td colspan="4">
						<asp:TextBox runat="server" ID="txtEmpSal"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="8">
						<asp:Label runat="server" ID="lblMessage" Font-Bold="true"></asp:Label>
					</td>
				</tr>
                <tr>
					<td colspan="2">
						<asp:Button runat="server" ID="btnSubmit" Text="Update" OnClick="btnSubmit_Click" />
					</td>
                    <td colspan="2">
                        <asp:Button runat="server" ID="btnCreateExcel" Text="Create Excel File" OnClick="btnCreateExcel_Click"/>
                    </td>
					<td colspan="2">
                        <asp:Button runat="server" ID="btnAddEmp" Text="Add Employee" OnClick="btnAddEmp_Click" />
                    </td>
					<td>
						<asp:Button runat="server" ID="btnBackTOHome" Text="Logout" OnClick="btnBackTOHome_Click"/>
					</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
