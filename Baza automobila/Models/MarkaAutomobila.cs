using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazaAutomobila.Models
{
    public class MarkaAutomobila
{
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Drzava { get; set; }
        public string Opis { get; set; }
        public ICollection<ModelAutomobila> ModeliAutomobila { get; set; }
    }
}
