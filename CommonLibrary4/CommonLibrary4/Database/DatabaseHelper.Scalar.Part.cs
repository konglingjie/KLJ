﻿using CommonLibrary4.Query;
using CommonLibrary4.Database.SqlBuilder;
using CommonLibrary4.Mapper;
using System;
using System.Data;
using System.Data.Common;

namespace CommonLibrary4.Database
{
    public partial class DatabaseHelper
    {

        /// <summary>
        /// 执行sql语句，将标值转换成<typeparamref name="T"/>并返回。
        /// </summary>
        /// <param name="helper"> </param>
        /// <param name="commandText">sql语句</param>
        /// <returns>如果是转换失败将抛出异常，表示sql返回的数据不符开发人员指定的类型。所以开发人员需要自己把握异常处理。</returns>
        public T ExecuteScalar<T>(string commandText)
        {
            return ExecuteScalar<T>(CommandType.Text, commandText, (ParameterCollection)null, (DbTransaction)null);
        }

        /// <summary>
        /// 执行sql语句，将标值转换成<typeparamref name="T"/>并返回。
        /// </summary>
        /// <param name="helper"> </param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameters">sql参数集合</param>
        /// <returns>如果是转换失败将抛出异常，表示sql返回的数据不符开发人员指定的类型。所以开发人员需要自己把握异常处理。</returns>
        public T ExecuteScalar<T>(string commandText, ParameterCollection parameters)
        {
            return ExecuteScalar<T>(CommandType.Text, commandText, parameters);
        }

        /// <summary>
        /// 执行sql语句，将标值转换成<typeparamref name="T"/>并返回。
        /// </summary>
        /// <param name="helper"> </param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameters">sql参数集合</param>
        /// <returns>如果是转换失败将抛出异常，表示sql返回的数据不符开发人员指定的类型。所以开发人员需要自己把握异常处理。</returns>
        public T ExecuteScalar<T>(string commandText, params object[] parameters)
        {
            return ExecuteScalar<T>(CommandType.Text, commandText, parameters);
        }

        /// <summary>
        /// 执行sql语句，将标值转换成<typeparamref name="T"/>并返回。
        /// </summary>
        /// <param name="helper"> </param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameters">sql参数集合</param>
        /// <param name="transaction"> </param>
        /// <returns>如果是转换失败将抛出异常，表示sql返回的数据不符开发人员指定的类型。所以开发人员需要自己把握异常处理。</returns>
        public T ExecuteScalar<T>(string commandText, DbTransaction transaction, params object[] parameters)
        {
            return ExecuteScalar<T>(CommandType.Text, commandText, parameters, transaction);
        }


        /// <summary>
        /// 执行sql语句，将标值转换成<typeparamref name="T"/>并返回。
        /// </summary>
        /// <param name="helper"> </param>
        /// <param name="commandText">sql语句</param>
        /// <returns>如果是转换失败将抛出异常，表示sql返回的数据不符开发人员指定的类型。所以开发人员需要自己把握异常处理。</returns>
        public T SprocExecuteScalar<T>(string commandText)
        {
            return ExecuteScalar<T>(CommandType.StoredProcedure, commandText, (ParameterCollection)null, (DbTransaction)null);
        }

        /// <summary>
        /// 执行sql语句，将标值转换成<typeparamref name="T"/>并返回。
        /// </summary>
        /// <param name="helper"> </param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameters">sql参数集合</param>
        /// <returns>如果是转换失败将抛出异常，表示sql返回的数据不符开发人员指定的类型。所以开发人员需要自己把握异常处理。</returns>
        public T SprocExecuteScalar<T>(string commandText, ParameterCollection parameters)
        {
            return ExecuteScalar<T>(CommandType.StoredProcedure, commandText, parameters);
        }

        /// <summary>
        /// 执行sql语句，将标值转换成<typeparamref name="T"/>并返回。
        /// </summary>
        /// <param name="helper"> </param>
        /// <param name="commandText">sql语句</param>
        /// <param name="parameters">sql参数集合</param>
        /// <param name="transaction"> </param>
        /// <returns>如果是转换失败将抛出异常，表示sql返回的数据不符开发人员指定的类型。所以开发人员需要自己把握异常处理。</returns>
        public T SprocExecuteScalar<T>(string commandText, ParameterCollection parameters, DbTransaction transaction)
        {
            return ExecuteScalar<T>(CommandType.StoredProcedure, commandText, parameters, transaction);
        }
    }
}
