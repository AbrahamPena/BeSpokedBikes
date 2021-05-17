<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="NewSale.aspx.cs" Inherits="BeSpokedBikes.NewSale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <span id="spnError" runat="server" visible="false" style="color: red">No available product to sell.</span>
        <form runat="server" style="padding: 5em;">

            <div class="row">
                <h2>New Sale</h2>
                <hr style="width: 100%" />
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <label for="ddlProduct">Product</label>
                        <asp:DropDownList ID="ddlProduct" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="ddlSalesperson">Salesperson</label>
                        <asp:DropDownList ID="ddlSalesperson" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <label for="ddlCustomer">Customer</label>
                        <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="txtSales">Sale Date</label>
                        <asp:TextBox ID="txtSales" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-1">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Insert" Style="width: 100%;" OnClick="btnUpdate_Click" />
                </div>
                <div class="col-1">
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" Style="width: 100%;" OnClick="btnCancel_Click" />
                </div>
            </div>

        </form>

    </div>

</asp:Content>
