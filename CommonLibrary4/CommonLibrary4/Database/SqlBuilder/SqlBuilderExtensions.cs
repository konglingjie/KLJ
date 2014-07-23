﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary4.Database;
using CommonLibrary4.Entity;
using CommonLibrary4.Mapper;
using CommonLibrary4.Mapper.Metadata;

namespace CommonLibrary4.Database.SqlBuilder
{
    /// <summary>
    /// <see cref="ISqlBuilder"/>的扩展方法
    /// </summary>
    internal static class SqlBuilderExtensions
    {

        private static string TableName(IEntityExplain entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (string.IsNullOrEmpty(entity.TableName))
                throw new MapperException("未设置一个有效的TableName。");

            return entity.TableName;
        }

        /// <summary>
        /// where条件
        /// </summary>
        /// <param name="condition"> </param>
        /// <param name="output"> </param>
        /// <param name="options"> </param>
        /// <returns>生成的where条件</returns>
        public static string Where(this ISqlBuilder builder, IEnumerable<ItemValue> condition, ParameterCollection output, SqlOptions options)
        {
            if (condition == null || !condition.Any())
                return string.Empty;

            var where = new StringBuilder();
            foreach (var item in condition)
            {
                if (item.Value is ICollection)
                {
                    var values = ((ICollection)item.Value);
                    var list = new List<string>();
                    foreach (var value in values)
                        list.Add(output.Append("p", value, true).ParameterName);

                    where.Append(builder.BuildField(item.Item)).Append("IN(").Append(builder.ExpressionsJoin(list)).Append(") AND ");
                }
                else
                {
                    where.Append(builder.BuildField(item.Item)).Append("=").Append(output.Append("p", item.Value, true).ParameterName).Append(" AND ");
                }
            }
            where.Remove(where.Length - 5, 5);
            return where.ToString();
        }

        /// <summary>
        /// where条件
        /// </summary>
        /// <param name="condition"> </param>
        /// <param name="output"> </param>
        /// <param name="options"> </param>
        /// <returns>生成的where条件</returns>
        public static string Where(this ISqlBuilder builder, IDictionary<string, object> condition, ParameterCollection output, SqlOptions options)
        {
            if (condition == null || condition.Count == 0)
                return string.Empty;

            var where = new StringBuilder();
            foreach (var item in condition)
            {
                if (item.Value is ICollection)
                {
                    var values = ((ICollection)item.Value);
                    var list = new List<string>();
                    foreach (var value in values)
                        list.Add(output.Append("p", value, true).ParameterName);

                    where.Append(builder.BuildField(item.Key)).Append("IN(").Append(builder.ExpressionsJoin(list)).Append(") AND ");
                }
                else
                {
                    where.Append(builder.BuildField(item.Key)).Append("=").Append(output.Append("p", item.Value, true).ParameterName).Append(" AND ");
                }
            }
            where.Remove(where.Length - 5, 5);
            return where.ToString();
        }

        public static string Delete(this ISqlBuilder builder, IEntityExplain entity, IEnumerable<ItemValue> condition, ParameterCollection output, SqlOptions options)
        {
            return builder.DeleteFormat(TableName(entity), builder.Where(condition, output, options), options);
        }

        public static string Delete(this ISqlBuilder builder, IEntityExplain entity, IDictionary<string, object> condition, ParameterCollection output, SqlOptions options)
        {
            return builder.DeleteFormat(TableName(entity), builder.Where(condition, output, options), options);
        }

        public static string Update(this ISqlBuilder builder, IEntityExplain entity, IEnumerable<ItemValue> fieldValues, IEnumerable<ItemValue> condition, ParameterCollection output, SqlOptions options)
        {
            return builder.UpdateFormat(TableName(entity), fieldValues.Select(x => new ItemValue<string, string>(x.Item, output.Append("p", x.Value, true).ParameterName)), builder.Where(condition, output, options), options);
        }

        public static string Update(this ISqlBuilder builder, IEntityExplain entity, IDictionary<string, object> fieldValues, IDictionary<string, object> condition, ParameterCollection output, SqlOptions options)
        {
            return builder.UpdateFormat(TableName(entity), fieldValues.Select(x => new ItemValue<string, string>(x.Key, output.Append("p", x.Value, true).ParameterName)), builder.Where(condition, output, options), options);
        }

        public static string Insert(this ISqlBuilder builder, IEntityExplain entity, IEnumerable<ItemValue> fieldValues, ParameterCollection output, SqlOptions options)
        {
            var list = new List<ItemValue<string, string>>();

            foreach (var item in fieldValues)
            {
                if (entity.Increment != null && entity.Increment.ColumnName == item.Item)
                    continue;

                list.Add(new ItemValue<string, string>(item.Item, output.Append("p", item.Value, true).ParameterName));
            }
            if (entity.Increment != null)
            {
                return builder.InsertFormat(TableName(entity), list, entity.Increment.ColumnName, entity.Increment.IncrementName, options);
            }
            else
            {
                return builder.InsertFormat(TableName(entity), list, options);
            }
        }

        public static string Insert(this ISqlBuilder builder, IEntityExplain entity, IDictionary<string, object> fieldValues, ParameterCollection output, SqlOptions options)
        {
            var list = new List<ItemValue<string, string>>();

            foreach (var item in fieldValues)
            {
                if (entity.Increment != null && entity.Increment.ColumnName == item.Key)
                    continue;

                list.Add(new ItemValue<string, string>(item.Key, output.Append("p", item.Value, true).ParameterName));
            }
            if (entity.Increment != null)
            {
                return builder.InsertFormat(TableName(entity), list, entity.Increment.ColumnName, entity.Increment.IncrementName, options);
            }
            else
            {
                return builder.InsertFormat(TableName(entity), list, options);
            }
        }

        public static string IncrementByQuery(this ISqlBuilder builder, IEntityExplain entity, string alias, SqlOptions options)
        {
            if (entity == null)
                throw new ArgumentNullException("metaInfo");
            if (entity.Increment == null)
                throw new ArgumentException("没有自动增长标识");

            return builder.IncrementByQuery(entity.Increment.IncrementName, alias, options);
        }
    }
}
