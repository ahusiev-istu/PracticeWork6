using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWork6
{
    internal class Parcel : IComparable<Parcel>
    {
        public int Number { get; private set; }
        public string DeliveryArea { get; private set; }
        public double Weight { get; private set; }
        public string CourierSurname { get; private set; }

        public Parcel(int number, string deliveryArea, double weight, string courierSurname)
        {
            Number = number;
            DeliveryArea = deliveryArea;
            Weight = weight;
            CourierSurname = courierSurname;
        }

        public override string ToString()
        {
            return $"Номер: {Number}, Район доставки: {DeliveryArea}, Вага: {Weight}, Прізвище кур’єра: {CourierSurname}";
        }

        public int CompareTo(Parcel? other)
        {
            if (other == null) return 1;
            return Weight.CompareTo(other.Weight);
        }
        public Parcel Clone()
        {
            return new Parcel(Number, DeliveryArea, Weight, CourierSurname);
        }
    }
}
