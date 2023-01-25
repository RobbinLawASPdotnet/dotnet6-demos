using System;
namespace WestWindSystem
{
	public class Supplier
	{
		public string CompanyName {get; set;}
		public string PhoneNumber {get; set;}

		public Supplier(string companyName, string phoneNumber)
		{
				if(string.IsNullOrWhiteSpace(companyName))
						throw new ArgumentNullException("companyName cannot be null or empty");
				if(string.IsNullOrWhiteSpace(phoneNumber))
						throw new ArgumentNullException("phoneNumber cannot be null or empty");
						
				CompanyName = companyName.Trim();
				PhoneNumber = phoneNumber.Trim();
		}

		public override string ToString()
		{
				return $"Company Name: {CompanyName}, Phone Number: {PhoneNumber}";
		}

		public static int Add(int num1, int num2){
				return num1 + num2;
		}
	}
}