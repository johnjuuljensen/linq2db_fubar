﻿using System;
using System.Data.Common;
using System.Linq.Expressions;

namespace LinqToDB.DataProvider.SQLite
{
	using Expressions;

	public class SQLiteProviderAdapter : IDynamicProviderAdapter
	{
		private static readonly object _systemSyncRoot = new ();
		private static readonly object _msSyncRoot     = new ();

		private static SQLiteProviderAdapter? _systemDataSQLite;
		private static SQLiteProviderAdapter? _microsoftDataSQLite;

		public const string SystemDataSQLiteAssemblyName       = "System.Data.SQLite";
		public const string SystemDataSQLiteClientNamespace    = "System.Data.SQLite";

		public const string MicrosoftDataSQLiteAssemblyName    = "Microsoft.Data.Sqlite";
		public const string MicrosoftDataSQLiteClientNamespace = "Microsoft.Data.Sqlite";

		private SQLiteProviderAdapter(
			Type                       connectionType,
			Type                       dataReaderType,
			Type                       parameterType,
			Type                       commandType,
			Type                       transactionType,
			Func<string, DbConnection> connectionFactory,
			bool                       disposeCommandOnError,
			bool                       supportsRowValue,
			bool                       supportsUpdateFrom,
			bool                       supportsDateOnly,
			Action?                    clearAllPulls)
		{
			ConnectionType     = connectionType;
			DataReaderType     = dataReaderType;
			ParameterType      = parameterType;
			CommandType        = commandType;
			TransactionType    = transactionType;
			_connectionFactory = connectionFactory;

			DisposeCommandOnError = disposeCommandOnError;
			SupportsRowValue      = supportsRowValue;
			SupportsUpdateFrom    = supportsUpdateFrom;
			SupportsDateOnly      = supportsDateOnly;

			ClearAllPools      = clearAllPulls;
		}

#region IDynamicProviderAdapter

		public Type ConnectionType  { get; }
		public Type DataReaderType  { get; }
		public Type ParameterType   { get; }
		public Type CommandType     { get; }
		public Type TransactionType { get; }

		readonly Func<string, DbConnection> _connectionFactory;
		public DbConnection CreateConnection(string connectionString) => _connectionFactory(connectionString);

#endregion

		/// <summary>
		/// Enables workaround for https://github.com/aspnet/EntityFrameworkCore/issues/17521
		/// for Microsoft.Data.Sqlite v3.0.0.
		/// </summary>
		internal bool DisposeCommandOnError { get; }

		// ROW VALUE feature introduced in SQLite 3.15.0.
		internal bool SupportsRowValue { get; }
		// UPDATE FROM feature introduced in SQLite 3.33.0.
		internal bool SupportsUpdateFrom { get; }
		// Classic driver does not store dates correctly
		internal bool SupportsDateOnly { get; }

		public Action? ClearAllPools { get; }

