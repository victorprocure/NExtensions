﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NExtensions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class EnumerableExtensionTests
    {
        [Test]
        public void Foreach_ShouldExecuteActionForeachItemInEnumerable()
        {
            var enumberable = Enumerable.Range(1, 5);
            var str = "testing";
            Action<int> action = i => str = str + i.ToString(); 

            enumberable.ForEach(action);

            str.Should().Be("testing12345");
        }

        [Test]
        public void None_IsNullSafe()
        {
            IEnumerable<string> strings = null;

            strings.None().Should().BeTrue();
        }

        [Test]
        public void None_ReturnsTrueWhenActuallyIsEmpty()
        {
            string[] strings = {};

            strings.None().Should().BeTrue();
        }

        [Test]
        public void None_ReturnFalseWhenEnumerableContainsValues()
        {
            string[] strings = {"boom"};

            strings.None().Should().BeFalse();
        }

        [Test]
        public void NoneWithPredicate_ReturnsTrueWhenNoItemsMeetPredicate()
        {
            string[] strings = {"one", "two", "three"};

            strings.None(s => s == "four").Should().BeTrue();
        }

        [Test]
        public void NoneWithPredicate_ReturnsFalseWhenItemsMeetPredicate()
        {
            string[] strings = { "one", "two", "three" };

            strings.None(s => s == "two").Should().BeFalse();
        }

    }
}