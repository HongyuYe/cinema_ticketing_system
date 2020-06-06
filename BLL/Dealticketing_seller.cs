using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Dealticketing_seller
    {
        SQLDAL.Dealticketing_seller dealticketing_seller = new SQLDAL.Dealticketing_seller();



        //增加售票员
        public bool AddTicketing_seller(Model.ticketing_seller model)
        {

            return dealticketing_seller.AddTicketing_seller(model);
        }


        //删除售票员
        public bool Deleteticketing_seller(int T_id)
        {
            return dealticketing_seller.Deleteticketing_seller(T_id);

        }


        //根据查询条件，获取售票员列表
        public DataTable Getseller(string strWhere)
        {
            return dealticketing_seller.Getseller(strWhere);
        }

        //获取所有售票员信息
        public DataTable Getallseller()
        {
            return dealticketing_seller.Getallseller();
        }

        //更改售票员信息
        public bool Updateseller_password(Model.ticketing_seller model)
        {

            return dealticketing_seller.Updateseller_password(model);


        }

        //判断售票员登录账号ID，密码是否正确
        public bool Login(int t_id, string password)
        {

            return dealticketing_seller.Login(t_id, password);


        }

        //根据管理员登陆ID获取super_seller的值判断其是否是超级管理员
        public bool getSuper_seller(int t_id)
        {
            DataTable dt = dealticketing_seller.getSuper_seller(t_id);
            string super1 = dt.Rows[0]["Super_seller"].ToString();
            int super = int.Parse(super1);
            if (super == 1)//超级管理员
            {
                return true;
            }
            else
            {
                return false;
            }


        }


    }
}
