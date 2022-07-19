using System.Collections.Generic;

namespace DemoshotWeb.Models
{
    public interface IShotRepository
    {
        public interface IUserRepository
        {
            void Create(Shot shot);
            void Delete(int id);
            Shot Get(int id);
            List<Shot> GetShots();
            void Update(Shot shot);
        }
    }
}
