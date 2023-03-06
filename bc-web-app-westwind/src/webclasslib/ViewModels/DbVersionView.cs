using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ViewModels
{
	public class DbVersionView
	{
		public int Id { get; set; }
		public int Major { get; set; }
		public int Minor { get; set; }
		public int Build { get; set; }
		public DateTime ReleaseDate { get; set; }

		public override string ToString() 
		{
			return $"Id: {Id}, Major: {Major}, Minor: {Minor}, Build: {Build}, Release Date: {ReleaseDate}";
		}
	}
}
