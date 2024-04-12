#nullable disable

public class Battle
{
    public static void StartBattle(Character character, string nombre)
    {
        int killCount = 0;

        Console.WriteLine("\nListo para la batalla? (S/N): ");
        string ready = Console.ReadLine();

        if (ready.ToLower() != "s" && ready.ToLower() != "si" && ready.ToLower() != "y" && ready.ToLower() != "yes")
        {
            Console.WriteLine("\nHasta la proxima!");
            return;
        }

        Console.WriteLine("\nComienza la batalla!");

        Thread.Sleep(2000);

        while (true) // Main loop que hara que las peleas continuen hasta que el HP del user sea 0
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"\nNivel: {killCount + 1}");

            Monster monster = new Monster();
            monster.IncreaseStats(killCount);

            while (character.HP > 0 && monster.HP > 0)
            {
                Console.WriteLine($"\n--- Estado de {nombre} ---".PadRight(40) + "--- Estado del monstruo ---");
                Console.WriteLine($"HP: {character.HP}".PadRight(40) + $"HP: {monster.HP}");
                Console.WriteLine($"ATK: {character.ATK}".PadRight(40) + $"ATK: {monster.ATK}");
                Console.WriteLine($"DEF: {character.DEF}".PadRight(40) + $"DEF: {monster.DEF}");
                Console.WriteLine($"INT: {character.INT}");
                Console.WriteLine($"LCK: {character.LCK}");

                // Turno del Jugador

                // Menu de batalla
                Console.WriteLine("\nMenu de Batalla:");
                Console.WriteLine("\n 1. Atacar\n 2. Items");
                Console.WriteLine("\n\nSeleccione su acción: ");

                int accion = Convert.ToInt32(Console.ReadLine());

                switch (accion)
                {
                    case 1: // Atacar

                        if (character.HasSpell)
                        {
                            Console.WriteLine("Tipo de ataque: \n 1. Ataque Básico\n 2. Ataque Mágico");
                            int ataque = Convert.ToInt32(Console.ReadLine());
                            
                            if (ataque == 1)
                            {
                                Console.WriteLine($"\n{nombre} ataca al monstruo con un ataque básico");

                                double damageplayer = Math.Max((character.ATK - (monster.DEF * 0.3)), 0);
                                monster.HP -= damageplayer;

                                Thread.Sleep(2000);
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"\n{nombre} ataca al monstruo con un ataque mágico!");

                                double damageplayer = Math.Max((character.INT - (monster.DEF * 0.15)), 0);
                                monster.HP -= damageplayer;

                                Thread.Sleep(2000);
                                break;

                            }
                        }
                        else
                        {
                            Console.WriteLine($"\n{nombre} ataca al monstruo con un ataque básico");

                            double damageplayer = Math.Max((character.ATK - (monster.DEF * 0.3)), 0);
                            monster.HP -= damageplayer;

                            Thread.Sleep(2000);
                            break;
                        }
                        
                    case 2: // Usar items
                        
                        Console.WriteLine("\n-- Item Bag --");
                        Console.WriteLine($"HP Potions: x{character.HPpotions}");

                        Console.WriteLine("\nDeseas usar una HP potion? (S/N): ");
                        string usar = Console.ReadLine();

                        if (usar.ToLower() == "s" || usar.ToLower() == "si" || usar.ToLower() == "y" || usar.ToLower() == "yes")
                        {
                            if (character.HPpotions > 0)
                            {
                                double initialHP = character.initialHP; // Restaurar el HP del jugador a su valor inicial
                                character.HP = initialHP;
                                character.HPpotions--;

                                Console.WriteLine($"\n{nombre} ha usado un HP Potion y ha recuperado su HP!");
                                Console.WriteLine($"HP: {character.HP}");
                                break; 
                            }
                            else
                            {
                                Console.WriteLine("\nNo tienes HP Potions en tu bolsa.");
                                continue;
                            }
                        }
                        else if (usar.ToLower() == "n" || usar.ToLower() == "no")
                        {
                            Console.WriteLine("\nNo se ha usado ninguna HP Potion.");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("\nRespuesta no válida.");
                        }
                        break;

                    default:
                        Console.WriteLine("\nAcción no valida");
                        continue;
                }

