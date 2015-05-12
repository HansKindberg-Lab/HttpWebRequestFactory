using System;
using System.Globalization;
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
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Could not get the assembly-qualified-name from the type \"{0}\".", httpRequestHeaderType));

			var defaultHttpWebRequestFactoryTypeAssemblyQualifiedName = httpRequestHeaderAssemblyQualifiedName.Replace(httpRequestHeaderType.Name, "HttpRequestCreator");

			var defaultHttpWebRequestFactoryType = Type.GetType(defaultHttpWebRequestFactoryTypeAssemblyQualifiedName, true);

			if(defaultHttpWebRequestFactoryType == null)
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Could not get the type from the assembly-qualified-name \"{0}\".", defaultHttpWebRequestFactoryTypeAssemblyQualifiedName));

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