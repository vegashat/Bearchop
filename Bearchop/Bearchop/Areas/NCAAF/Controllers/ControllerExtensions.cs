using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Reflection;

namespace Bearchop.Areas.NCAAF.Web.Controllers
{
    public static class ControllerExtensions
    {
        const string DISABLED = "disabled='disabled'";
        const string CHECKED = "checked";

        public static IEnumerable<T> ApplyFilter<T>(this IEnumerable<T> collection, string jsonFilter)
        {
            var filter = Bearchop.Areas.NCAAF.Web.jqGrid.Filter.Create(jsonFilter);
            IQueryable<T> query = Enumerable.Empty<T>().AsQueryable();
            IQueryable<T> tmpQuery = null;


            if (filter.groupOp == "AND")
            {
                query = collection.AsQueryable();
                foreach (var rule in filter.rules.Where(rule => rule.data != "All"))
                {
                    query = query.Where<T>(rule.field, rule.data, rule.op);
                }
            }
            else
            {
                tmpQuery = collection.AsQueryable();
                foreach (var rule in filter.rules.Where(rule => rule.data != "All"))
                {
                    var temp = tmpQuery.Where<T>(rule.field, rule.data, rule.op);
                    query = query.Concat<T>(temp);
                }

                query = query.Distinct<T>();
            }

            return query;
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> query, string column, object val, string operation)
        {
            //All operands will be case insensative
            string value = val.ToString().ToLower();

            if (string.IsNullOrEmpty(column))
                return query;

            ParameterExpression parameter = Expression.Parameter(query.ElementType, "p");

            MemberExpression memberAccess = null;
            foreach (var property in column.Split('.'))
                memberAccess = MemberExpression.Property
                   (memberAccess ?? (parameter as Expression), property);

            //change param value type
            //necessary to getting bool from string
            ConstantExpression filter = Expression.Constant
                (
                    Convert.ChangeType(value, memberAccess.Type)
                );

            //switch operation
            Expression condition = null;
            LambdaExpression lambda = null;

            if (memberAccess.Type.ToString() == "System.String")
            {
                //tolower the memberAccess so the operatios is case insensative
                MethodInfo toLowerMethod = typeof(string).GetMethod("ToLower", new Type[0]);
                MethodCallExpression memberAccessToLower = Expression.Call(memberAccess, toLowerMethod);

                switch (operation)
                {
                    //equal ==
                    case "eq":
                        condition = Expression.Equal(memberAccessToLower, filter);
                        lambda = Expression.Lambda(condition, parameter);
                        break;
                    //not equal !=
                    case "ne":
                        condition = Expression.NotEqual(memberAccessToLower, filter);
                        lambda = Expression.Lambda(condition, parameter);
                        break;
                    //string.Contains()
                    case "cn":
                        condition = Expression.Call(memberAccessToLower,
                            typeof(string).GetMethod("Contains"),
                            Expression.Constant(value));
                        lambda = Expression.Lambda(condition, parameter);
                        break;
                    //greaterthan or equal
                    case "ge":
                        condition = Expression.GreaterThanOrEqual(memberAccessToLower, filter);
                        lambda = Expression.Lambda(condition, parameter);
                        break;
                    //less than or equal
                    case "le":
                        condition = Expression.LessThanOrEqual(memberAccessToLower, filter);
                        lambda = Expression.Lambda(condition, parameter);
                        break;
                }
            }
            else
            {
                switch (operation)
                {
                    //equal ==
                    case "eq":
                        condition = Expression.Equal(memberAccess, filter);
                        lambda = Expression.Lambda(condition, parameter);
                        break;
                    //not equal !=
                    case "ne":
                        condition = Expression.NotEqual(memberAccess, filter);
                        lambda = Expression.Lambda(condition, parameter);
                        break;
                    //string.Contains()
                    case "cn":
                        condition = Expression.Call(memberAccess,
                            typeof(string).GetMethod("Contains"),
                            Expression.Constant(value));
                        lambda = Expression.Lambda(condition, parameter);
                        break;
                    //equal >=
                    case "ge":
                        condition = Expression.GreaterThanOrEqual(memberAccess, filter);
                        lambda = Expression.Lambda(condition, parameter);
                        break;
                    // less than or equal
                    case "le":
                        condition = Expression.LessThanOrEqual(memberAccess, filter);
                        lambda = Expression.Lambda(condition, parameter);
                        break;
                }
            }


            MethodCallExpression result = Expression.Call(
                   typeof(Queryable), "Where",
                   new[] { query.ElementType },
                   query.Expression,
                   lambda);

            return query.Provider.CreateQuery<T>(result);
        }
    }
}