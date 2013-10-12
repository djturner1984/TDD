using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using TDD.Business.Services;
using TDD.Data.Models;
using TDD.Data.Repositories;

namespace TDD
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AuthConfig.RegisterAuth();

			var builder = new ContainerBuilder();
			builder.RegisterType<DataRoomService>().As<IDataRoomService>();
			builder.RegisterType<DataRoomRepository>().As<IDataRoomRepository>();
			builder.Register(c => new FakeDatabase()
			{
				DataRooms = new List<DataRoom>()
				{
					new DataRoom() {DataRoomID = 1, DataRoomName = "LJ Hooker", LoginAddress = "LJHooker"},
					new DataRoom() {DataRoomID = 2, DataRoomName = "Panasonic", LoginAddress = "Panasonic"},
					new DataRoom() {DataRoomID = 3, DataRoomName = "Channel 9", LoginAddress = "ProjectChannelNine"},
					new DataRoom() {DataRoomID = 4, DataRoomName = "Yammer", LoginAddress = "Yammer"}
				},
				DataRoomUsers = new List<DataRoomUser>()
				{
					new DataRoomUser() {DataRoomUserID = 100, Username = "yammerUser1", DataRoomID = 4},
					new DataRoomUser() {DataRoomUserID = 101, Username = "yammerAdmin", DataRoomID = 4},
					new DataRoomUser() {DataRoomUserID = 102, Username = "channel9Admin", DataRoomID = 3},
					new DataRoomUser() {DataRoomUserID = 103, Username = "panasonicAdmin", DataRoomID = 2},
					new DataRoomUser() {DataRoomUserID = 104, Username = "ljHookerUser1", DataRoomID = 1},
					new DataRoomUser() {DataRoomUserID = 105, Username = "ljHookerAdmin", DataRoomID = 1},

				}
			}).As<FakeDatabase>();
			builder.RegisterControllers(Assembly.GetExecutingAssembly());
			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

			
		}
	}
}