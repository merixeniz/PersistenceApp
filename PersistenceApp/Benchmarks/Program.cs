using Application.Algorithms;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
            var summary = BenchmarkRunner.Run<Md5VsSha256Benchmarks>();
        }
        
    }
}
