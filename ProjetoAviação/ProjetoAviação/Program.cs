using System;
using System.Collections;
using System.Collections.Generic;

namespace Projeto_Aviação
{
    public class Rota
    {
        public int Id { get; set; }
        public string Destino { get; set; }
        public DateTime DataHora { get; set; }
    }

    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public long Telefone { get; set; }
        public string Numvoo { get; set; }
        public string Destino { get; set; }
        public DateTime DataHora { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rota primeiro = new Rota()
            {
                Id = 001,
                Destino = "Bahia",
                DataHora = Convert.ToDateTime("12:20")
            };
            Rota segundo = new Rota()
            {
                Id = 002,
                Destino = "Amazonas",
                DataHora = Convert.ToDateTime("17:00")
            };
            Rota terceiro = new Rota()
            {
                Id = 003,
                Destino = "Amapa",
                DataHora = Convert.ToDateTime("15:30")
            };

            List<Rota> voos = new List<Rota>();
            voos.Add(primeiro);
            voos.Add(segundo);
            voos.Add(terceiro);

            int posicao;
            Queue espera = new Queue();
            List<Cliente> listaCliente = new List<Cliente>();

            Cliente passageiro = new Cliente();

            Cliente porta1 = new Cliente()
            {
                Nome = "Vitor",
                CPF = "15926387458",
                Telefone = 319,
                Numvoo = " ",
                DataHora = Convert.ToDateTime("17:00")
            };
            Cliente porta2 = new Cliente()
            {
                Nome = "Juan",
                CPF = "98475612308",
                Telefone = 67997584623,
                Numvoo = " ",
                DataHora = Convert.ToDateTime("17:00")
            };
            Cliente porta3 = new Cliente()
            {
                Nome = "Carla",
                CPF = "11122233345",
                Telefone = 319874393871,
                Numvoo = " ",
                DataHora = Convert.ToDateTime("17:00")
            };
            Cliente porta4 = new Cliente()
            {
                Nome = "Carlos",
                CPF = "11150781602",
                Telefone = 31995160081,
                Numvoo = " ",
                DataHora = Convert.ToDateTime("17:00")
            };


            listaCliente.Add(porta1);
            listaCliente.Add(porta2);
            listaCliente.Add(porta3);
            listaCliente.Add(porta4);
            espera.Enqueue(porta1);
            espera.Enqueue(porta2);
            espera.Enqueue(porta3);
            espera.Enqueue(porta4);
            bool sair = false;
            do
            {
                string Destino = "";
                DateTime aux;
                for (int i = 0; i < voos.Count; i++)
                {
                    Destino = primeiro.Destino;
                    aux = primeiro.DataHora;
                    if (aux > segundo.DataHora)
                    {
                        Destino = segundo.Destino;
                    }
                    else if (aux > terceiro.DataHora)
                    {
                        Destino = terceiro.Destino;
                    }
                }
                Console.WriteLine("\n\t Bem Vindo ao Aeroporto de Confins:\n" + "\n" +
                    "\tOpções Para Voos\n" +
                    "\n\t[F1] Lista de Passageiros\n" +
                    "\t[F2] Pesquisar\n" +
                    "\t[F3] Registrar Novo Passageiro\n" +
                    "\t[F4] Deletar Passageiro da lista\n" +
                    "\t[F5] Mostrar Fila de Espera\n" +
                    "\t[ESC] SAIR", Destino);
                ConsoleKeyInfo Menu = Console.ReadKey();
                sair = Menu.Key == ConsoleKey.Escape;
                if (Menu.Key == ConsoleKey.F1)
                {
                    posicao = 1;
                    for (int i = 0; i < espera.Count; i++)
                    {
                        Console.WriteLine("\n" + posicao + "°: " + "Nome: {0} " +
                            "CPF: {1} " +
                            "Numero do Voo: 125{2} " +
                            "Destino: SP/{3} " +
                            "Telefone: {4} " +
                            "Horario: {5}",
                            listaCliente[i].Nome, listaCliente[i].CPF, listaCliente[i].Destino, listaCliente[i].Telefone, listaCliente[i].Telefone, listaCliente[i].DataHora);
                        posicao++;
                        
                    }
                }
                else if (Menu.Key == ConsoleKey.F2)
                {
                    Console.WriteLine("Digite o CPF requerido");
                    string CPF = Console.ReadLine();
                    for (int i = 0; i < listaCliente.Count && i < 6; i++)
                    {
                        if (CPF == listaCliente[i].CPF)
                        {
                            Console.WriteLine("\n" + "Nome: {0} " +
                            "CPF: {1} " +
                            "Numero do Voo: 127{2} " +
                            "Destino: BH/{3} " +
                            "Telefone: {4} " +
                            "Horario: {5}",
                            listaCliente[i].Nome, listaCliente[i].CPF, listaCliente[i].Destino, listaCliente[i].Telefone, listaCliente[i].Telefone, listaCliente[i].DataHora);
                           
                        }
                    }
                }
                else if (Menu.Key == ConsoleKey.F3)
                {
                    bool retornar = false;
                    do
                    {
                        Cliente cadastrado = new Cliente();

                        Console.WriteLine("Qual é o seu nome?");
                        cadastrado.Nome = Console.ReadLine();

                        Console.WriteLine("Informe o seu CPF");
                        cadastrado.CPF = (Console.ReadLine());

                        Console.WriteLine("Insira o local de destino");
                        string Numvoo = Console.ReadLine();

                        if (Numvoo == "SP")
                        {
                            cadastrado.Numvoo = "primeiro";
                        }
                        else if (Numvoo == "RE")
                        {
                            cadastrado.Numvoo = "segundo";
                        }
                        else if (Numvoo == "RJ")
                        {
                            cadastrado.Numvoo = "primeiro";
                        }
                        Console.WriteLine("Qual o Telefone para Contato?");
                        passageiro.Telefone = long.Parse(Console.ReadLine());

                        listaCliente.Add(cadastrado);
                        espera.Enqueue(cadastrado);

                        Console.WriteLine("Deseja efetuar um novo cadastro? Aperte ESC para retornar");
                        var terminar = Console.ReadKey();

                        retornar = terminar.Key == ConsoleKey.Escape;
                        Console.ReadKey();

                    } while (!retornar);
                }
                else if (Menu.Key == ConsoleKey.F4)
                {
                    espera.Dequeue();

                    Console.WriteLine("\nRemoção feita com Sucesso\n");
                   
                }

                else if (Menu.Key == ConsoleKey.F5)
                {
                    posicao = 6;
                    for (int i = 0; i > 6 && i < espera.Count; i++)
                    {
                        Console.WriteLine("\n" + posicao + "°: " + "Nome: {0} " +
                            "CPF: {1} " +
                            "Numero do Voo: 458{2} " +
                            "Destino: BH/{3} " +
                            "Telefone: {4} " +
                            "Horario: {5}",
                        listaCliente[i].Nome, listaCliente[i].CPF, listaCliente[i].Destino, listaCliente[i].Telefone, listaCliente[i].Telefone, listaCliente[i].DataHora);
                        posicao++;
                       
                    }
                }
            } while (!sair);
        }
    }

}