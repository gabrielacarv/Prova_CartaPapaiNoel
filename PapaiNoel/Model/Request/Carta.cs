namespace PapaiNoel.Model.Request
{
    public class Carta
    {
        public string Nome { get;  set; }
        public List<Endereco> Endereco { get;  set; }
        public int Idade { get;  set; }
        public string Conteudo { get;  set; }
    }
}
