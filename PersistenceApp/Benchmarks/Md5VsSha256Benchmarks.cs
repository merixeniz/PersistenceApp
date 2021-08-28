using Application.Algorithms;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class Md5VsSha256Benchmarks
    {
        private readonly Md5VsSha256 _crypto;
        public Md5VsSha256Benchmarks()
        {
            _crypto = new Md5VsSha256();
        }

        [Benchmark]
        public void Sha256() => _crypto.Sha256();
        
        [Benchmark]
        public void Md5() => _crypto.Md5();

    }
}
