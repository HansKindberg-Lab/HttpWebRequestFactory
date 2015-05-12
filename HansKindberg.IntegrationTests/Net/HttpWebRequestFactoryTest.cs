using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HansKindberg.IntegrationTests.Net
{
	[TestClass]
	public class HttpWebRequestFactoryTest
	{
		#region Methods

		[TestMethod]
		[SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings")]
		public void WebRequest_Create_WithStringParameter_ShouldReturnAHttpWebRequestWithCookieContainer()
		{
			var httpWebRequest = (HttpWebRequest) WebRequest.Create("http://localhost");
			Assert.IsNotNull(httpWebRequest.CookieContainer);

			httpWebRequest = (HttpWebRequest) WebRequest.Create("https://localhost");
			Assert.IsNotNull(httpWebRequest.CookieContainer);
		}

		[TestMethod]
		[SuppressMessage("Microsoft.Usage", "CA2234:PassSystemUriObjectsInsteadOfStrings")]
		public void WebRequest_Create_WithStringParameter_ShouldReturnAHttpWebRequestWithCredentials()
		{
			var httpWebRequest = (HttpWebRequest) WebRequest.Create("http://localhost");
			Assert.IsNotNull(httpWebRequest.Credentials);

			httpWebRequest = (HttpWebRequest) WebRequest.Create("https://localhost");
			Assert.IsNotNull(httpWebRequest.Credentials);
		}

		[TestMethod]
		public void WebRequest_Create_WithUriParameter_ShouldReturnAHttpWebRequestWithCookieContainer()
		{
			var httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri("http://localhost"));
			Assert.IsNotNull(httpWebRequest.CookieContainer);

			httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri("https://localhost"));
			Assert.IsNotNull(httpWebRequest.CookieContainer);
		}

		[TestMethod]
		public void WebRequest_Create_WithUriParameter_ShouldReturnAHttpWebRequestWithCredentials()
		{
			var httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri("http://localhost"));
			Assert.IsNotNull(httpWebRequest.Credentials);

			httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri("https://localhost"));
			Assert.IsNotNull(httpWebRequest.Credentials);
		}

		#endregion
	}
}