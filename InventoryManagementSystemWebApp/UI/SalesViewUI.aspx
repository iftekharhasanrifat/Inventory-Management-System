<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesViewUI.aspx.cs" Inherits="InventoryManagementSystemWebApp.UI.SalesViewUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <style type="text/css">
        .auto-style1 {
            height: 18px;
        }
    </style>
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
    <h2 class="text-center mt-4">View Sales</h2>
    <div class="d-flex justify-content-center mt-5">
        <form id="form1" style="width: 600px" runat="server">
            <div class="d-flex justify-content-center">
                <table>
                    <tr>
                        <td>From Date</td>
                        <td>
                            <asp:TextBox ID="fromDatePicker" CssClass="form-control" runat="server" Width="280px" AutoCompleteType="Disabled"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>To Date</td>
                        <td>
                            <asp:TextBox ID="toDatePicker" CssClass="form-control" runat="server" Width="280px" AutoCompleteType="Disabled"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="searchButton" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="searchButton_Click" />
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="outputLabel" CssClass="text-danger" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                </table>
            </div>
            <div id="printableArea">
                <asp:GridView ID="salesGridView" BorderStyle="None" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-responsive mt-1">
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Container.DataItemIndex+1%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Item")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Company">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Company")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sale Quantity">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("SaleQuantity")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
            <div>
                <input type="button" id="printButton" onclick="printDiv('printableArea')" value="Print" visible="False" class="btn btn-success" runat="server" />
            </div>
        </form>


        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
        <script src="../Scripts/jquery-3.6.0.min.js"></script>
        <script src="../Scripts/bootstrap-datepicker.min.js"></script>
        <script>
            $('#fromDatePicker').datepicker({
                orientation: "bottom auto",
                daysOfWeekHighlighted: "5",
                autoclose: true
            });
            $('#toDatePicker').datepicker({
                orientation: "bottom auto",
                daysOfWeekHighlighted: "5",
                autoclose: true
            });
            //$('#fromDatePicker').datepicker({
            //    daysOfWeekHighlighted: "5",
            //    autoclose: true,
            //    todayHighlight: true,
            //    format: "yyyy-mm-dd"
            //});
            //$('#toDatePicker').datepicker({
            //    daysOfWeekHighlighted: "5",
            //    autoclose: true,
            //    todayHighlight: true,

            //    format: "yyyy-mm-dd"
            //});

            function printDiv(divName) {
                var printContents = document.getElementById(divName).innerHTML;
                var originalContents = document.body.innerHTML;

                document.body.innerHTML = printContents;

                window.print();

                document.body.innerHTML = originalContents;
            }
        </script>
    </div>
</body>
</html>
