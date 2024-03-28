using Asp.Net.Core.DataContext.InterfaceRepository;
using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Dapper;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories
{
    public class UserAuthenticate : RepositoryBase, IUserAuthenticate
    {
        public UserAuthenticate(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<Users> Login(string User_Name, string Password)
        {
            var list = new List<UsersDTO>();
            var obj = new UsersDTO
            {
                user_name = User_Name,
                password = Password
            };
            list.Add(obj);
            DynamicParameters datas = new DynamicParameters();
            datas.Add("@v_txt", JsonConvert.SerializeObject(list));
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"common.fn_authenticate_usernameandpassword",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            List<Users> result = JsonConvert.DeserializeObject<List<Users>>(response.Records);
            return result[0];
        }

        //public long EncryptKey(string key)
        //{
        //    long lngHold = 0;

        //    for (int intLoop = 1; intLoop <= Strings.Len(key); intLoop++)
        //    {
        //        switch ((Strings.Asc(Strings.Left(key, 1)) * intLoop) % 4)
        //        {
        //            case 0:
        //                {
        //                    lngHold = (lngHold + (Strings.Asc(Strings.Mid(key, intLoop, 1)) * intLoop));
        //                    break;
        //                }
        //            case 1:
        //                {
        //                    lngHold = (lngHold - (Strings.Asc(Strings.Mid(key, intLoop, 1)) * intLoop));
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    lngHold = (lngHold + (Strings.Asc(Strings.Mid(key, intLoop, 1)) * (intLoop - Strings.Asc(Strings.Mid(key, intLoop, 1)))));
        //                    break;
        //                }
        //            case 3:
        //                {
        //                    lngHold = (lngHold - (Strings.Asc(Strings.Mid(key, intLoop, 1)) * (intLoop + Strings.Len(key))));
        //                    break;
        //                }
        //        }
        //    }
        //    return lngHold;
        //}
    }
}
