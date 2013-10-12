using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD.Data.Models
{
	public class FakeDatabase
	{
		public List<DataRoom> DataRooms { get; set; }
		public List<DataRoomUser> DataRoomUsers { get; set; }
	}
}
