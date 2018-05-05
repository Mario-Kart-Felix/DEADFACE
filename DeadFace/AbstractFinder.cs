using System;
using System.Collections.Generic;
using System.Linq;
using  System.Reflection;

namespace DeadFace
{
    public abstract class AbstractFinder
    {
        private static readonly Dictionary<Type, AbstractFinder> _finders = new Dictionary<Type, AbstractFinder>();
        public T GetF<T>() where T : AbstractFinder
        {
            return (T)_finders[typeof(T)];
        }
        public AbstractFinder(AbstractFinder[] children)
        {
            _finders.Add(GetType(), this);
            Children = children ?? new AbstractFinder[0];
        }
        protected AbstractFinder[] Children { get; }
        public virtual void Find()
        {
            foreach (var children in Children)
                children.Find();
        }
        public virtual double Rating()
        {
            return Children.Sum(x => x.Rating());
        }
    }
    public abstract  class AbstractFinder<TIn, TOut> : AbstractFinder
    {
        public TIn Input { protected get; set; }
        public TOut Output { get; protected set; }

        public AbstractFinder(AbstractFinder[] childrens) : base(childrens)
        {
        }
    }
}
