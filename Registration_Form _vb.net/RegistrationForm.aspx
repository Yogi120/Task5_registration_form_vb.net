<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistrationForm.aspx.vb" Inherits="Registration_Form__vb.net.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align:center; margin-bottom:80px">
           
            Registration Form
        </h1>
        <div style="margin-bottom:20px">
            Name: 
            <asp:TextBox ID="txtFName" runat ="server" placeholder="First Name"></asp:TextBox>
            <asp:TextBox  ID ="txtMName" runat ="server" placeholder="Middle Name"></asp:TextBox>
            <asp:TextBox  ID ="txtLName" runat ="server" placeholder="Last Name"></asp:TextBox>
        </div>
        <div style="margin-bottom:20px">
            Date of Birth: <asp:TextBox ID="txtdob" runat="server" type="date"></asp:TextBox>
        </div>
        <div style="margin-bottom:20px">
            Gender:
            <asp:RadioButton ID="rdMgen" name="rdGender" GroupName="gender" value="Male" runat="server" Checked="true" onchange="fnDisablebutton()" />Male
            <asp:RadioButton ID="rdFgen" name="rdGender" GroupName="gender" value="Female" runat="server" onchange="fnDisablebutton()" />Female
            <asp:RadioButton ID="rdOgen" name="rdGender" GroupName="gender" value="Other" runat="server" onchange="fnDisablebutton()"  />Other
        </div>
        <div style="margin-bottom: 20px">
            Phone Number:
            <asp:TextBox ID="txtPhone" runat="server" ></asp:TextBox>
        </div>
        <div style="margin-bottom:20px">
            Email_Id:
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </div>
        <div> Select Course:
            <asp:DropDownList ID="listCourse" runat="server"  >
                <asp:ListItem Value="" id="cousrseSelect">select course</asp:ListItem>
                <asp:ListItem Value="Mechanical">Mechanical</asp:ListItem>
                <asp:ListItem Value="Computer">Computer</asp:ListItem>
                <asp:ListItem Value="Electrial">Electrial Engineering</asp:ListItem>

            </asp:DropDownList>
        </div>
        <div style="margin-top:50px">
        <asp:Button ID="btnReset" runat="server" Text="Reset" />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
        <script type="text/javascript">
            function fnDisablebutton() {
                if (document.getElementById("rdOgen").checked == true) {
                    document.getElementById("btnSave").disabled = true;
                }
                else if (document.getElementById("rdOgen").checked == false) {
                    document.getElementById("btnSave").disabled = false;
                }
            }

        </script>
    </form>
</body>
</html>