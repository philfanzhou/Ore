using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ore.Infrastructure.MarketData.DataSource.Eastmoney.Model
{
    public class StockProfile : IStockProfile
    {
        public string AccountingFirm { get; internal set; }

        public string Area { get; internal set; }

        public string BoardSecretary { get; internal set; }

        public string BusinessRegistration { get; internal set; }

        public string Chairman { get; internal set; }

        public string CodeA { get; internal set; }

        public string CodeB { get; internal set; }

        public string CodeH { get; internal set; }

        public string CompanyProfile { get; internal set; }

        public string ContactNumber { get; internal set; }

        public string Email { get; internal set; }

        public string EnglishName { get; internal set; }

        public DateTime EstablishmentDate { get; internal set; }

        public Market Exchange { get; internal set; }

        public string Fax { get; internal set; }

        public string FullName { get; internal set; }

        public string GeneralManager { get; internal set; }

        public string IndependentDirectors { get; internal set; }

        public string Industry { get; internal set; }

        public string LawOffice { get; internal set; }

        public string LegalRepresentative { get; internal set; }

        public DateTime ListDate { get; internal set; }

        public string NameUsedBefore { get; internal set; }

        public int NumberOfEmployees { get; internal set; }

        public int NumberOfManagement { get; internal set; }

        public string OfficeAddress { get; internal set; }

        public string PrimeBusiness { get; internal set; }

        public string RegisteredAddress { get; internal set; }

        public string RegisteredCapital { get; internal set; }

        public string SecuritiesAffairsRepresentatives { get; internal set; }

        public string ShortNameA { get; internal set; }

        public string ShortNameB { get; internal set; }

        public string ShortNameH { get; internal set; }

        public string Website { get; internal set; }

        public string ZipCode { get; internal set; }
    }
}
