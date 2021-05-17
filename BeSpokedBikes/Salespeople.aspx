<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Salespeople.aspx.cs" Inherits="BeSpokedBikes.Salespeople" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $.fn.dataTable.ext.errMode = "none";
            var _salespersontable = $('#tblSalespersonList').DataTable({
                serverSide: false,
                processing: false,
                paging: false,
                searching: false,
                ajax: {
                    url: 'WebServices/PopulateList.asmx/GetSalespersonList',
                    type: 'POST',
                },
                columns: [
                    { data: "name", width: "15%" },
                    { data: "address", width: "30%" },
                    { data: "phone", width: "10%" },
                    { data: "start_date", width: "10%" },
                    { data: "termination_date", width: "10%" },
                    { data: "manager", width: "10%" },
                    { data: "", width: "15%" }
                ],
                columnDefs: [
                    {
                        render: function (data, type, row) {
                            return "<button class='btn btn-primary' onclick='RedirectUpdate(" + row.id + ")'>Edit Salesperson</button>";
                        },
                        targets: 6
                    }
                ] 
            });
        });

        function RedirectUpdate(id) {
            return window.location = 'Update.aspx?type=salesperson&id=' + id;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row" style="padding: 2em;">
            <h2>Salesperson List</h2>
            <hr style="width: 100%" />
        </div>
        <div class="row">
            <div class="col" style="padding: 2em;">
                <table id="tblSalespersonList" class="table table-striped table-bordered" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Address</th>
                            <th>Phone</th>
                            <th>Start Date</th>
                            <th>Termination Date</th>
                            <th>Manager</th>
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
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="New Salesperson" OnClick="btnAdd_Click" style="margin-left: 2em;" />
            </form>
        </div>
    </div>
</asp:Content>
