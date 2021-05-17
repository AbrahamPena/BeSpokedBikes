<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="InsertSalesperson.aspx.cs" Inherits="BeSpokedBikes.InsertSalesperson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtFirst').focusout(function () {
                if ($('#txtFirst').val() != "" && $('#txtSecond').val() != "") {
                    CheckDuplicate();
                }
            });

            $('#txtSecond').focusout(function () {
                if ($('#txtFirst').val() != "" && $('#txtSecond').val() != "") {
                    CheckDuplicate();
                }
            });
        });

        function CheckDuplicate() {
            $.ajax({
                type: 'POST',
                url: 'WebServices/DuplicateCheck.asmx/DuplicateSalesperson',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ "fname": $('#txtFirst').val(), "lname": $('#txtSecond').val() }),
                success: function (response) {
                    var result = JSON.parse(response.d);
                    if (result[0].duplicate == true) {
                        $('#btnUpdate').prop('disabled', true)
                        alert("Duplicate Salesperson is not allowed. Please change saleperson's name");
                    }
                    else {
                        $('#btnUpdate').prop('disabled', false);
                    }
                },
                error: function (response) {
                    console.log(response);
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">

        <form runat="server" style="padding: 5em;">

            <div class="row">
                <h2>New Salesperson</h2>
                <hr style="width: 100%;" />
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <label for="txtFirst">First Name</label>
                        <asp:TextBox ID="txtFirst" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="txtSecond">Last Name</label>
                        <asp:TextBox ID="txtSecond" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <label for="txtAddress">Address</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="txtPhone">Phone</label>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <label for="txtStart">Start Date</label>
                        <asp:TextBox ID="txtStart" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="txtEnd">Termination Date</label>
                        <asp:TextBox ID="txtEnd" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="form-group">
                        <label for="txtManager">Manager</label>
                        <asp:TextBox ID="txtManager" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Insert" Style="width: 100%;" OnClick="btnUpdate_Click" ClientIDMode="Static" />
                </div>
                <div class="col-1">
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" Style="width: 100%;" OnClick="btnCancel_Click" />
                </div>
            </div>

        </form>

    </div>

</asp:Content>
