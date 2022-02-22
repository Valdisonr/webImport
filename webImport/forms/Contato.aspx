<%@ Page Title="Contato" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="webImport.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3> Informações de contato.</h3>
    <address>
        Desenvolvedor: TI-Desenvolvimento <br />
       <%-- Redmond, WA 98052-6399<br />--%>
        <%--<abbr title="Email-su">P:</abbr>
        425.555.0100--%>
    </address>

    <address>
        <strong>Suporte:</strong>   <a href="suporte@suporte">valdison@outlook.com</a><br />
       
    </address>
</asp:Content>
