using static PlutoTool.Models.Vehicle;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlutoTool.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int AccountTypeId
        {
            // https://stackoverflow.com/questions/2646498/best-method-to-store-enum-in-database
            get
            {
                return (int)this.AccountType;
            }
            set
            {
                AccountType = (AccountTypes)value;
            }
        }
        [NotMapped]
        public AccountTypes AccountType { get; set; }
        public int OwnerUserId { get; set; }
        public bool Active { get; set; }
        public string? Note { get; set; }

        public enum AccountTypes
        {
            BANK_ACCOUNT = 0,
            WALLET,
            CREDIT_CARD,
            VIRTUAL_WALLET,
            SAVING_ACCOUNT,
        }

        private string[] AccoutTypesName = new string[] { 
            "Conto Bancario", 
            "Portafoglio",
            "Carta di Credito",
            "Portafoglio Virtuale",
            "Libretto di Risparmio"
        };
    }
}
