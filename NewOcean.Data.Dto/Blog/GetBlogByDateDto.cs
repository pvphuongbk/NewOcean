using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOcean.Data.Dto.Blog
{
	public class GetBlogByDateDto
	{
		public DateTime From { get; set; }

		public DateTime To { get; set; }
	}
}
