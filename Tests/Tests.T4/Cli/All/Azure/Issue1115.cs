// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591
#nullable enable

namespace Cli.All.SqlServer.Azure
{
	[Table("Issue1115")]
	public class Issue1115 : IEquatable<Issue1115>
	{
		[Column("id", DataType = LinqToDB.DataType.Udt, DbType = "hierarchyid", IsPrimaryKey = true)] public SqlHierarchyId Id { get; set; } // hierarchyid

		#region IEquatable<T> support
		private static readonly IEqualityComparer<Issue1115> _equalityComparer = ComparerBuilder.GetEqualityComparer<Issue1115>(c => c.Id);

		public bool Equals(Issue1115? other)
		{
			return _equalityComparer.Equals(this, other!);
		}

		public override int GetHashCode()
		{
			return _equalityComparer.GetHashCode(this);
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as Issue1115);
		}
		#endregion
	}
}
