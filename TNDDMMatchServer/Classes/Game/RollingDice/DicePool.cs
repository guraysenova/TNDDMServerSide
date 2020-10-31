using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes
{
    class DicePool
    {
        List<Dice> tierOneDices;
        List<Dice> tierTwoDices;
        List<Dice> tierThreeDices;
        List<Dice> tierFourDices;

        int diceUseLimit = 10;

        int diceUseCount = 0;

        public List<DiceSide> Roll(int levelOneDiceAmount = 0, int levelTwoDiceAmount = 0,
                        int levelThreeDiceAmount = 0, int levelFourDiceAmount = 0)
        {
            List<DiceSide> rollResults = new List<DiceSide>();

            for (int i = 0; i < levelOneDiceAmount; i++)
            {
                rollResults.Add(tierOneDices[0].Roll());
            }

            for (int i = 0; i < levelTwoDiceAmount; i++)
            {
                rollResults.Add(tierTwoDices[0].Roll());
            }

            for (int i = 0; i < levelThreeDiceAmount; i++)
            {
                rollResults.Add(tierThreeDices[0].Roll());
            }

            for (int i = 0; i < levelFourDiceAmount; i++)
            {
                rollResults.Add(tierFourDices[0].Roll());
            }

            return rollResults;
        }

        public bool CanRoll(int levelOneDiceAmount = 0, int levelTwoDiceAmount = 0,
                        int levelThreeDiceAmount = 0, int levelFourDiceAmount = 0)
        {
            int availableLevelOneDiceAmount = 0;
            int availableLevelTwoDiceAmount = 0;
            int availableLevelThreeDiceAmount = 0;
            int availableLevelFourDiceAmount = 0;

            for (int i = 0; i < tierOneDices.Count; i++)
            {
                if (!tierOneDices[i].IsUsed)
                {
                    availableLevelOneDiceAmount++;
                }
            }
            for (int i = 0; i < tierTwoDices.Count; i++)
            {
                if (!tierTwoDices[i].IsUsed)
                {
                    availableLevelTwoDiceAmount++;
                }
            }
            for (int i = 0; i < tierThreeDices.Count; i++)
            {
                if (!tierThreeDices[i].IsUsed)
                {
                    availableLevelThreeDiceAmount++;
                }
            }
            for (int i = 0; i < tierFourDices.Count; i++)
            {
                if (!tierFourDices[i].IsUsed)
                {
                    availableLevelFourDiceAmount++;
                }
            }

            return availableLevelOneDiceAmount >= levelOneDiceAmount &&
                   availableLevelTwoDiceAmount >= levelTwoDiceAmount &&
                   availableLevelThreeDiceAmount >= levelThreeDiceAmount &&
                   availableLevelFourDiceAmount >= levelFourDiceAmount;
        }

        public DicePool(int diceUseLimit = 10 , int levelOneDiceAmount = 4, int levelTwoDiceAmount = 4, 
                        int levelThreeDiceAmount = 3 , int levelFourDiceAmount = 3)
        {
            this.diceUseLimit = diceUseLimit;

            tierOneDices = new List<Dice>();
            tierTwoDices = new List<Dice>();
            tierThreeDices = new List<Dice>();
            tierFourDices = new List<Dice>();
            for (int i = 0; i < levelOneDiceAmount; i++)
            {
                tierOneDices.Add(TierOneDice());
            }

            for (int i = 0; i < levelTwoDiceAmount; i++)
            {
                tierTwoDices.Add(TierTwoDice());
            }

            for (int i = 0; i < levelThreeDiceAmount; i++)
            {
                tierThreeDices.Add(TierThreeDice());
            }

            for (int i = 0; i < levelFourDiceAmount; i++)
            {
                tierFourDices.Add(TierFourDice());
            }
        }

        public bool CanUseDice(int tier) // NOT ROLL
        {
            if(diceUseCount == diceUseLimit)
            {
                return false;
            }

            if(tier == 1)
            {
                foreach (var tierOneDice in tierOneDices)
                {
                    if (!tierOneDice.IsUsed)
                    {
                        return true;
                    }
                }
            }
            if (tier == 2)
            {
                foreach (var tierTwoDice in tierTwoDices)
                {
                    if (!tierTwoDice.IsUsed)
                    {
                        return true;
                    }
                }
            }
            if (tier == 3)
            {
                foreach (var tierThreeDice in tierThreeDices)
                {
                    if (!tierThreeDice.IsUsed)
                    {
                        return true;
                    }
                }
            }
            if (tier == 4)
            {
                foreach (var tierFourDice in tierFourDices)
                {
                    if (!tierFourDice.IsUsed)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void UseDice(int tier) // NOT ROLL
        {
            if(diceUseLimit > diceUseCount)
            {
                diceUseCount++;

                if (tier == 1)
                {
                    foreach (var tierOneDice in tierOneDices)
                    {
                        if (!tierOneDice.IsUsed)
                        {
                            tierOneDice.IsUsed = true;
                            break;
                        }
                    }
                }
                if (tier == 2)
                {
                    foreach (var tierTwoDice in tierTwoDices)
                    {
                        if (!tierTwoDice.IsUsed)
                        {
                            tierTwoDice.IsUsed = true;
                            break;
                        }
                    }
                }
                if (tier == 3)
                {
                    foreach (var tierThreeDice in tierThreeDices)
                    {
                        if (!tierThreeDice.IsUsed)
                        {
                            tierThreeDice.IsUsed = true;
                            break;
                        }
                    }
                }
                if (tier == 4)
                {
                    foreach (var tierFourDice in tierFourDices)
                    {
                        if (!tierFourDice.IsUsed)
                        {
                            tierFourDice.IsUsed = true;
                            break;
                        }
                    }
                }
            }
        }

        Dice TierOneDice()
        {
            Dice tierOneDice = new Dice(new List<DiceSide>() 
            {
                new DiceSide(new Crest(CrestType.Defense) , 2),
                new DiceSide(new Crest(CrestType.Movement)),
                new DiceSide(new Crest(CrestType.Summoning)),
                new DiceSide(new Crest(CrestType.Summoning)),
                new DiceSide(new Crest(CrestType.Summoning)),
                new DiceSide(new Crest(CrestType.Summoning))
            });

            return tierOneDice;
        }

        Dice TierTwoDice()
        {
            Dice tierTwoDice = new Dice(new List<DiceSide>()
            {
                new DiceSide(new Crest(CrestType.Attack) , 2),
                new DiceSide(new Crest(CrestType.Movement) , 2),
                new DiceSide(new Crest(CrestType.Spell) , 2),
                new DiceSide(new Crest(CrestType.Summoning , 2)),
                new DiceSide(new Crest(CrestType.Summoning , 2)),
                new DiceSide(new Crest(CrestType.Summoning , 2))
            });

            return tierTwoDice;
        }

        Dice TierThreeDice()
        {
            Dice tierThreeDice = new Dice(new List<DiceSide>()
            {
                new DiceSide(new Crest(CrestType.Attack)),
                new DiceSide(new Crest(CrestType.Movement)),
                new DiceSide(new Crest(CrestType.Movement)),
                new DiceSide(new Crest(CrestType.Trap) , 2),
                new DiceSide(new Crest(CrestType.Summoning , 3)),
                new DiceSide(new Crest(CrestType.Summoning , 3))
            });

            return tierThreeDice;
        }

        Dice TierFourDice()
        {
            Dice tierFourDice = new Dice(new List<DiceSide>()
            {
                new DiceSide(new Crest(CrestType.Attack)),
                new DiceSide(new Crest(CrestType.Defense)),
                new DiceSide(new Crest(CrestType.Movement), 2),
                new DiceSide(new Crest(CrestType.Trap)),
                new DiceSide(new Crest(CrestType.Spell)),
                new DiceSide(new Crest(CrestType.Summoning , 4))
            });

            return tierFourDice;
        }
    }
}
