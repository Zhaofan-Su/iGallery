﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsApp.Models;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;

namespace ProductsApp.Controllers
{
    public class CollectController : ApiController
    {
        //收藏动态
        [HttpGet]
        public IHttpActionResult InsertCollect(string moment_id, string founder_id, string name)
        {
            //创建返回信息，先假设插入及更新成功
            int status = 0;
            OracleConnection conn = new OracleConnection(DBAccess.connStr);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            OracleCommand cmd = new OracleCommand();
            string currentTime = DateTime.Now.ToString();
            cmd.CommandText = "insert into COLLECT(MOMENT_ID,FOUNDER_ID,NAME,TIME) " +
                    "values('" + moment_id + "','" + founder_id + "','" + name + "',TO_DATE('" + currentTime + "','yyyy-mm-dd hh24:mi:ss'))";
            cmd.Connection = conn;
            int result_1 = cmd.ExecuteNonQuery();
            if (result_1 != 1)//插入出现错误
            {
                status = 1;
            }
            else
            {
                int collect_num = 0;
                cmd.CommandText = "select COLLECT_NUM from MOMENT where ID='" + moment_id + "'";
                OracleDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    collect_num = rd.GetInt32(0);
                }
                collect_num = collect_num + 1;
                cmd.CommandText = "update MOMENT set COLLECT_NUM='" + collect_num + "' where ID='" + moment_id + "'";
                cmd.Connection = conn;
                int result_2 = cmd.ExecuteNonQuery();
                if (result_2 != 1)//更新出现错误
                {
                    status = 2;
                }
            }

            //关闭数据库连接
            conn.Close();

            //返回信息
            return Ok(status);
        }

        //取消收藏动态
        [HttpGet]
        public IHttpActionResult DeleteCollect(string moment_id, string user_id)
        {
            //创建返回信息，先假设删除及更新成功
            int status = 0;
            OracleConnection conn = new OracleConnection(DBAccess.connStr);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "delete from COLLECT where MOMENT_ID = '" + moment_id + "' and FOUNDER_ID = '" + user_id + "'";
            cmd.Connection = conn;
            int result_1 = cmd.ExecuteNonQuery();
            if (result_1 != 1)//删除出现错误
            {
                status = 1;
            }
            else
            {
                int collect_num = 0;
                cmd.CommandText = "select COLLECT_NUM from MOMENT where ID='" + moment_id + "'";
                OracleDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    collect_num = rd.GetInt32(0);
                }
                collect_num = collect_num - 1;
                cmd.CommandText = "update MOMENT set COLLECT_NUM='" + collect_num + "' where ID='" + moment_id + "'";
                cmd.Connection = conn;
                int result_2 = cmd.ExecuteNonQuery();
                if (result_2 != 1)//更新出现错误
                {
                    status = 2;
                }
            }

            //关闭数据库连接
            conn.Close();

            //返回信息
            return Ok(status);
        }
    }
}
