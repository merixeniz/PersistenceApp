using Application.Algorithms;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
            //var summary = BenchmarkRunner.Run<Md5VsSha256Benchmarks>();

            //var root = TreeFactory.CreateTree();

            //Console.WriteLine("DFS: ");
            //var dfs = new DFS();
            //dfs.Traverse(root);

            //Console.WriteLine("BFS: ");
            //var bfs = new BFS();
            //bfs.Traverse(root);

            //var treeTraversals = new TreeTraversals();

            //Console.WriteLine("In order:");
            //treeTraversals.InOrderTraversal(root);

            //Console.WriteLine("Pre order:");
            //treeTraversals.PreOrderTraversal(root);

            //Console.WriteLine("Post order:");
            //treeTraversals.PostOrderTraversal(root);

            IEnumerable<Person> tmp = new List<Person>();
            Dictionary<int, Person> dict = tmp.ToDictionary(key => key.Id);

            var parenthesisProblem = new ParenthesisProblem();
            Console.WriteLine(parenthesisProblem.CheckParenthesis("()[]{}"));
            Console.WriteLine(parenthesisProblem.CheckParenthesis("()[[]{}"));

            Console.WriteLine("Hello World!");
        }
        
    }
}
