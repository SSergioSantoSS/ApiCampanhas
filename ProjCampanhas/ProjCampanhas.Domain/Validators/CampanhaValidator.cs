using FluentValidation;
using ProjCampanhas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Domain.Validators
{
    /// <summary>
    /// Classe de validação para a entidade Campanha
    /// </summary>
    public class CampanhaValidator : AbstractValidator<Campanha>
    {        
        public CampanhaValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id da campanha é obrigatório.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome da campanha é obrigatório.")
                .Length(2, 50).WithMessage("Nome da campanha deve ter de 2 a 50 caracteres.");

            RuleFor(c => c.Codigo)
                .NotEmpty().WithMessage("Código da campanha é obrigatório.")
                .Length(1, 5).WithMessage("Nome da campanha deve ter de 1 a 5 caracteres.");

            RuleFor(c => c.PeriodoInicio)
                .NotEmpty().WithMessage("A data de início da campanha é obrigatório.");

            RuleFor(c => c.PeriodoFim)
                .NotEmpty().WithMessage("A data de Fim da campanha é obrigatório.");

            RuleFor(c => c.ValordoInvestimento)
                .NotEmpty().WithMessage("O valor do investimento da campanha é obrigatório.");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("A descrição da campanha é obrigatório.")
                .Length(3, 80).WithMessage("Nome da campanha deve ter de 3 a 80 caracteres.");

            RuleFor(c => c.QntHoras)
                .NotEmpty().WithMessage("A quantidade de horas da campanha é obrigatório.");

            RuleFor(c => c.TipoDeCampanha)
               .NotEmpty().WithMessage("O tipo de Campanha é obrigatório.");
        }
    }
}
