using IBatisNet.DataMapper;

namespace DataAccess
{
    public static class DbSqlMapper
    {
        private static readonly object Lock = new object();
        private static ISqlMapper _sqlMapper;

        static DbSqlMapper()
        {
            _sqlMapper = Mapper.Instance();
        }

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
                            _sqlMapper = Mapper.Instance();
                        }
                    }
                }
                return _sqlMapper;
            }
        }
    }
}
