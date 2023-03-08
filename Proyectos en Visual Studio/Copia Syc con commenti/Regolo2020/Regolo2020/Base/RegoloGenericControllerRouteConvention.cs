using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Regolo2020.Base.Controllers;
using Regolo2020.Base.DataModels;
using System.Reflection;

namespace Regolo2020.Base
{
    public class RegoloControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var assembly = Assembly.GetAssembly(typeof(IDataModel));
            if (assembly != null)
            {
                var exportedTypes = assembly.GetExportedTypes();

                AddCrudControllers(feature, exportedTypes);
                AddInstallControllers(feature, exportedTypes);
            }
        }

        private void AddCrudControllers(ControllerFeature feature, Type[] exportedTypes)
        {
            var candidates = exportedTypes.Where(t => !t.IsInterface && !t.IsAbstract && typeof(IDataModel).IsAssignableFrom(t));
            var baseCrudControllerType = typeof(BaseCrudController<,>);

            foreach (var candidate in candidates)
            {
                var hasCustomControllerType = exportedTypes
                    .Any(t => t.BaseType?.Name == baseCrudControllerType.Name && t.BaseType.GenericTypeArguments[1] == candidate);

                if (!hasCustomControllerType)
                {
                    feature.Controllers.Add(baseCrudControllerType.MakeGenericType(typeof(RegoloDbContext), candidate).GetTypeInfo());
                }
            }
        }

        private void AddInstallControllers(ControllerFeature feature, Type[] exportedTypes)
        {
            var candidates = exportedTypes.Where(t => t != typeof(RegoloDbContext) && typeof(DbContext).IsAssignableFrom(t));
            var baseInstallControllerType = typeof(BaseInstallController<>);

            foreach (var candidate in candidates)
            {
                feature.Controllers.Add(baseInstallControllerType.MakeGenericType(candidate).GetTypeInfo());
            }
        }
    }

    public class RegoloGenericControllerRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType)
            {
                if (controller.ControllerType.Name == typeof(BaseCrudController<,>).Name)
                {
                    var genericType = controller.ControllerType.GenericTypeArguments[1];
                    var codiceAmbiente = genericType?.Namespace?.Split(".")[2][..3];
                    controller.ControllerName = $"{codiceAmbiente}/{genericType?.Name}";
                }
                else if (controller.ControllerType.Name == typeof(BaseInstallController<>).Name)
                {
                    var genericType = controller.ControllerType.GenericTypeArguments[0];
                    var codiceAmbiente = genericType?.Namespace?.Split(".")[2][..3];
                    controller.ControllerName = $"{codiceAmbiente}/Installer";
                }
            }
        }
    }
}
