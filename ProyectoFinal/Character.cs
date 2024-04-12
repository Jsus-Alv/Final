public class Character
{
    public double HP { get; set; }
    public double ATK { get; set; }
    public double DEF { get; set; }
    public double INT { get; set; }
    public double LCK { get; set; }

    public double StartingHP { get; set; }
    public double initialHP { get; set; }

    public int HPpotions { get; set; } // Representara la cantidad de potions que el jugador ha encontrado 

    public bool HasSpell { get; set; } // Para saber si el Spell ha sido obtendio o no

    public Character(double startingHP)
    {
        StartingHP = startingHP;
        HP = startingHP;
        initialHP = StartingHP;
        
        HPpotions = 0;
        HasSpell = false;
    }
}

// Todo personaje tendra un maximo de 50 puntos distribuidos