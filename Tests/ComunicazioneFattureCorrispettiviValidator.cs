﻿using System.Linq;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ComunicazioneFattureCorrispettiviValidator  :
        BaseClass<ComunicazioneFattureCorrispettivi.ComunicazioneFattureCorrispettivi, ComunicazioneFattureCorrispettivi.Validators.ComunicazioneFattureCorrispettiviValidator>
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
        [TestMethod]
        public void FattureEmesseEmptyWhenRicevuteOrAnnullamentoAreNotEmpty()
        {
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.Annullamento.Posizione = 1;
            var r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = null;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = null;
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.Annullamento.Posizione = 0;
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = null;
            challenge.Annullamento.Posizione = 0;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = null;
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.Annullamento.Posizione = 0;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = null;
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = null;
            challenge.Annullamento.Posizione = 1;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
        }
    }
}
