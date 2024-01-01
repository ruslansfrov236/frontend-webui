using frontend.data.Abstract;
using frontend.data.Concrete.EfCore;
using frontend.data.Context;
using frontend.entity;


namespace frontend.data.Concrete.EfCore
{
    public class FilesReadRepository : ReadRepository<Files>, IFilesReadRepository
    {
        public FilesReadRepository(FrontEndDataDbContext context) : base(context)
        {
        }
    }
}
