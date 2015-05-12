using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyDescription("Enter a description")]
[assembly: CLSCompliant(true)]
[assembly: Guid("19c788df-ba50-46df-b3ac-6de0e63dccd9")]
[assembly: InternalsVisibleTo("HansKindberg.IntegrationTests")]
[assembly: InternalsVisibleTo("HansKindberg.ShimTests")]
[assembly: InternalsVisibleTo("HansKindberg.UnitTests")]

// ReSharper disable CheckNamespace
internal static class AssemblyInfo // ReSharper restore CheckNamespace
{
	#region Fields

	internal const string AssemblyName = "HansKindberg";

	#endregion
}