﻿using ComunicazioneFattureEmesseRicevute.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RappresentanteFiscaleValidator : 
        DenominazioneNomeCognomeValidator<RappresentanteFiscale, ComunicazioneFattureEmesseRicevute.Validators.RappresentanteFiscaleItaliaValidator>
    {

        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.IdFiscaleIVA, 
                typeof(ComunicazioneFattureEmesseRicevute.Validators.IdFiscaleIVAItaliaValidator));
        }
    }
}
