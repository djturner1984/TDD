using System;
using System.Collections.Generic;
using System.Linq;
using TDD.Data.Models;

namespace TDD.Data.Repositories
{
	public class DataRoomRepository : IDataRoomRepository
	{
		private readonly FakeDatabase _database = new FakeDatabase();

		public DataRoomRepository(FakeDatabase database)
		{
			_database = database;
		}

		public DataRoom GetDataRoomByID(int dataRoomID)
		{
			return _database.DataRooms.FirstOrDefault(x => x.DataRoomID == dataRoomID);
		}

		public DataRoomUser GetUserByID(int dataRoomUserID)
		{
			return _database.DataRoomUsers.FirstOrDefault(x => x.DataRoomUserID == dataRoomUserID);
		}

		public IEnumerable<DataRoomUser> SearchDataRoomUsers(int dataRoomID, string criteria)
		{
			return _database.DataRoomUsers.Where(x => x.DataRoomID == dataRoomID && x.Username.ToLower().Contains(criteria.ToLower()));
			//return _database.DataRoomUsers.Where(x => x.DataRoomID == dataRoomID && x.Username.IndexOf(criteria, StringComparison.InvariantCultureIgnoreCase) >= 0);
		}

		public IEnumerable<DataRoomUser> GetUsersByDataRoom(int dataRoomID)
		{
			return _database.DataRoomUsers.Where(x => x.DataRoomID == dataRoomID);
		}
	}
}