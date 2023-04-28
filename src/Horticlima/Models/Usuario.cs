using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Horticlima.Models
{
    [Table("Usuarios")]
    public class Usuario
    {

        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome!")]
        public string UsuarioNome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha!")]
        [DataType(DataType.Password)]
        public string UsuarioSenha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Perfil de Sistema!")]
        public Perfil Perfil { get; set; }
    }

    public enum Perfil
    {
        Admin,
        User
    }
}
