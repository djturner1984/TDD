using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDD.Data.Models;

namespace TDD.Models
{
	public class IndexViewModel
	{
		public List<DataRoomUser> DataRoomUsers { get; set; }
		public DataRoom DataRoom { get; set; }
	}
}