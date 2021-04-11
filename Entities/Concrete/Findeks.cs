using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Findeks : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NationalityId { get; set; }
        public int Score { get; set; }

    }
}
