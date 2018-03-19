<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Test.aspx.vb" Inherits="IOT.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100%;height:calc(100vh - 50px);text-align:center">
            <asp:Button ID="btnSendData" runat="server" Text="SendData" BackColor="LightGreen" ForeColor="White" Font-Bold="true" style="font-size:10vmin;"/>
    </div>
</asp:Content>