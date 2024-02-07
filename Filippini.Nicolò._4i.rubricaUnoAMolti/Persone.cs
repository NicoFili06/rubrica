using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filippini.Nicolò._4i.rubricaUnoAMolti
{
    internal class Persona
    {
        public int idPersona { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Persona() { }
        public Persona(string riga)
        {
            string[] campi = riga.Split(';');

            int id = 0;
            int.TryParse(campi[0], out id);
            idPersona = id;

            Nome = campi[1];
            Cognome = campi[2];
        }
    }
}