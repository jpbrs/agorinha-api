using System.Collections.Generic;
using System.Threading.Tasks;

namespace agorinha_api.Entities.Repository
{
    public interface IEncontrosRepository
    {
        IEnumerable<EncontrosDTO> GetAllEncontros();
    }
}