		private static SQLiteProviderAdapter CreateAdapter(string assemblyName, string clientNamespace, string prefix)
		{
			var assembly = Common.Tools.TryLoadAssembly(assemblyName, null);
			if (assembly == null)
				throw new InvalidOperationException($"Cannot load assembly {assemblyName}");

			var connectionType  = assembly.GetType($"{clientNamespace}.{prefix}Connection" , true)!;
			var dataReaderType  = assembly.GetType($"{clientNamespace}.{prefix}DataReader" , true)!;
			var parameterType   = assembly.GetType($"{clientNamespace}.{prefix}Parameter"  , true)!;
			var commandType     = assembly.GetType($"{clientNamespace}.{prefix}Command"    , true)!;
			var transactionType = assembly.GetType($"{clientNamespace}.{prefix}Transaction", true)!;

			var disposeCommandOnError = connectionType.AssemblyQualifiedName == "Microsoft.Data.Sqlite.SqliteConnection, Microsoft.Data.Sqlite, Version=3.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60";

			var version = assembly.GetName().Version;

			var typeMapper = new TypeMapper();
			if (clientNamespace == MicrosoftDataSQLiteClientNamespace)
			{
				typeMapper.RegisterTypeWrapper<SqliteConnection>(connectionType);
			}
			else
			{
				typeMapper.RegisterTypeWrapper<SQLiteConnection>(connectionType);
			}
			typeMapper.FinalizeMappings();

			Action? clearAllPools = null;

			if (clientNamespace == MicrosoftDataSQLiteClientNamespace)
			{
				if (version >= ClearPoolsMinVersionMDS)
				{
					clearAllPools = typeMapper.BuildAction(typeMapper.MapActionLambda(() => SqliteConnection.ClearAllPools()));
				}
			}
			else if (version >= ClearPoolsMinVersionSDS)
			{
				clearAllPools = typeMapper.BuildAction(typeMapper.MapActionLambda(() => SQLiteConnection.ClearAllPools()));
			}

			var supportsRowValue   = version >= (clientNamespace == MicrosoftDataSQLiteClientNamespace ? RowValueMinVersionMDS   : RowValueMinVersionSDS);
			var supportsUpdateFrom = version >= (clientNamespace == MicrosoftDataSQLiteClientNamespace ? UpdateFromMinVersionMDS : UpdateFromMinVersionSDS);
			var supportsDateOnly   = clientNamespace == MicrosoftDataSQLiteClientNamespace && assembly.GetName().Version >= MinDateOnlyAssemblyVersionMDS;

			Func<string, DbConnection> connectionFactory;
			if (clientNamespace == MicrosoftDataSQLiteClientNamespace)
			{
				connectionFactory = typeMapper.BuildTypedFactory<string, SqliteConnection, DbConnection>((string connectionString) => new SqliteConnection(connectionString));
			}
			else
			{
				connectionFactory = typeMapper.BuildTypedFactory<string, SQLiteConnection, DbConnection>((string connectionString) => new SQLiteConnection(connectionString));
			}

			return new SQLiteProviderAdapter(
				connectionType,
				dataReaderType,
				parameterType,
				commandType,
				transactionType,
				connectionFactory,
				disposeCommandOnError,
				supportsRowValue,
				supportsUpdateFrom,
				supportsDateOnly,
				clearAllPools);
		}

		private static readonly Version ClearPoolsMinVersionMDS       = new (6, 0, 0);
		private static readonly Version ClearPoolsMinVersionSDS       = new (1, 0, 55);
		private static readonly Version RowValueMinVersionMDS         = new (2, 0, 0);
		private static readonly Version RowValueMinVersionSDS         = new (1, 0, 104);
		private static readonly Version UpdateFromMinVersionMDS       = new (3, 1, 20);
		private static readonly Version UpdateFromMinVersionSDS       = new (1, 0, 114);
		private static readonly Version MinDateOnlyAssemblyVersionMDS = new (6, 0, 0);
		

		public static SQLiteProviderAdapter GetInstance(SQLiteProvider provider)
		{
			if (provider == SQLiteProvider.System)
			{
				if (_systemDataSQLite == null)
				{
					lock (_systemSyncRoot)
#pragma warning disable CA1508 // Avoid dead conditional code
						_systemDataSQLite ??= CreateAdapter(SystemDataSQLiteAssemblyName, SystemDataSQLiteClientNamespace, "SQLite");
#pragma warning restore CA1508 // Avoid dead conditional code
				}

				return _systemDataSQLite;
			}
			else
			{
				if (_microsoftDataSQLite == null)
				{
					lock (_msSyncRoot)
#pragma warning disable CA1508 // Avoid dead conditional code
						_microsoftDataSQLite ??= CreateAdapter(MicrosoftDataSQLiteAssemblyName, MicrosoftDataSQLiteClientNamespace, "Sqlite");
#pragma warning restore CA1508 // Avoid dead conditional code
				}

				return _microsoftDataSQLite;
			}
		}

		#region wrappers
		[Wrapper]
		private sealed class SqliteConnection
		{
			public SqliteConnection(string connectionString) => throw new NotImplementedException();

			public static void ClearAllPools() => throw new NotImplementedException();
		}

		[Wrapper]
		private sealed class SQLiteConnection
		{
			public SQLiteConnection(string connectionString) => throw new NotImplementedException();

			public static void ClearAllPools() => throw new NotImplementedException();
		}

		#endregion
	}
}
