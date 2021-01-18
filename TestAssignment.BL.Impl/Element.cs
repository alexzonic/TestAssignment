using TestAssignment.BL.Abstraction;

namespace TestAssignment.BL.Impl
{
    public class Element : IElement
    {
        public int Number { get; set; }
        public string Body { get; }

        public Element(int number, string body)
        {
            Number = number;
            Body = body;
        }
    }
}
