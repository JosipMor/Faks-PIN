using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BazaAutomobila.Models
{
    public class ModelAutomobila
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        [Display(Name = "Godina Proizvodnje")]
        public string GodinaProizvodnje { get; set; }
        public string Boja { get; set; }
        public int Snaga { get; set; }  
        [Display(Name = "Marka automobila")]
        public MarkaAutomobila MarkaAutomobila { get; set; }       
        public int MarkaAutomobilaId { get; set; }
    }
}
