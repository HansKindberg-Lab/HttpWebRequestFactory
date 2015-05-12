using System;
using System.Net;

namespace HansKindberg.Net
{
	public class DefaultHttpWebRequestFactory : IHttpWebRequestFactory, IWebRequestCreate
	{
		#region Fields

		private readonly IWebRequestCreate _httpRequestCreator;

		#endregion

		#region Constructors

		public DefaultHttpWebRequestFactory()
		{
			var httpRequestHeaderType = typeof(HttpRequestHeader);

			var httpRequestHeaderAssemblyQualifiedName = httpRequestHeaderType.AssemblyQualifiedName;

			if(httpRequestHeaderAssemblyQualifiedName == null)
				throw new InvalidOperationException("Could not get the assembly-qualified-name from the type \"{0}\".");

			var defaultHttpWebRequestFactoryTypeAssemblyQualifiedName = httpRequestHeaderAssemblyQualifiedName.Replace(httpRequestHeaderType.Name, "HttpRequestCreator");

			var defaultHttpWebRequestFactoryType = Type.GetType(defaultHttpWebRequestFactoryTypeAssemblyQualifiedName, true);

			this._httpRequestCreator = (IWebRequestCreate) Activator.CreateInstance(defaultHttpWebRequestFactoryType);
		}

		#endregion

		#region Properties

		protected internal virtual IWebRequestCreate HttpRequestCreator
		{
			get { return this._httpRequestCreator; }
		}

		#endregion

		#region Methods

		WebRequest IWebRequestCreate.Create(Uri uri)
		{
			return this.Create(uri);
		}

		public virtual HttpWebRequest Create(Uri uri)
		{
			return (HttpWebRequest) this.HttpRequestCreator.Create(uri);
		}

		#endregion
	}
}