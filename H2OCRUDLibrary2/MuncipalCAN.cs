//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace H2OCRUDLibrary2
{
    using System;
    using System.Collections.Generic;
    
    public partial class MuncipalCAN
    {
        public string Name { get; set; }
        public decimal PhoneNumber { get; set; }
        public string Mailid { get; set; }
        public long CANId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string ApartmentType { get; set; }
        public long RoofArea { get; set; }
        public int FlatCount { get; set; }
        public int PeopleCount { get; set; }
        public bool WaterMeter { get; set; }
        public bool TapWaterSavers { get; set; }
        public bool RWHS { get; set; }
        public string RWHSType { get; set; }
        public bool RWHSOverflow { get; set; }
        public short BoreWellCount { get; set; }
        public short FunctBoreWellCount { get; set; }
        public bool RecyclingPlant { get; set; }
        public string RecyclingPlantType { get; set; }
        public Nullable<long> PlantCapacity { get; set; }
        public short UsageScore { get; set; }
    }
}
