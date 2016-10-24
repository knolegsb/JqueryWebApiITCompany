namespace JqueryWebApiITCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDataOnCompanies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (1, 'Samsung Electronics', 'Mobile Devices, Semiconductor, Personal Computing', 212.68, 2013, 326000, 137.91, 'Seoul, South Korea')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (2, 'Apple Inc.', 'Mobile Devices, Personal Computing, Consumer software', 182.79, 2014, 98000, 616.59, 'Cupertino, CA, USA (Silicon Valley)')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (3, 'Foxconn', 'OEM Component Manufacturing', 132.07, 2013, 1290000, 32.15, 'New Taipei, Taiwan')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (4, 'HP','Personal Computing and Servers, Consulting', 111.45, 2014, 317500, 65.30, 'Palo Alto, CA, USA (Silicon Valley)')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (5, 'IBM', 'Computing services, Mainframes', 99.75, 2013, 433362, 188.21, 'Armonk, NY, USA')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (6, 'Amazon.com', 'Internet Retailer, App Hosting', 88.99, 2014, 154100, 175.22, 'Seattle, WA, USA')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (7, 'Microsoft', 'Business computing', 86.83, 2014, 128076, 370.31, 'Redmond, WA, USA')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (8, 'Sony', 'Electronic Devices, Personal Computing', 72.34, 2014, 146300, 17.60, 'Tokyo, Japan')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (9, 'Panasonic', 'Electronics Devices & Components', 70.83, 2013, 293742, 22.70, 'Osaka, Japan')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (10, 'Google', 'Internet Advertising, Search Engine, Miscellaneous', 59.82, 2013, 53546, 396.24, 'Mountain View, CA, USA (Silicon Valley)')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (11, 'Dell', 'Personal Computers and Servers', 56.94, 2013, 108800, 22.97, 'Austin, TX, USA')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (12, 'Toshiba', 'Semiconductor, Consumer devices', 56.20, 2013, 206087, 17.67, 'Tokyo, Japan')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (13, 'LG Electronics', 'Personal Computer, Electronics', 54.75, 2013, 38718, 17.67, 'Seoul, South Korea')");
            Sql("INSERT INTO Companies (Rank, Name, Industry, Revenue, FiscalYear, Employees, MarketCap, Headquarters) Values (14, 'Intel', 'Semiconductor', 52.70, '2013', 104700, 168.48, 'Santa Clara, CA, USA (Silicon Valley)')");
        }
        
        public override void Down()
        {
        }
    }
}
