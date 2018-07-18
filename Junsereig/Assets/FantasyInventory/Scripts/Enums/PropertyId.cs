namespace Assets.FantasyInventory.Scripts.Enums
{
    /// <summary>
    /// Add new item attributes here.
    /// Use constant integer values for enums to avoid data distortion when adding/removing new values.
    /// </summary>
    public enum PropertyId
    {
        Damage          = 0,
        Accuracy        = 1,
        Armour          = 2,
        Health          = 3,
        Divinity        = 4,
        Quality         = 5,
        Tier            = 6,
        Heal            = 7,
        RestoreDivinity = 8,
        AttackSpeed     = 9     //enter value to divide by 100 to create correct attack speed.
    }
}