﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionClientes
{
    internal class Cliente
    {

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }

        } 

        public override string ToString()
        {
            return NombreCompleto;
        }

    }
}
