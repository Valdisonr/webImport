<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfDuplicado.aspx.cs" Inherits="webImport.forms.wfDuplicado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/WebForms/MsgExcluirDupli.js"></script>
    <script src="../Scripts/msgAlert.js"></script>
    <script src="../Scripts/navegarLinha.js"></script>
    
     <br />
    <script language="javascript" type="text/javascript">
     function SelectAllCheckboxes(chk) {
            var totalRows = $("#<%=gv.ClientID %> tr").length;
            var selected = 0;
            $('#<%=gv.ClientID %>').find("input:checkbox").each(function () {
            if (this != chk) {
                this.checked = chk.checked;
                selected += 1;
            }
        });
    }

    function CheckedCheckboxes(chk) {
        if (chk.checked) {
            var totalRows = $('#<%=gv.ClientID %> :checkbox').length;
        var checked = $('#<%=gv.ClientID %> :checkbox:checked').length
        if (checked == (totalRows - 1)) {
            $('#<%=gv.ClientID %>').find("input:checkbox").each(function () {
                this.checked = true;
            });
        }
        else {
            $('#<%=gv.ClientID %>').find('input:checkbox:first').removeAttr('checked');
        }
    }
    else {
        $('#<%=gv.ClientID %>').find('input:checkbox:first').removeAttr('checked');
    }
}
    </script>
      <div class="panel panel-primary">

     <div class="panel-heading" style="font-size: large">Duplicados </div>
         </div>
    <hr />
   <%-- <div class="panel panel-primary">--%>


        <br />

      
        
        <div class="form-group">
   
     
            <div class ="col-md-2">
                <%--<asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-warning" OnClick="Button1_Click" />--%>
               <%--<asp:Button ID="btnExcluiDup" runat="server" OnClientClick ="this.disable=true;this.value='Enviando.Por favor aguarde...';" UseSubmitBehavior ="false"  CssClass="btn btn-danger" data-dismiss="modal" Text="Excluir" OnClick="Button1_Click"/>--%> 
                <%--<asp:Button ID="btnExcluiDup" runat="server" OnClientClick ="this.disable=true;this.value='Enviando.Por favor aguarde...';" UseSubmitBehavior ="false"  CssClass="btn btn-danger" data-dismiss="modal" Text="Excluir" OnClick="Button1_Click"/> --%>
                <asp:Button ID="btnExcluiDup" runat="server" Text="Excluir registro(s)" CssClass="btn btn-danger" OnClick="Button1_Click" OnClientClick="javascript:return confirm('Tem certeza que deseja realizar a ação?');"/>
                <%--<asp:Button ID="btnExcluir runat="server" OnClientClick ="this.disable=true;this.value='Excluíndo. Por favor aguarde...';" UseSubmitBehavior ="false"  CssClass="btn btn-success" data-dismiss="modal" Text="Enviar" OnClick="Button1_Click"/>--%> 
                </div>
            <asp:Label ID="lblMsg" runat="server" Font-Bold="true"/>
             <asp:Label ID="lblItemQty" runat="server" Font-Bold="true" CssClass="pull-right"></asp:Label> 
              </div>
        
  
   
       <br />
        	
					
		<br />
   <%-- </div>--%>
    <hr />
    
      <div class="panel panel-primary">
                <div class="panel-heading" style="font-size:large">Pessoas Duplicadas</div>
           
            
            
          
            <div style=" OVERFLOW: auto; WIDTH: 810px; HEIGHT: 208px"> 

            <asp:GridView ID="gv" runat="server" DataKeyNames="ID" CellPadding="6" AutoGenerateColumns="False" EmptyDataText="Não existe dados a serem carregados" OnRowCreated="gv_RowCreated">
           
            <RowStyle Width="175px" />
                <Columns>
                   <asp:TemplateField >
                <HeaderTemplate>                    
                       &nbsp; <asp:CheckBox ID="chkCheckAll" runat="server" onclick="javascript:SelectAllCheckboxes(this)" />
                    &nbsp;
                </HeaderTemplate>
                <ItemTemplate>
                    &nbsp;&nbsp;<asp:CheckBox ID="chkCheck" runat="server" onclick="javascript:CheckedCheckboxes(this)" />
             </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="ID" DataField="ID" />  
                     <asp:BoundField HeaderText="Identificador" DataField="Identificador" />  
                    <asp:BoundField HeaderText="Nome" DataField="Nome" />  
                    <asp:BoundField HeaderText="Cadastrado por" DataField="Cadastrado por" />   
                     <asp:BoundField HeaderText="DataCadastro" DataField="criacao_data" />   
                                       
                </Columns>
            <EmptyDataRowStyle BackColor="Silver" BorderColor="#999999" BorderStyle="Solid" 
                BorderWidth="1px" ForeColor="#003300" />
            <HeaderStyle BackColor="white" BorderColor="Silver"  BorderStyle="Solid" 
                BorderWidth="1px" VerticalAlign="Top" Width="200px"  Wrap="True" ForeColor="Black" />
              
                <SelectedRowStyle BackColor="#000099" />
              
        </asp:GridView>
            </div>
    

      </div>



</asp:Content>
