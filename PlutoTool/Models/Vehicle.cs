using System.ComponentModel.DataAnnotations.Schema;

namespace PlutoTool.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Maker { get; set; }
        public string? Model { get; set; }
        public string Plate { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public int VehicleTypeId
        {
            // https://stackoverflow.com/questions/2646498/best-method-to-store-enum-in-database
            get
            {
                return (int)this.VehicleType;
            }
            set
            {
                VehicleType = (VehicleTypes)value;
            }
        }
        [NotMapped]
        public VehicleTypes VehicleType { get; set; }

        public bool Active { get; set; }
        public string? Note { get; set; }

        public enum VehicleTypes
        {
            BIKE = 0,
            MOTORBIKE,
            CAR,
            CARAVAN,
            CAMPER,
        }
    }
}
