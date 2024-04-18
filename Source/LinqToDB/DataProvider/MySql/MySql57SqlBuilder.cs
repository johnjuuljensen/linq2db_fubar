﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LinqToDB.DataProvider.MySql
{
	using Extensions;
	using Mapping;
	using SqlProvider;
	using SqlQuery;

	sealed class MySql57SqlBuilder : MySqlSqlBuilder
	{
		public MySql57SqlBuilder(IDataProvider? provider, MappingSchema mappingSchema, DataOptions dataOptions, ISqlOptimizer sqlOptimizer, SqlProviderFlags sqlProviderFlags)
			: base(provider, mappingSchema, dataOptions, sqlOptimizer, sqlProviderFlags)
		{
		}

		MySql57SqlBuilder(BasicSqlBuilder parentBuilder) : base(parentBuilder)
		{
		}

		protected override ISqlBuilder CreateSqlBuilder()
		{
			return new MySql57SqlBuilder(this) { HintBuilder = HintBuilder };
		}

		protected override void BuildSelectClause(SelectQuery selectQuery)
		{
			// mysql < 8 doesn't support WHERE without FROM
			// https://docs.oracle.com/cd/E19957-01/mysql-refman-5.5/sql-syntax.html#select
			if (selectQuery.From.Tables.Count == 0 && !selectQuery.Where.IsEmpty)
			{
				AppendIndent().Append("SELECT").AppendLine();
				BuildColumns(selectQuery);
				AppendIndent().Append("FROM DUAL").AppendLine();
			}
			else
				base.BuildSelectClause(selectQuery);
		}

		protected override void BuildDataTypeFromDataType(SqlDataType type, bool forCreateTable, bool canBeNull)
		{
			// FLOAT/DOUBLE support in CAST added only in v8.0.17
			if (!forCreateTable && type.Type.DataType is DataType.Double or DataType.Single)
			{
				base.BuildDataTypeFromDataType(SqlDataType.Decimal, forCreateTable, canBeNull);
			}
			else
			{
				base.BuildDataTypeFromDataType(type, forCreateTable, canBeNull);
			}
		}
	}
}
