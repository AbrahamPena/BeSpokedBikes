<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="BeSpokedBikes.Sales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $.fn.dataTable.ext.errMode = "none";
            var _salesTable = $('#tblSalesList').DataTable({
                serverSide: false,
                processing: false,
                paging: false,
                searching: false,
                ajax: {
                    url: 'WebServices/PopulateList.asmx/GetSaleList',
                    type: 'POST',
                },
                columns: [
                    { data: 'product' },
                    { data: 'customer' },
                    { data: 'sales_date' },
                    { data: 'price' },
                    { data: 'sp_name' },
                    { data: 'commission' },
                ]
            });
        });

        function RedirectUpdate(id) {
            return window.location = 'Update.aspx?type=sales&id=' + id;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="padding: 2em;">
            <h2>Sales List</h2>
            <hr style="width: 100%" />
        </div>
        <div class="row">
            <div class="col" style="padding: 2em;">
                <table id="tblSalesList" class="table table-striped table-bordered" style="width: 100%">
                    <thead>
                        <tr>
                            <th>Product</th>
                            <th>Customer</th>
                            <th>Sales Date</th>
                            <th>Price</th>
                            <th>Salesperson</th>
                            <th>Commission</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <form runat="server">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="New Sale" OnClick="btnAdd_Click" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
