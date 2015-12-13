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
        //Map entities to the list of view models
        public static List<R> GetViewListOfEntity<I, R>(List<I> entities)
        {
            List<R> result = new List<R>();
            result = Mapper.Map<IEnumerable<I>, List<R>>(entities);
            return result;
        }

        //Map one object to another object
        public static R Map<I, R>(I source)
        {
            return Mapper.Map<I, R>(source);
        }
    }
}
