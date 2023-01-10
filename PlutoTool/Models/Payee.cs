using System.ComponentModel.DataAnnotations.Schema;

namespace PlutoTool.Models
{
    public class Payee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PayeeTypeId
        {
            // https://stackoverflow.com/questions/2646498/best-method-to-store-enum-in-database
            get
            {
                return (int)this.PayeeType;
            }
            set
            {
                PayeeType = (PayeeTypes)value;
            }
        }
        [NotMapped]
        public PayeeTypes PayeeType { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public int? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? NIN { get; set; }
        public string? VATID { get; set; }
        public bool Active { get; set; }
        public string? Note { get; set; }

        public enum PayeeTypes
        {
            NOT_DEFINED = 0,
            PERSON,
            BANK,
            BAR,
            SHOP,
            RESTURANT,
            HOSPITAL,
            DOCTOR,
            TRANSPORT,
            UTILITIES,
            MECHANIC,
            CAMPING_HOTEL,
            INTERNET,
            INDUSTRY,
            ITC_COMPANY,
            INSURANCE,
            PHARMACY,
            FIRM,
            GOVERNAMENT_AGENCY,
            SPORT_SOCIETY,
            SCHOOL
        }

        private string[] PayeeTypesName = new string[] {
            "Non Definito",
            "Persona",
            "Banca",
            "Bar",
            "Negozio",
            "Ristorante",
            "Ospedale",
            "Dottore",
            "Trasporto",
            "Ferramenta",
            "Meccanico",
            "Camping/Hotel",
            "Internet",
            "Industria",
            "Telefonia",
            "Assicurazione",
            "Farmacia",
            "Consulenza",
            "Agenzia Governativa",
            "Società Sportiva",
            "Scuola"
        };
    }
}
