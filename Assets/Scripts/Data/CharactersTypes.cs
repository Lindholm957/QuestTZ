using System;
using System.Collections.Generic;

namespace Data
{
    public static class CharactersTypes
    {
        public enum HeroType
        {
            None,
            Hawk,
            Eagle,
            Gull,
            Owl,
            Raven,
        }
        public enum Fraction
        {
            None,
            Eagles,
            Jackdaws,
            Gulls,
            JayBirds,
            Sparrows,
            Owls,
            Ravens,
            Phoenixes
        }

        public static string GetFractionNames(List<Fraction> fractions)
        {
            List<string> fractionsList = new List<string>();
            foreach (var fraction in fractions)
            {
                switch (fraction) 
                {
                    case Fraction.None:
                        fractionsList.Add("");
                        break;
                    case Fraction.Eagles:
                        fractionsList.Add("Орлы");
                        break;
                    case Fraction.Jackdaws:
                        fractionsList.Add("Галки");
                        break;
                    case Fraction.Gulls:
                        fractionsList.Add("Чайки");
                        break;
                    case Fraction.JayBirds:
                        fractionsList.Add("Сойки");
                        break;
                    case Fraction.Sparrows:
                        fractionsList.Add("Воробьи");
                        break;
                    case Fraction.Owls:
                        fractionsList.Add("Совы");
                        break;
                    case Fraction.Ravens:
                        fractionsList.Add("Вороны");
                        break;
                    case Fraction.Phoenixes:
                        fractionsList.Add("Фениксы");
                        break;
                    default:
                        fractionsList.Add("");
                        break;
                }    
            }

            return String.Join(", ", fractionsList);
        }

        public static string GetHeroName(HeroType heroType)
        {
            switch (heroType)
            {
                case HeroType.None:
                    return "";
                case HeroType.Hawk:
                    return "Ястреб";
                case HeroType.Eagle:
                    return "Орел";
                case HeroType.Gull:
                    return "Чайка";
                case HeroType.Owl:
                    return "Совух";
                case HeroType.Raven:
                    return "Ворон";
                default:
                    return "";
            }
        }
    }
}