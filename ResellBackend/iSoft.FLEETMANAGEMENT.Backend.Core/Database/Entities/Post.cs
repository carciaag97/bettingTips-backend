using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Database.Entities
{
    public class Post:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Condition { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Photo> photos { get; set; }
    }
}
