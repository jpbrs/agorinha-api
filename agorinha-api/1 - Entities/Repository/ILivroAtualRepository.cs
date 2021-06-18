using agorinha_api.Entities.DTO;

namespace agorinha_api.Entities.Repository
{
    public interface ILivroAtualRepository
    {
        LivroDTO GetLivroAtual();

        bool UpdateLivroAtual(LivroDTO livro);

    }
}
