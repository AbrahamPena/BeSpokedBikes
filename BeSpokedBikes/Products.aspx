<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="BeSpokedBikes.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $.fn.dataTable.ext.errMode = "none";
            var _productTable = $('#tblProductsList').DataTable({
                serverSide: false,
                processing: false,
                paging: false,
                searching: false,
                ajax: {
                    url: 'WebServices/PopulateList.asmx/GetProductList',
                    type: 'POST',
                },
                columns: [
                    { data: "name" },
                    { data: "manufacturer" },
                    { data: "style" },
                    { data: "price" },
                    { data: "qty" },
                    { data: "" }
                ],
                columnDefs: [
                    {
                        render: function (data, type, row) {
                            return "<button class='btn btn-primary' onclick='RedirectUpdate(" + row.id + ")'>Edit Product</button>";
                        },
                        targets: 5
                    }
                ] 
            });
        });

        function RedirectUpdate(id) {
            return window.location = 'Update.aspx?type=product&id=' + id;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="padding: 2em;">
            <h2>Product List</h2>
            <hr style="width: 100%" />
        </div>
        <div class="row">
            <div class="col" style="padding: 2em;">
                <table id="tblProductsList" class="table table-striped table-bordered" style="width: 100%">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Manufacturer</th>
                            <th>Bike Style</th>
                            <th>Sales Price</th>
                            <th>Quantity</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <form runat="server">
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="New Product" OnClick="btnAdd_Click" style="margin-left: 2em;" />
            </form>
        </div>
    </div>
</asp:Content>
