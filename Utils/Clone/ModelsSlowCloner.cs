using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CommonLogic.Clone
{
    public class ModelsSlowCloner<T> : IModelSlowCloner<T> where T : class, new()
    {
        private static readonly object _dictLocker = new object();
        private static readonly Type _cloneAttributeType = typeof(CloneProperty);

        protected static Dictionary<Type, IEnumerable<PropertyInfo>> CloneableProperties =
            new Dictionary<Type, IEnumerable<PropertyInfo>>();

        protected readonly Type RelatedType;

        public ModelsSlowCloner(object obj)
        {
            RelatedType = obj.GetType();
            extractCloneProperties();
        }

        public ModelsSlowCloner(Type deriveredType)
        {
            RelatedType = deriveredType;
            extractCloneProperties();
        }

        public ModelsSlowCloner()
        {
            RelatedType = typeof(T);
            extractCloneProperties();
        }

        #region Methods

        public T Clone(T cloneFrom)
        {
            var cloneInto = Activator.CreateInstance(RelatedType) as T;
            Clone(cloneInto, cloneFrom);
            return cloneInto;
        }

        public void Clone(T cloneInto, T cloneFrom)
        {
            foreach (var property in CloneableProperties[RelatedType])
            {
                var value = property.GetValue(cloneFrom, null);
                property.SetValue(cloneInto, value, null);
            }
        }

        private void extractCloneProperties()
        {
            if (CloneableProperties.ContainsKey(RelatedType)) return;

            var props = RelatedType.GetProperties().Where(
                prop => Attribute.IsDefined(prop, _cloneAttributeType))
                .OrderBy(it => (it.GetCustomAttributes(_cloneAttributeType, true).First() as CloneProperty).Order);

            lock (_dictLocker)
            {
                // other thread could already add list to doctionary
                if (CloneableProperties.ContainsKey(RelatedType)) return;
                CloneableProperties[RelatedType] = props;
            }
        }

        #endregion

        public T Clone(object cloneFrom)
        {
            var from = cloneFrom as T;
            if (cloneFrom == null) throw new ArgumentException("cloneFrom has to have type " + typeof(T).ToString());
            return Clone(from);
        }

        public void Clone(object cloneInto, object cloneFrom)
        {
            var from = cloneFrom as T;
            var to = cloneInto as T;
            if (cloneFrom == null) throw new ArgumentException("cloneFrom has to have type " + typeof(T).ToString());
            if (cloneInto == null) throw new ArgumentException("cloneFrom has to have type " + typeof(T).ToString());
            Clone(to, from);
        }
    }
}
