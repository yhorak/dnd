using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLogic.Clone
{
    public interface IModelSlowCloner<out T>
    {
        T Clone(object cloneFrom);
        void Clone(object cloneInto, object cloneFrom);
    }
}
