

using frontend.data.Abstract;
using frontend.data.Context;
using frontend.entity;

namespace frontend.data.Concrete.EfCore
{
    public class FilesWriteRepository : WriteRepository<Files>, IFilesWriteRepository
    {
        public FilesWriteRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
