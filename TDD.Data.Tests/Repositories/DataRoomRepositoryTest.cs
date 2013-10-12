using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDD.Data.Models;
using TDD.Data.Repositories;
using Xunit;

namespace TDD.Data.Tests.Repositories
{
	public class DataRoomRepositoryTest
	{
		[Fact]
		public void GetDataRoomByID_ShouldGetCorrectDataRoom()
		{
			var database = new FakeDatabase()
			{
				DataRooms = new List<DataRoom>
				{
					new DataRoom {DataRoomID = 1, DataRoomName = "I Love Data"},
					new DataRoom {DataRoomID = 2, DataRoomName = "I Hate Data"}
				}
			};
			var repository = new DataRoomRepository(database);

			var dataRoom = repository.GetDataRoomByID(1);

			Assert.NotNull(dataRoom);
			Assert.Equal(dataRoom.DataRoomID, 1);
			Assert.Equal(dataRoom.DataRoomName, "I Love Data");
		}

		[Fact]
		public void GetUserByID_ShouldGetCorrectUser()
		{
			var database = new FakeDatabase()
			{
				DataRoomUsers = new List<DataRoomUser>
				{
					new DataRoomUser {DataRoomUserID = 1, Username = "DataLover"},
					new DataRoomUser {DataRoomUserID = 2, Username = "Hater"}
				}
			};
			var repository = new DataRoomRepository(database);

			var dataRoomUser = repository.GetUserByID(2);

			Assert.NotNull(dataRoomUser);
			Assert.Equal(dataRoomUser.DataRoomUserID, 2);
			Assert.Equal(dataRoomUser.Username, "Hater");
		}

		[Fact]
		public void ShouldGetTwoDataRoomUsers()
		{
			var database = new FakeDatabase()
			{
				DataRooms = new List<DataRoom>
				{
					new DataRoom {DataRoomID = 1, DataRoomName = "I Love Data"},
					new DataRoom {DataRoomID = 2, DataRoomName = "I Hate Data"}
				},
				DataRoomUsers = new List<DataRoomUser>
				{
					new DataRoomUser {DataRoomUserID = 100, Username = "DataLover", DataRoomID = 1},
					new DataRoomUser {DataRoomUserID = 200, Username = "DataHater", DataRoomID = 1},
					new DataRoomUser {DataRoomUserID = 300, Username = "User1", DataRoomID = 1},
					new DataRoomUser {DataRoomUserID = 400, Username = "User2", DataRoomID = 1},
					new DataRoomUser {DataRoomUserID = 500, Username = "User3", DataRoomID = 2}
				}
			};
			var repository = new DataRoomRepository(database);

			var users = repository.SearchDataRoomUsers(1, "data").OrderBy(x => x.Username).ToList();

			Assert.NotNull(users);
			Assert.Equal(users.Count, 2);
			Assert.Equal(users[0].DataRoomUserID, 200);
			Assert.Equal(users[0].Username, "DataHater");
			Assert.Equal(users[1].DataRoomUserID, 100);
			Assert.Equal(users[1].Username, "DataLover");
		}

		[Fact]
		public void ShouldGetThreeDataRoomUsers()
		{
			var database = new FakeDatabase()
			{
				DataRooms = new List<DataRoom>
				{
					new DataRoom {DataRoomID = 1, DataRoomName = "I Love Data"}
				},
				DataRoomUsers = new List<DataRoomUser>
				{
					new DataRoomUser {DataRoomUserID = 100, Username = "DataLover", DataRoomID = 1},
					new DataRoomUser {DataRoomUserID = 200, Username = "DataHater", DataRoomID = 1},
					new DataRoomUser {DataRoomUserID = 300, Username = "User1", DataRoomID = 1},
					new DataRoomUser {DataRoomUserID = 500, Username = "User3", DataRoomID = 2}
				}
			};
			var repository = new DataRoomRepository(database);

			var users = repository.GetUsersByDataRoom(1).OrderBy(x => x.Username).ToList();

			Assert.NotNull(users);
			Assert.Equal(users.Count, 3);
			Assert.Equal(users[0].DataRoomUserID, 200);
			Assert.Equal(users[0].Username, "DataHater");
			Assert.Equal(users[1].DataRoomUserID, 100);
			Assert.Equal(users[1].Username, "DataLover");
			Assert.Equal(users[2].DataRoomUserID, 300);
			Assert.Equal(users[2].Username, "User1");
		}
	}
}
