using System.ComponentModel.DataAnnotations;

namespace ClienteAPI___01.Dtos
{
    public class ClienteDTO
    {

        /* [MinLength(5)]*/

        public int Id { get; set; }


        [Required]  
        public string Nome { get; set; }

        [Required]
        public string DataNasc { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public string Rg { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Email { get; set; }


    }
}
