using ReqresDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqresDemo.Utilities
{
    public class TestHelper<T>
    {
        public ListUsers GetAllUserHelper(string endPoint)
        {
            var user = new APIHelper<ListUsers>();
            var url = user.SetUrl(endPoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            ListUsers content = user.GetContent<ListUsers>(response);
            return content;
        }

        public CreateUser CreateNewUserTest(string endPoint, dynamic payLoad)
        {
            var user = new APIHelper<CreateUser>();
            var url = user.SetUrl(endPoint);
            var request = user.CreatePostRequest(payLoad);
            var response = user.GetResponse(url, request);
            CreateUser content = user.GetContent<CreateUser>(response);
            return content;
        }
    }
}
