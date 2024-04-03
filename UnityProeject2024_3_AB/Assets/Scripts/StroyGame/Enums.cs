using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STORYGAME
{
    public class Enums
    {
        public enum StoryType
        {
            MAIN,
            SUB,
            SERIAL
        }
        public enum EventType
        {
            NONE,
            GoToBattle = 100,
            CheckSTR = 1000,
            CheckDEX,
            CheckCON,//1000 이후로 1001 1002 이런식으로 들어감 
            CheckINT,
            CheckWIN,
            CheckCHA

        }
        public enum ResultType
        {
            ChangeHP,
            ChangeSP,
            AddExperience,
            GoToShop,
            GoToNextStroy,
            GoToRandomStroy,
            GoToEnding
        }
    }
    [System.Serializable]
    public class Stats
    {
        public int hpPoint;
        public int spPoint;

        public int currentHpPoint;
        public int currentSpPoint;
        public int currentXpPoint;

        //기본 스텟 설명
        public int strength;        //STR
        public int dexterity;       //DEX
        public int consitiution;    //CON
        public int intelligence;    //INT
        public int wisdom;          //WIS
        public int charisma;        //CHA


    }
}
