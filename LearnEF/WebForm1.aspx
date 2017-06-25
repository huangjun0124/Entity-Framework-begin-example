<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LearnEF.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>ENTITY FRAMEWORK EXAMPLE</h1>
        </div>
        Search
        <p>
            First Name:&nbsp; <asp:TextBox ID="txtFirstNameSearch" runat="server"></asp:TextBox>
            <br />
            City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCitySearch" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </p>
        <div/>

        </div>
        Select Employee:&nbsp;&nbsp;<asp:DropDownList ID="ddlEmployee" runat="server" Height="18px" Width="135px" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
        </asp:DropDownList>
        <hr/>
        HR EMP ID:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtHREmpID" runat="server"></asp:TextBox>
        <br/>
        First Name:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br/>
        Last Name:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br/>
        Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br/>
        City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        <br/><asp:Button ID="btUpdate" runat="server" Text="UPDATE" OnClick="btUpdate_Click" />&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click" />
        <br/>
        <hr/>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <hr />
        Search Results:<br />

        <asp:GridView ID="GridSearch" runat="server">
        </asp:GridView>

    </form>
</body>
</html>
