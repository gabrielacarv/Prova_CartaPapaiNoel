using System.ComponentModel.DataAnnotations;

namespace PapaiNoel.Model.Request
{
    public class Endereco
    {
        [Required(ErrorMessage = "Rua é obrigatório!")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Número é obrigatório!")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório!")]
        public string Estado { get; set; }
    }
}
