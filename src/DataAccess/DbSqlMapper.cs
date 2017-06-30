using System.Xml;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace DataAccess
{
    public static class DbSqlMapper
    {
        private static readonly object Lock = new object();
        private static ISqlMapper _sqlMapper;

        public static ISqlMapper SqlMapper
        {
            get
            {
                if (_sqlMapper == null)
                {
                    lock (Lock)
                    {
                        if (_sqlMapper == null)
                        {
                            DomSqlMapBuilder builder = new DomSqlMapBuilder();
                            XmlDocument sqlMapConfig = Resources.GetEmbeddedResourceAsXmlDocument("Config.SqlMap.config, DataAccess");
                            _sqlMapper = builder.Configure(sqlMapConfig);
                            //_sqlMapper = Mapper.Instance();
                        }
                    }
                }
                return _sqlMapper;
            }
        }
    }
}
