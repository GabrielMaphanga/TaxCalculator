using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TaxCalulator.Core.Entities;
using TaxCalulator.Core.Interfaces;

namespace TaxCalculator.Infrastructure.Data
{
    public class TaxCalculatorRepository : ITaxCalculatorRepository
    {
        private readonly IConfiguration _config;

        public TaxCalculatorRepository(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection Connection => new SqlConnection(_config.GetConnectionString("CalculatedAnnualTax"));
        public bool CreateCalculatedAnnualTax(CalculatedAnnualTax calculatedAnnualTax)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO dbo.CalculatedAnnualTax (CalculatedTax, DateTime, NetPay)"
                   + "VALUES(@CalculatedTax, @DateTime, @NetPay)";
                dbConnection.Open();
                int rowAffectd = dbConnection.Execute(sQuery, calculatedAnnualTax);
                if (rowAffectd > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteCalculatedAnnualTax(int calculatedAnnualTaxId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM CalculatedAnnualTax WHERE Id =" + calculatedAnnualTaxId;
                dbConnection.Open();
                int rowAffectd = dbConnection.Execute(sQuery);
                if (rowAffectd > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public CalculatedAnnualTax GetCalculatedAnnualTax(int calculatedAnnualTaxId)
        {
            CalculatedAnnualTax calculatedAnnualTax = new CalculatedAnnualTax();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "SELECT * FROM CalculatedAnnualTax WHERE Id =" + calculatedAnnualTaxId;
                calculatedAnnualTax = dbConnection.QueryFirst<CalculatedAnnualTax>(query);
                dbConnection.Close();
            }
            return calculatedAnnualTax;
        }

        public List<CalculatedAnnualTax> GetCalculatedAnnualTaxes()
        {
            IEnumerable<CalculatedAnnualTax> calculatedAnnualTaxes = new List<CalculatedAnnualTax>();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "SELECT * FROM CalculatedAnnualTax";
                calculatedAnnualTaxes = dbConnection.Query<CalculatedAnnualTax>(query);
                dbConnection.Close();
            }
            return calculatedAnnualTaxes.AsList<CalculatedAnnualTax>();
        }

        public CalculatedAnnualTax UpdateCalculatedAnnualTax(CalculatedAnnualTax calculatedAnnualTax)
        {
            throw new NotImplementedException();
        }
    }
}
