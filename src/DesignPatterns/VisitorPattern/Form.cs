using System.Collections.Generic;

namespace VisitorPattern
{
    public class Form
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public ICollection<Control> Body { get; set; }

        public void Accept(IVisitor visitor)
        {
            foreach (var control in Body)
            {
                control.Accept(visitor);
            }
        }
    }

}
