using System;
using System.Collections.Generic;
using System.Linq;

namespace FaceFinder
{
    public abstract class AbstractFinder
    {
        public abstract string Name { get; }
        private static readonly Dictionary<Type, AbstractFinder> _finders = new Dictionary<Type, AbstractFinder>();
        public IEnumerable<AbstractFinder> Finders => _finders.Select(x => x.Value);
        protected T GetF<T>() where T : AbstractFinder
        {
            return (T)_finders[typeof(T)];
        }
        protected AbstractFinder()
        {
            _finders[GetType()] = this;
        }
        protected AbstractFinder[] Children { get; set; }
        public virtual void Find()
        {
            foreach (var children in Children ?? Enumerable.Empty<AbstractFinder>())
                children.Find();
        }

        public bool? IsReliable { get; protected set; } = true;
    }
    public abstract  class AbstractFinder<TIn, TOut> : AbstractFinder
    {
        public TIn Input { protected get; set; }
        public TOut Output { get; protected set; }
    }
}
