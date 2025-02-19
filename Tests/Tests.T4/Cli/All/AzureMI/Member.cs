// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.Tools.Comparers;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

#pragma warning disable 1573, 1591
#nullable enable

namespace Cli.All.SqlServer.Azure.MI
{
	[Table("Member")]
	public class Member : IEquatable<Member>
	{
		[Column("MemberId", DataType = LinqToDB.DataType.Int32   , DbType = "int"         , IsPrimaryKey = true, IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public SqlInt32  MemberId { get; set; } // int
		[Column("Alias"   , DataType = LinqToDB.DataType.NVarChar, DbType = "nvarchar(50)", Length       = 50                                                               )] public SqlString Alias    { get; set; } // nvarchar(50)

		#region IEquatable<T> support
		private static readonly IEqualityComparer<Member> _equalityComparer = ComparerBuilder.GetEqualityComparer<Member>(c => c.MemberId);

		public bool Equals(Member? other)
		{
			return _equalityComparer.Equals(this, other!);
		}

		public override int GetHashCode()
		{
			return _equalityComparer.GetHashCode(this);
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as Member);
		}
		#endregion

		#region Associations
		/// <summary>
		/// FK_Provider_Member backreference
		/// </summary>
		[Association(ThisKey = nameof(MemberId), OtherKey = nameof(MI.Provider.ProviderId))]
		public Provider? Provider { get; set; }
		#endregion
	}
}
