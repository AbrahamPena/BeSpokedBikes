<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalespersonEdit.ascx.cs" Inherits="BeSpokedBikes.WebControls.SalespersonEdit" %>



<div class="containter-fluid">

    <form runat="server" style="padding: 5em;">

        <div class="row">
            <h2>Update Salesperson</h2>
            <hr style="width: 100%;" />
        </div>
        <div class="row">
            <div class="col">
                <div class="form-group">
                    <label for="txtFirstName">First Name</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
             <div class="col">
                <div class="form-group">
                    <label for="txtLastName">Last Name</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-8">
                <div class="form-group">
                    <label for="txtAddress">Address</label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-4">
                <div class="form-group">
                    <label for="txtPhone">Phone</label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <div class="form-group">
                    <label for="txtStart">Start Date</label>
                    <asp:TextBox ID="txtStart" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="col-4">
                <div class="form-group">
                    <label for="txtEnd">Termination Date</label>
                    <asp:TextBox ID="txtEnd" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
            <div class="col-4">
                <div class="form-group">
                    <label for="txtManager">Manager</label>
                    <asp:TextBox ID="txtManager" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
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
