using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MementoPattern.Problem
{
    // Originator (inicjator)
    public partial class Article
    {
        public string Content { get; set; }
        public string Title { get; set; }

        public string Comments { get; set; }
    }

    // Abstract Caretaker
    public interface IArticleCaretaker
    {
        void SetState(ArticleMemento memento);
        ArticleMemento GetState();
    }

    public interface IIndexArticleCaretaker : IArticleCaretaker
    {
        ArticleMemento GetState(int index);
    }

    public interface IByDateArticleCaretaker : IArticleCaretaker
    {
        ArticleMemento GetState(DateTime date);
    }

    // Concrete Caretaker
    public class LastArticleCaretaker : IArticleCaretaker
    {
        private ArticleMemento memento;

        public ArticleMemento GetState()
        {
            return this.memento;
        }

        public void SetState(ArticleMemento memento)
        {
            this.memento = memento;
        }
    }

    // Concrete Caretaker
    public class StackArticleCaretaker : IArticleCaretaker
    {
        private Stack<ArticleMemento> mementos = new Stack<ArticleMemento>();

        public ArticleMemento GetState()
        {
            return mementos.Pop();
        }

        public void SetState(ArticleMemento memento)
        {
            mementos.Push(memento);
        }
    }

    public class IndexArticleCaretaker : IIndexArticleCaretaker
    {
        private List<ArticleMemento> mementos = new List<ArticleMemento>();

        public ArticleMemento GetState()
        {
            return mementos.Last();
        }

        public ArticleMemento GetState(int index)
        {
            return mementos[index];
        }

        public void SetState(ArticleMemento memento)
        {
            mementos.Add(memento);
        }
    }

    public class HistoryArticleCaretaker : IByDateArticleCaretaker
    {
        private readonly Dictionary<DateTime, ArticleMemento> mementos = new Dictionary<DateTime, ArticleMemento>();

        public ArticleMemento GetState(DateTime date)
        {
            return mementos[date];
        }

        public ArticleMemento GetState()
        {
            return mementos.Last().Value;
        }

        public void SetState(ArticleMemento memento)
        {
            mementos.Add(memento.SnapshotDate, memento);
        }
    }




    // Memento (migawka, snapshot)
    public class ArticleMemento
    {
        public string Content { get;  }
        public string Title { get; }
        public DateTime SnapshotDate { get; }

        public ArticleMemento(string title, string content)
        {
            SnapshotDate = DateTime.Now;
            Content = content;
            Title = title;
        }
    }


}
