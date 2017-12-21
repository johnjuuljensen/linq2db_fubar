﻿using System;
using System.Collections.Generic;
using System.Text;
using LinqToDB.Mapping;

namespace LinqToDB.SqlQuery
{
	public class SqlCteTable : SqlTable
	{
		public          CteClause CTE  { get; }

		public override string    Name
		{
			get => CTE?.Name ?? base.Name;
			set => base.Name = value;
		}

		public SqlCteTable(
			[JetBrains.Annotations.NotNull] MappingSchema mappingSchema,
			[JetBrains.Annotations.NotNull] CteClause cte) : base(mappingSchema, cte.ObjectType)
		{
			CTE = cte ?? throw new ArgumentNullException(nameof(cte));
		}

		internal SqlCteTable(int id, string alias, SqlField[] fields, CteClause cte)
		   : base(id, cte.Name, alias, string.Empty, string.Empty, cte.Name, cte.ObjectType, null, fields, SqlTableType.CTE, null)
		{
			CTE = cte;
		}

		public SqlCteTable(SqlCteTable table, IEnumerable<SqlField> fields, CteClause cte)
		{
			Alias              = table.Alias;
			Database           = table.Database;
			Owner              = table.Owner;

			PhysicalName       = table.PhysicalName;
			ObjectType         = table.ObjectType;
			SequenceAttributes = table.SequenceAttributes;

			CTE                = cte;

			AddRange(fields);
		}

		public override QueryElementType ElementType  => QueryElementType.SqlCteTable;
		public override SqlTableType     SqlTableType => SqlTableType.CTE;

		public StringBuilder ToString(StringBuilder sb, Dictionary<IQueryElement, IQueryElement> dic)
		{
			return sb.Append(Name);
		}

		#region IQueryElement Members

		public string SqlText =>
			((IQueryElement) this).ToString(new StringBuilder(), new Dictionary<IQueryElement, IQueryElement>())
			.ToString();


		#endregion
	}
}
