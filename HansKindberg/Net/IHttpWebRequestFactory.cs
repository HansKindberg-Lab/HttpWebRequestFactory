using System;
using System.Net;

namespace HansKindberg.Net
{
	public interface IHttpWebRequestFactory
	{
		#region Methods

		HttpWebRequest Create(Uri uri);

		#endregion
	}
}