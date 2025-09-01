using System;
using System.Collections.Generic;

namespace TraductorBasico
{
    class Program
    {
        static void Main(string[] args)
        {
            // Diccionario base inglés -> español
            Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"time", "tiempo"},
                {"person", "persona"},
                {"year", "año"},
                {"way", "camino"},
                {"day", "día"},
                {"thing", "cosa"},
                {"man", "hombre"},
                {"world", "mundo"},
                {"life", "vida"},
                {"hand", "mano"},
                {"part", "parte"},
                {"child", "niño"},
                {"eye", "ojo"},
                {"woman", "mujer"},
                {"place", "lugar"},
                {"work", "trabajo"},
                {"week", "semana"},
                {"case", "caso"},
                {"point", "punto"},
                {"government", "gobierno"},
                {"company", "empresa"}
            };

            int opcion;
            do
            {
                Console.WriteLine("\n=========== MENÚ ===========");
                Console.WriteLine("1. Traducir una frase");
                Console.WriteLine("2. Agregar palabras al diccionario");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        TraducirFrase(diccionario);
                        break;
                    case 2:
                        AgregarPalabra(diccionario);
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del traductor...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        break;
                }

            } while (opcion != 0);
        }

        static void TraducirFrase(Dictionary<string, string> diccionario)
        {
            Console.Write("\nIngrese la frase a traducir: ");
            string frase = Console.ReadLine();

            string[] palabras = frase.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> traducidas = new List<string>();

            foreach (var palabra in palabras)
            {
                string limpia = palabra.Trim(',', '.', ';', ':', '!', '?');

                if (diccionario.ContainsKey(limpia.ToLower()))
                {
                    string traduccion = diccionario[limpia.ToLower()];
                    traducidas.Add(palabra.Replace(limpia, traduccion));
                }
                else
                {
                    traducidas.Add(palabra);
                }
            }

            Console.WriteLine("\nTraducción:");
            Console.WriteLine(string.Join(" ", traducidas));
        }

        static void AgregarPalabra(Dictionary<string, string> diccionario)
        {
            Console.Write("\nIngrese la palabra en inglés: ");
            string ingles = Console.ReadLine().Trim().ToLower();

            Console.Write("Ingrese su traducción al español: ");
            string espanol = Console.ReadLine().Trim().ToLower();

            if (!diccionario.ContainsKey(ingles))
            {
                diccionario.Add(ingles, espanol);
                Console.WriteLine($"Palabra '{ingles}' añadida con traducción '{espanol}'.");
            }
            else
            {
                Console.WriteLine("Esa palabra ya existe en el diccionario.");
            }
        }
    }
}
