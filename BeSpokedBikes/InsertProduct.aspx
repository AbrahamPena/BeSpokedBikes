<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="InsertProduct.aspx.cs" Inherits="BeSpokedBikes.InsertProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $('#txtName').focusout(function () {
                CheckDuplicate();
            });
        });

        function CheckDuplicate() {
            $.ajax({
                type: 'POST',
                url: 'WebServices/DuplicateCheck.asmx/DuplicateProduct',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ "name": $('#txtName').val() }),
                success: function (response) {
                    var result = JSON.parse(response.d);
                    if (result[0].duplicate == true) {
                        $('#btnUpdate').prop('disabled', true)
                        alert("Duplicate Products are not allowed. Please change product name");
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
                <h2>New Product</h2>
                <hr style="width: 100%;" />
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <label for="txtName">Product Name</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="ddlMFG">Manufacturer</label>
                        <asp:DropDownList ID="ddlMFG" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <label for="ddlBS">Bike Style</label>
                        <asp:DropDownList ID="ddlBS" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="txtQTY">Quantity</label>
                        <asp:TextBox ID="txtQty" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <label for="txtPurchasePrice">Purchase Price</label>
                        <asp:TextBox ID="txtPurchasePrice" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="txtSalePrice">Sale Price</label>
                        <asp:TextBox ID="txtSalePrice" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="form-group">
                        <label for="txtCommission">Commission Percentage</label>
                        <asp:TextBox ID="txtCommission" runat="server" CssClass="form-control"></asp:TextBox>
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
