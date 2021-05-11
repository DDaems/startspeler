using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Models
{
    public class Bestelling
    {
        public int BestellingID { get; set; }

        public User User { get; set; }

        [NotMapped]
        public List<Bestellijn> Items { get; set; }

        public void ItemToevoegen(int productId)
        {
            // Hier voeg je een aantal toe aan de bestelling. Indien de lijn alreeds bestaat, moet je het aantal verhogen met de opgegeven waarde.
            Bestellijn nieuw = new Bestellijn(productId);

            if (Items.Contains(nieuw))
            {
                foreach (Bestellijn item in Items)
                {
                    if (item.Equals(nieuw))
                    {
                        item.Aantal++;
                        return;
                    }
                }
            }
            else
            {
                nieuw.Aantal = 1;
                Items.Add(nieuw);
            }
        }

        public void ItemVerwijderen(int productId)
        {
            // Hier trek je 1 waarde af van het aantal bij de juiste bestellijn. Indien het aantal naar nul wordt gebracht, mag de waarde niet lager gebracht worden.
            Bestellijn nieuw = new Bestellijn(productId);

            if (Items.Contains(nieuw))
            {
                foreach (Bestellijn item in Items)
                {
                    if (item.Equals(nieuw))
                    {
                        if (item.Aantal <= 0)
                        {
                            //verwijderen hoeft niet, we laten gewoon aantal nul staan.
                        }
                        else
                        {
                            item.Aantal--;
                        }
                        return;
                    }
                }
            }
        }

        public void ItemAantalInstellen(int productId, int aantal)
        {
            Bestellijn nieuw = new Bestellijn(productId);

            foreach (var item in Items)
            {
                if (item.Equals(nieuw))
                {
                    item.Aantal = aantal;
                    return;
                }
            }
        }
    }
}