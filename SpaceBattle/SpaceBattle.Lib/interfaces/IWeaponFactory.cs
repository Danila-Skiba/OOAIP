namespace SpaceBattle.Lib
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(Vector position, Vector velocity);
    }
}

//фабрика для создания оружия