using AutoMapper;
using DAL.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBL
{
    public static class RoleMapperManager
    {
        public static I Map<I>(IUser source)
        {
            if (source is Driver) return Mapper.Map<Driver, I>(source as Driver);
            if (source is Manager) return Mapper.Map<Manager, I>(source as Manager);
            return Mapper.Map<User, I>(source as User);
        }
    }
}