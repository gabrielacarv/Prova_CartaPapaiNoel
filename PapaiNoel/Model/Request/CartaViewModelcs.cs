using System.ComponentModel.DataAnnotations;

namespace PapaiNoel.Model.Request
{
    public class CartaViewModelcs
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres e máximo de 255 caracteres!")]
        public string Nome { get;  set; }


        [Required(ErrorMessage = "Endereço é obrigatório!")]
        public List<Endereco> Endereco { get;  set; }


        [Required(ErrorMessage = "Idade é obrigatório!")]
        [Range(0, 14, ErrorMessage = "A criança deve ser menor que 15 anos!")]
        public int Idade { get;  set; }


        [Required(ErrorMessage = "Conteúdo da carta é obrigatório!")]
        [StringLength(500, ErrorMessage = "O Conteúdo deve ter no máximo de 500 caracteres!")]
        public string Conteudo { get;  set; }
    }
}