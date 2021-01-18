using System.Collections.Generic;
using System.Linq;
using TestAssignment.BL.Abstraction;

namespace TestAssignment.BL.Impl
{
    public class ElementMerger : IElementMerger
    {
        private ElementMerger() { }

        private static ElementMerger _instance;
        
        public static ElementMerger Get() => _instance ??= new ElementMerger();

        public IEnumerable<IElement> MergeElements(IEnumerable<IElement> elements, IElement newElement)
        {
            if (elements is null) return elements.Append(newElement);
            
            var number = newElement.Number;
            
            // поиск отрезка без пропусков номеров 
            var invalidPart = elements
                .OrderBy(el => el.Number)
                .SkipWhile(el => el.Number != newElement.Number)
                .TakeWhile(el => DiffIsOne(el.Number, ref number))
                .ToDictionary(el => el.Number, el => el.Body);

            var result = elements.ToDictionary(el => el.Number, el => el.Body);
            
            result[newElement.Number] = newElement.Body;
            
            foreach (var (key, value) in invalidPart)
                result[key + 1] = value;

            return result.OrderBy(key => key.Key).Select(pair => new Element(pair.Key, pair.Value));
        }

        // начиная с элемента (допустим 2), номер которого равен номеру нового элемента, на каждой итерации будет:
        // current.number (2) минус newElement.numberCopy (3) == -1
        // можно сразу от newElement.numberCopy отнять 2, тогда == 1 
        private static bool DiffIsOne(int elNumber, ref int number) => elNumber - ++number == -1;
    }
}