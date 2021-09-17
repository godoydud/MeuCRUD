using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeuCRUD.Models.Entidades
{
    [Table("Usuario")]
    public class Usuario
    {

    
        public int Id { get; set; }

        [DisplayName("Nome do usuário")]
        public string NomeUsuario { get; set; }

        [DisplayName("Idade")]
        public int Idade { get; set; }


        [DisplayName("Tipo de usuário")]
        public int Tipo { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Avatar")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload imagem")]
        [Required]
        public IFormFile ImageFile { get; set; }

        public int ImagemId { get; set; }
        public UsuarioImagem Imagem { get; set; }
    }

    public class UsuarioImagem
    {
        [Key]
        public int Id { get; set; }
        
       
        public byte[] Imagem { get; set; }
    }
}
