using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Dealmember
    {
        SQLDAL.Dealmember dealmember = new SQLDAL.Dealmember();

        public bool Addmember(Model.member model)
        {
            return dealmember.Addmember(model);

        }
        //删除会员
        public bool Deletemember(string Member_id)
        {
            return dealmember.Deletemember(Member_id);

        }


        //根据查询条件，查询会员列表
        public DataTable GetList(string strWhere)
        {
            return dealmember.GetList(strWhere);
        }




        //根据会员号，查询某个会员信息
        public Model.member GetOnemember(string Member_id)
        {
            return dealmember.GetOnemember(Member_id);     

        }


        //根据等级，查询某种等级所有会员
        public DataTable Getmember_level(string Level)
        {
            return dealmember.Getmember_level(Level);
        }

        //查询所有会员信息
        public DataTable GetMember()
        {
            return dealmember.GetMember();

        }

        //更改会员信息(更改密码，更改等级)
        public bool Updatemember_passwd(Model.member model)
        {
            return dealmember.Updatemember_passwd(model);

        }

        //判断Member_id，判断原密码是否正确
        public bool Login(string member_id, string password)
        {
            return dealmember.Login(member_id, password);
        
        }

         //根据Member_id修改密码
        public bool Updatemember_passwd2(string member_id, string password) {

            return dealmember.Updatemember_passwd2(member_id, password);
        }

    }
}

