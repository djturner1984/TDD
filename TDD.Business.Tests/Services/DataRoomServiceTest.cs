using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using TDD.Business.Services;
using TDD.Data.Models;
using TDD.Data.Repositories;
using Xunit;

namespace TDD.Business.Tests.Services
{
	public class DataRoomServiceTest
	{
		[Fact]
		public void GetDataRoom_ShouldGetCorrectDataRoomFromService()
		{
			var repository = Substitute.For<IDataRoomRepository>();
			repository.GetDataRoomByID(200).Returns(new DataRoom() { DataRoomID = 200, DataRoomName = "Data Room"});
			var service = new DataRoomService(repository);

			var dataRoom = service.GetDataRoom(200);

			Assert.NotNull(dataRoom);
			Assert.Equal(dataRoom.DataRoomID, 200);
			Assert.Equal(dataRoom.DataRoomName, "Data Room");
		}

		[Fact]
		public void IsUserFromDataRoom_ShouldFindUserInDataRoom()
		{
			var repository = Substitute.For<IDataRoomRepository>();
			repository.GetUsersByDataRoom(200)
				.Returns(new List<DataRoomUser>
				{
					new DataRoomUser {DataRoomID = 200, DataRoomUserID = 1},
					new DataRoomUser {DataRoomID = 300, DataRoomUserID = 2}
				});
			var service = new DataRoomService(repository);

			var result = service.IsUserFromDataRoom(200, 1);

			Assert.True(result);
		}

		[Fact]
		public void IsUserFromDataRoom_ShouldFindUserNotInDataRoom()
		{
			var repository = Substitute.For<IDataRoomRepository>();
			repository.GetUsersByDataRoom(200)
				.Returns(new List<DataRoomUser>
				{
					new DataRoomUser {DataRoomID = 200, DataRoomUserID = 1},
					new DataRoomUser {DataRoomID = 300, DataRoomUserID = 2}
				});
			var service = new DataRoomService(repository);

			var result = service.IsUserFromDataRoom(300, 1);

			Assert.False(result);
		}

		[Fact]
		public void GetDataRoomUsers_ShouldFindTwoUsersInDataRoom()
		{
			var repository = Substitute.For<IDataRoomRepository>();
			repository.GetUsersByDataRoom(200)
				.Returns(new List<DataRoomUser>
				{
					new DataRoomUser {DataRoomID = 200, DataRoomUserID = 1},
					new DataRoomUser {DataRoomID = 200, DataRoomUserID = 2},
					new DataRoomUser {DataRoomID = 200, DataRoomUserID = 2}
				});
			var service = new DataRoomService(repository);

			var users = service.GetDataRoomUsers(200).ToList();

			Assert.NotNull(users);
			Assert.Equal(users.Count(), 2);
		}
	}
}
