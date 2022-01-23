
using DIO.Series.Classes;
using DIO.Series.Enum;

namespace DIO.Series
{
    public static class SerieService
    {
        public static SerieRepositorio serieRepositorio = new SerieRepositorio();
        public static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			serieRepositorio.Excluir(indiceSerie);
		}

        public static void VisualizarSerie()
		{
			System.Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = serieRepositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        public static void AtualizarSerie()
		{	
			System.Console.WriteLine();
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in GeneroEnum.GetValues(typeof(GeneroEnum)))
			{
				Console.WriteLine("{0}-{1}", i, GeneroEnum.GetName(typeof(GeneroEnum), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (GeneroEnum)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
                                        excluido: false);

			serieRepositorio.Atualizar(indiceSerie, atualizaSerie);
		}
        public static void ListarSeries()
		{
			System.Console.WriteLine();
			Console.WriteLine("Listar séries");

			var lista = serieRepositorio.Listar();

			if (lista.Count() == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.RetornarExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornarId(), serie.RetornarTitulo(), (excluido ? "*Excluído*" : ""));
			}
			System.Console.WriteLine();
		}

        public static void InserirSerie()
		{
			System.Console.WriteLine();
			Console.WriteLine("Inserir nova série");

			foreach (int i in GeneroEnum.GetValues(typeof(GeneroEnum)))
			{
				Console.WriteLine("{0}-{1}", i, GeneroEnum.GetName(typeof(GeneroEnum), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: serieRepositorio.ProximoId(),
										genero: (GeneroEnum)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
                                        excluido: false);

			serieRepositorio.Inserir(novaSerie);
		}
    }
}