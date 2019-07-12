using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Web.Services.Protocols;


namespace pharmaceuticalfactory
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        public MySoapHeader header = new MySoapHeader();//  必须保证是public和字段名必须与SoapHeader("memberName")中memberName一样
        [WebMethod(Description = "参数类型为String数组，长度为31，索引0为订单号，索引1为药名，索引2为药数量，索引3为二维码；索引4为药名2，索引5为药名2的数量，，，以此类推至索引31为药10的二维码。")]
        //[WebMethod(Description = "参数类型为ArrayList集合，长度为31，索引0为订单号，索引1为药名，索引2为药数量，索引3为二维码；索引4为药名2，索引5为药名2的数量，，，以此类推至索引31为药10的二维码。如果订单药的种类不足10种，则多出的药位请默认值处理，否则即报错")]
        [SoapHeader("header")]
        public string Addprescription(string[] inf)
        {
            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            // localhost 代表本机，端口号port
            MySqlConnection conn = new MySqlConnection(connetStr);

            //字符串数组数据获取
            string OrderNumber = inf[0];
            string DrugName1 = inf[1];
            string DrugrNumber1 = inf[2];
            string BarCode1 = inf[3];
            string DrugName2 = inf[4];
            string DrugrNumber2 = inf[5];
            string BarCode2 = inf[6];
            string DrugName3 = inf[7];
            string DrugrNumber3 = inf[8];
            string BarCode3 = inf[9];
            string DrugName4 = inf[10];
            string DrugrNumber4 = inf[11];
            string BarCode4 = inf[12];
            string DrugName5 = inf[13];
            string DrugrNumber5 = inf[14];
            string BarCode5 = inf[15];
            string DrugName6 = inf[16];
            string DrugrNumber6 = inf[17];
            string BarCode6 = inf[18];
            string DrugName7 = inf[19];
            string DrugrNumber7 = inf[20];
            string BarCode7 = inf[21];
            string DrugName8 = inf[22];
            string DrugrNumber8 = inf[23];
            string BarCode8 = inf[24];
            string DrugName9 = inf[25];
            string DrugrNumber9 = inf[26];
            string BarCode9 = inf[27];
            string DrugName10 = inf[28];
            string DrugrNumber10 = inf[29];
            string BarCode10 = inf[30];

            if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句

                //对数据库进行增删查改
                string sql = "insert into prescription(OrderNumber,DrugName1,DrugrNumber1,BarCode1,DrugName2,DrugrNumber2,BarCode2,DrugName3,DrugrNumber3,BarCode3,DrugName4,DrugrNumber4,BarCode4,DrugName5,DrugrNumber5,BarCode5,DrugName6,DrugrNumber6,BarCode6,DrugName7,DrugrNumber7,BarCode7,DrugName8,DrugrNumber8,BarCode8,DrugName9,DrugrNumber9,BarCode9,DrugName10,DrugrNumber10,BarCode10) values('" + OrderNumber + "','" + DrugName1 + "','" + DrugrNumber1 + "','" + BarCode1 + "','" + DrugName2 + "','" + DrugrNumber2 + "','" + BarCode2 + "','" + DrugName3 + "','" + DrugrNumber3 + "','" + BarCode3 + "','" + DrugName4 + "','" + DrugrNumber4 + "','" + BarCode4 + "','" + DrugName5 + "','" + DrugrNumber5 + "','" + BarCode5 + "','" + DrugName6 + "','" + DrugrNumber6 + "','" + BarCode6 + "','" + DrugName7 + "','" + DrugrNumber7 + "','" + BarCode7 + "','" + DrugName8 + "','" + DrugrNumber8 + "','" + BarCode8 + "','" + DrugName9 + "','" + DrugrNumber9 + "','" + BarCode9 + "','" + DrugName10 + "','" + DrugrNumber10 + "','" + BarCode10 + "')";
                //string sql = "insert into drugstorage(username,password,registerdate) values('啊宽','sjw123','" + DateTime.Now + "')";
                //string sql = "delete from user where userid='9'";
                //string sql = "update user set username='啊哈',password='sjw123' where userid='8'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //执行插入、删除、更改语句。执行成功返回受影响的数据的行数，返回1可做true判断。执行失败不返回任何数据，报错，下面代码都不执行
                int result = cmd.ExecuteNonQuery();
                return "已经插入" + result;

            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
            else
            {
                return "您没有权限访问";
            }
        }

        [WebMethod(Description = "清除数据库订单号信息")]
        [SoapHeader("header")]
        public string ClearOrder(int month) {

            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            if (header.ValideUser(header.UserName, header.PassWord))
            {
                try
                {
                    conn.Open();
                    string sql = "delete From prescription where DATE(Createtime) <= DATE(DATE_SUB(NOW(),INTERVAL " + month + " MONTH))";
                    //Delete From prescription where DATE(Createtime)<= DATE(DATE_SUB(NOW(),INTERVAL 1 MONTH)); 
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int result = cmd.ExecuteNonQuery();
                    return "删除记录数=" + result.ToString();
                }
                catch (MySqlException ex)
                {
                    return ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                return "您没有权限访问";
            }
        
        }

        [WebMethod(Description = "顾客完成购买订单失效")]
        [SoapHeader("header")]
        public string Ordersfailure(string OrderNumber)
        {
            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
             if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "update prescription set Check_order ='0' where OrderNumber='" + OrderNumber + "'";
                //update repertory set number='number ',spare1='spare1' where devicenumber='devicenumber'and drugclasses='drugclasses ';
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return result.ToString();
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
             else
             {
                 return "您没有权限访问";
             }

        }


        [WebMethod(Description = "参数为string类型的订单号，返回为ArrayList集合类型的药单信息和订单有效信息")]
        [SoapHeader("header")]
        public string[] Checkprescription(string OrderNumber)
        {
            // server=127.0.0.1/localhost 代表本机，端口号port默认是3306可以不写
            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            //创建长度为33的字符串数组
            string[] inf = new string[33];
            if (header.ValideUser(header.UserName, header.PassWord))
            {
                try
                {
                    conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句

                    //对数据库进行增删查改
                    string sql = "select * from prescription where OrderNumber='" + OrderNumber + "'"; //按照查询条件去查找
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //查询结果读取器
                    MySqlDataReader result = null;
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        inf[0] = result[0].ToString();
                        inf[1] = result[1].ToString();
                        inf[2] = result[2].ToString();
                        inf[3] = result[3].ToString();
                        inf[4] = result[4].ToString();
                        inf[5] = result[5].ToString();
                        inf[6] = result[6].ToString();
                        inf[7] = result[7].ToString();
                        inf[8] = result[8].ToString();
                        inf[9] = result[9].ToString();
                        inf[10] = result[10].ToString();
                        inf[11] = result[11].ToString();
                        inf[12] = result[12].ToString();
                        inf[13] = result[13].ToString();
                        inf[14] = result[14].ToString();
                        inf[15] = result[15].ToString();
                        inf[16] = result[16].ToString();
                        inf[17] = result[17].ToString();
                        inf[18] = result[18].ToString();
                        inf[19] = result[19].ToString();
                        inf[20] = result[20].ToString();
                        inf[21] = result[21].ToString();
                        inf[22] = result[22].ToString();
                        inf[23] = result[23].ToString();
                        inf[24] = result[24].ToString();
                        inf[25] = result[25].ToString();
                        inf[26] = result[26].ToString();
                        inf[27] = result[27].ToString();
                        inf[28] = result[28].ToString();
                        inf[29] = result[29].ToString();
                        inf[30] = result[30].ToString();
                        inf[31] = result[31].ToString();
                        inf[32] = result[32].ToString();
                    }
                    if (inf[0] == null) { inf[0] = "无此订单"; }//如果索引为0的字符串数组的值是null值（string类型创建时，默认值是null），则无此订单。
                    //if (inf[32] == "False") { inf[0] = "此订单已经失效"; }
                    return inf;
                }
                catch (MySqlException ex)
                {
                    inf[0] = ex.Message;
                    return inf;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
             {
                 inf[0] = "你没有权限访问";
                 return inf;
             }
        }

        //[WebMethod(Description = "顾客购买核实订单信息")]
        //public string CheckOrder(string OrderNumber)
        //{
        //    String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
        //    MySqlConnection conn = new MySqlConnection(connetStr);
        //    try
        //    {
        //        conn.Open();
        //        string sql = "select Check_order from prescription where OrderNumber='" + OrderNumber + "'";
        //        MySqlCommand cmd = new MySqlCommand(sql, conn);
        //        MySqlDataReader result = cmd.ExecuteReader();
        //        string bol = null;
        //        while (result.Read())
        //        {
        //            bol = result[0].ToString();//1返回True(注意是大写T)，0返回False;
        //        }
        //        //return "bol=" + bol;
        //        if (bol == "True") { return "True"; } else { return "False"; }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        return ex.Message;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        [WebMethod(Description = "添加销售记录")]
        [SoapHeader("header")]
        public string Addsalesrecord(string devicenumber, string selldatedatetime, string ordernumber, string amount)
        {

            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "insert into salesrecord(devicenumber,selldatedatetime,ordernumber,amount) values('" + devicenumber + "','" + selldatedatetime + "','" + ordernumber + "','" + amount + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return "受影响的行数" + result;

            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
            else
            {
                return "您没有权限访问";
            }
        }

        [WebMethod(Description = "清除销售记录")]
        [SoapHeader("header")]
        public string Clearsalesrecord(int month)
        {

            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
              if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "Delete From salesrecord where DATE(Createtime) <= DATE(DATE_SUB(NOW(),INTERVAL " + month + " MONTH))";
                //Delete From prescription where DATE(Createtime)<= DATE(DATE_SUB(NOW(),INTERVAL 1 MONTH)); 
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return "删除记录数=" + result.ToString();
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
              else
              {
                  return "您没有权限访问";
              }
        }

        [WebMethod(Description = "查询销售记录,日期格式举例：2019-04-14")]
        [SoapHeader("header")]
        public List<salesrecord> Searchsalesrecord(string devicenumber, string begintime,string endtime)
        {
            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            List<salesrecord> salList = new List<salesrecord>();//创建类集合
              if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "select * from salesrecord where devicenumber='" + devicenumber + "' and DATE(createtime) BETWEEN DATE('"+begintime+"') AND DATE('"+endtime+"');";
                //select * from salesrecord where DATE(createtime) BETWEEN DATE('2019-04-14 13:51:11') AND DATE('2019-04-15 11:49:10');
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = null;
                result = cmd.ExecuteReader();
                while (result.Read())//索引从-1开始，让MYSqlDataReader 前进到下一条记录,如果存在更多行，则为 true；否则为 false。
                {

                    salList.Add(new salesrecord()
                    {
                        devicenumber = Convert.ToInt32(result[0].ToString()),
                        selldatedatetime = result[1].ToString(),
                        ordernumber = result[2].ToString(),
                        amount = result[3].ToString(),
                        spare1 = result[4].ToString(),
                        spare2 = result[5].ToString()

                    });
                }
                if (salList.Count() == 0) { salList.Add(new salesrecord() { spare1 = "无机器" });  }
                return salList;
            }
            catch (MySqlException ex)
            {
                salList.Add(new salesrecord()
                {

                    spare1 = ex.Message.ToString(),

                });
                return salList;
            }
            finally
            {
                conn.Close();
            }
            }
              else
              {
                  salList.Add(new salesrecord()
                  {
                      spare1 ="您没有权限访问",
                  });
                  return salList;
              }
        }

        [WebMethod(Description = "增加库存药类")]
        [SoapHeader("header")]
        public string Addrepertory(string devicenumber, string drugclasses, string number, string spare1,string spare2)
        {
            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);

             if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "insert into repertory(devicenumber,drugclasses,number,spare1,spare2) values('" + devicenumber + "','" + drugclasses + "','" + number + "','" + spare1 +  "','"+spare2+"')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return "受影响的行数" + result;

            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
             else
             {
                 return "您没有权限访问";
             }
        }

        [WebMethod(Description = "删除库存指定药类")]
        [SoapHeader("header")]
        public string Clearrepertory(string devicenumber, string drugclasses)
        {

            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
             if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "Delete From repertory where devicenumber='" + devicenumber + "' and drugclasses='" + drugclasses + "';";
                //Delete From prescription where DATE(Createtime)<= DATE(DATE_SUB(NOW(),INTERVAL 1 MONTH)); 
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return "删除记录数=" + result.ToString();
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
             else
             {
                 return "您没有权限访问";
             }
        }

        [WebMethod(Description = "更新库存")]
        [SoapHeader("header")]
        public string Updaterepertory(string devicenumber, string drugclasses, string number, string spare1, string spare2)
        {
            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "update repertory set number='" + number + "',spare1='" + spare1 + "',spare2='" + spare2 + "' where devicenumber='" + devicenumber + "'and drugclasses='" + drugclasses + "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return "已经插入" + result;

            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
            else
            {
                return "您没有权限访问";
            }
        }

       
        [WebMethod(Description = "查询机号库存")]
        [SoapHeader("header")]
        public List<repertory> Searchrepertory(string devicenumber)
        {

            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            List<repertory> repertory = new List<repertory>();
            if (header.ValideUser(header.UserName, header.PassWord))
            {
                try
                {
                    conn.Open();

                    string sql = "select * from repertory where devicenumber='" + devicenumber + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader result = null;
                    result = cmd.ExecuteReader();

                    while (result.Read())
                    {

                        repertory.Add(new repertory()
                        {
                            devicenumber = Convert.ToInt32(result[0].ToString()),
                            drugclasses = result[1].ToString(),
                            number = Convert.ToInt32(result[2].ToString()),
                            spare1 = result[3].ToString(),
                            spare2 = result[4].ToString()

                        });

                    }
                    if (repertory.Count() == 0) { repertory.Add(new repertory() { spare1 = "无此药" }); }
                    return repertory;
                }
                catch (MySqlException ex)
                {
                    repertory.Add(new repertory()
                    {

                        spare1 = ex.Message.ToString(),


                    });

                    return repertory;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                repertory.Add(new repertory { spare1 = "您没有权限访问" });
                return repertory;
            }

        }

        [WebMethod(Description = "增加在册药类")]
        [SoapHeader("header")]
        public string Addondrugs(string drugclass, string price,string spare1, string spare2)
        {
            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
             if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "insert into ondrugs(drugclass,price,spare1,spare2) values('" + drugclass + "','" + price + "','" + spare1 + "','" + spare2 + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return "受影响的行数" + result;

            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
             else
             {
                 return "您没有权限访问";
             }
        }

        [WebMethod(Description = "删除在册药类")]
        [SoapHeader("header")]
        public string Clearondrugs(string drugclasses)
        {

            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
              if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "Delete From ondrugs where  drugclass='" + drugclasses + "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return "删除记录数=" + result.ToString();
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
              else
              {
                  return "您没有权限访问";
              }
        }

        [WebMethod(Description = "更改在册药类的信息")]
        [SoapHeader("header")]
        public string Updateondrugs(string drugclass, string price, string spare1, string spare2)
        {
            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
             if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "update ondrugs set price='" + price + "',spare1='" + spare1 + "',spare2='" + spare2 + "' where  drugclass='" + drugclass + "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return "已经插入" + result;

            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
             else
             {
                 return "您没有权限访问";
             }
        }

        [WebMethod(Description = "查询在册药品")]
        [SoapHeader("header")]
        public List<Ondrug> Searchondrug(string drugclass)
        {
            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            List<Ondrug> Ondrug = new List<Ondrug>();
            if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();

                string sql = "select * from ondrugs where drugclass='" + drugclass + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = null;
                result = cmd.ExecuteReader();
                //if (result.Read() == false)
                //{
                //    Ondrug.Add(new Ondrug() { durgclass = "无此药" });
                //    return Ondrug;
                //}
                //else
                //{
                while (result.Read())
                {
                    Ondrug.Add(new Ondrug()
                    {
                        durgclass = result[0].ToString(),
                        price = result[1].ToString(),
                        spare1 = result[2].ToString(),
                        spare2 = result[3].ToString(),

                    });

                }
                if (Ondrug.Count() == 0) { Ondrug.Add(new Ondrug() { durgclass = "无此药" }); }
                return Ondrug;
                //}

            }
            catch (MySqlException ex)
            {
                Ondrug.Add(new Ondrug()
                {

                    spare1 = ex.Message.ToString(),

                });

                return Ondrug;
            }
            finally
            {
                conn.Close();
            }
            }
            else
            {
                Ondrug.Add(new Ondrug()
                {

                    spare1 = "您没有权限访问",

                });

                return Ondrug;
            }
        }

        [WebMethod(Description = "添加日志记录")]
        [SoapHeader("header")]
        public string Addlog(string devicenumber, string faulttime, string diagnosis, string spare1, string spare2)
        {

            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "insert into log(devicenumber,faulttime,diagnosis,spare1,spare2) values('" + devicenumber + "','" + faulttime + "','" + diagnosis + "','" + spare2 + "','" + spare2 + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return "受影响的行数" + result;

            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
            else
            {
                return "您没有权限访问";
            }
        }

        [WebMethod(Description = "清除销售记录")]
        [SoapHeader("header")]
        public string Clearlog(int month)
        {

            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
             if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "Delete From log where DATE(Createtime) <= DATE(DATE_SUB(NOW(),INTERVAL " + month + " MONTH))";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return "删除记录数=" + result.ToString();
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                conn.Close();
            }
            }
             else
             {
                 return "您没有权限访问";
             }
        }

        [WebMethod(Description = "查询日志记录")]
        [SoapHeader("header")]
        public List<Log> Searchlog(string devicenumber, string begintime, string endtime)
        {
            String connetStr = "server=localhost;port=3316;user=root;password=sjw123; database=drugstorage;Charset=utf8";
            MySqlConnection conn = new MySqlConnection(connetStr);
            List<Log> log = new List<Log>();
             if (header.ValideUser(header.UserName, header.PassWord))
            {
            try
            {
                conn.Open();
                string sql = "select * from log where devicenumber='" + devicenumber + "' and Date(Createtime) between date('"+begintime+"') and date('" + endtime + "');";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    log.Add(new Log
                    {
                        devicenumber = Convert.ToInt32(result[0].ToString()),
                        faulttime = result[1].ToString(),
                        diagnosis = result[2].ToString(),
                        spare1 = result[3].ToString(),
                        spare2 = result[4].ToString()
                    });
                }
                if (log.Count() == 0) { log.Add(new Log() { spare1 = "无此号机" }); }
                return log;
            }
            catch (MySqlException ex)
            {
                log.Add(new Log { spare1 = ex.Message.ToString() });
                return log;
            }
            finally
            {
                conn.Close();
            }
            }
             else
             {
               log.Add(new Log { spare1 = "您没有权限访问" });
                return log;
             }
        }

        //[WebMethod(Description = "自定义类型集合作为参数测试")]
        //public List<salesrecord> Query(List<salesrecord> salesrecord) 
        //{
        //    return salesrecord;
        //}

    }
}