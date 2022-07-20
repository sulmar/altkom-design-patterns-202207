using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern.Problem
{
    public partial class Article
    {
        // Backup (snapshot)
        public ArticleMemento CreateMemento()
        {
            return new ArticleMemento(Title, Content);
        }

        public void SetMemento(ArticleMemento memento)
        {
            this.Title = memento.Title;
            this.Content = memento.Content;
        }
    }
}
