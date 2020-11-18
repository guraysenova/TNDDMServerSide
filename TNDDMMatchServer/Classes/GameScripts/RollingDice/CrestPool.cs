using System;
using System.Collections.Generic;
using System.Text;

namespace TNDDMMatchServer.Classes
{
    class CrestPool
    {
        List<PlayerCrest> crests;

        public CrestPool()
        {
            crests = new List<PlayerCrest>()
            {
                new PlayerCrest(new Crest(CrestType.Attack)),
                new PlayerCrest(new Crest(CrestType.Defense)),
                new PlayerCrest(new Crest(CrestType.Movement)),
                new PlayerCrest(new Crest(CrestType.Spell)),
                new PlayerCrest(new Crest(CrestType.Trap)),
                new PlayerCrest(new Crest(CrestType.Summoning , 1)),
                new PlayerCrest(new Crest(CrestType.Summoning , 2)),
                new PlayerCrest(new Crest(CrestType.Summoning , 3)),
                new PlayerCrest(new Crest(CrestType.Summoning , 4))
            };
        }

        public bool HasCrests(CrestType crestType , int crestLevel , int crestAmount)
        {
            foreach (PlayerCrest crest in crests)
            {
                if(crest.IsCrest(crestType , crestLevel) && crest.Amount >= crestAmount)
                {
                    return true;
                }
                if(crest.IsCrest(crestType, crestLevel) && crest.Amount < crestAmount)
                {
                    return false;
                }
            }
            return false;
        }

        public void AddCrests(List<DiceSide> rollResults)
        {
            foreach (DiceSide diceSide in rollResults)
            {
                foreach (var crest in crests)
                {
                    if(crest.IsCrest(diceSide.Crest.CrestType , diceSide.Crest.CrestLevel))
                    {
                        crest.Amount += diceSide.Amount;
                    }
                }
            }
        }

        public void AddCrests(CrestType crestType, int crestLevel, int crestAmount)
        {
            foreach (var crest in crests)
            {
                if (crest.IsCrest(crestType, crestLevel))
                {
                    crest.Amount += crestAmount;
                }
            }
        }

        public void RemoveCrests(CrestType crestType , int crestLevel , int crestAmount)
        {
            foreach (var crest in crests)
            {
                if (crest.IsCrest(crestType, crestLevel))
                {
                    crest.Amount -= crestAmount;
                }
            }
        }
        
        #region Crest Properties
        public PlayerCrest AttackCrests
        {
            get
            {
                return crests[0];
            }
            set
            {
                crests[0] = value;
            }
        }

        public PlayerCrest DefenseCrests
        {
            get
            {
                return crests[1];
            }
            set
            {
                crests[1] = value;
            }
        }

        public PlayerCrest MovementCrests
        {
            get
            {
                return crests[2];
            }
            set
            {
                crests[2] = value;
            }
        }

        public PlayerCrest SpellCrests
        {
            get
            {
                return crests[3];
            }
            set
            {
                crests[3] = value;
            }
        }

        public PlayerCrest TrapCrests
        {
            get
            {
                return crests[4];
            }
            set
            {
                crests[4] = value;
            }
        }

        public PlayerCrest T1SummoningCrests
        {
            get
            {
                return crests[5];
            }
            set
            {
                crests[5] = value;
            }
        }

        public PlayerCrest T2SummoningCrests
        {
            get
            {
                return crests[6];
            }
            set
            {
                crests[6] = value;
            }
        }

        public PlayerCrest T3SummoningCrests
        {
            get
            {
                return crests[7];
            }
            set
            {
                crests[7] = value;
            }
        }

        public PlayerCrest T4SummoningCrests
        {
            get
            {
                return crests[8];
            }
            set
            {
                crests[8] = value;
            }
        }
        #endregion
    }
}
