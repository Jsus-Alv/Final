public class ItemFinding
{
    public enum ItemType
    {
        HP_Potion,
        Armor, 
        Spell,
        Skill_Point
    }

    private static bool spellObtained = false; // Spell solo puede ser obtenido una vez, esto revisara si ya se ha dado el caso

    public static ItemType? FindItem(double characterLuck)
    {
        // Se calcular la probabilidad de encontrar un item basado en la suerte (LCK)
        double chanceOfFindingItem = characterLuck * 0.04; /* Habra un 40% de probabilidad como base de que despues de cada batalla en jugador encuentre un item.  
                                                                Aumentara o disminuira dependiendo del valor de LCK, si es mayor o menor de el default 10.*/

        Random random = new Random();
        double randomValue = random.NextDouble();

        if (randomValue < chanceOfFindingItem)
        {
            double randomItemValue = random.NextDouble();

            if (randomItemValue < 0.55) // HP_Potion tendra un 55% de drop rate
            {
                return ItemType.HP_Potion;
            }
            else if (randomItemValue < 0.85) // Armor tendra un 30% de drop rate 
            {
                return ItemType.Armor;
            }
            else if (!spellObtained && randomItemValue < 0.95) // Spell tendra un 10% de drop rate
            {
                spellObtained = true; // Se cambia a true para que no se pueda obtener mas de una vez
                return ItemType.Spell;
            }
            else
            {
                return ItemType.Skill_Point; // Skill point solo tendra un 5% de drop rate y sera el item mas raro
            }
        }

        // No se encuentra un item 
        return null;
    }
}
