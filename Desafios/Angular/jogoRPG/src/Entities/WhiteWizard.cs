using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jogoRPG.src.Entities
{
    public class WhiteWizard : Hero
    {
        //Custom Hero
        public WhiteWizard(string name, int level, int hp, int mp, int baseCost)
        {
            this.Name = name;
            this.Level = level;
            this.HeroType = "White Wizard";
            this.HP = hp;
            this.MP = mp;
            this.BaseCost = baseCost;
        }

        //Default Hero
        public WhiteWizard(string name)
        {
            this.Name = "Jenica";
            this.Level = 1;
            this.HeroType = "White Wizard";
            this.HP = 601;
            this.MP = 482;
            this.BaseCost = (MP * 10 / 100) + 2;
        }



        public override string Attack()
        {
            return this.Name + " Lançou Magia";
        }

        public string Attack(int Bonus)
        {
            int newMP;
            if ((newMP = MPConsume(this.MP, this.BaseCost)) == -1)
            {
                return "Você não possui Mana suficiente para efetuar este ataque!";
            }
            else
            {
                this.MP = newMP;
                if (Bonus > 6)
                {
                    return this.Name + " Lançou Magia com dano crítico, com bonus de " + Bonus + " de dano mágico.";
                }
                else
                {
                    return this.Name + " Lançou Magia com bonus base de " + Bonus + ".";
                }
            }

        }
    }
}