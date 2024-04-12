#nullable disable

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nBIENVENIDO A LA BATALLA DE TIC!");

        Character character = null;
        int respuesta;

        do
        {
            Console.WriteLine("\nElija la clase de su personaje:\n\n 1. Warrior\n 2. Knight\n 3. Samurai\n 4. Astrologer\n 5. Thief\n 6. Prisoner\n 7. Wanderer\n");
            if (int.TryParse(Console.ReadLine(), out respuesta))
            {
                switch (respuesta)
                {
                    case 1:
                        character = new Warrior();
                        break;

                    case 2:
                        character = new Knight();
                        break;

                    case 3:
                        character = new Samurai();
                        break;

                    case 4:
                        character = new Astrologer();
                        break;

                    case 5:
                        character = new Thief();
                        break;

                    case 6:
                        character = new Prisoner();
                        break;

                    case 7:
                        character = new Wanderer();
                        break;

                    default:
                        Console.WriteLine("Seleccione una opcion valida");
                        continue;
                }
            }
            
            else
            {
                Console.WriteLine("Ingrese un numero valido");
            }
        } while (character == null);

        Console.WriteLine("Ingrese su nombre: ");
        string nombre = Console.ReadLine();

        if (character != null)
        {
            Console.WriteLine($"\nSe ha creado el personaje {nombre} de la clase {character.GetType().Name}!");
            Console.WriteLine("\nHP: " + character.HP);
            Console.WriteLine("ATK: " + character.ATK);
            Console.WriteLine("DEF: " + character.DEF);
            Console.WriteLine("INT: " + character.INT);
            Console.WriteLine("LCK: " + character.LCK);
        }

        Battle.StartBattle(character, nombre);
    }
}
