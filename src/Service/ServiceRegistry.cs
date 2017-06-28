using StructureMap;

namespace Service
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
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
                x.ImportRegistry(typeof(DataAccess.DataAccessRegistry));
            });
        }
    }
}
