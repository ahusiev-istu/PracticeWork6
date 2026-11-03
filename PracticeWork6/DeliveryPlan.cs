using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PracticeWork6
{
    internal class DeliveryPlan : IEnumerable<Parcel>, ICloneable
    {
        private readonly List<Parcel> parcels = new List<Parcel>();
        public void Add(Parcel parcel) {
            parcels.Add(parcel);
        }

        public IEnumerator<Parcel> GetEnumerator()
        {
            List<Parcel> sorted = new List<Parcel>(parcels);
            sorted.Sort();

            foreach (Parcel parcel in sorted)
            {
                yield return parcel;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerable<Parcel> HeavierThan(double kg, int count)
        {
            int shown = 0;
            foreach (Parcel parcel in parcels)
            {
                if (parcel.Weight > kg)
                {
                    if (shown == count)
                    {
                        yield break;
                    }
                    shown++;
                    yield return parcel;
                }

            }
        }

        public object Clone()
        {
            DeliveryPlan copy = new DeliveryPlan();

            foreach (Parcel parcel in parcels)
            {
                copy.Add(parcel.Clone());
            }

            return copy;
        }

        public void ChangeCourier(string oldSurname, string newSurname)
        {
            for (int i = 0; i < parcels.Count; i++)
            {
                if (parcels[i].CourierSurname == oldSurname)
                {
                    parcels[i] = new Parcel(
                        parcels[i].Number,
                        parcels[i].DeliveryArea,
                        parcels[i].Weight,
                        newSurname
                    );
                }
            }
        }
    }
}
