﻿using ComunicazioneFattureCorrispettivi;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FattureCorrispettiviValidator  :
        BaseClass<FattureCorrispettivi, ComunicazioneFattureCorrispettivi.Validators.FattureCorrispettiviValidator>
    {
        [TestMethod]
        public void HeaderHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.Header, typeof(ComunicazioneFattureCorrispettivi.Validators.HeaderValidator));
        }
        [TestMethod]
        public void FattureEmesseHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.FattureEmesse, typeof(ComunicazioneFattureCorrispettivi.Validators.FattureEmesseValidator));
        }
        [TestMethod]
        public void FattureRicevuteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.FattureRicevute, typeof(ComunicazioneFattureCorrispettivi.Validators.FattureRicevuteValidator));
        }
        [TestMethod]
        public void AnnullamentoHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.Annullamento, typeof(ComunicazioneFattureCorrispettivi.Validators.RettificaValidator));
        }
    }
}
