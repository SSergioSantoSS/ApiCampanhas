using FluentValidation.Results;
using ProjCampanhas.Domain.Core.Interfaces;
using ProjCampanhas.Domain.Enums;
using ProjCampanhas.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Domain.Entities
{
    public class Campanha : IEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #region Atributos

        private string? _nome;
        public string? _Codigo;
        private DateTime? _PeriodoInicio;
        private DateTime? _PeriodoFim;
        private decimal? _ValordoInvestimento;
        private string? _Descricao;
        private int? _QntHoras;

        #endregion

        #region Propriedades

        public string? Nome
        { get => _nome; set => _nome = value; }
        public string? Codigo
        { get => _Codigo; set => _Codigo = value; }
        public DateTime? PeriodoInicio
        { get => _PeriodoInicio; set => _PeriodoInicio = value; }
        public DateTime? PeriodoFim
        { get => _PeriodoFim; set => _PeriodoFim = value; }
        public decimal? ValordoInvestimento
        { get => _ValordoInvestimento; set => _ValordoInvestimento = value; }
        public string? Descricao
        { get => _Descricao; set => _Descricao = value; }
        public int QntHoras
        { get => (int)_QntHoras; set => _QntHoras = value; }

        public TipoDeCampanha TipoDeCampanha { get; set; }

        public ValidationResult Validate => new CampanhaValidator().Validate(this);

        #endregion

    }
}
