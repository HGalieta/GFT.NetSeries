using DIO_TvShows.Classes;
using System;

namespace DIO_TvShows
{
    internal class Program
    {
        static TvShowRepository repository = new TvShowRepository();
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("Bem vindo ao DIO Séries!");

            string userOption = GetUserOption();

            while(userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        DeletarSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("");
            Console.WriteLine("Obrigado por utilizar o DIO Séries! Tecle [Enter] para sair");
            Console.ReadLine();
        }
        private static void ListarSeries()
        {
            var lista = repository.ListTvShows();

            if (lista.Count == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Nenhuma serie cadastrada");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Lista de séries cadastradas:");
                Console.WriteLine("");

                foreach (var serie in lista)
                {
                    var excluido = serie.IsDeleted();

                    Console.WriteLine("#ID {0}: - {1} ({2})", serie.ReturnId(), serie.ReturnTitle(), (excluido ? "SÉRIE EXCLUIDA" : ""));
                }
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("");
            Console.WriteLine("Para inserir uma série escolha inicialmente um gênero da lista abaixo");
            Console.WriteLine("");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.WriteLine("");
            Console.Write("Digite o número referente ao gênero da série a ser adicionada: ");
            var entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.Write("Digite o título da série: ");
            var entradaTitulo = Console.ReadLine();

            Console.WriteLine("");
            Console.Write("Digite o ano de lançamento da série: ");
            var entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.Write("Digite uma descriçao da série: ");
            var entradaDescricao = Console.ReadLine();

            TvShow novaSerie = new TvShow(repository.NextId(), (Genre)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
            repository.AddShow(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("");
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.WriteLine("");
            Console.Write("Digite o número referente ao gênero correto da série: ");
            var entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.Write("Digite o título correto da série: ");
            var entradaTitulo = Console.ReadLine();

            Console.WriteLine("");
            Console.Write("Digite o ano correto de lançamento da série: ");
            var entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.Write("Digite uma descriçao atualizada da série: ");
            var entradaDescricao = Console.ReadLine();

            TvShow serieAtualizada = new TvShow(indiceSerie, (Genre)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
            repository.RefreshShow(indiceSerie, serieAtualizada);
        }

        private static void DeletarSerie()
        {
            Console.WriteLine("");
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repository.DeleteShow(indiceSerie);
        } 

        private static void VisualizarSerie()
        {
            Console.WriteLine("");
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repository.ReturnShowById(indiceSerie);
            Console.WriteLine("");
            Console.WriteLine(serie);
        }

        private static string GetUserOption()
        {
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
