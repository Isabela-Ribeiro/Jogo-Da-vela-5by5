using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDavelhaAtualizado
{
    class Program
    {
        static void Main(string[] args)
        {
            int op;
            try
            {
                do
                {//menu de sair e de jogar
                    string[,] mat = new string[3, 3] { { "_", "_", "_" },
                                                       { "_", "_", "_" },
                                                       { "_", "_", "_" } };
                    string jogador = "X";

                    Console.WriteLine("\nJOGO DA VELHA\n");
                    Console.WriteLine("1-Jogar\n0-Sair\n");
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Imprimir_Jogo(mat);
                            while (Jogando(mat, jogador))
                            {

                                jogador = TrocarJogador(jogador);
                            };
                            break;
                        case 0:
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opcao invalida");
                            break;
                    }
                } while (op != 0);
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Imprimir_Jogo(string[,] mat)
        {
            Console.Clear();
            Console.WriteLine("\t[0]\t[1]\t[2]");
            for (int l = 0; l < mat.GetLength(0); l++)
            {
                Console.Write($"[{l}]");
                for (int c = 0; c < mat.GetLength(1); c++)
                {
                    Console.Write("\t" + mat[l, c]);
                }
                Console.WriteLine();
            }
        }

        static bool Verificar(string[,] mat, int[] jogada)
        {   //verifica se o jogador lançou numero menor que zero ou maior que zero,já que são posiçoes invalidas
            if ((jogada[0] < 0 || jogada[0] > 2) || (jogada[1] < 0 || jogada[1] > 2))
            {
                Imprimir_Jogo(mat);
                Console.WriteLine("Não existe essa posição");
                return false;
            }
            //Verifica se o espaço é diferente que branco
            else if (mat[jogada[0], jogada[1]] != "_")
            {   
                Imprimir_Jogo(mat);
                Console.WriteLine("Você não pode jogar nesta posição");
                return false;
            }
            return true;
        }
        static int[] Jogada(string[,] mat)
        {
            int[] jogada = new int[2] { -1, -1 };
            do
            {
                try
                {
                    Console.WriteLine("Informe a linha do 0 ao 2: ");
                    jogada[0] = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe a coluna do 0 ao 2: ");
                    jogada[1] = int.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine();
                }
            } while (!Verificar(mat, jogada));
            return jogada;
        }
        static bool Jogando(string[,] mat, string jogador)
        {
            int[] jogada = Jogada(mat);

            mat[jogada[0], jogada[1]] = jogador;

            Imprimir_Jogo(mat);

            int status = VerificaStatus(mat, jogada);
            //Serve para verificar qual jogdor ganhou
            if (status > 0 && status < 3)
            {
                Console.WriteLine($"O jogador {status} ganhou");
                return false;
            }
            else if (status == 0)
            {
                Console.WriteLine("Deu velha");
                return false;
            }
            return true;
        }
        static int VerificaStatus(string[,] mat, int[] jogada)
        {
            //contador que conta quantos espaço foi preenchido
            int cont = 0;
            for (int l = 0; l < mat.GetLength(0); l++)
            {
                for (int c = 0; c < mat.GetLength(1); c++)
                {
                    if (mat[l, c] != "_")
                    {
                        cont++;
                    }
                }
            }
            if (cont >= 5)
            {
                //verifica a matriz na diagonal
                if ((mat[0, 0] == mat[1, 1] && mat[0, 0] == mat[2, 2]) && mat[0, 0] != "_")
                {
                    if (mat[0, 0] == "X")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                //verifica a diagonal secundaria
                if ((mat[0, 2] == mat[1, 1] && mat[0, 2] == mat[2, 0]) && mat[0, 2] != "_")
                {
                    if (mat[0, 2] == "X")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                // Verifica as linhas
                for (int l = 0; l < mat.GetLength(0); l++)
                {
                    if ((mat[l, 0] == mat[l, 1] && mat[l, 0] == mat[l, 2]) && mat[l, 0] != "_")
                    {
                        if (mat[l, 0] == "X")
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                }
                //verifica as colunas
                for (int c = 0; c < mat.GetLength(0); c++)
                {
                    if ((mat[0, c] == mat[1, c] && mat[0, c] == mat[2, c]) && mat[0, c] != "_")
                    {
                        if (mat[0, c] == "X")
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                }
            }
            //verifica se o jogo de velha
            if (cont == 9)
            {
                return 0;
            }
            return 3;
        }
        static string TrocarJogador(string jogador)
        {
            
            if (jogador == "x" || jogador == "X")
            {
                Console.WriteLine("\nAgora é a vez do jogador 2 ou bolinha:\n");
                return "O";
            }
            else
            {
                Console.WriteLine("\nAgora é a vez do jogador 1 ou xis:\n");
                return "X";
            }
        }
    }
}
    

