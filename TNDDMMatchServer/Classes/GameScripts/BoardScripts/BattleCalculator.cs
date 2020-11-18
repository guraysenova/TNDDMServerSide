using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes.GameScripts.BoardScripts
{
    class BattleCalculator
    {
        public List<BattleEvent> Calculate(Agent attacker , Agent defender) // later get attack spell ids etc but dont care atm for alpha
        {
            List<BattleEvent> battleEvents = new List<BattleEvent>();
            int damageGiven = 0;
            if(attacker.MonsterData.AttackPower > defender.MonsterData.DefensePower)
            {
                damageGiven = attacker.MonsterData.AttackPower;
            }
            battleEvents.Add(new BattleEvent(BattleEventType.Hit, damageGiven, attacker.ID, defender.ID));
            return battleEvents;
        }
    }
    public class BattleEvent
    {
        public BattleEventType BattleEventType { get; }
        public int DamageGiven { get; }
        public int AttackerID { get; }
        public int DefenderID { get; }
        
        public BattleEvent(BattleEventType battleEventType , int damageGiven , int attackerID , int defenderID)
        {
            BattleEventType = battleEventType;
            DamageGiven = damageGiven;
            AttackerID = attackerID;
            DefenderID = defenderID;
        }
    }
    public enum BattleEventType
    {
        Hit = 0,
        ActivatePassive = 1
    }
}
