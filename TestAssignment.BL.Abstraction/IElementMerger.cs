using System.Collections.Generic;

namespace TestAssignment.BL.Abstraction
{
    public interface IElementMerger
    {
        IEnumerable<IElement> MergeElements(IEnumerable<IElement> elements, IElement newElement);
    }
}
