
using System.Collections.Generic;


namespace CommonLogic.Clone
{
    public interface IModelSlowGroupCloner<out T> : IModelSlowCloner<T>
    {
        T Clone(IEnumerable<object> cloneFrom);
        void Clone(object cloneInto, IEnumerable<object> cloneFrom);
    }
}
