using System;
using System.Threading;

namespace filosofos_console
{
    class Program
    {
        static void Main(string [] args)
        {
            Random random = new Random();
            Filosofo aristoteles = new Filosofo(Mesa.aco, Mesa.madeira, "Aristoteles", random.Next(4, 10));
            Filosofo socrates = new Filosofo(Mesa.madeira, Mesa.metal, "Socrates", random.Next(4, 10));
            Filosofo kant = new Filosofo(Mesa.metal, Mesa.ouro, "Kant", random.Next(4, 10));
            Filosofo descartes = new Filosofo(Mesa.ouro, Mesa.plastico, "Descartes", random.Next(4, 10));
            Filosofo platao = new Filosofo(Mesa.plastico, Mesa.prata, "Platao", random.Next(4, 10));
            Filosofo nietzsche = new Filosofo(Mesa.prata, Mesa.aco, "Nietzsche", random.Next(4, 10));

            new Thread(aristoteles.Pensando).Start();
            new Thread(socrates.Pensando).Start();
            new Thread(kant.Pensando).Start();
            new Thread(descartes.Pensando).Start();
            new Thread(platao.Pensando).Start();
            new Thread(nietzsche.Pensando).Start();

            Console.ReadKey();
        }
    }
}
