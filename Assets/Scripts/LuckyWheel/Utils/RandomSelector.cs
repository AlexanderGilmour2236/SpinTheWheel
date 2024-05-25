using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace LuckyWheel.Utils
{
    public class RandomSelector
    {
        public static ObjectWithProbability<T> GetRandomObject<T>(List<ObjectWithProbability<T>> objects)
        {
            float totalProbability = 0f;

            foreach (ObjectWithProbability<T> obj in objects)
            {
                totalProbability += obj.Probability;
            }

            float randomPoint = Random.value * totalProbability;

            foreach (ObjectWithProbability<T> obj in objects)
            {
                if (randomPoint < obj.Probability)
                {
                    return obj;
                }

                randomPoint -= obj.Probability;
            }

            throw new IndexOutOfRangeException("Can't get random object from a list");
        }
    }
}