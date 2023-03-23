using System;
namespace Models
{
	public class Person
	{
		private string _name;
		public string Name
		{
			get => _name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))                  
				{
					throw new ArgumentException("Name cannot be blank");
				   
				}
				if (value.Length < 5)
				{
					throw new ArgumentException("Name must contain 5 or more characters");

				}
				_name = value.Trim();
			}
		}

		private DateTime _dateOfBirth;
		public DateTime DateOfBirth
		{
			get => _dateOfBirth;
			set
			{
				if (value == DateTime.MinValue)
				{
					throw new ArgumentException("BirthDate cannot be blank");
				}
				if (value > DateTime.Now)
				{
					throw new ArgumentException("BirthDate cannot be in the future");
				}
				_dateOfBirth = value;
			}
		}

		public Person()
		{
			Name = "Robbin Law";
			DateOfBirth = DateTime.Parse("1960-02-11");
		}

		public Person(string name, DateTime dateOfBirth)
		{
			Name = name;
			DateOfBirth = dateOfBirth;
		}

		public int CurrentAge
		{
			get
			{
				// https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday

				DateTime today = DateTime.Now;
				TimeSpan timeDifference = today - DateOfBirth;
				return (int) (timeDifference.TotalDays / 365.242199);
				
			}
		}

		public int AgeOn(DateTime onDate)
		{
			if (onDate == DateTime.MinValue)
			{
				throw new ArgumentException("Relative Date cannot be blank");
			}
			if (onDate < DateOfBirth)
			{
				throw new ArgumentException("Relative Date cannot be less than the Date of Birth");
			}
			TimeSpan currentTimeSpan = onDate - DateOfBirth;
			return (int) (currentTimeSpan.TotalDays / 365.242199);
		}

		/**
		 *
		 *  birthYear % 12      Animal
		 *  --------------      ------
		 *  0                   Monkey
		 *  1                   Rooster
		 *  2                   Dog
		 *  3                   Pig
		 *  4                   Rat
		 *  5                   Ox
		 *  6                   Tiger
		 *  7                   Rabbit
		 *  8                   Dragon
		 *  9                   Snake
		 *  10                  Horse
		 *  11                  Sheep
		 *
		 * @return the animal for the birth year according to the Chinese Zodiac
		 */
		public String ChineseZodiac()
		{
			string animal;

			string[] Animals = {
				"Monkey",
				"Rooster",
				"Dog",
				"Pig",
				"Rat",
				"Ox",
				"Tiger",
				"Rabbit",
				"Dragon",
				"Snake",
				"Horse",
				"Sheep",
			};

			int offSet = DateOfBirth.Year % 12;
			animal = Animals[offSet];

			return animal;
		}

		/**
		 *
		 *  Birth Dates                     Sign
		 *  --------------                   ------
		 *  March 21 - April 19             Aries
		 *  April 20 - May 20               Taurus
		 *  May 21 - June 21                Gemini
		 *  June 22 - July 22               Cancer
		 *  July 23 - August 22             Leo
		 *  August 23 - September 22        Virgo
		 *  September 23 - October 22       Libra
		 *  October 23 - November 22        Scorpio
		 *  November 23 - December 21       Sagittarius
		 *  December 22 - January 19        Capricorn
		 *  January 20 - February 18        Aquarius
		 *  February 19 - March 20          Pisces
		 *
		 * @return the astrological sign for the birth dates according to the Chinese Zodiac
		 */
		public string AstrologicalSign()
		{
			const string ARIES = "Aries";
			const string TAURUS = "Taurus";
			const string GEMINI = "Gemini";
			const string CANCER = "Cancer";
			const string LEO = "Leo";
			const string VIRGO = "Virgo";
			const string LIBRA = "Libra";
			const string SCORPIO = "Scorpio";
			const string SAGITTARIUS = "Sagittarius";
			const string CAPRICORN = "Capricorn";
			const string AQUARIUS = "Aquarius";
			const string PISCES = "Pisces";

			int month = DateOfBirth.Month;
			int day = DateOfBirth.Day;
			return month switch
			{
				3 => (day >= 21) ? ARIES : PISCES,
				4 => (day >= 20) ? TAURUS : ARIES,
				5 => (day >= 21) ? GEMINI : TAURUS,
				6 => (day >= 22) ? CANCER : GEMINI,
				7 => (day >= 23) ? LEO : CANCER,
				8 => (day >= 23) ? VIRGO : LEO,
				9 => (day >= 23) ? LIBRA : VIRGO,
				10 => (day >= 23) ? SCORPIO : LIBRA,
				11 => (day >= 23) ? SAGITTARIUS : SCORPIO,
				12 => (day >= 22) ? CAPRICORN : SAGITTARIUS,
				1 => (day >= 20) ? AQUARIUS : CAPRICORN,
				2 => (day >= 19) ? PISCES : AQUARIUS,
				_ => "Invalid month or day",
			};

		}
	}
}

