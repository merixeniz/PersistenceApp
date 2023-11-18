using Application.Algorithms;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Algorithms;
using Xunit;

namespace Persistence.Tests
{
    public class TreeTraverseTests
    {
        [Fact]
        public void DfsRecursiveTraverseTest()
        {
            Node root = BuildSampleTree();
            string expectedOutput = "ABDEFC";
            string actualOutput = RunTraverseAndCaptureOutput(() => DFS.Traverse(root));
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void DfsIterativeTraverseTest()
        {
            Node root = BuildSampleTree();
            string expectedOutput = "ABDEFC";
            string actualOutput = RunTraverseAndCaptureOutput(() => DFS.TraverseIterative(root));
            actualOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void BfsTest()
        {
            Node root = BuildSampleTree();
            string expectedOutput = "ABCDEF";
            string actualOutput = RunTraverseAndCaptureOutput(() => BFS.Traverse(root));
            actualOutput.Should().Be(expectedOutput);
        }

        private Node BuildSampleTree()
        {
            // Sample tree:
            //       A
            //      / \
            //     B   C
            //    / \
            //   D   E
            //        \
            //         F

            Node d = new Node("D");
            Node e = new Node("E", null, new Node("F"));
            Node b = new Node("B", d, e);
            Node c = new Node("C");
            Node root = new Node("A", b, c);

            return root;
        }

        private string RunTraverseAndCaptureOutput(Action action)
        {
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            action.Invoke();
            return consoleOutput
                .ToString()
                .Replace("\n", "")
                .Replace("\r", "")
                .Replace("\\c", "")
                .Trim();
        }
    }
}
