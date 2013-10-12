using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NSubstitute;
using TDD;
using TDD.Business.Services;
using TDD.Controllers;
using TDD.Data.Models;
using TDD.Models;
using Xunit;

namespace TDD.Tests.Controllers
{

	public class HomeControllerTest
	{
		[Fact]
		public void Index_ShouldGetCorrectViewModel()
		{
			var service = Substitute.For<IDataRoomService>();
			var expectedUsers = new List<DataRoomUser>()
			{
				new DataRoomUser {DataRoomID = 1, DataRoomUserID = 100, Username = "User"},
				new DataRoomUser {DataRoomID = 1, DataRoomUserID = 200, Username = "User2"}
			};
			var expectedDataRoom = new DataRoom() {DataRoomID = 1, DataRoomName = "room"};
			service.GetDataRoomUsers(1).Returns(expectedUsers);
			service.GetDataRoom(1).Returns(expectedDataRoom);
			var controller = new HomeController(service);

			var result = controller.Index(1);

			Assert.IsType<ViewResult>(result);
			var viewModel = (IndexViewModel)((ViewResult) result).ViewData.Model;
			Assert.Equal(viewModel.DataRoomUsers, expectedUsers);
			Assert.Equal(viewModel.DataRoom.DataRoomID, 1);
			Assert.Equal(viewModel.DataRoom.DataRoomName, "room");
		}
	}
}
