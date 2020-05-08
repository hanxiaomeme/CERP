﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Dynamic
{
    /// <summary>
    /// Linq工具类
    /// </summary>
    public static class QueryableHelper
    {
        // <summary>
        /// 排序
        /// </summary>
        public static IQueryable<T> DataSorting<T>(IQueryable<T> source, string sortExpression, string sortDirection)
        {
            string sortingDir = string.Empty;
            if (sortDirection.ToUpper().Trim() == "ASC")
                sortingDir = "OrderBy";
            else if (sortDirection.ToUpper().Trim() == "DESC")
                sortingDir = "OrderByDescending";
            ParameterExpression param = Expression.Parameter(typeof(T), sortExpression);
            PropertyInfo pi = typeof(T).GetProperty(sortExpression);
            Type[] types = new Type[2];
            types[0] = typeof(T);
            types[1] = pi.PropertyType;
            Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, source.Expression, Expression.Lambda(Expression.Property(param, sortExpression), param));
            IQueryable<T> query = source.AsQueryable().Provider.CreateQuery<T>(expr);
            return query;
        }

        /// <summary>
        /// 分页
        /// </summary>
        public static IQueryable<T> DataPaging<T>(IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (pageIndex <= 1)
            {
                return source.Take(pageSize);
            }
            else
            {
                return source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        public static List<T> ListPaged<T>(List<T> dataList, int pageIndex, int pageSize)
        {

            return dataList.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();


        }

        /// <summary>
        /// 查询In
        /// </summary>
        public static IQueryable<T> WhereIn<T, TProp>(this IQueryable<T> source, Expression<Func<T, TProp>> memberExpr, IEnumerable<TProp> values) where T : class
        {
            Expression predicate = null;
            ParameterExpression param = Expression.Parameter(typeof(T), "t");

            bool IsFirst = true;

            MemberExpression me = (MemberExpression)memberExpr.Body;
            foreach (TProp val in values)
            {
                ConstantExpression ce = Expression.Constant(val);

                Expression comparison = Expression.Equal(me, ce);

                if (IsFirst)
                {
                    predicate = comparison;
                    IsFirst = false;
                }
                else
                {
                    predicate = Expression.Or(predicate, comparison);
                }
            }

            return predicate != null
                ? source.Where(Expression.Lambda<Func<T, bool>>(predicate, param)).AsQueryable<T>()
                : source;
        }

        /// <summary>
        /// 查询Or
        /// </summary>
        public static IQueryable<T> WhereOR<T>(this IQueryable<T> source, params Expression<Func<T, bool>>[] predicates)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (predicates == null) throw new ArgumentNullException("predicates");
            if (predicates.Length == 0) return source.Where(x => false); // no matches!
            if (predicates.Length == 1) return source.Where(predicates[0]); // simple

            var param = Expression.Parameter(typeof(T), "x");
            Expression body = Expression.Invoke(predicates[0], param);
            for (int i = 1; i < predicates.Length; i++)
            {
                body = Expression.OrElse(body, Expression.Invoke(predicates[i], param));
            }
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);

            return source.Where(lambda.Compile()).AsQueryable();
        }
    }
}
