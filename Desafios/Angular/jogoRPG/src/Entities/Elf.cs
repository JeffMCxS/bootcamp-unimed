using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jogoRPG.src.Entities
{
    public class Elf : Hero
    {
        //Custom Hero
        public Elf(string name, int level, int hp, int mp, int baseCost)
        {
            this.Name = name;
            this.Level = level;
            this.HeroType = "Ninja";
            this.HP = hp;
            this.MP = mp;
            this.BaseCost = baseCost;
        }

        //Default Hero
        public Elf(string name)
        {
            this.Name = "Wedge";
            this.Level = 1;
            this.HeroType = "Ninja";
            this.HP = 574;
            this.MP = 89;
            this.BaseCost = (MP * 10 / 100) + 3;
        }

        public override string Attack()
        {
            return this.Name + " Lançou um ataque Melee";
        }


        public string Attack(int bonus)
        {
            int newMP;
            if ((newMP = MPConsume(this.MP, this.BaseCost)) == -1)
            {
                return "Você não possui Mana suficiente para efetuar este ataque!";
            }
            else
            {
                this.MP = newMP;
                if (bonus > 4)
                {
                    return this.Name + " Lançou ataque rápido e deu evasão no ataque do oponente";
                }
                return this.Name + " Lançou um ataque Melee.";
            }
        }
    }
}