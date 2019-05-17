using DatingApp.Model.Data;
using DatingApp.Model.Models;
using DatingApp.Model.Repository.IRepository;

namespace DatingApp.Model.Repository
{
    public class ValueRepository : BaseRepository<Value>, IValueRepository
    {
        public ValueRepository(DataContext context) : base(context)
        {
        }
    }
}
