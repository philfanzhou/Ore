using System;

namespace Ore.Infrastructure.MarketData
{
    /// <summary>
    /// 定义股票基本信息接口
    /// </summary>
    public interface IStockProfile
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        string FullName { get; }
        /// <summary>
        /// 公司英文名称
        /// </summary>
        string EnglishName { get; }
        /// <summary>
        /// 曾用名
        /// </summary>
        string NameUsedBefore { get; }
        /// <summary>
        /// A股交易代码
        /// </summary>
        string CodeA { get; }
        /// <summary>
        /// A股证券简称
        /// </summary>
        string ShortNameA { get; }
        /// <summary>
        /// B股交易代码
        /// </summary>
        string CodeB { get; }
        /// <summary>
        /// B股证券简称
        /// </summary>
        string ShortNameB { get; }
        /// <summary>
        /// H股交易代码
        /// </summary>
        string CodeH { get; }
        /// <summary>
        /// B股证券简称
        /// </summary>
        string ShortNameH { get; }
        /// <summary>
        /// 证券交易所
        /// </summary>
        Market Exchange { get; }
        /// <summary>
        /// 所属行业
        /// </summary>
        string Industry { get; }
        /// <summary>
        /// 总经理
        /// </summary>
        string GeneralManager { get; }
        /// <summary>
        /// 法人代表
        /// </summary>
        string LegalRepresentative { get; }
        /// <summary>
        /// 董秘
        /// </summary>
        string BoardSecretary { get; }
        /// <summary>
        /// 董事长
        /// </summary>
        string Chairman { get; }
        /// <summary>
        /// 证券事务代表
        /// </summary>
        string SecuritiesAffairsRepresentatives { get; }
        /// <summary>
        /// 独立董事
        /// </summary>
        string IndependentDirectors { get; }
        /// <summary>
        /// 联系电话
        /// </summary>
        string ContactNumber { get; }
        /// <summary>
        /// 电子信箱
        /// </summary>
        string Email { get; }
        /// <summary>
        /// 传真
        /// </summary>
        string Fax { get; }
        /// <summary>
        /// 公司网址
        /// </summary>
        string Website { get; }
        /// <summary>
        /// 办公地址
        /// </summary>
        string OfficeAddress { get; }
        /// <summary>
        /// 注册地址
        /// </summary>
        string RegisteredAddress { get; }
        /// <summary>
        /// 区域
        /// </summary>
        string Area { get; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        string ZipCode { get; }
        /// <summary>
        /// 注册资本(元)
        /// </summary>
        string RegisteredCapital { get; }
        /// <summary>
        /// 工商登记
        /// </summary>
        string BusinessRegistration { get; }
        /// <summary>
        /// 雇员人数
        /// </summary>
        int NumberOfEmployees { get; }
        /// <summary>
        /// 管理人员人数
        /// </summary>
        int NumberOfManagement { get; }
        /// <summary>
        /// 律师事务所
        /// </summary>
        string LawOffice { get; }
        /// <summary>
        /// 会计师事务所
        /// </summary>
        string AccountingFirm { get; }
        /// <summary>
        /// 公司简介
        /// </summary>
        string CompanyProfile { get; }
        /// <summary>
        /// 主营业务范围
        /// </summary>
        string PrimeBusiness { get; }
        /// <summary>
        /// 成立日期
        /// </summary>
        DateTime EstablishmentDate { get; }
        /// <summary>
        /// 上市日期
        /// </summary>
        DateTime ListDate { get; }
    }
}
