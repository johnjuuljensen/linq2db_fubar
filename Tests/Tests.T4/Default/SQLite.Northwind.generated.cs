﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1573, 1591
#nullable enable

using System;
using System.Linq;

using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Mapping;

namespace Default.SQLiteNorthwind
{
	public partial class TestDataDB : LinqToDB.Data.DataConnection
	{
		public ITable<AlphabeticalListOfProduct>  AlphabeticalListOfProducts   { get { return this.GetTable<AlphabeticalListOfProduct>(); } }
		public ITable<Category>                   Categories                   { get { return this.GetTable<Category>(); } }
		public ITable<CurrentProductList>         CurrentProductLists          { get { return this.GetTable<CurrentProductList>(); } }
		public ITable<Customer>                   Customers                    { get { return this.GetTable<Customer>(); } }
		public ITable<CustomerAndSuppliersByCity> CustomerAndSuppliersByCities { get { return this.GetTable<CustomerAndSuppliersByCity>(); } }
		public ITable<CustomerCustomerDemo>       CustomerCustomerDemoes       { get { return this.GetTable<CustomerCustomerDemo>(); } }
		public ITable<CustomerDemographic>        CustomerDemographics         { get { return this.GetTable<CustomerDemographic>(); } }
		public ITable<Employee>                   Employees                    { get { return this.GetTable<Employee>(); } }
		public ITable<EmployeeTerritory>          EmployeeTerritories          { get { return this.GetTable<EmployeeTerritory>(); } }
		public ITable<Order>                      Orders                       { get { return this.GetTable<Order>(); } }
		public ITable<OrderDetail>                OrderDetails                 { get { return this.GetTable<OrderDetail>(); } }
		public ITable<OrderDetailsExtended>       OrderDetailsExtendeds        { get { return this.GetTable<OrderDetailsExtended>(); } }
		public ITable<OrdersQry>                  OrdersQries                  { get { return this.GetTable<OrdersQry>(); } }
		public ITable<OrderSubtotal>              OrderSubtotals               { get { return this.GetTable<OrderSubtotal>(); } }
		public ITable<Product>                    Products                     { get { return this.GetTable<Product>(); } }
		public ITable<ProductsAboveAveragePrice>  ProductsAboveAveragePrices   { get { return this.GetTable<ProductsAboveAveragePrice>(); } }
		public ITable<ProductsByCategory>         ProductsByCategories         { get { return this.GetTable<ProductsByCategory>(); } }
		public ITable<Region>                     Regions                      { get { return this.GetTable<Region>(); } }
		public ITable<Shipper>                    Shippers                     { get { return this.GetTable<Shipper>(); } }
		public ITable<SummaryOfSalesByQuarter>    SummaryOfSalesByQuarters     { get { return this.GetTable<SummaryOfSalesByQuarter>(); } }
		public ITable<SummaryOfSalesByYear>       SummaryOfSalesByYears        { get { return this.GetTable<SummaryOfSalesByYear>(); } }
		public ITable<Supplier>                   Suppliers                    { get { return this.GetTable<Supplier>(); } }
		public ITable<Territory>                  Territories                  { get { return this.GetTable<Territory>(); } }

		public TestDataDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public TestDataDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public TestDataDB(DataOptions options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table("Alphabetical list of products", IsView=true)]
	public partial class AlphabeticalListOfProduct
	{
		[Column, NotNull    ] public int     ProductID       { get; set; } // int
		[Column, NotNull    ] public string  ProductName     { get; set; } = null!; // varchar(40)
		[Column,    Nullable] public int?    SupplierID      { get; set; } // int
		[Column,    Nullable] public int?    CategoryID      { get; set; } // int
		[Column,    Nullable] public string? QuantityPerUnit { get; set; } // varchar(20)
		[Column,    Nullable] public double? UnitPrice       { get; set; } // float
		[Column,    Nullable] public int?    UnitsInStock    { get; set; } // int
		[Column,    Nullable] public int?    UnitsOnOrder    { get; set; } // int
		[Column,    Nullable] public int?    ReorderLevel    { get; set; } // int
		[Column, NotNull    ] public int     Discontinued    { get; set; } // int
		[Column, NotNull    ] public string  CategoryName    { get; set; } = null!; // varchar(15)
	}

