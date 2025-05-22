using System;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Player
{
    public enum CharacterAtribute
    {
        //Determines item/ability usage
        Technology,
        //Determines ship repairs
        Engineering,
        //Determines how good they fight
        Fighting,
        //Determines Life
        Spirit
    }

    [Serializable]
    public class CharacterAtributeValue
    {
        public CharacterAtribute atributeType;
        public int atributeValue;

        public CharacterAtributeValue(CharacterAtribute atributeType, int atributeValue = 0)
        {
            this.atributeType = atributeType;
            this.atributeValue = atributeValue;
        }   
    }

    [Serializable]
    public class CharacterAtributeGroup
    {
        public List<CharacterAtributeValue> atributeValues;

        public CharacterAtributeGroup()
        {
            atributeValues = new List<CharacterAtributeValue>();
            atributeValues.Add(new CharacterAtributeValue(CharacterAtribute.Technology));
            atributeValues.Add(new CharacterAtributeValue(CharacterAtribute.Engineering));
            atributeValues.Add(new CharacterAtributeValue(CharacterAtribute.Spirit));
            atributeValues.Add(new CharacterAtributeValue(CharacterAtribute.Fighting));
        }
    }

    public class Character : MonoBehaviour
    {
        [SerializeField] CharacterAtributeGroup characterAtributes;

        public void Start()
        {
            characterAtributes = new CharacterAtributeGroup();
        }
    }

}
