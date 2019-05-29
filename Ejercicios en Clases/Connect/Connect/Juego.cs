using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect
{
    class Juego
    {
        #region "Enums"
        public enum eEstadoJuego
        {
            MostrandoMenu,
            Jugando,
            Animando,
            JuegoFinalizado

        }
        #endregion

        #region "Atributos"
        public eEstadoJuego Estado { get; set; }
        public bool TurnoPrimerJugador { get; set; }
        public string SiguienteAccion { get; set; }
        public int SiguienteColumna { get; set; }
        public int ProximaFila { get; set; }

        public const float GRAVEDAD = 9.8f;
        public bool?[,] Tablero { get; set; }

        public const System.ConsoleColor SPRITEYELLOW = ConsoleColor.Yellow;
        public const System.ConsoleColor SPRITERED = ConsoleColor.Red;

        #endregion

        #region "Comportamiento"

        public int ProximaFilaDisponible(int numeroColumna)
        {
            int filaActual = Tablero.GetLength(0);

            while (filaActual > 0 && Tablero[filaActual - 1, numeroColumna] != null)
            {
                filaActual--;
            }

            return filaActual - 1;
        } 

        #endregion

        public bool VerificarFinPartida(int f, int c)
        {
            int i, j, k;
            int[] Consecutivo = new int[4];
            int iMin = c - 3 < 0 ? 0 : c - 3;
            int iMax = c + 3 >= Tablero.GetLength(0) ? Tablero.GetLength(0) - 1 : c + 3;
            int jMin = f - 3 < 0 ? 0 : f - 3;
            int jMax = f + 3 >= Tablero.GetLength(1) ? Tablero.GetLength(1) - 1 : f + 3;
            int kMin = f - 3 < 0 ? 0 : f - 3;
            int kMax = f + 3 >= Tablero.GetLength(1) ? Tablero.GetLength(1) - 1 : c + 3;


            for (i = iMin, j = jMin, k = kMax; i <= iMax || j <= jMax || k >= kMin; i++, j++, k--)
            {



                // Horizontales:
                if (j <= jMax && Tablero[f, j] == TurnoPrimerJugador)
                    Consecutivo[0]++;
                // Verticales
                if (i <= iMax && Tablero[i, c] == TurnoPrimerJugador)
                    Consecutivo[1]++;
                //Diagonal 1
                if (i <= iMax && j <= jMax && Tablero[i, j] == TurnoPrimerJugador)
                    Consecutivo[2]++;
                //Diagonal 2
                if (i <= iMax && k >= kMin && Tablero[i, k] == TurnoPrimerJugador)
                    Consecutivo[3]++;

                if (Consecutivo.Any(contador => contador == 4))
                    return true;
            }

           

            return false;
        }
    }
}