	[Table("Categories")]
	public partial class Category
	{
		[PrimaryKey, NotNull    ] public int     CategoryID   { get; set; } // int
		[Column,     NotNull    ] public string  CategoryName { get; set; } = null!; // varchar(15)
		[Column,        Nullable] public string? Description  { get; set; } // text(max)
		[Column,        Nullable] public byte[]? Picture      { get; set; } // blob
	}

	[Table("Current Product List", IsView=true)]
	public partial class CurrentProductList
	{
		[Column, NotNull] public int    ProductID   { get; set; } // int
		[Column, NotNull] public string ProductName { get; set; } = null!; // varchar(40)
	}

	[Table("Customers")]
	public partial class Customer
	{
		[PrimaryKey, NotNull    ] public string  CustomerID   { get; set; } = null!; // varchar(5)
		[Column,     NotNull    ] public string  CompanyName  { get; set; } = null!; // varchar(40)
		[Column,        Nullable] public string? ContactName  { get; set; } // varchar(30)
		[Column,        Nullable] public string? ContactTitle { get; set; } // varchar(30)
		[Column,        Nullable] public string? Address      { get; set; } // varchar(60)
		[Column,        Nullable] public string? City         { get; set; } // varchar(15)
		[Column,        Nullable] public string? Region       { get; set; } // varchar(15)
		[Column,        Nullable] public string? PostalCode   { get; set; } // varchar(10)
		[Column,        Nullable] public string? Country      { get; set; } // varchar(15)
		[Column,        Nullable] public string? Phone        { get; set; } // varchar(24)
		[Column,        Nullable] public string? Fax          { get; set; } // varchar(24)
	}

	[Table("Customer and Suppliers by City", IsView=true)]
	public partial class CustomerAndSuppliersByCity
	{
		[Column,    Nullable] public string? City         { get; set; } // varchar(15)
		[Column, NotNull    ] public string  CompanyName  { get; set; } = null!; // varchar(40)
		[Column,    Nullable] public string? ContactName  { get; set; } // varchar(30)
		[Column,    Nullable] public object? Relationship { get; set; }
	}

	[Table("CustomerCustomerDemo")]
	public partial class CustomerCustomerDemo
	{
		[PrimaryKey(0), NotNull] public string CustomerID     { get; set; } = null!; // varchar(5)
		[PrimaryKey(1), NotNull] public string CustomerTypeID { get; set; } = null!; // varchar(10)
	}

	[Table("CustomerDemographics")]
	public partial class CustomerDemographic
	{
		[PrimaryKey, NotNull    ] public string  CustomerTypeID { get; set; } = null!; // varchar(10)
		[Column,        Nullable] public string? CustomerDesc   { get; set; } // text(max)
	}

	[Table("Employees")]
	public partial class Employee
	{
		[PrimaryKey,                                   NotNull    ] public int       EmployeeID      { get; set; } // int
		[Column,                                       NotNull    ] public string    LastName        { get; set; } = null!; // varchar(20)
		[Column,                                       NotNull    ] public string    FirstName       { get; set; } = null!; // varchar(10)
		[Column,                                          Nullable] public string?   Title           { get; set; } // varchar(30)
		[Column,                                          Nullable] public string?   TitleOfCourtesy { get; set; } // varchar(25)
		[Column(SkipOnInsert=true, SkipOnUpdate=true),    Nullable] public DateTime? BirthDate       { get; set; } // timestamp
		[Column(SkipOnInsert=true, SkipOnUpdate=true),    Nullable] public DateTime? HireDate        { get; set; } // timestamp
		[Column,                                          Nullable] public string?   Address         { get; set; } // varchar(60)
		[Column,                                          Nullable] public string?   City            { get; set; } // varchar(15)
		[Column,                                          Nullable] public string?   Region          { get; set; } // varchar(15)
		[Column,                                          Nullable] public string?   PostalCode      { get; set; } // varchar(10)
		[Column,                                          Nullable] public string?   Country         { get; set; } // varchar(15)
		[Column,                                          Nullable] public string?   HomePhone       { get; set; } // varchar(24)
		[Column,                                          Nullable] public string?   Extension       { get; set; } // varchar(4)
		[Column,                                          Nullable] public byte[]?   Photo           { get; set; } // blob
		[Column,                                          Nullable] public string?   Notes           { get; set; } // text(max)
		[Column,                                          Nullable] public int?      ReportsTo       { get; set; } // int
		[Column,                                          Nullable] public string?   PhotoPath       { get; set; } // varchar(255)
	}

