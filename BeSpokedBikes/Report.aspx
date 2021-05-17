<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="BeSpokedBikes.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $.fn.dataTable.ext.errMode = "none";
            var _reportTable = $('#tblCommissionReport').DataTable({
                serverSide: false,
                processing: false,
                paging: false,
                searching: false,
                ajax: {
                    url: 'WebServices/Report.asmx/GetReport',
                    type: 'POST',
                },
                columns: [
                    { data: 'name' },
                    { data: 'sales' },
                    { data: 'comm' }
                ]
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row" style="padding: 2em;">
            <h2>Quarterly Commission Report</h2>
            <hr style="width: 100%" />
        </div>
        <div class="row" style="padding: 2em;">
            <div class="col">
                <table id="tblCommissionReport" class="table table-striped table-bordered" style="width: 100%">
                    <thead>
                        <tr>
                            <th>Salesperson</th>
                            <th># of Sales</th>
                            <th>Commission Total</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
        

</asp:Content>
