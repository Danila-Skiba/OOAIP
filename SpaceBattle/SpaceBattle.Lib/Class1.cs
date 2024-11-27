namespace SpaceBattle.Lib;

public class SomeClass
{
    public int CalculateDamage(int attack, int defense)
    {
        return Math.Max(0, attack - defense);
    }
}
