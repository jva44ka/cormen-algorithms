﻿using System.Collections.Generic;
using System.Linq;
using CLRS.Core.Structures;
using CLRS.Tests.Generators;
using CLRS.Tests.Stubs;
using NUnit.Framework;

namespace CLRS.Tests.Tests.Structures
{
    [TestFixture(Category = "Data Structures")]
    public class HashTableTests
    {
        [Test]
        public void Add()
        {
            var key1 = "Ключик 8495485";
            var value1 = "Значение №8493448";
            var key2 = "Ключик 8495";
            var value2 = "Значение №8498";

            var hashTable = new HashTable<string, string>();
            Assert.AreEqual(0, hashTable.Count);
            Assert.AreEqual(null, hashTable[key1]);
            Assert.AreEqual(null, hashTable[key2]);

            hashTable.Insert(key1, value1);
            Assert.AreEqual(1, hashTable.Count);
            Assert.AreEqual(value1, hashTable[key1]);

            hashTable.Insert(key2, value2);
            Assert.AreEqual(2, hashTable.Count);
            Assert.AreEqual(value2, hashTable[key2]);
        }

        [Test]
        public void AddAndRemove()
        {
            var key = "Ключик 85485";
            var value = "Значение №93448";

            var hashTable = new HashTable<string, string>();
            Assert.AreEqual(0, hashTable.Count);
            Assert.AreEqual(null, hashTable[key]);

            hashTable.Insert(key, value);
            Assert.AreEqual(1, hashTable.Count);
            Assert.AreEqual(value, hashTable[key]);

            hashTable.Remove(key);
            Assert.AreEqual(0, hashTable.Count);
            Assert.AreEqual(null, hashTable[key]);
        }
        
        [Test]
        public void Insert_OtherNumbers_AddsAllNumbersWithCollision()
        {
            //Arrange
            var hashTable = new HashTable<SameHashCodeIntStub, string>();
            hashTable.Insert((SameHashCodeIntStub)1, "1");

            //Act
            hashTable.Insert((SameHashCodeIntStub)2, "2");

            //Assert
            Assert.AreEqual((SameHashCodeIntStub)1, hashTable[(SameHashCodeIntStub)1]);
            Assert.AreEqual((SameHashCodeIntStub)2, hashTable[(SameHashCodeIntStub)2]);
        }
    }
}
