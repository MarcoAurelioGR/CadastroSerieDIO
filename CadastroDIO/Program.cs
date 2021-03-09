using System;

namespace Cadastro_DIO
{
    class Program
{
        static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
        string escolha = MenuUsuario();

        while (escolha != "S")
        {
            switch (escolha)
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
                    ExcluirSerie();
                    break;
                case "5":
                    VisualizarSerie();
                    break;
                case "L":
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("ERRO: Informe umas das Opcoes Validas!");
                    Console.WriteLine();
                    break;

            }

            Console.WriteLine();
            escolha = MenuUsuario();

        }

    }

        private static void ListarSeries()
        {
            Console.WriteLine("Lista de Series: ");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie Cadastrada.");
                return;
            }

            foreach (var series in lista)
            {
                var excluido = series.RetornaExcluir();
                Console.WriteLine("#ID {0}: - {1} Excluido: {2}",  series.RetornaID(), series.RetornaTitulo(), excluido);
                 
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Serie: ");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i ));
            }

            Console.Write("Digite o Genero Entre as Opcoes Acima: ");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Serie: ");
            string entraTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Serie: ");
            int entraAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a DEscricao da Serie: ");
            string entraDescricao = Console.ReadLine();

            Series newSerie = new Series(ID: repositorio.proximoID(),
                                         genero: (Genero)entraGenero,
                                         titulo: entraTitulo,
                                         ano: entraAno,
                                         descricao: entraDescricao);

            repositorio.Insere(newSerie);

        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da Serie: ");
            int IDSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o Genero Entre as Opcoes Acima: ");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Serie: ");
            string entraTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Serie: ");
            int entraAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a DEscricao da Serie: ");
            string entraDescricao = Console.ReadLine();

            Series attSerie = new Series(ID: IDSerie,
                                         genero: (Genero)entraGenero,
                                         titulo: entraTitulo,
                                         ano: entraAno,
                                         descricao: entraDescricao);

            repositorio.Atualizar(IDSerie, attSerie);

        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da Serie: ");
            int IDSerie = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Tem Certeza? S/N ");
            char permicao = char.Parse(Console.ReadLine());
            
            if (permicao.Equals('S') || permicao.Equals('s'))
                repositorio.Exclui(IDSerie);
        }
        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da Serie: ");
            int IDSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarID(IDSerie);

            Console.WriteLine();
            Console.WriteLine(serie);
        }


        private static string MenuUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("1 - Listar Series: ");
        Console.WriteLine("2 - Inserir uma Nova Serie: ");
        Console.WriteLine("3 - Atualizar Serie: ");
        Console.WriteLine("4 - Excluir Serie: ");
        Console.WriteLine("5 - Visualizar Serie: ");
        Console.WriteLine("L - Limpar Tela: ");
        Console.WriteLine("S - Sair ");
        Console.WriteLine();
        Console.Write("Escolha e Informe a Opcao Desejada: ");
        
        string escolha = Console.ReadLine().ToUpper();
        Console.WriteLine();

        return escolha;

        }
    }
}