using System;
using HansKindberg.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HansKindberg.IntegrationTests.Net
{
	[TestClass]
	public class DefaultHttpWebRequestFactoryTest
	{
		#region Methods

		[TestMethod]
		public void Create_ShouldReturnAHttpWebRequestInstance()
		{
			Assert.IsNotNull(new DefaultHttpWebRequestFactory().Create(new Uri("http://localhost")));
		}

		[TestMethod]
		public void Create_ShouldReturnAHttpWebRequestInstanceWithCorrectAddress()
		{
			var uri = new Uri("http://localhost/");

			var httpWebRequest = new DefaultHttpWebRequestFactory().Create(uri);

			Assert.AreEqual(uri, httpWebRequest.Address);
		}

		[TestMethod]
		public void Create_ShouldReturnAHttpWebRequestInstanceWithCorrectRequestUri()
		{
			var uri = new Uri("http://localhost/");

			var httpWebRequest = new DefaultHttpWebRequestFactory().Create(uri);

			Assert.AreEqual(uri, httpWebRequest.RequestUri);
		}

		#endregion
	}
}