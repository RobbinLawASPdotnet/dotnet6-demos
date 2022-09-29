using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities;
using DAL;

namespace BLL 
{
    public class DbVersionServices 
    {
        private readonly Context Context;
        public  DbVersionServices(Context context) 
        {
            if (context == null)
                throw new ArgumentNullException();
            Context = context;
        }

        public BuildVersion GetDbVersion() 
        {
            Console.WriteLine($"DbServices: GetDbVersion;");
            var result = Context.BuildVersions.ToList();
            return result.First();
        }
        
    }
}