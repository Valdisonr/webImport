<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formAluno.aspx.cs" Inherits="webImport.forms.formAlunos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    

       <style type="text/css">
    .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: black;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
         -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }
    .loading
    {
        font-family: Arial;
        /*font-size: 8pt;*/
        border: 5px solid dodgerblue;
        width: 200px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: dodgerblue;
        z-index: 999;
    }
</style>
    <%--<script src="../Scripts/jquery-3.0.0.min.js"></script>--%>
    
<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.0.0/jquery.min.js"></script>

    <script src="../Scripts/WebForms/progressbar.js"></script>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    function ShowProgress() {
        setTimeout(function () {
            var modal = $('<div />');
            modal.addClass("modal");
            $('body').append(modal);
            var loading = $(".loading");
            loading.show();
            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
            loading.css({ top: top, left: left });
        }, 200);
    }
    $('form').live("submit", function () {
        ShowProgress();
    });
</script>
 
     <br />
      <div class="panel panel-primary">
     <div class="panel-heading" style="font-size: large">Import  Pessoas</div>
         </div>
    <hr />

    <div class="panel panel-primary">
       
     
        <br />

        

      <asp:FileUpload ID="FileUploadToServer" runat="server" CssClass="btn btn-warning"/>              
      

       <br />
              
       <p>
           
      &nbsp;  <asp:Button ID="btnload" runat="server" CssClass="btn btn-success" data-dismiss="modal" Text="Enviar" OnClick="Button1_Click"/> 
           
          

           
                 <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />--%>
                   
      <%-- &nbsp; <asp:Button ID="btnEnviar" runat="server" OnClientClick ="this.disable=true;this.value='Enviando.Por favor aguarde...';" UseSubmitBehavior ="false"  CssClass="btn btn-success" data-dismiss="modal" Text="Enviar" OnClick="Button1_Click"/> 
              
         --%>

          <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Por favor adicione o arquivo." ControlToValidate="FileUploadToServer">*</asp:RequiredFieldValidator>--%>

          
              <asp:Label ID="lblMsg" runat="server"  Font-Bold ="true"></asp:Label>

         <%--<asp:Label ID="lblModalBody" runat="server" Text="" Font-Bold ="true"></asp:Label>
           
           <%-- <div class="loading" align ="center" style="color: #FF0000; font-weight: bold;">
    Carregando. Aguarde...<br />
    <br />
    <img src="../Images/loader.gif" alt="" height="30" />
</div>--%>
          <div class="loading" align="center" style="color: #ffffff; font-weight: bold;">
    Carregando. Aguarde...<br />
    <br />
    <img src="../Images/loader.gif" alt="" height="30" />
</div>
           

            <asp:Label ID="lblItemQty" runat="server" Font-Bold="true" CssClass="pull-right"></asp:Label> 
                
  </p>
  
      
              
   
   
    
    
      
   </div>
        
      
               
                  
    <hr />
      
     
   
             
                  <div class="panel panel-primary">
                <div class="panel-heading" style="font-size:large">Pessoas </div>
           
            
            <div style=" OVERFLOW: auto; WIDTH: auto; HEIGHT: 208px">

               

            <asp:GridView ID="Gv" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                runat="server" AutoGenerateColumns="false" OnRowDataBound="Gv_RowDataBound" >
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID"  />
                    <asp:BoundField DataField="Nome" HeaderText="NOME" />
                    <asp:BoundField DataField="Empresa" HeaderText="EMPRESA" />
                    <asp:BoundField DataField="CLassificacao" HeaderText="CLASSIFICAÇÃO"  />
                    <asp:BoundField DataField="Funcao" HeaderText="FUNÇÃO"  />
                    <asp:BoundField DataField="Departamento" HeaderText="DEPARTAMENTO" />
                    <asp:BoundField DataField="Estado" HeaderText="ESTADO"/>
                    <asp:BoundField DataField="Horario" HeaderText="HORÁRIO" />
                </Columns>
            
            <EmptyDataRowStyle BackColor="Silver" BorderColor="#999999" BorderStyle="Solid" 
                BorderWidth="1px" ForeColor="#003300" />
            <HeaderStyle BackColor="white" BorderColor="Silver"  BorderStyle="Solid" 
                BorderWidth="1px" VerticalAlign="Top" Width="208px"  Wrap="True" ForeColor="Black" />
              
        </asp:GridView>
                
 
   

 <%--   <div class="loading" align ="center" style="color: #FF0000; font-weight: bold;">
    Carregando. Aguarde...<br />
    <br />
    <img src="../Images/loader.gif" alt="" height="30" />

</div>--%>
               <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
    <ProgressTemplate>--%>
     
              <%-- </div>--%>
         


               <%--<div class="modal fade" data-backdrop="static" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">

            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>

                    </div>
                     <div class="loading" align ="center" style="color: #FF0000; font-weight: bold;">
    
                          <asp:Label ID="lbResult" runat="server" Text="Pressione o botão para processar"></asp:Label>
           
    <div class="loading"  style="color: #FF0000; font-weight: bold;">
    Carregando..Aguarde...<br />
    
    <img src="../Images/loader.gif" alt="" height="30" />    

       <br />
</div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
  <%--      </asp:UpdatePanel>--%>
    </div>
</div>
      
    <%--  --%>

     


</asp:Content>
