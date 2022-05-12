using System;

namespace ValidationService
{
    public class DateValidation
	{
		private const int dayLength = 2;
		private const int monthLength = 2;
		private const int yearLength = 4;

		public bool IsValid(string dateParam)
		{
			string day = "";
			string month = "";
			string year = "";
			int index = 0;
			int lastIndex = 0;

			if (dateParam == null || dateParam.Length != 10)
			{
				return false;
			}

			dateParam = dateParam.Trim();
			index = dateParam.IndexOf('/');
			lastIndex = dateParam.LastIndexOf('/');
			if (index == -1 || lastIndex == -1)
			{
				throw new ArgumentException("Index out of range");
			}

			if (index != 2 || lastIndex != 5)
			{
				return false;
			}

			return true;

			//string temp = dateParam; //Ex: 30/04/2022
			//day = temp.Substring(0, dayLength);
			//month = temp.Substring(3, monthLength);
			//year = temp.Substring(6, yearLength);

		}
	}
}