	[Table("EmployeeTerritories")]
	public partial class EmployeeTerritory
	{
		[PrimaryKey(0), NotNull] public int    EmployeeID  { get; set; } // int
		[PrimaryKey(1), NotNull] public string TerritoryID { get; set; } = null!; // varchar(20)
	}

	[Table("Orders")]
	public partial class Order
	{
		[PrimaryKey,                                   NotNull    ] public int       OrderID        { get; set; } // int
		[Column,                                          Nullable] public string?   CustomerID     { get; set; } // varchar(5)
		[Column,                                          Nullable] public int?      EmployeeID     { get; set; } // int
		[Column(SkipOnInsert=true, SkipOnUpdate=true),    Nullable] public DateTime? OrderDate      { get; set; } // timestamp
		[Column(SkipOnInsert=true, SkipOnUpdate=true),    Nullable] public DateTime? RequiredDate   { get; set; } // timestamp
		[Column(SkipOnInsert=true, SkipOnUpdate=true),    Nullable] public DateTime? ShippedDate    { get; set; } // timestamp
		[Column,                                          Nullable] public int?      ShipVia        { get; set; } // int
		[Column,                                          Nullable] public double?   Freight        { get; set; } // float
		[Column,                                          Nullable] public string?   ShipName       { get; set; } // varchar(40)
		[Column,                                          Nullable] public string?   ShipAddress    { get; set; } // varchar(60)
		[Column,                                          Nullable] public string?   ShipCity       { get; set; } // varchar(15)
		[Column,                                          Nullable] public string?   ShipRegion     { get; set; } // varchar(15)
		[Column,                                          Nullable] public string?   ShipPostalCode { get; set; } // varchar(10)
		[Column,                                          Nullable] public string?   ShipCountry    { get; set; } // varchar(15)
	}

	[Table("Order Details")]
	public partial class OrderDetail
	{
		[PrimaryKey(0), NotNull    ] public int     OrderID   { get; set; } // int
		[PrimaryKey(1), NotNull    ] public int     ProductID { get; set; } // int
		[Column,           Nullable] public double? UnitPrice { get; set; } // float
		[Column,           Nullable] public int?    Quantity  { get; set; } // int
		[Column,           Nullable] public double? Discount  { get; set; } // float
	}

	[Table("Order Details Extended", IsView=true)]
	public partial class OrderDetailsExtended
	{
		[Column, NotNull    ] public int     OrderID       { get; set; } // int
		[Column, NotNull    ] public int     ProductID     { get; set; } // int
		[Column, NotNull    ] public string  ProductName   { get; set; } = null!; // varchar(40)
		[Column,    Nullable] public double? UnitPrice     { get; set; } // float
		[Column,    Nullable] public int?    Quantity      { get; set; } // int
		[Column,    Nullable] public double? Discount      { get; set; } // float
		[Column,    Nullable] public object? ExtendedPrice { get; set; }
	}

