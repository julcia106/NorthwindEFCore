using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindEFCore.Model
{
    public class Product
    {
        #region mapowanie pól
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        [Column("UnitPrice", TypeName = "money")]
        public decimal? Cost { get; set; } // zmiana nazwy

        [Column("UnitsInStock")]
        public short? Stock { get; set; }

        public bool Discontinued { get; set; }

        #endregion

        #region zależność od klucza obcego    
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        #endregion

    }
}