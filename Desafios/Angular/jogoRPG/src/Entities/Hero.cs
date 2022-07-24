using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jogoRPG.src.Entities
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string HeroType { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int BaseCost { get; set; }

        public Hero(string name, int level, string heroType, int hp, int mp, int baseCost)
        {
            this.Name = name;
            this.Level = level;
            this.HeroType = heroType;
            this.HP = hp;
            this.MP = mp;
            this.BaseCost = baseCost;
        }

        public Hero() { }

        public override string ToString()
        {
            return this.Name + " " + this.Level + " " + this.HeroType;
        }

        public virtual string Attack() //Virtual faz permitir override
        {
            return this.Name + " Atacou com sua espada.";
        }

        public virtual int MPConsume(int mp, int baseCost)
        {
            if (baseCost <= mp)
            {
                mp -= baseCost;
                System.Console.WriteLine("Consumiu " + baseCost + " de Mana.");
                System.Console.WriteLine("Possui " + mp + " de Mana restante.");
                return mp;
            }
            else
            {
                return -1;
            }


        }
    }
}