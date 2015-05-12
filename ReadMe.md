# HttpWebRequestFactory
HansKindberg.Net.HttpWebRequestFactory implementing System.Net.IWebRequestCreate creates a HttpWebRequest with DefaultCredentials and CookieContainer.

**Configuration example:**
<pre>
&lt;?xml version="1.0" encoding="utf-8" ?&gt;
&lt;configuration&gt;
	&lt;system.net&gt;
		&lt;webRequestModules&gt;
			&lt;remove prefix="http" /&gt;
			&lt;remove prefix="http:" /&gt;
			&lt;remove prefix="https" /&gt;
			&lt;remove prefix="https:" /&gt;
			&lt;add prefix="http" type="HansKindberg.Net.HttpWebRequestFactory, HansKindberg" /&gt;
		&lt;/webRequestModules&gt;
	&lt;/system.net&gt;
&lt;/configuration&gt;
</pre>