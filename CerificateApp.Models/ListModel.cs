using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCCS.Web.Models
{
    public class ListModel<T>
    {
        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public ListModel()
        {
        }

        /// <summary>
        /// Konstruktor koji prima listu modela
        /// </summary>
        /// <param name="items">Modeli koji su u listi</param>
        public ListModel(IEnumerable<T> items)
        {
            this.Items = items;
        }

        /// <summary>
        /// Lista modela koji su dio ove liste
        /// </summary>
        public IEnumerable<T> Items { get; set; }
    }
}
