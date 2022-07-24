using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jogoRPG.src.Entities
{
    public class BlackWizard : Hero
    {

        //Custom Hero
        public BlackWizard(string name, int level, int hp, int mp, int baseCost)
        {
            this.Name = name;
            this.Level = level;
            this.HeroType = "Black Wizard";
            this.HP = hp;
            this.MP = mp;
            this.BaseCost = baseCost;
        }

        //Default Hero
        public BlackWizard(string name)
        {
            this.Name = "Topapa";
            this.Level = 1;
            this.HeroType = "Black Wizard";
            this.HP = 385;
            this.MP = 641;
            this.BaseCost = (MP * 10 / 100) + 5;
        }

        public override string Attack()
        {
            return this.Name + " Lançou Magia Negra";
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
                    this.MP += bonus * 3;
                    return this.Name + " Lançou uma Magia Negra perfeita e recuperou " + bonus * 3 + " de MP.";
                }
                return this.Name + " Lançou uma Magia Negra.";

            }


        }
    }
}