using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDD.Business.Services;
using TDD.Models;

namespace TDD.Controllers
{
	public class HomeController : Controller
	{
		private readonly IDataRoomService _dataRoomService;

		public HomeController(IDataRoomService dataRoomService)
		{
			_dataRoomService = dataRoomService;
		}

		public ActionResult Index(int dataRoomID)
		{
			var vm = new IndexViewModel()
			{
				DataRoomUsers = _dataRoomService.GetDataRoomUsers(dataRoomID).ToList(),
				DataRoom = _dataRoomService.GetDataRoom(dataRoomID)
			};

			return View(vm);
		}
	}
}
