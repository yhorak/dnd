using System;
using System.Collections.Generic;

namespace CommonLogic.Clone
{
    public class ModelSlowGroupCloner<T> : ModelsSlowCloner<T>, IModelSlowGroupCloner<T> where T : class, new()
    {
        #region Constructor

        public ModelSlowGroupCloner(object obj)
            : base(obj) {}

        public ModelSlowGroupCloner(Type deriveredType)
            : base(deriveredType) {}

        public ModelSlowGroupCloner() {}

        #endregion

        public void Clone(object cloneInto, IEnumerable<object> cloneFrom)
        {
            if (cloneFrom == null) throw new ArgumentException("There has to be at least one item to clone from");
            foreach (var property in CloneableProperties[RelatedType])
            {
                object value = null;
                foreach (var item in cloneFrom)
                {
                    value = property.GetValue(item, null);
                    if (value != null)
                    {
                        break;
                    }
                }
                property.SetValue(cloneInto, value, null);
            }
        }

        public T Clone(IEnumerable<object> cloneFrom)
        {
            var cloneInto = Activator.CreateInstance(RelatedType) as T;
            Clone(cloneInto, cloneFrom);
            return cloneInto;
        }
    }
}
