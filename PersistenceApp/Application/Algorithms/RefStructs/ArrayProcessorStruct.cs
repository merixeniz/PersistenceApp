using System;

namespace Application.Algorithms.RefStructs
{
    public ref struct ArrayProcessorStruct
    {
        private Span<int> _data;

        public ArrayProcessorStruct(Span<int> data)
        {
            _data = data;
        }

        public void Process()
        {
            for (int i = 0; i < _data.Length; i++)
            {
                _data[i] *= 2;
            }
        }
    }
}
