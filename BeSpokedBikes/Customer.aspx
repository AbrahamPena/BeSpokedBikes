<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="BeSpokedBikes.Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $.fn.dataTable.ext.errMode = "none";
            var _customerTable = $('#tblCustomerList').DataTable({
                serverSide: false,
                processing: false,
                paging: false,
                searching: false,
                ajax: {
                    url: 'WebServices/PopulateList.asmx/GetCustomerList',
                    type: 'POST',
                },
                columns: [
                    { data: 'fname' },
                    { data: 'lname' },
                    { data: 'address' },
                    { data: 'phone' },
                    { data: 'start' },
                    { data: '' }
                ],
                columnDefs: [
                    {
                        render: function (data, type, row) {
                            return "<button class='btn btn-primary' onclick='RedirectUpdate(" + row.id + ")'>Edit Customer</button>";
                        },
                        targets: 5
                    }
                ] 
            });
        });

        function RedirectUpdate(id) {
            return window.location = 'Update.aspx?type=customer&id=' + id;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="padding: 2em;">
            <h2>Customer List</h2>
            <hr style="width: 100%" />
        </div>
        <div class="row">
            <div class="col" style="padding: 2em;">
                <table id="tblCustomerList" class="table table-striped table-bordered" style="width: 100%">
                    <thead>
                        <tr>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Address</th>
                            <th>Phone</th>
                            <th>Start Date</th>
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
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="New Customer" OnClick="btnAdd_Click" style="margin-left: 2em;" />
            </form>
        </div>
    </div>
</asp:Content>
