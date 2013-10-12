using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDD.Data.Models;

namespace TDD.Data.Repositories
{
	public interface IDataRoomRepository
	{
		DataRoom GetDataRoomByID(int dataRoomID);
		DataRoomUser GetUserByID(int dataRoomUserID);
		IEnumerable<DataRoomUser> SearchDataRoomUsers(int dataRoomID, string criteria);
		IEnumerable<DataRoomUser> GetUsersByDataRoom(int dataRoomID);
	}
}
