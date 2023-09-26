using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PapaiNoel.Model.Request;

namespace PapaiNoel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartaController : PrincipalController
    {
        #region Construtor
        public CartaController()
        {
            _cartaCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "jogosMega.json");
        }

        private readonly string _cartaCaminhoArquivo;
        #endregion

        #region Métodos arquivo
        private List<Carta> LerCartaDoArquivo()
        {
            if (!System.IO.File.Exists(_cartaCaminhoArquivo))
            {
                return new List<Carta>();
            }

            string json = System.IO.File.ReadAllText(_cartaCaminhoArquivo);
            if (string.IsNullOrEmpty(json))
            {
                return new List<Carta>();
            }
            return JsonConvert.DeserializeObject<List<Carta>>(json);
        }

        private void EscreverCartaNoArquivo(List<Carta> cartas)
        {
            string json = JsonConvert.SerializeObject(cartas);
            System.IO.File.WriteAllText(_cartaCaminhoArquivo, json);
        }
        #endregion

        #region Métodos Http

        [HttpGet]
        public IActionResult Get()
        {
            List<Carta> jogos = LerCartaDoArquivo();
            return Ok(jogos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CartaViewModelcs carta)
        {
            if (!ModelState.IsValid)
            {
                return ApiBadRequestResponse(ModelState, "Dados Inválidos");
            }

            List<Carta> cartas = LerCartaDoArquivo();

            Carta novaCarta = new Carta()
            {
                Nome = carta.Nome,
                Endereco = carta.Endereco,
                Idade = carta.Idade,
                Conteudo = carta.Conteudo
            };

            cartas.Add(novaCarta);
            EscreverCartaNoArquivo(cartas);

            return ApiResponse(novaCarta, "Jogo registrado com sucesso!");

            #endregion
        }
    }
}