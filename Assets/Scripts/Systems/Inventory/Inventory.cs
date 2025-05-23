using ScriptableObjects;
using System;
using Systems.Player;
using UnityEngine;

namespace Systems.Inventory
{
    internal class Inventory : MonoBehaviour
    {
        public ShipItem[] shipItems;
        public CharItem[] charItems;
        [SerializeField] Ship ship;
        [SerializeField] Character character;

        public Inventory() { }

        void Start()
        {
            if (shipItems != null && shipItems.Length > 0)
            {
                PlaceItem(shipItems[0]);
            }

            if (charItems != null && charItems.Length > 0)
            {
                PlaceItem(charItems[0]);
            }
        }

        public void PlaceItem(Item item)
        {
            if (item.GetType() == typeof(ShipItem)) 
            {
                ShipItem _item = (ShipItem)item;

                foreach (var shipStatMod in _item.shipStatMods)
                {
                    ShipStatValue currentStat = ship.GetStat(shipStatMod.statType);

                    switch (shipStatMod.operation) 
                    { 
                        case Operation.ADD:
                            currentStat.ModifyStatModBase(shipStatMod.statMod);
                            break;
                        case Operation.ADD_PERCENTAGE:
                            currentStat.ModifyStatModPercent(shipStatMod.statMod);
                            break;
                    }
                }

                //foreach (var shipAtributeMod in _item.shipAtributeMods)
                //{
                //    ShipAtributeValue currentAtribute = ship.GetAtribute(shipAtributeMod.atributeType);
                //    currentAtribute.ModifyAtributeModBase(shipAtributeMod.atributeMod);
                //}
            }

            if (item.GetType() == typeof(CharItem)) 
            {
                Debug.Log("Char Item", item);
            }
        }

        public void RemoveItem(Item item)
        {
            if (item.GetType() == typeof(ShipItem))
            {
                ShipItem _item = (ShipItem)item;

                foreach (var shipStatMod in _item.shipStatMods)
                {
                    ShipStatValue currentStat = ship.GetStat(shipStatMod.statType);

                    switch (shipStatMod.operation)
                    {
                        case Operation.ADD:
                            currentStat.ModifyStatModBase((-1) * shipStatMod.statMod);
                            break;
                        case Operation.ADD_PERCENTAGE:
                            currentStat.ModifyStatModPercent((-1) * shipStatMod.statMod);
                            break;
                    }
                }

                //foreach (var shipAtributeMod in _item.shipAtributeMods)
                //{
                //    ShipAtributeValue currentAtribute = ship.GetAtribute(shipAtributeMod.atributeType);
                //    currentAtribute.ModifyAtributeModBase((-1) * shipAtributeMod.atributeMod);
                //}
            }

            if (item.GetType() == typeof(CharItem))
            {
                Debug.Log("Char Item", item);
            }
        }
    }
}
