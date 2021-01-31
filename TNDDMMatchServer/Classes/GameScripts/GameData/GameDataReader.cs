using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TNDDMMatchServer.Classes.GameScripts.GameData
{
    class GameDataReader
    {
        GameData gameData = new GameData();

        Dictionary<string, Monster> monsterDictionary = new Dictionary<string, Monster>();
        Dictionary<string, Trap> trapDictionary = new Dictionary<string, Trap>();
        Dictionary<string, Spell> spellDictionary = new Dictionary<string, Spell>();
        Dictionary<string, Ability> abilityDictionary = new Dictionary<string, Ability>();

        public GameDataReader()
        {
            string json = File.ReadAllText(@"C:\Users\Guray\Documents\Projects\Guray\TNDDMServerSide\TNDDMMatchServer\Classes\GameScripts\GameData\DataSamples.json");
            gameData = JsonConvert.DeserializeObject<GameData>(json);
            foreach (Monster monster in gameData.Monsters)
            {
                monsterDictionary.Add(monster.MonsterID, monster);
            }
            foreach (Trap trap in gameData.Traps)
            {
                trapDictionary.Add(trap.TrapID, trap);
            }
            foreach (Spell spell in gameData.Spells)
            {
                spellDictionary.Add(spell.SpellID, spell);
            }
            foreach (Ability ability in gameData.Abilities)
            {
                abilityDictionary.Add(ability.AbilityID, ability);
            }
        }

        public GameData GameData
        {
            get
            {
                return gameData;
            }
        }

        public Monster GetMonster(string id)
        {
            Monster monster = null;
            if(monsterDictionary.TryGetValue(id , out monster))
            {
                return monster;
            }
            else
            {
                Console.WriteLine("WRONG MONSTER ID GIVEN : " + id);
                return monster;
            }
        }

        public Spell GetSpell(string id)
        {
            Spell spell = null;
            if(spellDictionary.TryGetValue(id , out spell))
            {
                return spell;
            }
            else
            {
                Console.WriteLine("WRONG SPELL ID GIVEN : " + id);
                return spell;
            }
        }

        public Trap GetTrap(string id)
        {
            Trap trap = null;
            if (trapDictionary.TryGetValue(id, out trap))
            {
                return trap;
            }
            else
            {
                Console.WriteLine("WRONG TRAP ID GIVEN : " + id);
                return trap;
            }
        }

        public Ability GetAbility(string id)
        {
            Ability ability = null;
            if (abilityDictionary.TryGetValue(id, out ability))
            {
                return ability;
            }
            else
            {
                Console.WriteLine("WRONG ABILITY ID GIVEN : " + id);
                return ability;
            }
        }
    }
}
