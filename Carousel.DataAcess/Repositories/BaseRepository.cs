﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Carousel.DataAccess;
using Microsoft.ApplicationBlocks.Data;



namespace Carousel.DataAcess.Repositories
{
 public  class BaseRepository
    {
        protected static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connCarousel"].ConnectionString);
            return connection;
        }

        protected static DataSet GetDataset(string storedProcName, params object[] parameterValues)
        {
           
           //
                return SqlHelper.ExecuteDataset(GetConnection(), storedProcName, parameterValues);
            
           
        }

        private static T PopulateData<T>(IDataReader reader, object data) where T : class
        {
            var obj = data as T;
            if (obj == null) throw new InvalidCastException("Could not cast data as T.");

            foreach (var prop in obj.GetType().GetProperties())
            {
                if (reader.IsColumnExists(prop.Name))
                    prop.SetValue(obj, reader[prop.Name]);
            }

            return obj;
        }

        protected static T PopulateData<T>(DataRow row) where T : class, new()
        {
            var obj = new T();
            if (obj == null) throw new InvalidCastException("Could not cast data as T.");

            if (row == null) return null;

            foreach (var prop in obj.GetType().GetProperties())
            {
                if (row.Table.Columns.Contains(prop.Name))
                    if (Nullable.GetUnderlyingType(prop.PropertyType)?.IsEnum == true)
                        prop.SetValue(obj, row.GetValue(prop) == DBNull.Value ? null : Enum.ToObject(Nullable.GetUnderlyingType(prop.PropertyType), row.GetValue(prop)));
                    else
                        prop.SetValue(obj, row.GetValue(prop));
            }

            return obj;
        }

        protected static T PopulateData<T>(DataRow row, object data) where T : class
        {
            var obj = data as T;
            if (obj == null) throw new InvalidCastException("Could not cast data as T.");

            foreach (var prop in obj.GetType().GetProperties())
            {
                if (row.Table.Columns.Contains(prop.Name))
                    prop.SetValue(obj, row.GetValue(prop));
            }

            return obj;
        }

        protected static T GetValue<T>(string storedProcName, params SqlParameter[] parameterValues)
        {
            return (T)SqlHelper.ExecuteScalar(GetConnection(), CommandType.StoredProcedure, storedProcName, parameterValues);
        }

        protected static void NonQuery(string storedProcName, params SqlParameter[] parameterValues)
        {
            SqlHelper.ExecuteNonQuery(GetConnection(), storedProcName, parameterValues);
        }

        protected static T GetObject<T>(string storedProcName, params object[] parameterValues) where T : class, new()
        {
            var obj = new T();
            using (var reader = SqlHelper.ExecuteReader(GetConnection(), storedProcName, parameterValues))
            {
                while (reader.Read())
                {
                    PopulateData<T>(reader, obj);
                }

                return obj;
            }
        }
    }
}
