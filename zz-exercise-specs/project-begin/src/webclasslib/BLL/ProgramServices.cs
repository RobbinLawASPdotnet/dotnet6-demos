using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Additional Namespaces
using DAL;
using Entities;
using ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BLL
{
	public class ProgramServices
	{
		#region Constructor Dependency Injection
		private readonly Context Context;
		public ProgramServices(Context context)
		{
			if (context == null)
				throw new ArgumentNullException();
			Context = context;
		}
		#endregion

		#region Queries

		public List<ProgramList> FindProgramsByPartialName(string partialName)
		{
			Console.WriteLine($"ProgramServices: FindProgramsByPartialName(); partialName= {partialName}");
			var info =
				Context.Programs
				.Where(x => x.ProgramName.Contains(partialName))
				.Select(x => new ProgramList
				{
					ProgramId = x.ProgramId,
					ProgramName = x.ProgramName,
					DiplomaName = x.DiplomaName,
					School = x.School.SchoolName,
					Tuition = x.Tuition,
					InternationalTuition = x.InternationalTuition
				})
				.OrderBy(x => x.ProgramName);
			return info.ToList();
		}   

		public List<ProgramList> FindProgramsBySchool(string schoolcode)
		{
			Console.WriteLine($"ProgramServices: FindProgramsBySchool(); SchoolCode= {schoolcode}");
			var info = 
				Context.Programs
				.Where(x => x.SchoolCode == schoolcode)
				.Select(x => new ProgramList
				{
					ProgramId = x.ProgramId,
					ProgramName = x.ProgramName,
					DiplomaName = x.DiplomaName,
					School = x.School.SchoolName,
					Tuition = x.Tuition,
					InternationalTuition = x.InternationalTuition
				})
				.OrderBy(x => x.ProgramName);
			return info.ToList();
		}

		#endregion

		#region READ - Retrieve, Edit, Add, Delete

		public ProgramItem Retrieve(int id)
		{
			Console.WriteLine($"ProgramServices: Retrieve; programId= {id}");

			var info = 
				Context.Programs
				.Where(x => x.ProgramId == id)
				.Select(x => new ProgramItem
				{
					ProgramId = x.ProgramId,
					ProgramName = x.ProgramName,
					DiplomaName = x.DiplomaName,
					SchoolCode = x.SchoolCode,
					Tuition = x.Tuition,
					InternationalTuition = x.InternationalTuition
				}).FirstOrDefault();
			return info;
		}

		public int Add(ProgramItem item)
		{
			Console.WriteLine($"ProgramServices: Add; programId= {item.ProgramId}");

			//BLL Validation
			//for no program duplicates
			var exists = 
				Context.Programs.FirstOrDefault(x => 
				x.ProgramName == item.ProgramName && 
				x.SchoolCode == item.SchoolCode);
			if (exists != null)
				throw new Exception("A program with the same name, and school code already exists");

			var newProgram = new Program();
			newProgram.ProgramId = item.ProgramId;
			newProgram.ProgramName = item.ProgramName;
			newProgram.DiplomaName = item.DiplomaName;
			newProgram.SchoolCode = item.SchoolCode;
			newProgram.Tuition = item.Tuition;
			newProgram.InternationalTuition = item.InternationalTuition;

			Context.Programs.Add(newProgram);
			Context.SaveChanges();
			return newProgram.ProgramId;
		}

		public void Edit(ProgramItem item)
		{
				Console.WriteLine($"ProgramServices: Edit; programId= {item.ProgramId}");

				//BLL Validation
				Program existing = Context.Programs.Find(item.ProgramId);
					if (existing == null)
						throw new Exception("Program does not exist");
					
				existing.ProgramId = item.ProgramId;
				existing.ProgramName = item.ProgramName;
				existing.DiplomaName = item.DiplomaName;
				existing.SchoolCode = item.SchoolCode;
				existing.Tuition = item.Tuition;
				existing.InternationalTuition = item.InternationalTuition;

				EntityEntry<Program> updating = Context.Entry(existing);
				updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				Context.SaveChanges();
		}

		public void Delete(ProgramItem item)
		{
			Console.WriteLine($"ProgramServices: Delete; programId= {item.ProgramId}");

			//BLL Validation
			Program existing = Context.Programs.Find(item.ProgramId);
				if (existing == null)
			 		throw new Exception("Program does not exist");

			EntityEntry<Program> removing = Context.Entry(existing);
			removing.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			Context.SaveChanges();
		}
		#endregion
	}
}
