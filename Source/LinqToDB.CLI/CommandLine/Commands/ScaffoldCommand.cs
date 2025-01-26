﻿using LinqToDB.Scaffold;

namespace LinqToDB.CommandLine
{
	/// <summary>
	/// Scaffold command implementation.
	/// </summary>
	internal sealed partial class ScaffoldCommand : CliCommand
	{
		private ScaffoldCommand()
			: base(
				"scaffold",
				true,
				true,
				"<options>",
				"generate database data model classes from database schema",
				new CommandExample[]
				{
					new (
						"dotnet linq2db scaffold -o c:\\my_project\\model -p SqlServer -c \"Server=MySqlServer;Database=MyDatabase;User Id=scaffold_user;Password=secret;\"",
						"generates database model classes in specified folder for SQL Server database, pointed by specified connection string"),
					new (
						"dotnet linq2db scaffold -i path\\to\\my_scaffold_options.json -c \"Server=MySqlServer;Database=MyDatabase;User Id=scaffold_user;Password=secret;\"",
						"generates database model classes using options, specified in json file, except database connection string, passed explicitly"),
				})
		{
			// use current defaults to configure options defaults
			var defaultOptions = ScaffoldOptions.Default();

			// generic options
			AddOption(_generalOptions, General.Import);
			AddOption(_generalOptions, General.Output);
			AddOption(_generalOptions, General.Overwrite);
			AddOption(_generalOptions, General.Provider);
			AddOption(_generalOptions, General.ProviderLocation);
			AddOption(_generalOptions, General.ConnectionString);
			AddOption(_generalOptions, General.AdditionalConnectionString);
			AddOption(_generalOptions, General.Architecture);
			AddOption(_generalOptions, General.OptionsTemplate);
			AddOption(_generalOptions, General.Interceptors);

			// codegeneration options
			AddOption(_codeGenerationOptions, CodeGen.NRTEnable);
			AddOption(_codeGenerationOptions, CodeGen.Indent);
			AddOption(_codeGenerationOptions, CodeGen.NewLine);
			AddOption(_codeGenerationOptions, CodeGen.NoXmlDocWarns);
			AddOption(_codeGenerationOptions, CodeGen.MarkAutogenerated);
			AddOption(_codeGenerationOptions, CodeGen.SingleFile);
			AddOption(_codeGenerationOptions, CodeGen.AddGeneratedFileSuffix);
			AddOption(_codeGenerationOptions, CodeGen.ConflictingIdentifiers);
			AddOption(_codeGenerationOptions, CodeGen.CustomHeader);
			AddOption(_codeGenerationOptions, CodeGen.Namespace);

			// data model options
			AddOption(_dataModelOptions, DataModel.GenerateDbName);
			AddOption(_dataModelOptions, DataModel.GenerateDefaultSchemaName);
			AddOption(_dataModelOptions, DataModel.Metadata);
			AddOption(_dataModelOptions, DataModel.BaseEntity);
			AddOption(_dataModelOptions, DataModel.DataTypeOnTables);
			AddOption(_dataModelOptions, DataModel.DbTypeOnTables);
			AddOption(_dataModelOptions, DataModel.LengthOnTables);
			AddOption(_dataModelOptions, DataModel.PrecisionOnTables);
			AddOption(_dataModelOptions, DataModel.ScaleOnTables);
			AddOption(_dataModelOptions, DataModel.EmitDbInfo);
			AddOption(_dataModelOptions, DataModel.EmitDefaultConstructor);
			AddOption(_dataModelOptions, DataModel.EmitConfigurationConstructor);
			AddOption(_dataModelOptions, DataModel.EmitOptionsConstructor);
			AddOption(_dataModelOptions, DataModel.EmitTypedOptionsConstructor);
			AddOption(_dataModelOptions, DataModel.DataContextName);
			AddOption(_dataModelOptions, DataModel.DataContextBaseClass);
			AddOption(_dataModelOptions, DataModel.EmitInitDataContextMethod);
			AddOption(_dataModelOptions, DataModel.EmitAssociations);
			AddOption(_dataModelOptions, DataModel.EmitAssociationExtensions);
			// combines AssociationCollectionAsArray + AssociationCollectionType options
			AddOption(_dataModelOptions, DataModel.AssociationCollectionType);
			AddOption(_dataModelOptions, DataModel.ReuseEntitiesInFunctions);
			AddOption(_dataModelOptions, DataModel.TableFunctionReturnsITable);
			AddOption(_dataModelOptions, DataModel.EmitSchemaErrors);
			AddOption(_dataModelOptions, DataModel.StoredProcedureTypes);
			AddOption(_dataModelOptions, DataModel.SkipProceduresWithSchemaErrors);
			AddOption(_dataModelOptions, DataModel.ReturnListFromProcedures);
			AddOption(_dataModelOptions, DataModel.DbTypeInProcedures);
			AddOption(_dataModelOptions, DataModel.SchemasAsTypes);
			AddOption(_dataModelOptions, DataModel.GenerateIEquatable);
			AddOption(_dataModelOptions, DataModel.GenerateFind);
			AddOption(_dataModelOptions, DataModel.FindParametersInOrdinalOrder);
			AddOption(_dataModelOptions, DataModel.EntityClassIsPartial);
			AddOption(_dataModelOptions, DataModel.SchemaTypeClassNames);
			AddOption(_dataModelOptions, DataModel.UseFluentEntityTypeDiscriminator);
			// naming options
			AddOption(_dataModelOptions, DataModel.DataContextClassNaming);
			AddOption(_dataModelOptions, DataModel.EntityClassNaming);
			AddOption(_dataModelOptions, DataModel.EntityColumnPropertyNaming);
			AddOption(_dataModelOptions, DataModel.EntityContextPropertyNaming);
			AddOption(_dataModelOptions, DataModel.AssociationNaming);
			AddOption(_dataModelOptions, DataModel.AssocationBackReferenceSingleNaming);
			AddOption(_dataModelOptions, DataModel.AssocationBackReferenceManyNaming);
			AddOption(_dataModelOptions, DataModel.ProcOrFuncMethodNaming);
			AddOption(_dataModelOptions, DataModel.ProcOrFuncParameterNaming);
			AddOption(_dataModelOptions, DataModel.ProcOrFuncResultClassNaming);
			AddOption(_dataModelOptions, DataModel.AsyncProcResultClassNaming);
			AddOption(_dataModelOptions, DataModel.AsyncProcResultClassPropertyNaming);
			AddOption(_dataModelOptions, DataModel.ProcOrFuncResultColumnPropertyNaming);
			AddOption(_dataModelOptions, DataModel.FunctionTupleClassNaming);
			AddOption(_dataModelOptions, DataModel.FunctionTupleFieldPropertyNaming);
			AddOption(_dataModelOptions, DataModel.SchemaWrapperClassNaming);
			AddOption(_dataModelOptions, DataModel.SchemaContextPropertyNaming);
			AddOption(_dataModelOptions, DataModel.FindParameterNaming);
			// EntityClassNameProvider option : no CLI support
			// EntityContextPropertyNameProvider : no CLI support

			// schema options
			AddOption(_schemaOptions, SchemaOptions.LoadedObjects);
			AddOption(_schemaOptions, SchemaOptions.PreferProviderTypes);
			AddOption(_schemaOptions, SchemaOptions.IgnoreDuplicateFKs);
			AddOption(_schemaOptions, SchemaOptions.UseSafeSchemaLoadOnly);
			AddOption(_schemaOptions, SchemaOptions.LoadDatabaseName);
			AddOption(_schemaOptions, SchemaOptions.LoadProcedureSchema);
			AddOption(_schemaOptions, SchemaOptions.EnableSqlServerReturnValue);
			//defaultOptions.Schema.IncludeSchemas + defaultOptions.Schema.Schemas
			//defaultOptions.Schema.ExcludeSchemas + defaultOptions.Schema.Schemas
			AddMutuallyExclusiveOptions(_schemaOptions, SchemaOptions.IncludedSchemas, SchemaOptions.ExcludedSchemas);
			//defaultOptions.Schema.IncludeCatalogs + defaultOptions.Schema.Catalogs
			//defaultOptions.Schema.ExcludeCatalogs + defaultOptions.Schema.Catalogs
			AddMutuallyExclusiveOptions(_schemaOptions, SchemaOptions.IncludedCatalogs, SchemaOptions.ExcludedCatalogs);
			AddOption(_schemaOptions, SchemaOptions.DefaultSchemas);
			AddMutuallyExclusiveOptions(_schemaOptions, SchemaOptions.IncludedTables, SchemaOptions.ExcludedTables);
			AddMutuallyExclusiveOptions(_schemaOptions, SchemaOptions.IncludedViews, SchemaOptions.ExcludedViews);
			AddMutuallyExclusiveOptions(_schemaOptions, SchemaOptions.ProceduresWithSchema, SchemaOptions.ProceduresWithoutSchema);
			AddMutuallyExclusiveOptions(_schemaOptions, SchemaOptions.IncludedStoredProcedures, SchemaOptions.ExcludedStoredProcedures);
			AddMutuallyExclusiveOptions(_schemaOptions, SchemaOptions.IncludedTableFunctions, SchemaOptions.ExcludedTableFunctions);
			AddMutuallyExclusiveOptions(_schemaOptions, SchemaOptions.IncludedScalarFunctions, SchemaOptions.ExcludedScalarFunctions);
			AddMutuallyExclusiveOptions(_schemaOptions, SchemaOptions.IncludedAggregateFunctions, SchemaOptions.ExcludedAggregateFunctions);
		}
	}
}
