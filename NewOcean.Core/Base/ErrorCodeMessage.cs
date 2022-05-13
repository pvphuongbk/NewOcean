using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOcean.Core.Base
{
	public class ErrorCodeMessage
	{
		public static readonly KeyValuePair<int, string> Success = new KeyValuePair<int, string>(0, "The operation completed successfully.");
		public static readonly KeyValuePair<int, string> IncorrectFunction = new KeyValuePair<int, string>(1, "Incorrect function.");
		public static readonly KeyValuePair<int, string> BlogExisted = new KeyValuePair<int, string>(2, "This blog already exist.");
		public static readonly KeyValuePair<int, string> BlogNotExisted = new KeyValuePair<int, string>(3, "blog does not existed");
	}
}
