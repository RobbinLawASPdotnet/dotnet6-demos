using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Entities;
using DAL;

namespace BLL 
{
    public class OtherServices 
    {
        private readonly Context Context;
        public  OtherServices(Context context) 
        {
            if (context == null)
                throw new ArgumentNullException();
            Context = context;
        }

        #region QUERY
        
        
        #endregion
    }
}

// List<ProgramCourse> SearchedRecords = Context.ProgramCourses.Where(x => x.ProgramId == item.ProgramId).ToList();
            // if(SearchedRecords.Count != 0)
            //     throw new Exception("Cannot delete a program that has a course");