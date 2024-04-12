public class Evade
{
    public static bool AttemptEvade(double characterLuck)
    {
        // Se calcula la probabilidad de que el personaje evada un ataque del monstruo basado en la suerte (LCK) 
        double evasionProbability = characterLuck * 0.05; /* LCK * 5 / 100. Ejemplo: Thief tiene 16 LCK, lo cual seria 16 * 0.05 = 0.8 = 80% 
                                                            El valor de default seria 10, lo cual significa que la probabilidad base de evadir un ataque es de 50%*/

        Random random = new Random();
        double randomValue = random.NextDouble();

        return randomValue < evasionProbability; // Se evadira el ataque si el valor random es menor que la probabilidad de evasion
    }
}
