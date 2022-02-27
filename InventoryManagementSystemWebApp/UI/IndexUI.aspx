<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="InventoryManagementSystemWebApp.UI.IndexUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
</head>
<body style="background-image: url(../images/inventory-bg.jpg); background-size: cover; opacity: 0.8" class="container">
     
    <form id="form1" runat="server">
        <%--<nav class="navbar navbar-expand-lg navbar-dark bg-success">
            <a class="navbar-brand" href="IndexUI.aspx">Inventory Management System</a>
            <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                <div class="navbar-nav ms-auto">
                    <asp:HyperLink ID="HyperLink1" CssClass="nav-item nav-link" NavigateUrl="CategoryUI.aspx" runat="server">Category</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink2" CssClass="nav-item nav-link" NavigateUrl="CompanyUI.aspx" runat="server">Company</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink3" CssClass="nav-item nav-link" NavigateUrl="ItemUI.aspx" runat="server">Item</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink4" CssClass="nav-item nav-link" NavigateUrl="StockInUI.aspx" runat="server">Stock In</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink5" CssClass="nav-item nav-link" NavigateUrl="StockOutUI.aspx" runat="server">Stock Out</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink6" CssClass="nav-item nav-link" NavigateUrl="SearchViewUI.aspx" runat="server">Search And View</asp:HyperLink>
                    <asp:HyperLink ID="HyperLink7" CssClass="nav-item nav-link" NavigateUrl="SalesViewUI.aspx" runat="server">Sales And View</asp:HyperLink>
                </div>
            </div>
        </nav>--%>
        <div style="height: 90vh" class="d-flex justify-content-center align-items-center">
            
            <div>
                <h1 class="text-center text-white">Inventory Management System</h1>
                <asp:TextBox ID="userNameTextBox" placeholder="User Name" CssClass="form-control mb-1" runat="server"></asp:TextBox>


                <asp:TextBox ID="passwordTextBox" placeholder="Password" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>



                <asp:Label ForeColor="red" ID="outputLabel" CssClass="mt-2" runat="server" Text=""></asp:Label>


                <div class="d-flex justify-content-center mt-2">
                    <asp:Button ID="logginButton" Width="560px" CssClass="btn btn-primary" runat="server" Text="Login" OnClick="logginButton_Click" />
                </div>
            </div>

        </div>

    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
