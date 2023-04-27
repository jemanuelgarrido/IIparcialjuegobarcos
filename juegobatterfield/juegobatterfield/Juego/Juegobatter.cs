class Program
{
    static int[,] tablero;
    static int numBarcos;
    static int intentos;

    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido al juego batterfield!");
        Console.WriteLine("¡Eres un pirata, derribalos todos!");
        Console.WriteLine("¡SUERTE!");

        Console.WriteLine();
        Console.WriteLine("          __^__                                      __^__");
        Console.WriteLine("        .'  O  '.                                  .'  O  '.");
        Console.WriteLine("       /  O    O \\                                /  O    O \\");
        Console.WriteLine("      /____      \\______________________/___________           \\");
        Console.WriteLine("      /    \\     /                    \\     /                   \\");
        Console.WriteLine("     /      \\__/                      \\__/                        \\");
        Console.WriteLine("    /         O        O         O        O        O        O        \\");
        Console.WriteLine("   /     O                   O         O                  O           \\");
        Console.WriteLine("   ____________________________________________________________________");
 
        Console.WriteLine("Seleccione el nivel de dificultad:");
        Console.WriteLine("1 - Fácil (5x5 con 3 barcos)");
        Console.WriteLine("2 - Avanzado (10x10 con 8 barcos)");
        Console.WriteLine("Recuerde que las filas y columnas se inicializan en 0");
        Console.Write("Opción: ");

        string opcion = Console.ReadLine();
        int tamanoTablero, numBarcos;
        switch (opcion)
        {
            case "1":
                tamanoTablero = 5;
                numBarcos = 3;
                break;
            case "2":
                tamanoTablero = 10;
                numBarcos = 8;
                break;
            default:
                Console.WriteLine("Opción inválida. fuera de rango.");
                return;
        }
        tablero = new int[tamanoTablero, tamanoTablero];
        InicializarTablero();
        ColocarBarcos(numBarcos);
        MostrarTablero(false );

        while (numBarcos > 0)
        {
            int fila, columna;
            Console.WriteLine("Intento No.{0}", intentos + 1);
            Console.Write("Fila: ");
            if (!int.TryParse(Console.ReadLine(), out fila) || fila < 0 || fila >= tamanoTablero)
            {
                Console.WriteLine("Fila inválida. Intente de nuevo.");
                continue;
            }
            Console.Write("Columna: ");
            if (!int.TryParse(Console.ReadLine(), out columna) || columna < 0 || columna >= tamanoTablero)
            {
                Console.WriteLine("Columna inválida. Intente de nuevo.");
                continue;
            }
            if (tablero[fila, columna] == 1)
            {
                Console.WriteLine("¡Excelente pirata!, ¡derribaste un barco con tu cañon!");
                Console.Beep();
                tablero[fila, columna] = 2;
                numBarcos--;
            }
            else
            {
                Console.WriteLine("Luser, Apunta bien ese cañon.");
                tablero[fila, columna] = -1;
            }
            intentos++;
            MostrarTablero(false );
        }

        Console.WriteLine("¡Eres todo un pirata! Has hundido todos los barcos en {0} intentos.", intentos);
        Console.ReadLine();
       
    }

    static void InicializarTablero()
    {
        for (int f = 0; f < tablero.GetLength(0); f++)
        {
            for (int c = 0; c < tablero.GetLength(1); c++)
            {
                tablero[f, c] = 0;
            }
        }
    }

    static void ColocarBarcos(int numBarcos)
    {
        Random rnd = new Random();
        while (numBarcos > 0)
        {
            int fila = rnd.Next(tablero.GetLength(0));
            int columna = rnd.Next(tablero.GetLength(1));
            if (tablero[fila, columna] == 0)
            {
                tablero[fila, columna] = 1;
                numBarcos--;
            }
        }
    }

    static void MostrarTablero(bool mostrarBarcos)
    {
        Console.WriteLine();
        Console.Write("  ");
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            Console.Write("{0} ", c);
        }
        Console.WriteLine();//salto de linea

        for (int f = 0; f < tablero.GetLength(0); f++)
        {
            Console.Write("{0} ", f);
            for (int c = 0; c < tablero.GetLength(1); c++)
            {
                if (tablero[f, c] == 2)
                {
                    Console.Write("* ");
                }
                else if (tablero[f, c] == 1 && mostrarBarcos)
                {
                    Console.Write("# ");
                }
                else if (tablero[f, c] == -1)
                {
                    Console.Write("x ");
                }
                else
                {
                    Console.Write("- ");
                }
            }
            Console.WriteLine();
        }
    }
}
   

