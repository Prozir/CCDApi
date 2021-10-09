<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CCD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>CCD API</h1>
        
    </div>

    <div class="row">
        <div class="col-md-4">
           
       
        <div class="col-md-4">
            <asp:Button ID="Button1" runat="server" Text="Get Token" OnClick="GetToken_Click" />
        </div>
            <div class="col-md-4">
            <asp:Button ID="Button2" runat="server" Text="Get Items" OnClick="GetItems_Click" />
        </div>
    </div>

    </div>
    <br /><br /><br />
    <div class="row">
         <div class="col-md-4">
            <asp:Label ID="Label1" runat="server" Text="Token Label"></asp:Label>
        </div>
    </div><br /><br />
    <div class="row">
         <div class="col-md-4">
            <asp:Label ID="Label2" runat="server" Text="Items Label"></asp:Label>
        </div>
    </div>
</asp:Content>
