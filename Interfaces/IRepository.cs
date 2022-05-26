using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO_TvShows.Interfaces
{
    public interface IRepository<T>
    {
        List<T> ListTvShows();
        T ReturnShowById(int id);
        void AddShow(T entity);
        void DeleteShow(int id);
        void RefreshShow(int id, T entity);
        int NextId();
    }
}
