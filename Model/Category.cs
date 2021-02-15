using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindEFCore.Model
{
    public class Category
    {
        #region mapowanie kolumn
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        #endregion

        // navigation property for related rows
        public virtual ICollection<Product> Products { get; set; }

        // konstruktor
        public Category()
        {
            // to enable developers to add products to a Category we must
            // initialize the navigation property to an empty collection 
            this.Products = new HashSet<Product>();
        }
    }
}