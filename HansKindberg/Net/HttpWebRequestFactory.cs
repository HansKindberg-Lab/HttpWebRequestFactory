using System;
using System.Net;

namespace HansKindberg.Net
{
	public class HttpWebRequestFactory : IHttpWebRequestFactory, IWebRequestCreate
	{
		#region Fields

		private readonly IHttpWebRequestFactory _defaultHttpWebRequestFactory;

		#endregion

		#region Constructors

		public HttpWebRequestFactory() : this(new DefaultHttpWebRequestFactory()) {}

		public HttpWebRequestFactory(IHttpWebRequestFactory defaultHttpWebRequestFactory)
		{
			if(defaultHttpWebRequestFactory == null)
				throw new ArgumentNullException("defaultHttpWebRequestFactory");

			this._defaultHttpWebRequestFactory = defaultHttpWebRequestFactory;
		}

		#endregion

		#region Properties

		protected internal virtual IHttpWebRequestFactory DefaultHttpWebRequestFactory
		{
			get { return this._defaultHttpWebRequestFactory; }
		}

		#endregion

		#region Methods

		WebRequest IWebRequestCreate.Create(Uri uri)
		{
			return this.Create(uri);
		}

		public virtual HttpWebRequest Create(Uri uri)
		{
			var httpWebRequest = this.DefaultHttpWebRequestFactory.Create(uri);

			httpWebRequest.CookieContainer = new CookieContainer();
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;

			return httpWebRequest;
		}

		#endregion
	}
}