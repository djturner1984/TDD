using System.Collections.Generic;
using System.Linq;
using TDD.Data.Models;
using TDD.Data.Repositories;

namespace TDD.Business.Services
{
	public class DataRoomService : IDataRoomService
	{
		private readonly IDataRoomRepository _repository;

		public DataRoomService(IDataRoomRepository repository)
		{
			_repository = repository;
		}

		public DataRoom GetDataRoom(int dataRoomID)
		{
			return _repository.GetDataRoomByID(dataRoomID);
		}
		#region omitted code
		public bool IsUserFromDataRoom(int dataRoomID, int dataRoomUserID)
		{
			return _repository.GetUsersByDataRoom(dataRoomID).Any(x => x.DataRoomUserID == dataRoomUserID);
		}

		public IEnumerable<DataRoomUser> GetDataRoomUsers(int dataRoomID)
		{
			return _repository.GetUsersByDataRoom(dataRoomID);
		}
		#endregion
	}

}
