using System.Collections.Generic;
using TestAssignment.BL.Abstraction;
using TestAssignment.BL.Impl;
using Xunit;

namespace TestAssignment.BL.Tests
{
    public class ElementProviderTests
    {
        [Fact]
        public void MergeElementsTest()
        {
            var collection = new List<IElement>()
            {
                new Element(1, "Item 1"),
                new Element(3, "Item 3"),
                new Element(2, "Item 2"),
                new Element(4, "Item 4"),
                new Element(7, "Item 7"),
                new Element(9, "Item 9"),
                new Element(8, "Item 8"),
                new Element(15, "Item 15")
            };

            var newItem = new Element(2, "New Item");
            var result = ElementMerger.Get().MergeElements(collection, newItem);

            Assert.Collection(result,
                item => checkElement(1, "Item 1", item),
                item => checkElement(2, "New Item", item),
                item => checkElement(3, "Item 2", item),
                item => checkElement(4, "Item 3", item),
                item => checkElement(5, "Item 4", item),
                item => checkElement(7, "Item 7", item),
                item => checkElement(8, "Item 8", item),
                item => checkElement(9, "Item 9", item),
                item => checkElement(15, "Item 15", item));
        }

        private void checkElement(int expectedNumber, string expectedBody, IElement actual)
        {
            Assert.Equal(expectedNumber, actual.Number);
            Assert.Equal(expectedBody, actual.Body);
        }
    }
}
