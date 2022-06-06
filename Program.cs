using FinalWork.EducationalSoftware.Series;

namespace FinalWork.EducationalSoftware
{
    class Program
    {
        static DadosRepositorio repositorio = new DadosRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarDados();
                        break;
                    case "2":
                        InserirDados();
                        break;
                    case "3":
                        AtualizarDados();
                        break;
                    case "4":
                        ExcluirDados();
                        break;
                    case "5":
                        VisualizarDados();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar dados da Instituição");
            Console.WriteLine("2 - Inserir dados da Instituição");
            Console.WriteLine("3 - Atualizar Tipo de Dado");
            Console.WriteLine("4 - Excluir Dado");
            Console.WriteLine("5 - Visualizar Dado separadamente da Instituição");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }

        private static void ListarDados()
        {
            Console.WriteLine("Listar dados da Instituição");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum dado cadastrado na instituição.");
                return;
            }

            foreach (var dado in lista)
            {
                var excluido = dado.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", dado.retornaId(), dado.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirDados()
        {
            Console.WriteLine("Inserir dados  Instituição ");

            foreach (int i in Enum.GetValues(typeof(SelecioneTipoDado)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(SelecioneTipoDado), i));
            }

            Console.Write("Digite o tipo dado entre as opções acima: ");
            int entradaDado = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Telefone: ");
            int entradaTelefone = int.Parse(Console.ReadLine());

            Console.Write("Digite o E-mail: ");
            string entradaEmail = Console.ReadLine();

            Dado novoDado = new Dado(id: repositorio.ProximoId(),
                                        tipo: (SelecioneTipoDado)entradaDado,
                                        nome: entradaNome,
                                        telefone: entradaTelefone,
                                        email: entradaEmail);

            repositorio.Insere(novoDado);
        }

        private static void AtualizarDados()
        {
            Console.Write("Digite o ID do dado: ");
            int indiceDado = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(SelecioneTipoDado)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(SelecioneTipoDado), i));
            }

            Console.Write("Digite o tipo entre as opções acima: ");
            int entradaDado = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            int entradaTelefone = int.Parse(Console.ReadLine());

            Console.Write("Digite o E-mail: ");
            string entradaEmail = Console.ReadLine();

            Dado atualizaDado = new Dado(id: indiceDado,
                                        tipo: (SelecioneTipoDado)entradaDado,
                                        nome: entradaNome,
                                        telefone: entradaTelefone,
                                        email: entradaEmail);

            repositorio.Atualiza(indiceDado, atualizaDado);
        }

        private static void ExcluirDados()
        {
            Console.Write("Digite o ID do dado: ");
            int indiceDado = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceDado);
        }

        private static void VisualizarDados()
        {
            Console.Write("Digite o ID do dado: ");
            int indiceDado = int.Parse(Console.ReadLine());

            var dado = repositorio.RetornaPorId(indiceDado);
            Console.WriteLine(dado);
        }
    }
}
