using DIO_TvShows.Classes;
using DIO_TvShows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO_TvShows
{
    public class TvShowRepository : IRepository<TvShow>
    {
        private List<TvShow> TvShowList = new List<TvShow>();
        public void DeleteShow(int id)
        {
            TvShowList[id].Delete();
        }

        public void AddShow(TvShow entity)
        {
            TvShowList.Add(entity);
        }

        public List<TvShow> ListTvShows()
        {
            return TvShowList;
        }

        public int NextId()
        {
            return TvShowList.Count;
        }

        public void RefreshShow(int id, TvShow entity)
        {
            TvShowList[id] = entity;
        }

        public TvShow ReturnShowById(int id)
        {
            return TvShowList[id];
        }
    }
}
