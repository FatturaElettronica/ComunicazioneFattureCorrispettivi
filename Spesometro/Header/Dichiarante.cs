﻿using System.Xml;
using FatturaElettronica.Common;

namespace Spesometro.Header
{
    public class Dichiarante : BaseClassSerializable
    {
        public Dichiarante() { }
        public Dichiarante(XmlReader r) : base(r) { }

        [DataProperty]
        public string CodiceFiscale { get; set; }
        [DataProperty]
        public int Carica { get; set; } 
    }
}
