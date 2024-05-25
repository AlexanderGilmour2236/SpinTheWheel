namespace LuckyWheel.Utils
{
    public struct ObjectWithProbability<T>
    {
        public T Object;
        public float Probability;

        public ObjectWithProbability(T obj, float probability)
        {
            Object = obj;
            Probability = probability;
        }
    }
}