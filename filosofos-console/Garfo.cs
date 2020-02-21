using System;

namespace filosofos_console
{
    enum EstadoGarfo { Pego, NaMesa }

    class Garfo
    {
        public string IdGarfo { get; set; }
        public EstadoGarfo Estado { get; set; }
        public string PegoPor { get; set; }

        public bool Pego(string pegoPor)
        {
            lock (this)
            {
                if(this.Estado == EstadoGarfo.NaMesa)
                {
                    Estado = EstadoGarfo.Pego;
                    PegoPor = pegoPor;
                    Console.WriteLine("{0} foi pego por {1}", IdGarfo, PegoPor);
                    return true;
                }
                else
                {
                    Estado = EstadoGarfo.Pego;
                    return false;
                }
            }
        }

        public void ColocarNaMesa()
        {
            Estado = EstadoGarfo.NaMesa;
            Console.WriteLine("{0} foi colocado na mesa por {1}", IdGarfo, PegoPor);
            PegoPor = string.Empty;
        }
    }
}
