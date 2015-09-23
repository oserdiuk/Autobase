using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL
{
    public static class MapperManager
    {
        public static List<R> GetViewListOfEntity<I, R>(List<I> entities)
        {
            List<R> result = new List<R>();
            try
            {
                result = Mapper.Map<IEnumerable<I>, List<R>>(entities);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public static R Map<I, R>(I source)
        {
            return Mapper.Map<I, R>(source);
        }
    }
}
