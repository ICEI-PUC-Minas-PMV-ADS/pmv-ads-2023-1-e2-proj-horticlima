using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Horticlima.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome!")]
        public string UsuarioNome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha!")]
        [DataType(DataType.Password)]
        public string UsuarioSenha { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }

        public Perfil Perfil { get; set; }
    }

    public enum Perfil
    {
        Admin,
        Gerente,
        User
    }


}
