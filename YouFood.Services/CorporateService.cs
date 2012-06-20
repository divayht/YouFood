using YouFood.Data.Repositories;
using YouFood.Domain.Model;

namespace YouFood.Services
{
    public class CorporateService
    {
        private readonly CorporateRepository corporateRepository;

        public CorporateService()
        {
            corporateRepository = new CorporateRepository();
        }

        public Corporate Get(int id)
        {
            return corporateRepository.Get(id);
        }
    }
}
