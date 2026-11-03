using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PracticeWork6
{
    internal class ParcelComparer : IComparer<Parcel>
    {
        public int Compare(Parcel? x, Parcel? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            int result = string.Compare(x.DeliveryArea, y.DeliveryArea, StringComparison.CurrentCulture);

            if (result == 0)
            {
                return x.Number.CompareTo(y.Number);
            }

            return result;
        }
    }
}
