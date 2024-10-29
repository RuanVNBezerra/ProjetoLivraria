using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ProjetoLivraria.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivrosController : ControllerBase
{
    // fazendo uma função privada para retornar a lista de livros do JSON
    private static List<Livro> livros = new List<Livro>()
    {
        new Livro{ id = 1, titulo = "O Senhor dos Aneis", autor = "J.R.R. Tolkien", editora = "WMF Martins Fontes", ano = 2010,
         preco = 50.00, quantidade = 10},
        new Livro{ id = 2, titulo = "Harry Potter e a pedra filosofal", autor = "J.K. Rowling", editora = "Rocco", ano = 2000, quantidade = 5,
         preco = 40.00},
    };
    //criando um crud para a classe Livro
    [HttpGet]
    [Route("livros")]
    //criando um metodo para retornar a lista de livros
    // usando IEnumerable para retornar uma lista de livros e ActionResult para retornar um status code.
    public ActionResult<IEnumerable<Livro>> PegarLivros()
    {
        return Ok(livros);
    }
    /*
     1.	Anotação [HttpGet("{id}")]:
	Esta anotação indica que o método responde a requisições HTTP GET no formato api/livros/{id}, 
    onde {id} é um parâmetro que será passado na URL. 
    Por exemplo, uma requisição para api/livros/1 chamará este método com id igual a 1.
     */
    [HttpGet("{id}")]
    /*
    O método é definido como public, o que significa que pode ser acessado de fora da classe.
	Retorna um ActionResult<Livro>, que é um tipo de retorno que pode representar diferentes tipos de respostas HTTP, incluindo sucesso (Ok) e erro (NotFound).
	O parâmetro int id é o ID do livro que se deseja obter.
     */
    public ActionResult<Livro> PegarLivro(int id)
    {   /*
        var livro = livros.FirstOrDefault(x => x.id == id);
	    Esta linha usa LINQ para procurar o primeiro livro na lista livros que tenha o id igual ao valor passado como parâmetro.
        Se nenhum livro for encontrado, FirstOrDefault retorna null.
         */
        var livro = livros.FirstOrDefault(procurarLivro => procurarLivro.id == id);
        if (livro == null)
        {
            return NotFound();
        }
        return Ok(livro);
    }

    // criando um metodo para criar um livro
    /*
     	[HttpPost]: Indica que este método responde a requisições HTTP POST. Isso é usado para criar novos recursos no servidor.
     */
    [HttpPost]

    /*
     	public ActionResult<Livro> CriarLivro(Livro livro): Define um método público que retorna um ActionResult<Livro>. 
        O parâmetro livro é um objeto do tipo Livro que será enviado no corpo da requisição. 
     */
    public ActionResult <Livro> CriarLivro(Livro livro)
    {
        /*
         1.	livro.id = livros.Max(numeroId => numeroId.id);
	Objetivo: Atribuir um ID único ao novo livro.
	Detalhes:
	livro.id = livros.Max(numeroId => numeroId.id) + 1; para garantir que o novo livro tenha um ID único.
         */
        livro.id = livros.Max(numeroId => numeroId.id) + 1;
        /*
         	Objetivo: Adicionar o novo livro à lista de livros.
	        Detalhes: A lista livros é uma coleção estática que armazena todos os livros. Esta linha adiciona o novo livro a essa lista.
         */
        livros.Add(livro);
        /*
         	Objetivo: Retornar uma resposta HTTP 201 Created.
	Detalhes:
	CreatedAtAction(nameof(PegarLivro), new { id = livro.id }, livro): Cria uma resposta que inclui um cabeçalho Location apontando para o recurso recém-criado. O método PegarLivro será usado para gerar a URL do novo recurso.
	new { id = livro.id }: Passa o ID do novo livro como parâmetro para a URL.
	livro: O corpo da resposta incluirá o objeto livro recém-criado.
         */
        return CreatedAtAction(nameof(PegarLivro), new { id = livro.id }, livro);
    }

    // atualizar livro
    /*
     1.	Anotação [HttpPut("{id}")]:
	Indica que este método responde a requisições HTTP PUT no formato api/livros/{id}, onde {id} é um parâmetro que será passado na URL. 
    Por exemplo, uma requisição para api/livros/1 chamará este método com id igual a 1.
     */
    [HttpPut("{id}")]
    /*
     	public ActionResult AtualizarLivro(int id, Livro livro): Define um método público que retorna um ActionResult.
        O parâmetro id é o ID do livro que se deseja atualizar, 
        e livro é um objeto do tipo Livro que contém os novos dados para o livro.
     */
    /*
     	var livroExistente = livros.FirstOrDefault(x => x.id == id);: Usa LINQ para procurar o primeiro livro na lista livros que tenha o id igual ao valor passado como parâmetro. 
        Se nenhum livro for encontrado, FirstOrDefault retorna null.
     */
    public ActionResult AtualizarLivro(int id, Livro livro)
    {
        var livroExistente = livros.FirstOrDefault(atualizar => atualizar.id == id);
        if (livroExistente == null)
        {
            return NotFound();
        }
        /*
         Essas linhas de código estão copiando os valores dos campos do objeto livro (que foi passado como parâmetro para o método) para o objeto livroExistente (que foi encontrado na lista de livros com base no ID). 
         Basicamente, isso atualiza o livro existente com os novos valores fornecidos.
         */
        livroExistente.titulo = livro.titulo;
        livroExistente.autor = livro.autor;
        livroExistente.editora = livro.editora;
        livroExistente.ano = livro.ano;
        livroExistente.preco = livro.preco;
        livroExistente.quantidade = livro.quantidade;
        return NoContent();
    }

    // deletar livro
    //deletar o livro especificado pelo id
    [HttpDelete("{id}")]
    public ActionResult DeletarLivro(int id)
    {   //procurar o livro pelo id usando lambda expression e remover o livro da lista
        var livro = livros.FirstOrDefault(remover => remover.id == id);
        if (livro == null)
        { // se o livro for nulo, retorna um status code 404
            return NotFound();
        }
        //caso ache o livro, remove o livro da lista
        livros.Remove(livro);
        return NoContent();
    }
}

