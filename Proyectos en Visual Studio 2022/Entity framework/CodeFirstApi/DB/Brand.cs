using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption .Identity)]
        public int BrandID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Beer> Beers { get; set; }
    }
}
