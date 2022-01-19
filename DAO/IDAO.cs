using DTO;
using System.Collections;
using System.Data;

namespace DAO
{
    public interface IDAO {
        void Inserṭ̣̣(object a);
        void Update(object a);
        void Delete(object a);
        List<object> All();
        Dictionary<string, string> GetColumns();
        DataTable All(bool resultDataTable);
        void Delete(Dictionary<string, string> values);
        void Inserṭ̣̣(Dictionary<string, string> values);
        void Update(Dictionary<string, string> values);
    }
}