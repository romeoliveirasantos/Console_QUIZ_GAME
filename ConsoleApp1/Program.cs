using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> QuestionAndAnswer = new Dictionary<string, string>() {
                    {"Qual é a capital do Brasil?","Brasília" },
                    {"Quem é o autor de 'Cem Anos de Solidão'?","Gabriel García Márquez" },
                    {"Qual é o elemento químico cujo símbolo é 'O'?","Oxigênio" },
                    {"Quem foi o primeiro homem a pisar na Lua?","Neil Armstrong" },
                    {"Em que ano ocorreu a Revolução Francesa?","1789" },
                    {"Qual é o maior oceano do mundo?","Oceano Pacífico" },
                    {"Quem pintou a Mona Lisa?","Leonardo da Vinci" },
                    {"Quem foi o líder do movimento pelos direitos civis nos Estados Unidos na década de 1960?","Martin Luther King Jr." },
                    {"Qual é a maior cordilheira do mundo em extensão?","Cordilheira dos Andes" },
                    {"Quem foi o primeiro presidente do Brasil?","Marechal Deodoro da Fonseca" },
                    {"Qual é a capital da França?","Paris" },
                    {"Quem escreveu 'Dom Quixote', considerado um dos primeiros romances modernos?","Miguel de Cervantes" },
                    {"Qual é o maior deserto do mundo em área?","Antártica" },
                    {"Quem foi o cientista que formulou a teoria da relatividade?","Albert Einstein" },
                    {"Qual é o segundo planeta a partir do sol em nosso sistema solar?","Vênus" },
                   };
            void Gabarito()
            {
                CreateTittle("Gabarito");
                foreach (var perguntas in QuestionAndAnswer)
                {
                    Console.Write($"Pergunta: {perguntas.Key}\nResposta: {perguntas.Value}\n\n");
                    Console.WriteLine("\n\nDigite qualquer para passar para a próxima: ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            void startQUIZ()
            {
                CreateTittle("QUIZ GAME");
                Loading();
                Instrucoes();
                Console.Write("Preparado(a)? Y/N: ");
                string userResponse = Console.ReadLine();
                int score = 0;

                if (userResponse.ToLower() == "y")
                {
                    Console.Clear();
                    Console.WriteLine("Iniciando o QUIZ");
                    Loading();

                    var random = new Random();
                    var shuffledQuestions = QuestionAndAnswer.OrderBy(x => random.Next()).ToList();

                    foreach (var perguntas in shuffledQuestions)
                    {
                        Console.WriteLine(perguntas.Key);
                        userResponse = Console.ReadLine();

                        if (userResponse.ToLower() == perguntas.Value.ToLower())
                        {
                            Console.WriteLine("Resposta correta!\n");
                            score++;
                            Loading();
                        }
                        else
                        {
                            Console.WriteLine("\n\nResposta incorreta!");
                            Loading();
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Encerrando!");
                    Loading();
                    Environment.Exit(Environment.ExitCode);
                }
                Loading();
                Console.WriteLine($"Parabéns! você concluiu o QUIZ\nSua pontuação final é: {score}\n");
                Loading();
                Console.Write("Deseja iniciar jogar novamente? Y/N: ");
                userResponse = Console.ReadLine();
                if (userResponse.ToLower() == "y")
                {
                    Loading();
                    startQUIZ();
                }
                else
                {
                    Console.Write("Deseja consultar o gabarito? Y/N: ");
                    userResponse = Console.ReadLine();
                    if (userResponse.ToLower() == "y")
                    {
                        Gabarito();
                    }

                    Loading();
                    Console.WriteLine("Encerrando");
                    Thread.Sleep(3000);

                }

            }
            startQUIZ();
        }

        public static void CreateTittle(string titulo)
        {
            int qtdCaracteres = titulo.Length;
            string specialCaractere = string.Empty.PadLeft(qtdCaracteres, '*');
            Console.WriteLine(specialCaractere);
            Console.WriteLine(titulo);
            Console.WriteLine(specialCaractere);
        }

        public static void Loading()
        {
            Console.Write("Loading");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void Instrucoes()
        {
            Console.WriteLine("Instruções para jogar o QUIZ GAME!\n");
            Console.WriteLine("Serão 15 perguntas de conhecimentos gerais com respostas únicas\n");
            Console.WriteLine("Há uma pontuação que se inicia em 0 e a cada pergunta é acrescentado 1 ponto\n");
            Console.WriteLine("No final do game, sua pontuação será exibida\n");
        }

    }
}
