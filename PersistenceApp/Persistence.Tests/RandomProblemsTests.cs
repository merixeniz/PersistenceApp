﻿using Application.Algorithms.MultiplePointer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Algorithms.RandomStuff;
using Application.Algorithms.Trees;
using FluentAssertions;
using Xunit;

namespace Persistence.Tests
{
    public class RandomProblemsTests
    {
        [Fact]
        public void RandomProblems_ReverseInt()
        {
            var sut = new RandomProblems();
            var result = sut.Reverse(-120);
            var result2 = sut.Reverse(-2147483648);

            result.Should().Be(-21);
            result2.Should().Be(0);
        }

        [Fact]
        public void Trie_Test()
        {
            var trie = new Trie();
            trie.Insert("abc");
            trie.Insert("anno");

            trie.Search("anno").Should().BeTrue();
        }
    }
}