	[Table("Orders Qry", IsView=true)]
	public partial class OrdersQry
	{
		[Column,                                       NotNull    ] public int       OrderID        { get; set; } // int
		[Column,                                          Nullable] public string?   CustomerID     { get; set; } // varchar(5)
		[Column,                                          Nullable] public int?      EmployeeID     { get; set; } // int
		[Column(SkipOnInsert=true, SkipOnUpdate=true),    Nullable] public DateTime? OrderDate      { get; set; } // timestamp
		[Column(SkipOnInsert=true, SkipOnUpdate=true),    Nullable] public DateTime? RequiredDate   { get; set; } // timestamp
		[Column(SkipOnInsert=true, SkipOnUpdate=true),    Nullable] public DateTime? ShippedDate    { get; set; } // timestamp
		[Column,                                          Nullable] public int?      ShipVia        { get; set; } // int
		[Column,                                          Nullable] public double?   Freight        { get; set; } // float
		[Column,                                          Nullable] public string?   ShipName       { get; set; } // varchar(40)
		[Column,                                          Nullable] public string?   ShipAddress    { get; set; } // varchar(60)
		[Column,                                          Nullable] public string?   ShipCity       { get; set; } // varchar(15)
		[Column,                                          Nullable] public string?   ShipRegion     { get; set; } // varchar(15)
		[Column,                                          Nullable] public string?   ShipPostalCode { get; set; } // varchar(10)
		[Column,                                          Nullable] public string?   ShipCountry    { get; set; } // varchar(15)
		[Column,                                       NotNull    ] public string    CompanyName    { get; set; } = null!; // varchar(40)
		[Column,                                          Nullable] public string?   Address        { get; set; } // varchar(60)
		[Column,                                          Nullable] public string?   City           { get; set; } // varchar(15)
		[Column,                                          Nullable] public string?   Region         { get; set; } // varchar(15)
		[Column,                                          Nullable] public string?   PostalCode     { get; set; } // varchar(10)
		[Column,                                          Nullable] public string?   Country        { get; set; } // varchar(15)
	}

	[Table("Order Subtotals", IsView=true)]
	public partial class OrderSubtotal
	{
		[Column, NotNull    ] public int     OrderID  { get; set; } // int
		[Column,    Nullable] public object? Subtotal { get; set; }
	}

	[Table("Products")]
	public partial class Product
	{
		[PrimaryKey, NotNull    ] public int     ProductID       { get; set; } // int
		[Column,     NotNull    ] public string  ProductName     { get; set; } = null!; // varchar(40)
		[Column,        Nullable] public int?    SupplierID      { get; set; } // int
		[Column,        Nullable] public int?    CategoryID      { get; set; } // int
		[Column,        Nullable] public string? QuantityPerUnit { get; set; } // varchar(20)
		[Column,        Nullable] public double? UnitPrice       { get; set; } // float
		[Column,        Nullable] public int?    UnitsInStock    { get; set; } // int
		[Column,        Nullable] public int?    UnitsOnOrder    { get; set; } // int
		[Column,        Nullable] public int?    ReorderLevel    { get; set; } // int
		[Column,     NotNull    ] public int     Discontinued    { get; set; } // int
	}

	[Table("Products Above Average Price", IsView=true)]
	public partial class ProductsAboveAveragePrice
	{
		[Column, NotNull    ] public string  ProductName { get; set; } = null!; // varchar(40)
		[Column,    Nullable] public double? UnitPrice   { get; set; } // float
	}

	[Table("Products by Category", IsView=true)]
	public partial class ProductsByCategory
	{
		[Column, NotNull    ] public string  CategoryName    { get; set; } = null!; // varchar(15)
		[Column, NotNull    ] public string  ProductName     { get; set; } = null!; // varchar(40)
		[Column,    Nullable] public string? QuantityPerUnit { get; set; } // varchar(20)
		[Column,    Nullable] public int?    UnitsInStock    { get; set; } // int
		[Column, NotNull    ] public int     Discontinued    { get; set; } // int
	}

	[Table("Region")]
	public partial class Region
	{
		[PrimaryKey, NotNull] public int    RegionID          { get; set; } // int
		[Column,     NotNull] public string RegionDescription { get; set; } = null!; // varchar(50)
	}

	[Table("Shippers")]
	public partial class Shipper
	{
		[PrimaryKey, NotNull    ] public int     ShipperID   { get; set; } // int
		[Column,     NotNull    ] public string  CompanyName { get; set; } = null!; // varchar(40)
		[Column,        Nullable] public string? Phone       { get; set; } // varchar(24)
	}

	[Table("Summary of Sales by Quarter", IsView=true)]
	public partial class SummaryOfSalesByQuarter
	{
		[Column(SkipOnInsert=true, SkipOnUpdate=true),    Nullable] public DateTime? ShippedDate { get; set; } // timestamp
		[Column,                                       NotNull    ] public int       OrderID     { get; set; } // int
		[Column,                                          Nullable] public object?   Subtotal    { get; set; }
	}

