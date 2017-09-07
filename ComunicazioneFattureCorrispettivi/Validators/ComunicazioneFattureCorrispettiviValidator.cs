﻿using FluentValidation;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class ComunicazioneFattureCorrispettiviValidator : AbstractValidator<ComunicazioneFattureCorrispettivi>
    {
        public ComunicazioneFattureCorrispettiviValidator()
        {
            RuleFor(x => x.Header)
                .SetValidator(new HeaderValidator());
            RuleFor(x => x.FattureEmesse)
                .SetValidator(new FattureEmesseValidator());
            RuleFor(x => x.FattureRicevute)
                .SetValidator(new FattureRicevuteValidator());
            RuleFor(x => x.Annullamento)
                .SetValidator(new RettificaValidator())
                .When(x=>!x.Annullamento.IsEmpty());
            RuleFor(x => x.FattureEmesse)
                .Must(x=>x.IsEmpty())
                .When(x => !x.FattureRicevute.IsEmpty() || !x.Annullamento.IsEmpty())
                .WithMessage("FattureEmesse dovrebbe essere vuoto quando FattureRicevute o Annullamento sono valorizzati.");
            RuleFor(x => x.FattureRicevute)
                .Must(x=>x.IsEmpty())
                .When(x => !x.FattureEmesse.IsEmpty() || !x.Annullamento.IsEmpty())
                .WithMessage("FattureRicevute dovrebbe essere vuoto quando FattureEmesse o Annullamento sono valorizzati.");
            RuleFor(x => x.Annullamento)
                .Must(x=>x.IsEmpty())
                .When(x => !x.FattureEmesse.IsEmpty() || !x.FattureRicevute.IsEmpty())
                .WithMessage("Annullamento dovrebbe essere vuoto quando FattureEmesse o FattureRicevute sono valorizzati.");
        }
    }
}
