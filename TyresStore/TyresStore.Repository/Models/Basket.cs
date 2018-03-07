using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TyresStore.Repository.Models
{
    public class Basket
    {   
        [Key]
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Season { get; set; }
        public double Price { get; set; }
        public string ArticleCode { get; set; }
        public int TyreId { get; set; }
        public string AddedDate { get; set; }
        public string Description { get; set; }
    }
}
