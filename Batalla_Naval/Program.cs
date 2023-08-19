using System;


namespace Batalla_Naval
    {
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Batalla Naval!");
            char[,] tablero = new char[10, 10];
            CrearTablero(tablero);
            MostrarTablero(tablero);


            char[,] tableroOculto = new char[10, 10];
            char[,] tableroVisible = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tableroOculto[i, j] = '~';
                    tableroVisible[i, j] = '~';
                }
            }

            int longitudBarco = 0;
            while (longitudBarco < 2 || longitudBarco > 5)
            {
                Console.Write("Ingrese la longitud del barco (entre 2 y 5): ");
                longitudBarco = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");
            }

            int posicionBarco = -1;
            while (posicionBarco != 0 && posicionBarco != 1)
            {
                Console.Write("Eliga la posición del barco (0 para horizontal, 1 para vertical): ");
                posicionBarco = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");
            }

            int filaBarco = -1, columnaBarco = -1;
            while (filaBarco < 0 || filaBarco >= 10 || columnaBarco < 0 || columnaBarco >= 10)
            {
                Console.Write("Ingrese la fila y columna para ubicar el barco de la forma x,y --> (fila,columna): ");
                string[] posicion = Console.ReadLine().Split(',');
                filaBarco = int.Parse(posicion[0]);
                columnaBarco = int.Parse(posicion[1]);
                Console.WriteLine(" ");
            }

            for (int i = 0; i < longitudBarco; i++)
            {
                if (posicionBarco == 0)
                {
                    tableroOculto[filaBarco, columnaBarco + i] = '0';
                }
                else
                {
                    tableroOculto[filaBarco + i, columnaBarco] = '0';
                }
            }

            MostrarTablero(tableroVisible);

            // Juego: Atacar el barco
            int posicionesRestantes = longitudBarco;
            while (posicionesRestantes > 0)
            {
                Console.Write("Ingresa la fila y columna para atacar (fila,columna): ");
                string[] ataque = Console.ReadLine().Split(',');
                int filaAtaque = int.Parse(ataque[0]);
                int columnaAtaque = int.Parse(ataque[1]);
                Console.WriteLine(" ");

                if (tableroOculto[filaAtaque, columnaAtaque] == '0')
                {
                    Console.WriteLine("¡Ataque exitoso! Has impactado al barco.\n");
                    tableroVisible[filaAtaque, columnaAtaque] = '0';
                    tableroOculto[filaAtaque, columnaAtaque] = 'X';
                    posicionesRestantes--;
                }
                else if (tableroVisible[filaAtaque, columnaAtaque] == 'X' || tableroVisible[filaAtaque, columnaAtaque] == '0')
                {
                    Console.WriteLine("Ya has atacado esta posición antes.\n");
                }
                else
                {
                    Console.WriteLine("¡Ataque fallido! No has impactado al barco.\n");
                    tableroVisible[filaAtaque, columnaAtaque] = 'X';
                }

                MostrarTablero(tableroVisible);
            }

            Console.WriteLine("¡Barco Hundido! ¡Fin del juego!");
        }

        static void CrearTablero(char[,] tablero)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            for (int j = 0; j < tablero.GetLength(1); j++)
                tablero[i, j] = '~';
        }

        static void MostrarTablero(char[,] tablero)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(tablero[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}