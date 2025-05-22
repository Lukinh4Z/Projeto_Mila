using Assets.Scripts;
using ScriptableObjects;
using System.Linq;
using UnityEngine;
using static PlayerShooting;
using static PlayerMovement;

public class PlayerItems : MonoBehaviour
{
    public Item[] Items;
    public PlayerShooting shooting;
    public PlayerMovement playerMovement;

    void Start()
    {
        if(Items != null)
        {
            foreach (var item in Items)
            {
                switch (item.type)
                {
                    case ItemType.WEAPON:
                        for (int i = 0; i < item.weaponModifiers.Length; i++)
                        {
                            ShootingModifiers shootingModifier = shooting.modifiers.FirstOrDefault(m => m.mod == item.weaponModifiers[i].modifier);
                            shootingModifier.value = item.weaponModifiers[i].modValue;   
                        }
                        break;
                    case ItemType.ENGINE:
                        for (int i = 0; i < item.engineModifiers.Length; i++)
                        {
                            PlayerMovementModifiers movementModifier = playerMovement.modifiers.FirstOrDefault(m => m.modifier == item.engineModifiers[i].modifier);
                            movementModifier.value = item.engineModifiers[i].modValue;
                        }
                        break;
                    case ItemType.HULL:
                        Debug.Log(item);
                        break;
                    case ItemType.SHIELD:
                        Debug.Log(item);
                        break;
                    case ItemType.COMPUTER:
                        Debug.Log(item);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
