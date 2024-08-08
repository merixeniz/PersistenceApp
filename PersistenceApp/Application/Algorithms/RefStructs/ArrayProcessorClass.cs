namespace Application.Algorithms.RefStructs
{
    public class ArrayProcessorClass
    {
        public int[] ProcessArray(int[] input)
        {
            int[] output = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = input[i] * 2;
            }
            return output;
        }
    }
}
