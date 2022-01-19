using DTO;

namespace DAO
{
    public interface IDAO {
        void Inserṭ̣̣(Object a);
        void Update(Object a);
        void Delete(Object a);
        List<Object> All();
        Dictionary<String, String> GetColumns();
    }
}