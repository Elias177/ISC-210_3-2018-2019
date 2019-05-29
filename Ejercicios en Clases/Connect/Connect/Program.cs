using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Connect
{
    class Program
    {
        static Thread hiloCaptura;
        static Juego juegoActual = new Juego();
        static int[] posicionesColumnas = new int[7] { 1, 3, 5, 7, 9, 11, 13 };

        static void InicializarJuego()
        {
            juegoActual.Estado = Juego.eEstadoJuego.MostrandoMenu;
            juegoActual.TurnoPrimerJugador = true;
            juegoActual.SiguienteColumna = -1;
            juegoActual.Tablero = new bool?[6,7];
            Console.CursorVisible = false;
            hiloCaptura = new Thread(CapturarTeclado);
            hiloCaptura.Start();
        }

        static void Main(string[] args)
        {
            InicializarJuego();

            while (juegoActual.Estado != Juego.eEstadoJuego.JuegoFinalizado)
            {
                
                //Primero: verificamos la entrada del usuario
                if (juegoActual.Estado == Juego.eEstadoJuego.Jugando && juegoActual.SiguienteColumna >= 0)
                {
                    juegoActual.Estado = Juego.eEstadoJuego.Animando;
                    Thread nuevoHilo = new Thread(AnimarNuevaMoneda);
                    juegoActual.ProximaFila = juegoActual.ProximaFilaDisponible(juegoActual.SiguienteColumna);

                    nuevoHilo.Start();
                    nuevoHilo.Join();

                    juegoActual.Tablero[juegoActual.ProximaFila,
                        juegoActual.SiguienteColumna] = juegoActual.TurnoPrimerJugador;

                    if (juegoActual.VerificarFinPartida(juegoActual.ProximaFila,juegoActual.SiguienteColumna))
                    {
                        juegoActual.Estado = Juego.eEstadoJuego.JuegoFinalizado;
                        Console.SetCursorPosition(8,5);
                        Console.WriteLine("Fin");
                    }
                    juegoActual.SiguienteColumna = -1;
                    juegoActual.TurnoPrimerJugador = !juegoActual.TurnoPrimerJugador;



                }

                //Seugndo: actualizamos valores en funciones del estado actual.

                //Tercero: renderizamos el juego.

                Renderizar();
                Thread.Sleep(50);
                
            }

            Console.WriteLine("Gracias por jugar! Presione cualquier tecla para cerrar");

            Console.ReadKey();

            Environment.Exit(2);

        }

        static void AnimarNuevaMoneda()
        {
            TimeSpan horaInicial = new TimeSpan(DateTime.Now.Ticks);
            short posAnterior,posInicial = 5, posActual, posFinal = 6;
            posAnterior = posInicial;
            posFinal =  (short) (juegoActual.ProximaFila + 1);

            if(posFinal < 1)
                return;


            Console.ForegroundColor = juegoActual.TurnoPrimerJugador ? Juego.SPRITERED : Juego.SPRITEYELLOW;

            do
            {
                posActual = Convert.ToInt16(posInicial + Juego.GRAVEDAD * Math.Pow(new TimeSpan(DateTime.Now.Ticks).Subtract(horaInicial).TotalSeconds, 2) / 2);

                Console.SetCursorPosition(posicionesColumnas[juegoActual.SiguienteColumna],posAnterior);
                Console.Write(" ");
                Console.SetCursorPosition(posicionesColumnas[juegoActual.SiguienteColumna], posActual);

                Console.Write("O");
                posAnterior = posActual;

            } while (posActual <= (posFinal + posInicial));

            Console.ForegroundColor = ConsoleColor.White;
            juegoActual.Estado = Juego.eEstadoJuego.Jugando;

        }

        static void Renderizar()
        {
            switch (juegoActual.Estado)
            {
                case Juego.eEstadoJuego.MostrandoMenu:
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Selecione una opcion del menu: ");
                    Console.WriteLine("\n\t1: Jugar.");
                    Console.WriteLine("\t2: Salir.");
                    break;
                case Juego.eEstadoJuego.Jugando:
                    ImprimirEscena();
                    ImprimirTablero();
                    break;
                    
                    
               // case Juego.eEstadoJuego.
            }
        }

        static void ImprimirTablero()
        {
            short posInicial = 6;

           

            for (int i = 0; i < juegoActual.Tablero.GetLength(0); i++)
            {
                for (int j = 0; j < juegoActual.Tablero.GetLength(1) ; j++)
                {
                    if (juegoActual.Tablero[i, j] == null)
                        continue;

                    Console.SetCursorPosition(posicionesColumnas[j], posInicial + i);

                    Console.ForegroundColor = juegoActual.Tablero[i,j] == true ? Juego.SPRITERED : Juego.SPRITEYELLOW;
                    Console.Write("O");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        static void CapturarTeclado()
        {
            int _tmp;
            string capturaActual;
            while (true)
            {
                capturaActual = Console.ReadLine();
                switch (juegoActual.Estado)
                {
                    case Juego.eEstadoJuego.MostrandoMenu:
                        if (capturaActual == "2")
                            juegoActual.Estado = Juego.eEstadoJuego.JuegoFinalizado;
                        else if(capturaActual == "1")
                        {
                            juegoActual.Estado = Juego.eEstadoJuego.Jugando;
                        }
                        break;
                    case Juego.eEstadoJuego.Jugando:
                        if (Int32.TryParse(capturaActual, out _tmp) && _tmp >= 1 && _tmp <= 7)
                        {
                            //Selecciono una columna.
                            juegoActual.SiguienteColumna = _tmp - 1;
                        }
                        break;
                        
                }
            }
        }

        static void ImprimirEscena()
        {
            Console.Clear();
            
            Console.WriteLine("Connect-4");
            Console.WriteLine("Turno Actual: " + (juegoActual.TurnoPrimerJugador ? "Primer Jugador" : "Segundo Jugador"));
            Console.WriteLine("\nSelecciona una columna [1-7]");
            Console.WriteLine(" 1 2 3 4 5 6 7");
            Console.WriteLine("----------------");
            Console.WriteLine("| | | | | | | |");
            Console.WriteLine("| | | | | | | |");
            Console.WriteLine("| | | | | | | |");
            Console.WriteLine("| | | | | | | |");
            Console.WriteLine("| | | | | | | |");
            Console.WriteLine("| | | | | | | |");
            Console.WriteLine("----------------");
            

        }

        
    }
}
