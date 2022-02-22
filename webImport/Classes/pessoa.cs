using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webImport
{
    public class Pessoa
    {
        private string id;
        private string nome;
        private string empresa;
        private string classificacao;
        private string funcao;
        private string departamento;
        private string estado;
        private string horario;

        public string Id
        {
            get => id; set => id = value; }
            public string Nome
        {
            get => nome; set => nome = value; }
            public string Empresa
        {
            get => empresa; set => empresa = value; }
            public string Classificacao
        {
            get => classificacao; set => classificacao = value; }
            public string Funcao
        {
            get => funcao; set => funcao = value; }
            public string Departamento
        {
            get => departamento; set => departamento = value; }
            public string Estado
        {
            get => estado; set => estado = value; }
            public string Horario
        {
            get => horario; set => horario = value; }
        }

    
}