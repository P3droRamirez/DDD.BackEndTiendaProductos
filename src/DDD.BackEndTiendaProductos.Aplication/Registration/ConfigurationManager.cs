using Microsoft.Extensions.Configuration;

namespace DDD.BackEndTiendaProductos.Application.Registration
{
    public class ConfigurationManager
    {
        public static IConfiguration? Configuration { get; set; }

        // ESTE MÉTODO ES DE DEEPSEEK
        #region Swagger
        public static bool SwaggerEnabled
        {
            get
            {
                if (Configuration != null && bool.TryParse(Configuration["Swagger:Enabled"], out bool enabled))
                {
                    return enabled;
                }
                return false;
            }
        }
        #endregion Swagger
        // ESTE MÉTODO ES DE DEEPSEEK

        #region ConnectionStrings

        public static string? LocalDB
        {
            get
            {
                return Configuration != null ? Configuration["ConnectionStrings:Connection"] : string.Empty;
            }
        }

    }
    #endregion ConnectionStrings
}