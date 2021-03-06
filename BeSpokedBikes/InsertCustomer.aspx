<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="InsertCustomer.aspx.cs" Inherits="BeSpokedBikes.InsertCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <form runat="server" style="padding: 5em;">
            
            <div class="row">
                <h2>New Customer</h2>
                <hr style="width: 100%" />
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <label for="txtFirst">First Name</label>
                        <asp:TextBox ID="txtFirst" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <label for="txtLast">Last Name</label>
                        <asp:TextBox ID="txtLast" runat="server" CssClass="form-control"></asp:TextBox>
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
                <div class="col-6">
                    <div class="form-group">
                        <label for="txtStart">Start Date</label>
                        <asp:TextBox ID="txtStart" runat="server" CssClass="form-control"></asp:TextBox>
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
