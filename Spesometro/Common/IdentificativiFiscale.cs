﻿using System.Xml;
using FatturaElettronica.Common;
using FatturaElettronica.Core;

namespace Spesometro.Common
{
    public class IdentificativiFiscali : BaseClassSerializable
    {
        private readonly IdFiscaleIVA _idFiscaleIVA;

        public IdentificativiFiscali()
        {
            _idFiscaleIVA = new IdFiscaleIVA();
        }
        public IdentificativiFiscali(XmlReader r) : base(r) { }

        [DataProperty]
        public IdFiscaleIVA IdFiscaleIVA => _idFiscaleIVA;
        [DataProperty]
        public string CodiceFiscale { get; set; }
    }
}
