<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInUI.aspx.cs" Inherits="InventoryManagementSystemWebApp.UI.StockInUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
</head>
<body class="bg-light">
   <nav class="navbar navbar-expand-lg navbar-dark bg-success p-2">
        <a class="navbar-brand">Inventory Management System</a>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div class="navbar-nav ms-auto">
                <asp:HyperLink ID="HyperLink1" CssClass="nav-item nav-link" NavigateUrl="CategoryUI.aspx" runat="server">Category</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" CssClass="nav-item nav-link" NavigateUrl="CompanyUI.aspx" runat="server">Company</asp:HyperLink>
                <asp:HyperLink ID="HyperLink3" CssClass="nav-item nav-link" NavigateUrl="ItemUI.aspx" runat="server">Item</asp:HyperLink>
                <asp:HyperLink ID="HyperLink4" CssClass="nav-item nav-link" NavigateUrl="StockInUI.aspx" runat="server">Stock In</asp:HyperLink>
                <asp:HyperLink ID="HyperLink5" CssClass="nav-item nav-link" NavigateUrl="StockOutUI.aspx" runat="server">Stock Out</asp:HyperLink>
                <asp:HyperLink ID="HyperLink6" CssClass="nav-item nav-link" NavigateUrl="SearchViewUI.aspx" runat="server">Search And View</asp:HyperLink>
                <asp:HyperLink ID="HyperLink7" CssClass="nav-item nav-link" NavigateUrl="SalesViewUI.aspx" runat="server">Sales And View</asp:HyperLink>
                <a href="IndexUI.aspx"><span class="btn btn-danger">Logout</span></a>
            </div>
        </div>
    </nav>
    <h2 class="text-center mt-4">Stock In Item</h2>
    <div class="d-flex justify-content-center mt-5">
        <form id="form1" style="width: 600px" runat="server">
            <div>
                <div class="d-flex align-items-center mt-1">
                    <label>Company</label>
                    <asp:DropDownList ID="companyDropdown" CssClass="ms-2 form-control" runat="server" OnSelectedIndexChanged="companyDropdown_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="d-flex align-items-center mt-1">
                    <label>Item</label>
                    <asp:DropDownList ID="ItemDropdown" CssClass="ms-2 form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ItemDropdown_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="d-flex align-items-center mt-1">
                    <label>Reorder Level</label>
                    <asp:TextBox ID="reorderLevelTextBox" Enabled="False" CssClass="ms-2 form-control" runat="server"></asp:TextBox>
                </div>
                <div class="d-flex align-items-center mt-1">
                    <label>Available Quantity</label>
                    <asp:TextBox ID="quantityTextBox" CssClass="ms-2 form-control" runat="server" Enabled="False"></asp:TextBox>
                </div>
                <div class="d-flex align-items-center mt-1">
                    <label>Stock in Quantity</label>
                    <asp:TextBox ID="stockInTextBox" CssClass="ms-2 form-control" runat="server"></asp:TextBox>
                </div>
                <div class="d-flex align-items-center justify-content-center mt-1">
                    <asp:Button ID="saveButton" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="saveButton_Click" />
                </div>
                <div class="d-flex align-items-center justify-content-center mt-1">
                    <asp:Label ForeColor="red" ID="outputLabel" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </form>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>

    </div>
</body>
</html>
