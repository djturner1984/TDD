using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TDD.Data.Models;

namespace TDD.Business.Services
{
	public interface IDataRoomService
	{
		DataRoom GetDataRoom(int dataRoomID);
		bool IsUserFromDataRoom(int dataRoomID, int dataRoomUserID);
		IEnumerable<DataRoomUser> GetDataRoomUsers(int dataRoomID);
	}
}