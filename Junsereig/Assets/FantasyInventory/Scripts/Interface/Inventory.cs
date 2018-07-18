using System.Collections.Generic;
using System.Linq;
using Assets.FantasyInventory.Scripts.Data;
using Assets.FantasyInventory.Scripts.Enums;
using Assets.FantasyInventory.Scripts.GameData;
using Assets.FantasyInventory.Scripts.Interface.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FantasyInventory.Scripts.Interface
{
    /// <summary>
    /// High-level inventory inverface.
    /// </summary>
    public class Inventory : ItemWorkspace
    {
        public BasicAttack basicAttack;
        public CombatStats combatStats;
        public Equipment Equipment;
        public ScrollInventory Bag;
        public Button EquipButton;
        public Button RemoveButton;
        public AudioSource AudioSource;
        public AudioClip EquipSound;
        public AudioClip RemoveSound;
        public GameObject ItemPanel;
        public float infoDelay;
        private float timer;
        private bool PanelActive;
        public GameObject EquipFail;
        public bool canEquip = false;

        /// <summary>
        /// Initialize owned items (just for example).
        /// </summary>
        public void Awake()
        {
            PanelActive = false;
            var inventory = new List<Item>
            {
                new Item(ItemId.FireballScroll, 1),
                new Item(ItemId.Flute, 2),
                new Item(ItemId.Gold, 2000),
                new Item(ItemId.HealthPotion, 10),
                new Item(ItemId.IronSword, 1),
                new Item(ItemId.IvyBow, 1),
                new Item(ItemId.LeatherArmor, 1),
                new Item(ItemId.LeatherHelmet, 1),
                new Item(ItemId.ManaPotion, 2),
                new Item(ItemId.RoundShield, 1),
                new Item(ItemId.SilverRing, 1),
                new Item(ItemId.Spear, 1),
                new Item(ItemId.StoneAmulet, 1),
                new Item(ItemId.TwoHandedSword, 1),
                new Item(ItemId.WoodcutterAxe, 2),
                new Item(ItemId.BronzeSword, 1),
            };

            var equipped = new List<Item>();

            Bag.Initialize(ref inventory);
            Equipment.Initialize(ref equipped);
        }

        protected void Start()
        {
            Reset();
            EquipButton.interactable = RemoveButton.interactable = false;
            // TODO: Assigning static callbacks. Don't forget to set null values when UI will be closed. You can also use events instead.
            InventoryItem.OnItemSelected = SelectItem;
            InventoryItem.OnDragStarted = SelectItem;
            InventoryItem.OnDragCompleted = InventoryItem.OnDoubleClick = item => { if (Bag.Items.Contains(item)) Equip(); else Remove(); };
        }

        public void SelectItem(Item item)
        {
            SelectItem(item.Id);
        }

        public void SelectItem(ItemId itemId)
        {
            SelectedItem = itemId;
            SelectedItemParams = Items.Params[itemId];
            ItemPanel.SetActive(true);
            PanelActive = true;
            timer = infoDelay;
            ItemInfo.Initialize(SelectedItem, SelectedItemParams);
            Refresh();
        }

        void Update()
        {
            if(PanelActive == true)
            {
                timer -= Time.deltaTime;
                if(timer <= 0)
                {
                    ItemPanel.SetActive(false);
                    PanelActive = false;
                }
            }
        }

        public void Equip()
        {
            var equipped = Equipment.Items.LastOrDefault(i => i.Params.Type == SelectedItemParams.Type);
            if (SelectedItemParams.Tags.Contains(ItemTag.Ranged))
            {
                foreach (var attribute in SelectedItemParams.Properties)
                {
                    if (attribute.Id.ToString() == "Tier")
                    {
                        if (attribute.Value <= GameObject.FindGameObjectWithTag("Player").GetComponent<Bowmaster>().curLevel)
                        {
                            canEquip = true;
                            if (equipped != null)
                            {
                                AutoRemove(SelectedItemParams.Type, Equipment.Slots.Count(i => i.ItemType == SelectedItemParams.Type));
                            }

                            if (SelectedItemParams.Tags.Contains(ItemTag.TwoHanded))
                            {
                                var shield = Equipment.Items.SingleOrDefault(i => i.Params.Type == ItemType.Offhand);

                                if (shield != null)
                                {
                                    MoveItem(shield, Equipment, Bag);
                                }
                            }
                            else if (SelectedItemParams.Type == ItemType.Offhand)
                            {
                                var weapon2H = Equipment.Items.SingleOrDefault(i => i.Params.Tags.Contains(ItemTag.TwoHanded));

                                if (weapon2H != null)
                                {
                                    MoveItem(weapon2H, Equipment, Bag);
                                }
                            }

                            //foreach (var attribute in SelectedItemParams.Properties)
                            //{
                            //    if (attribute.Id.ToString() == "Armour")
                            //    {
                            //        print(attribute.Id);
                            //    }
                            //}

                            MoveItem(SelectedItem, Bag, Equipment);
                            AudioSource.PlayOneShot(EquipSound);
                        }
                        else
                        {
                            canEquip = false;
                            EquipFail.GetComponent<Text>().text = "You need " + attribute.Value + " Bowmastery to equip this item!";
                            EquipFail.SetActive(true);
                            Invoke("HideNotice", 3);
                        }
                    }

                    if (attribute.Id.ToString() == "AttackSpeed" && canEquip == true)
                    {
                        basicAttack.CalculateAttackSpeed((float)((float)attribute.Value / 100));
                    }

                    if (attribute.Id.ToString() == "Damage" && canEquip == true)
                    {
                        combatStats.Damage = attribute.Value;
                        combatStats.Style = "range";
                    }
                    if (attribute.Id.ToString() == "Accuracy" && canEquip == true)
                    {
                        combatStats.Accuracy = attribute.Value;
                    }
                }
            }
            else if (SelectedItemParams.Tags.Contains(ItemTag.Melee))
            {
                foreach (var attribute in SelectedItemParams.Properties)
                {
                    if (attribute.Id.ToString() == "Tier")
                    {
                        if (attribute.Value <= GameObject.FindGameObjectWithTag("Player").GetComponent<Blademaster>().curLevel)
                        {
                            canEquip = true;

                            if (equipped != null)
                            {
                                AutoRemove(SelectedItemParams.Type, Equipment.Slots.Count(i => i.ItemType == SelectedItemParams.Type));
                            }

                            if (SelectedItemParams.Tags.Contains(ItemTag.TwoHanded))
                            {
                                var shield = Equipment.Items.SingleOrDefault(i => i.Params.Type == ItemType.Offhand);

                                if (shield != null)
                                {
                                    MoveItem(shield, Equipment, Bag);
                                }
                            }
                            else if (SelectedItemParams.Type == ItemType.Offhand)
                            {
                                var weapon2H = Equipment.Items.SingleOrDefault(i => i.Params.Tags.Contains(ItemTag.TwoHanded));

                                if (weapon2H != null)
                                {
                                    MoveItem(weapon2H, Equipment, Bag);
                                }
                            }

                            MoveItem(SelectedItem, Bag, Equipment);
                            AudioSource.PlayOneShot(EquipSound);
                        }
                        else
                        {
                            canEquip = false;
                            EquipFail.GetComponent<Text>().text = "You need " + attribute.Value + " Blademastery to equip this item!";
                            EquipFail.SetActive(true);
                            Invoke("HideNotice", 3);
                        }
                    }
                    if (attribute.Id.ToString() == "AttackSpeed" && canEquip == true)
                    {
                        basicAttack.CalculateAttackSpeed((float)((float)attribute.Value / 100));
                    }

                    if (attribute.Id.ToString() == "Damage" && canEquip == true)
                    {
                        combatStats.Damage = attribute.Value;
                        combatStats.Style = "melee";
                    }
                    if (attribute.Id.ToString() == "Accuracy" && canEquip == true)
                    {
                        combatStats.Accuracy = attribute.Value;
                    }

                }
            }
            else if (SelectedItemParams.Tags.Contains(ItemTag.Magic))
            {
                foreach (var attribute in SelectedItemParams.Properties)
                {
                    if (attribute.Id.ToString() == "Tier")
                    {
                        if (attribute.Value <= GameObject.FindGameObjectWithTag("Player").GetComponent<Runemaster>().curLevel)
                        {
                            canEquip = true;

                            if (equipped != null)
                            {
                                AutoRemove(SelectedItemParams.Type, Equipment.Slots.Count(i => i.ItemType == SelectedItemParams.Type));
                            }

                            if (SelectedItemParams.Tags.Contains(ItemTag.TwoHanded))
                            {
                                var shield = Equipment.Items.SingleOrDefault(i => i.Params.Type == ItemType.Offhand);

                                if (shield != null)
                                {
                                    MoveItem(shield, Equipment, Bag);
                                }
                            }
                            else if (SelectedItemParams.Type == ItemType.Offhand)
                            {
                                var weapon2H = Equipment.Items.SingleOrDefault(i => i.Params.Tags.Contains(ItemTag.TwoHanded));

                                if (weapon2H != null)
                                {
                                    MoveItem(weapon2H, Equipment, Bag);
                                }
                            }

                            //foreach (var attribute in SelectedItemParams.Properties)
                            //{
                            //    if (attribute.Id.ToString() == "Armour")
                            //    {
                            //        print(attribute.Id);
                            //    }
                            //}

                            MoveItem(SelectedItem, Bag, Equipment);
                            AudioSource.PlayOneShot(EquipSound);
                        }
                        else
                        {
                            canEquip = false;
                            EquipFail.GetComponent<Text>().text = "You need " + attribute.Value + " Runemastery to equip this item!";
                            EquipFail.SetActive(true);
                            Invoke("HideNotice", 3);
                        }
                    }
                    if (attribute.Id.ToString() == "AttackSpeed" && canEquip == true)
                    {
                        basicAttack.CalculateAttackSpeed((float)((float)attribute.Value / 100));
                    }

                    if (attribute.Id.ToString() == "Damage" && canEquip == true)
                    {
                        combatStats.Damage = attribute.Value;
                        combatStats.Style = "magic";
                    }
                    if(attribute.Id.ToString() == "Accuracy" && canEquip == true)
                    {
                        combatStats.Accuracy = attribute.Value;
                    }
                    
                }
            }
            else if (SelectedItemParams.Tags.Contains(ItemTag.Armour))
            {
                foreach (var attribute in SelectedItemParams.Properties)
                {
                    if (attribute.Id.ToString() == "Tier")
                    {
                        if (attribute.Value <= GameObject.FindGameObjectWithTag("Player").GetComponent<Defence>().curLevel)
                        {
                            canEquip = true;

                            if (equipped != null)
                            {
                                AutoRemove(SelectedItemParams.Type, Equipment.Slots.Count(i => i.ItemType == SelectedItemParams.Type));
                            }

                            if (SelectedItemParams.Tags.Contains(ItemTag.TwoHanded))
                            {
                                var shield = Equipment.Items.SingleOrDefault(i => i.Params.Type == ItemType.Offhand);

                                if (shield != null)
                                {
                                    MoveItem(shield, Equipment, Bag);
                                }
                            }
                            else if (SelectedItemParams.Type == ItemType.Offhand)
                            {
                                var weapon2H = Equipment.Items.SingleOrDefault(i => i.Params.Tags.Contains(ItemTag.TwoHanded));

                                if (weapon2H != null)
                                {
                                    MoveItem(weapon2H, Equipment, Bag);
                                }
                            }
                            MoveItem(SelectedItem, Bag, Equipment);
                            AudioSource.PlayOneShot(EquipSound);
                        }

                        else if (attribute.Value > GameObject.FindGameObjectWithTag("Player").GetComponent<Defence>().curLevel)
                        {
                            canEquip = false;
                            EquipFail.GetComponent<Text>().text = "You need " + attribute.Value + " Defence to equip this item!";
                            EquipFail.SetActive(true);
                            Invoke("HideNotice", 3);
                        }
                    }
                    if (attribute.Id.ToString() == "Armour" && canEquip == true)
                    {
                        combatStats.ArmourRating += attribute.Value;
                    }
                }
            }
            else
            {
                if (equipped != null)
                {
                    AutoRemove(SelectedItemParams.Type, Equipment.Slots.Count(i => i.ItemType == SelectedItemParams.Type));
                }

                if (SelectedItemParams.Tags.Contains(ItemTag.TwoHanded))
                {
                    var shield = Equipment.Items.SingleOrDefault(i => i.Params.Type == ItemType.Offhand);

                    if (shield != null)
                    {
                        MoveItem(shield, Equipment, Bag);
                    }
                }
                else if (SelectedItemParams.Type == ItemType.Offhand)
                {
                    var weapon2H = Equipment.Items.SingleOrDefault(i => i.Params.Tags.Contains(ItemTag.TwoHanded));

                    if (weapon2H != null)
                    {
                        MoveItem(weapon2H, Equipment, Bag);
                    }

                    //foreach (var attribute in SelectedItemParams.Properties)
                    //{
                    //    if (attribute.Id.ToString() == "Armour")
                    //    {
                    //        print(attribute.Id);
                    //    }
                    //}

                    MoveItem(SelectedItem, Bag, Equipment);
                    AudioSource.PlayOneShot(EquipSound);
                    canEquip = true;
                }
            }

            //refresh targeters
            if (basicAttack.canAttack == true)
            {
                combatStats.DeactivateWeapons();
                combatStats.ActivateWeapons();
            }
        }

        private void HideNotice()
        {
            EquipFail.SetActive(false);
        }

        public void Remove()
        {
            if (Bag.Items.Count() < 28)
            {
                MoveItem(SelectedItem, Equipment, Bag);
                SelectItem(Equipment.Items.FirstOrDefault(i => i.Id == SelectedItem) ?? Bag.Items.Single(i => i.Id == SelectedItem));
                AudioSource.PlayOneShot(RemoveSound);

                foreach (var attribute in SelectedItemParams.Properties)
                {
                    if (SelectedItemParams.Tags.Contains(ItemTag.Ranged))
                    {
                        if (attribute.Id.ToString() == "AttackSpeed")
                        {
                            basicAttack.CalculateAttackSpeed((float)(((float)attribute.Value / 100) * -1.0f));
                        }

                        if (attribute.Id.ToString() == "Damage")
                        {
                            combatStats.Damage -= attribute.Value;
                            combatStats.Style = "melee";
                        }
                    }
                    else if (SelectedItemParams.Tags.Contains(ItemTag.Melee))
                    {
                        if (attribute.Id.ToString() == "AttackSpeed")
                        {
                            basicAttack.CalculateAttackSpeed((float)(((float)attribute.Value / 100) * -1.0f));
                        }

                        if (attribute.Id.ToString() == "Damage")
                        {
                            combatStats.Damage -= attribute.Value;
                            combatStats.Style = "melee";
                        }
                    }
                    else if (SelectedItemParams.Tags.Contains(ItemTag.Magic))
                    {
                        if (attribute.Id.ToString() == "AttackSpeed")
                        {
                            basicAttack.CalculateAttackSpeed((float)(((float)attribute.Value / 100) * -1.0f));
                        }

                        if (attribute.Id.ToString() == "Damage")
                        {
                            combatStats.Damage -= attribute.Value;
                            combatStats.Style = "melee";
                        }
                    }
                    else if (SelectedItemParams.Tags.Contains(ItemTag.Armour))
                    {
                        if (attribute.Id.ToString() == "Armour")
                        {
                            combatStats.ArmourRating -= attribute.Value;
                        }
                    }
                }
            }
            else
            {
                Debug.Log("Debug: Not enough room in inventory");
            }

            //refresh targeters
            if (basicAttack.canAttack == true)
            {
                combatStats.DeactivateWeapons();
                combatStats.ActivateWeapons();
            }
        }

        public override void Refresh()
        {
            if (SelectedItem == ItemId.Undefined)
            {
                ItemInfo.Reset();
                EquipButton.interactable = RemoveButton.interactable = false;
            }
            else
            {
                if (CanEquip())
                {
                    EquipButton.interactable = Bag.Items.Any(i => i.Id == SelectedItem)
                        && Equipment.Slots.Count(i => i.ItemType == SelectedItemParams.Type) > Equipment.Items.Count(i => i.Id == SelectedItem);
                    RemoveButton.interactable = Equipment.Items.Any(i => i.Id == SelectedItem);
                    ItemInfo.Price.enabled = !SelectedItemParams.Tags.Contains(ItemTag.NotForSale);
                }
                else
                {
                    EquipButton.interactable = RemoveButton.interactable = false;
                }
            }
        }

        private bool CanEquip()
        {
            return Equipment.Slots.Any(i => i.ItemType == SelectedItemParams.Type && i.ItemTags.All(j => SelectedItemParams.Tags.Contains(j)));
        }

        /// <summary>
        /// Automatically removes items if target slot is busy.
        /// </summary>
        private void AutoRemove(ItemType itemType, int max)
        {
            var items = Equipment.Items.Where(i => i.Params.Type == itemType).ToList();
            long sum = 0;

            foreach (var p in items)
            {
                sum += p.Count;
            }

            if (sum == max)
            {
                MoveItem(items.LastOrDefault(i => i.Id != SelectedItem) ?? items.Last(), Equipment, Bag);
            }
        }
    }
}