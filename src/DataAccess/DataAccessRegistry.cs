using StructureMap;

namespace DataAccess
{
    public class DataAccessRegistry : Registry
    {
        public DataAccessRegistry()
        {
            ConfigureScan();   
        }

        private void ConfigureScan()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            Configure(x =>
            {
                
            });
        }
    }
}
