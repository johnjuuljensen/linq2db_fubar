// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB;
using LinqToDB.Mapping;
using System.Data.SqlTypes;

#pragma warning disable 1573, 1591
#nullable enable

namespace Cli.All.SqlServer.Azure
{
	[Table("TestSchema_SameTableName")]
	public class TestSchemaSameTableName
	{
		[Column("id", DataType = LinqToDB.DataType.Int32, DbType = "int")] public SqlInt32? Id { get; set; } // int
	}
}
