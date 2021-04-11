using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CreditCardNo { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cvv { get; set; }
        public string CardType { get; set; }
        public int Installment { get; set; }

    }
}
