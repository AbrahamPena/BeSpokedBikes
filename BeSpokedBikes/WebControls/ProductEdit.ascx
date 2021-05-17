<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductEdit.ascx.cs" Inherits="BeSpokedBikes.WebControls.ProductEdit" %>

<div class="container-fluid">

    <form runat="server" style="padding: 5em;">

        <div class="row">
            <h2>Update Product</h2>
            <hr style="width: 100%;" />
        </div>
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <label for="txtName">Product Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
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
            <div class="col">
                <div class="form-group">
                    <label for="txtCommission">Commission Percentage</label>
                    <asp:TextBox ID="txtCommission" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-1">
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" Style="width: 100%;" OnClick="btnUpdate_Click" />
            </div>
            <div class="col-1">
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" Style="width: 100%;" OnClick="btnCancel_Click" />
            </div>
        </div>

    </form>

</div>

