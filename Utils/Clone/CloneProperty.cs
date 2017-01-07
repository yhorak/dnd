using System;

namespace CommonLogic.Clone
{
    public class CloneProperty : Attribute
    {
        /// <summary>
        /// Properties are cloned starting from lower order number to greater.
        /// default value is set to 100
        /// </summary>
        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }
        private int _order = 100;
    }
}
