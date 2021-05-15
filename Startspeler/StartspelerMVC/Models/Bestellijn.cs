using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class Bestellijn
    {
        public int BestellijnID { get; set; }
        private int _aantal;

        public int Aantal
        {
            get { return _aantal; }
            set { _aantal = value; }
        }

        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
            }
        }

        public Product Prod { get; set; }

        /*          public float SinglePrijs
                   {
                       get { return Prod.Prijs; }
                   }

                   public float TotalePrijs
                   {
                       get { return Aantal * SinglePrijs; }
                   }
        */

        public Bestellijn()
        {
        }

        public Bestellijn(int productid)
        {
            this.ProductId = productid;
            this.Prod = new Product(productid);
        }

        /*
                public bool Equals(Bestellijn item)
                {
                    // Twee lijnen zijn gelijk als het productID gelijk is!!!
                    return item.ProductId == this.ProductId;
                }
        */
    }
}