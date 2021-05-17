<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="BeSpokedBikes.WebControls.Login" %>

<style type="text/css">

    body {
        background: #007194;
    }

    .login-row {
        padding-top: 10em;
    }

    .login-box {
        background-color: white;
        border-radius: 25px;
        height: 35em;
        padding: 1em;
    }

</style>

<div class="container-fluid">
    <div class="row login-row">
        <div class="col-5"></div>
        <div class="col-2 login-box">
            <div class="row" style="justify-content: center;">
                <i class="fas fa-bicycle fa-7x"></i>
                <h3>BeSpoked Bikes</h3>
            </div>
            <form runat="server" style="margin-top: 2em;">
                <div class="form-group">
                    <label for="txtUserName">User Name</label>
                    <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtPassword">Password</label>
                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="btnLogin" CssClass="btn" Text="Login" style="width: 100%; background-color: #0ECCB6;" OnClick="btnLogin_Click" />
                </div>
            </form>
        </div>
        <div class="col-5"></div>
    </div>
</div>
