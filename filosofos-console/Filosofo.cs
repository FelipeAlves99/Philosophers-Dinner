using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace filosofos_console
{
    enum EstadoFilosofo { Comendo, Pensando }

    class Filosofo
    {
        public string Nome { get; set; }
        public EstadoFilosofo Estado { get; set; }

        readonly int LimiteFome;
        public readonly Garfo GarfoDireito;
        public readonly Garfo GarfoEsquerdo;

        Random random = new Random();

        int countPensamentos = 0;

        public Filosofo(Garfo garfoEsquerdo, Garfo garfoDireito, string nome, int limiteFome)
        {
            GarfoEsquerdo = garfoEsquerdo;
            GarfoDireito = garfoDireito;
            Nome = nome;
            LimiteFome = limiteFome;
            Estado = EstadoFilosofo.Pensando;
        }

        public void Comer()
        {
            if (GarfoPegoMaoDireita())
            {
                if (GarfoPegoMaoEsquerda())
                {
                    this.Estado = EstadoFilosofo.Comendo;
                    Console.WriteLine("{0} esta comendo com o {1} e {2}", Nome, GarfoDireito.IdGarfo, GarfoEsquerdo.IdGarfo);
                    Thread.Sleep(random.Next(5000, 10000));

                    countPensamentos = 0;

                    GarfoDireito.ColocarNaMesa();
                    GarfoEsquerdo.ColocarNaMesa();
                }
                else
                {
                    Thread.Sleep(random.Next(100, 400));
                    if (GarfoPegoMaoEsquerda())
                    {
                        this.Estado = EstadoFilosofo.Comendo;
                        Console.WriteLine("{0} esta comendo com o {1} e {2}", Nome, GarfoDireito.IdGarfo, GarfoEsquerdo.IdGarfo);
                        Thread.Sleep(random.Next(5000, 10000));

                        countPensamentos = 0;

                        GarfoDireito.ColocarNaMesa();
                        GarfoEsquerdo.ColocarNaMesa();
                    }
                    else
                        GarfoDireito.ColocarNaMesa();
                }
            }
            else
            {
                if (GarfoPegoMaoEsquerda())
                {
                    Thread.Sleep(random.Next(100, 400));
                    if (GarfoPegoMaoDireita())
                    {
                        this.Estado = EstadoFilosofo.Comendo;
                        Console.WriteLine("{0} esta comendo com o {1} e {2}", Nome, GarfoDireito.IdGarfo, GarfoEsquerdo.IdGarfo);
                        Thread.Sleep(random.Next(5000, 10000));

                        countPensamentos = 0;

                        GarfoDireito.ColocarNaMesa();
                        GarfoEsquerdo.ColocarNaMesa();
                    }
                    else
                        GarfoEsquerdo.ColocarNaMesa();
                }
            }

            Pensando();
        }

        public void Pensando()
        {
            this.Estado = EstadoFilosofo.Pensando;
            Console.WriteLine("{0} esta pensando ... prioridade {1}", Nome, Thread.CurrentThread.Priority.ToString());
            Thread.Sleep(random.Next(2500, 20000));
            countPensamentos++;

            if (countPensamentos > LimiteFome)
                Console.WriteLine("{0} esta com fome", Nome);

            Comer();
        }

        private bool GarfoPegoMaoEsquerda()
        {
            return GarfoEsquerdo.Pego(Nome);
        }

        private bool GarfoPegoMaoDireita()
        {
            return GarfoDireito.Pego(Nome);
        }
    }
}