	[Table("Summary of Sales by Year", IsView=true)]
	public partial class SummaryOfSalesByYear
	{
		[Column(SkipOnInsert=true, SkipOnUpdate=true),    Nullable] public DateTime? ShippedDate { get; set; } // timestamp
		[Column,                                       NotNull    ] public int       OrderID     { get; set; } // int
		[Column,                                          Nullable] public object?   Subtotal    { get; set; }
	}

	[Table("Suppliers")]
	public partial class Supplier
	{
		[PrimaryKey, NotNull    ] public int     SupplierID   { get; set; } // int
		[Column,     NotNull    ] public string  CompanyName  { get; set; } = null!; // varchar(40)
		[Column,        Nullable] public string? ContactName  { get; set; } // varchar(30)
		[Column,        Nullable] public string? ContactTitle { get; set; } // varchar(30)
		[Column,        Nullable] public string? Address      { get; set; } // varchar(60)
		[Column,        Nullable] public string? City         { get; set; } // varchar(15)
		[Column,        Nullable] public string? Region       { get; set; } // varchar(15)
		[Column,        Nullable] public string? PostalCode   { get; set; } // varchar(10)
		[Column,        Nullable] public string? Country      { get; set; } // varchar(15)
		[Column,        Nullable] public string? Phone        { get; set; } // varchar(24)
		[Column,        Nullable] public string? Fax          { get; set; } // varchar(24)
		[Column,        Nullable] public string? HomePage     { get; set; } // text(max)
	}

	[Table("Territories")]
	public partial class Territory
	{
		[PrimaryKey, NotNull] public string TerritoryID          { get; set; } = null!; // varchar(20)
		[Column,     NotNull] public string TerritoryDescription { get; set; } = null!; // varchar(50)
		[Column,     NotNull] public int    RegionID             { get; set; } // int
	}

	public static partial class TableExtensions
	{
		public static Category? Find(this ITable<Category> table, int CategoryID)
		{
			return table.FirstOrDefault(t =>
				t.CategoryID == CategoryID);
		}

		public static Customer? Find(this ITable<Customer> table, string CustomerID)
		{
			return table.FirstOrDefault(t =>
				t.CustomerID == CustomerID);
		}

		public static CustomerCustomerDemo? Find(this ITable<CustomerCustomerDemo> table, string CustomerID, string CustomerTypeID)
		{
			return table.FirstOrDefault(t =>
				t.CustomerID     == CustomerID &&
				t.CustomerTypeID == CustomerTypeID);
		}

		public static CustomerDemographic? Find(this ITable<CustomerDemographic> table, string CustomerTypeID)
		{
			return table.FirstOrDefault(t =>
				t.CustomerTypeID == CustomerTypeID);
		}

		public static Employee? Find(this ITable<Employee> table, int EmployeeID)
		{
			return table.FirstOrDefault(t =>
				t.EmployeeID == EmployeeID);
		}

		public static EmployeeTerritory? Find(this ITable<EmployeeTerritory> table, int EmployeeID, string TerritoryID)
		{
			return table.FirstOrDefault(t =>
				t.EmployeeID  == EmployeeID &&
				t.TerritoryID == TerritoryID);
		}

		public static Order? Find(this ITable<Order> table, int OrderID)
		{
			return table.FirstOrDefault(t =>
				t.OrderID == OrderID);
		}

		public static OrderDetail? Find(this ITable<OrderDetail> table, int OrderID, int ProductID)
		{
			return table.FirstOrDefault(t =>
				t.OrderID   == OrderID &&
				t.ProductID == ProductID);
		}

		public static Product? Find(this ITable<Product> table, int ProductID)
		{
			return table.FirstOrDefault(t =>
				t.ProductID == ProductID);
		}

		public static Region? Find(this ITable<Region> table, int RegionID)
		{
			return table.FirstOrDefault(t =>
				t.RegionID == RegionID);
		}

		public static Shipper? Find(this ITable<Shipper> table, int ShipperID)
		{
			return table.FirstOrDefault(t =>
				t.ShipperID == ShipperID);
		}

		public static Supplier? Find(this ITable<Supplier> table, int SupplierID)
		{
			return table.FirstOrDefault(t =>
				t.SupplierID == SupplierID);
		}

		public static Territory? Find(this ITable<Territory> table, string TerritoryID)
		{
			return table.FirstOrDefault(t =>
				t.TerritoryID == TerritoryID);
		}
	}
}
