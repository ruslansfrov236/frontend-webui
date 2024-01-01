using frontend.entity.Customers;
using Microsoft.EntityFrameworkCore;


namespace frontend.data.Abstract
{
     public interface IRepository< T> where T : BaseEntity
    {
       DbSet<T> Table { get;  }
    }
}
