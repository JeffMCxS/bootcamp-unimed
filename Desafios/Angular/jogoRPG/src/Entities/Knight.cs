using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jogoRPG.src.Entities
{
    public class Knight : Hero
    {
        //Custom Hero
        public Knight(string name, int level, int hp, int mp, int baseCost)
        {
            this.Name = name;
            this.Level = level;
            this.HeroType = "Knight";
            this.HP = hp;
            this.MP = mp;
            this.BaseCost = baseCost;
        }

        //Default Hero
        public Knight(string name)
        {
            this.Name = "Arus";
            this.Level = 1;
            this.HeroType = "Knight";
            this.HP = 749;
            this.MP = 72;
            this.BaseCost = (MP * 10 / 100) + 2;
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
                    return this.Name + " Lançou um ataque perfeito e atordou o inimigo por " + bonus / 2 + " segundos.";
                }
                return this.Name + " Lançou uma ataque com bonus de " + bonus + " de dano.";

            }


        }
    }
}