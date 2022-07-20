using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace VisitorPattern.UnitTests
{

    [TestClass]
    public class HtmlVisitorTests
    {
        [TestMethod]
        public void Output_Form_ShouldReturnsHtml()
        {
            // Arrange

            const string expected = "<html><title>Design Patterns</title><body><span>Person</span><span>FirstName</span><input type='text' value='John'></input><span>IsAdult</span><input type='checkbox' value='true'></input><button><img src='save.png'/>Submit</button></body></html>";

            Form form = Get();

            IVisitor visitor = new HtmlVisitor();

            // Act
            form.Accept(visitor);


            // Assert
            Assert.AreEqual(expected, visitor.Output);

        }

        private static Form Get()
        {
            Form form = new Form
            {
                Name = "/forms/customers",
                Title = "Design Patterns",

                Body = new Collection<Control>
                {
                    new LabelControl { Caption = "Person", Name = "lblName" },
                    new TextBoxControl { Caption = "FirstName", Name = "txtFirstName", Value = "John"},
                    new CheckboxControl { Caption = "IsAdult", Name = "chkIsAdult", Value = true },
                    new ButtonControl {  Caption = "Submit", Name = "btnSubmit", ImageSource = "save.png" },
                }

            };

            return form;
        }
    }
}
