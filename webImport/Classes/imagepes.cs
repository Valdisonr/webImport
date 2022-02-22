using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webImport.classes
{
    public class ImagePes
    {

        private string id;
        private byte[] imagem;

        public string Id { get => id; set => id = value; }
        public byte[] Imagem { get => imagem; set => imagem = value; }
    }
}