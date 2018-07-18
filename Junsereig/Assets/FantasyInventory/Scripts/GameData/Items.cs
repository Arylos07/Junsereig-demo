using System.Collections.Generic;
using Assets.FantasyInventory.Scripts.Data;
using Assets.FantasyInventory.Scripts.Enums;

namespace Assets.FantasyInventory.Scripts.GameData
{
    /// <summary>
    /// Item params are stored here. If you want to store them in any kind of database, please refer to dictionary serialization:
    /// https://docs.unity3d.com/ScriptReference/ISerializationCallbackReceiver.html
    /// </summary>
    public class Items
    {
        public static readonly Dictionary<ItemId, ItemParams> Params = new Dictionary<ItemId, ItemParams>
        {
            {
                ItemId.FireballScroll,
                new ItemParams
                {
                    Type = ItemType.Scroll,
                    Tags = new List<ItemTag> { ItemTag.Magic },
                    Properties = new List<Property> { new Property(PropertyId.Damage, 100)},
                    Price = 1000
                }
            },
            {
                ItemId.Flute,
                new ItemParams
                {
                    Type = ItemType.Loot,
                    Price = 10
                }
            },
            {
                ItemId.Gold,
                new ItemParams
                {
                    Type = ItemType.Currency,
                    Tags = new List<ItemTag> { ItemTag.NotForSale }
                }
            },
            {
                ItemId.HealthPotion,
                new ItemParams
                {
                    Type = ItemType.Potion,
                    Properties = new List<Property> { new Property(PropertyId.Health, 50) },
                    Price = 200
                }
            },
            {
                ItemId.IronSword,
                new ItemParams
                {
                    Type = ItemType.Mainhand,
                    Tags = new List<ItemTag> { ItemTag.Sword, ItemTag.Melee },
                    Properties = new List<Property> {new Property(PropertyId.Tier, 10), new Property(PropertyId.AttackSpeed, -122), new Property(PropertyId.Damage, 122), new Property(PropertyId.Accuracy, 202)},
                    Price = 1000
                }
            },
            {
                ItemId.IvyBow,
                new ItemParams
                {
                    Type = ItemType.Mainhand,
                    Tags = new List<ItemTag> { ItemTag.Bow, ItemTag.TwoHanded, ItemTag.Ranged },
                    Properties = new List<Property> { new Property(PropertyId.Tier, 5), new Property(PropertyId.AttackSpeed, -198), new Property(PropertyId.Damage, 15) },
                    Price = 2000
                }
            },
            {
                ItemId.LeatherArmor,
                new ItemParams
                {
                    Type = ItemType.Torso,
                    Tags = new List<ItemTag> { ItemTag.Armour },
                    Properties = new List<Property> {new Property(PropertyId.Tier, 5), new Property(PropertyId.Armour, 34)},
                    Price = 1000
                }
            },
            {
                ItemId.LeatherHelmet,
                new ItemParams
                {
                    Type = ItemType.Head,
                    Tags = new List<ItemTag> { ItemTag.Armour },
                    Properties = new List<Property> {new Property(PropertyId.Tier, 5), new Property(PropertyId.Armour, 5) },
                    Price = 500
                }
            },
            {
                ItemId.ManaPotion,
                new ItemParams
                {
                    Type = ItemType.Potion,
                    Properties = new List<Property> { new Property(PropertyId.RestoreDivinity, 50) },
                    Price = 200
                }
            },
            {
                ItemId.RoundShield,
                new ItemParams
                {
                    Type = ItemType.Offhand,
                    Tags = new List<ItemTag> { ItemTag.Armour },
                    Properties = new List<Property> {new Property(PropertyId.Tier, 5), new Property(PropertyId.Armour, 10) },
                    Price = 1000
                }
            },
            {
                ItemId.SilverRing,
                new ItemParams
                {
                    Type = ItemType.Ring,
                    Tags = new List<ItemTag> { ItemTag.Armour },
                    Properties = new List<Property> { new Property(PropertyId.Tier, 1), new Property(PropertyId.Armour, 5), new Property(PropertyId.Health, 50) },
                    Price = 500
                }
            },
            {
                ItemId.Spear,
                new ItemParams
                {
                    Type = ItemType.Mainhand,
                    Tags = new List<ItemTag> { ItemTag.Spear, ItemTag.TwoHanded, ItemTag.Melee },
                    Properties = new List<Property> { new Property(PropertyId.Tier, 15), new Property(PropertyId.AttackSpeed, -168), new Property(PropertyId.Damage, 15), },
                    Price = 2500
                }
            },
            {
                ItemId.StoneAmulet,
                new ItemParams
                {
                    Type = ItemType.Neck,
                    Tags = new List<ItemTag> { ItemTag.Armour },
                    Properties = new List<Property> {new Property(PropertyId.Tier, 1), new Property(PropertyId.Armour, 10)},
                    Price = 1000
                }
            },
            {
                ItemId.TwoHandedSword,
                new ItemParams
                {
                    Type = ItemType.Mainhand,
                    Tags = new List<ItemTag> { ItemTag.Sword, ItemTag.TwoHanded, ItemTag.Melee },
                    Properties = new List<Property> { new Property(PropertyId.Tier, 5), new Property(PropertyId.AttackSpeed, -168), new Property(PropertyId.Damage, 223), new Property(PropertyId.Accuracy, 202)},
                    Price = 5000
                }
            },
            {
                ItemId.WoodcutterAxe,
                new ItemParams
                {
                    Type = ItemType.Mainhand,
                    Tags = new List<ItemTag> { ItemTag.Axe },
                    Properties = new List<Property> { new Property(PropertyId.Tier, 5), new Property(PropertyId.AttackSpeed, -168), new Property(PropertyId.Damage, 5) },
                    Price = 100
                }
            },
            {
                ItemId.BronzeSword,
                new ItemParams
                {
                    Type = ItemType.Mainhand,
                    Tags = new List<ItemTag> { ItemTag.Sword, ItemTag.Melee },
                    Properties = new List<Property> {new Property(PropertyId.Tier, 1), new Property(PropertyId.AttackSpeed, -98), new Property(PropertyId.Damage, 61), new Property(PropertyId.Accuracy, 150)},
                    Price = 1000
                }
            }
        };
    }
}