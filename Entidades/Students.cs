using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace AAVD.Entidades
{
    class Students
    {
		public Guid student_id { get; set; }
		public string name { get; set; }
		public string last_name { get; set; }
		public string mother_last_name { get; set; }
		public int semester { get; set; }
		public DateTime creation_date { get; set; }
		
	}
}
