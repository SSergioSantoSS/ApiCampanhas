using ProjCampanhas.Domain.Entities;
using ProjCampanhas.Domain.Enums;
using ProjCampanhas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCampanhas.Domain.Services
{
    /// <summary>
    /// Classe de serviço de domínio para a entidade Campanha
    /// </summary>
    public class CampanhaDomainService : ICampanhaDomainService
    {
        private readonly IUnitOfWork _unitOfWork;


        //construtor para injeção de dependência
        public CampanhaDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Campanha entity)
        {
            #region O nome do Campanha deve ser único

            if (_unitOfWork.CampanhaRepository.GetByNome(entity.Nome) != null)
                throw new ArgumentException("O nome informado já está cadastrado, tente outro.");

            #endregion

            #region O codigo do Campanha deve ser único

            if (_unitOfWork.CampanhaRepository.GetByCodigo(entity.Codigo) != null)
                throw new ArgumentException("O codigo informado já está cadastrado, tente outro.");

            #endregion

            await _unitOfWork.CampanhaRepository.CreateAsync(entity);



            
            var opcao = entity.TipoDeCampanha;                      
                                    
            switch (opcao)
            {
                case TipoDeCampanha.MidiaTradicional:
                    entity.TipoDeCampanha = TipoDeCampanha.MidiaTradicional;
                    break;

                case TipoDeCampanha.MarketingDeInfluencia:
                    entity.TipoDeCampanha = TipoDeCampanha.MarketingDeInfluencia;
                    entity.QntHoras = (int)(entity.QntHoras * 1.2);
                    break;
            }
                     

            if (_unitOfWork.CampanhaRepository.GetByTipoDeCampanha(entity.TipoDeCampanha) == null)            
                                                            

            await _unitOfWork.CampanhaRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Campanha entity)
        {
            #region A Campanha deve existir no banco de dados

            if (await _unitOfWork.CampanhaRepository.GetByIdAsync(entity.Id) == null)
                throw new ArgumentException("Campanha não encontrada, verifique o ID informado.");

            #endregion

            #region O nome atualizado não pode ser igual ao de outra Campanha

            var campanhaByNome = _unitOfWork.CampanhaRepository.GetByNome(entity.Nome);
            if (campanhaByNome != null && !campanhaByNome.Id.Equals(entity.Id))
                throw new ArgumentException("O nome informado já pertence a outra Campanha cadastrada.");



            #endregion

            #region O codigo atualizado não pode ser igual ao de outra Campanha

            var campanhaByCodigo = _unitOfWork.CampanhaRepository.GetByCodigo(entity.Codigo);
            if (campanhaByCodigo != null && !campanhaByCodigo.Id.Equals(entity.Id))
                throw new ArgumentException("O código informado já pertence a outra Campanha cadastrada.");

            #endregion

            await _unitOfWork.CampanhaRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Campanha entity)
        {
            #region A Campanha deve existir no banco de dados

            if (await _unitOfWork.CampanhaRepository.GetByIdAsync(entity.Id) == null)
                throw new ArgumentException("Campanha não encontrada, verifique o ID informado.");

            #endregion

            await _unitOfWork.CampanhaRepository.DeleteAsync(entity);
        }


        public async Task<List<Campanha>> GetAllAsync(int page, int limit)
        {
            #region O limite de paginação de Campanha é de 25 registros

            if (limit > 25)
                throw new ArgumentException("Informe um limite de no máximo 25 registros.");

            #endregion

            return await _unitOfWork.CampanhaRepository.GetAllAsync(page, limit);
        }

        public async Task<Campanha> GetByIdAsync(Guid id)
            => await _unitOfWork.CampanhaRepository.GetByIdAsync(id);

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
