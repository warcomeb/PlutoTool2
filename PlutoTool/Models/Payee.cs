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
            BANK_ACCOUNT = 0,
            WALLET,
            CREDIT_CARD,
            VIRTUAL_WALLET,
            SAVING_ACCOUNT,
        }
    }
}
