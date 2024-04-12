public class Monster
{
    public double HP { get; set; }
    public double ATK { get; set; }
    public double DEF { get; set; }

    public Monster()
    {
        HP = 10;
        ATK = 10;
        DEF = 10;
    }

    public void IncreaseStats(int killCount)
    {
        HP += killCount * 0.05; 
        ATK += killCount * 0.05; 
        DEF += killCount * 0.05;
    }
}
