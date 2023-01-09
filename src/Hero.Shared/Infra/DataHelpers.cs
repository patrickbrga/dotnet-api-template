using System.Globalization;
using System.Linq.Expressions;

namespace Shared.Infra
{
    public static class DataHelpers
    {
        public static T CheckUpdateObject<T>(T originalObj, T updateObj) where T : class
        {
            foreach (var property in updateObj.GetType().GetProperties())
            {
                var updateValue = property.GetValue(updateObj, null);
                var originalValue = originalObj.GetType().GetProperty(property.Name)?.GetValue(originalObj, null);

                if (updateValue == null || updateValue?.ToString() == DateTime.MinValue.ToString(CultureInfo.CurrentCulture))
                {
                    property.SetValue(updateObj, originalValue);
                }
            }
            return updateObj;
        }

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> q, string sortField, bool ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, sortField);
            var exp = Expression.Lambda(prop, param);
            var method = ascending ? "OrderBy" : "OrderByDescending";
            var types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }

        public static bool CheckExistingProperty<T>(string property) where T : class
        {
            return !string.IsNullOrEmpty(property) && typeof(T).GetProperties().Any(w => string.Equals(w.Name, property, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