                Thread.Sleep(1000); // 1 segundo de delay para que el usuario pueda leer

                Console.WriteLine($"\nHP del monstruo despues del ataque: {monster.HP}");

                if (monster.HP <= 0)
                {
                    killCount++;
                    Console.WriteLine("\nEl monstruo fue derrotado!");

                    Thread.Sleep(2000);

                    // Se revisa si el jugador encuentra un item entre batallas
                    ItemFinding.ItemType? foundItem = ItemFinding.FindItem(character.LCK);
                    if (foundItem.HasValue)
                    {
                        switch (foundItem.Value)
                        {
                            case ItemFinding.ItemType.HP_Potion:

                                character.HPpotions++; 
                                Console.WriteLine($"\n{nombre} ha encontrado un HP potion!");
                                break;

                            case ItemFinding.ItemType.Armor:

                                character.DEF++; // Si es Armor el valor de DEF del jugador aumentara por 1
                                Console.WriteLine($"\n{nombre} ha encontrado una armadura y su DEF ha aumentado 1 punto!");
                                break;
                                
                            case ItemFinding.ItemType.Spell:

                                if (!character.HasSpell) 
                                {
                                    character.HasSpell = true;
                                    Console.WriteLine($"\n{nombre} ha encontrado un Spell!");
                                }
                                break;

                            case ItemFinding.ItemType.Skill_Point:

                                Console.WriteLine("Felicidades, has encontrado un Skill point!");
                                
                                int skillpointElegido;
                                bool opcionValida = false;

                                do
                                {
                                    Console.WriteLine("\nSeleccione el atributo en el que deseas gastarlo: ");
                                    Console.WriteLine("\n 1. HP\n 2. ATK\n 3. DEF\n 4. INT\n 5. LCK");
                                    
                                    if (int.TryParse(Console.ReadLine(), out skillpointElegido))
                                    {
                                        switch (skillpointElegido)
                                        {
                                            case 1:
                                                character.initialHP++;
                                                Console.WriteLine($"El HP de {nombre} ahora es {character.initialHP}!");
                                                opcionValida = true;
                                                break;

                                            case 2:
                                                character.ATK++;
                                                Console.WriteLine($"El ATK de {nombre} ahora es {character.ATK}!");
                                                opcionValida = true;
                                                break;

                                            case 3:
                                                character.DEF++;
                                                Console.WriteLine($"La DEF de {nombre} ahora es {character.DEF}!");
                                                opcionValida = true;
                                                break;

                                            case 4:
                                                character.INT++;
                                                Console.WriteLine($"La INT de {nombre} ahora es {character.INT}!");
                                                opcionValida = true;
                                                break;

                                            case 5:
                                                character.LCK++;
                                                Console.WriteLine($"La LCK de {nombre} ahora es {character.LCK}!");
                                                opcionValida = true;
                                                break;

                                            default:
                                                Console.WriteLine("Seleeccione un numero valido");
                                                break;
                                        }
                                    }

                                    else
                                    {
                                        Console.WriteLine("Ingrese un numero valido");
                                    }
                                } while (!opcionValida); 

                                break;
                        }
                    }
                    break;
                }

                // Turno del monstruo

                Console.WriteLine($"\nEl monstruo ataca a {nombre}!");

                if (Evade.AttemptEvade(character.LCK))
                {
                    Console.WriteLine($"\n{nombre} ha evadido el ataque del monstruo!");
                }
                else
                {
                    double damagemonster = Math.Max((monster.ATK - (character.DEF * 0.3)), 0);
                    character.HP -= damagemonster;

                    Thread.Sleep(1000); // 1 segundo de delay para que el usuario pueda leer

                    Console.WriteLine($"\nHP de {nombre} despues del ataque: {character.HP}");

                    if (character.HP <= 0)
                    {
                        Console.WriteLine($"\n {nombre} ha sido derrotado!\n GAME OVER");
                        return;
                    }
                }
            }
        }
    }
}
