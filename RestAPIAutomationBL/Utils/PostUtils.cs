using APIFramework.Utils;
using Newtonsoft.Json;
using RestAPIAutomationBL.Requests;
using RestAPIAutomationBL.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIAutomationBL.Utils
{
    public class PostUtils
    {
        // Create a new post
        public static CreatePostValidResponse CreatePost(
            int id, string title, string author)
        {
           return RestClientUtil.Post<CreatePostValidResponse>
                (
                "posts", createPostRequestBody(id, title, author),
                DataFormat.Json
                );
        }



        public static string createPostRequestBody(int id,string title,string author)
        {
            CreatePostValidRequest request = new CreatePostValidRequest();
            request.id = id;
            request.title = title;
            request.author = author;
            return JsonConvert.SerializeObject(request);
        }
        //Delete a post

        public static bool DeletePost(int id)
        {
            return RestClientUtil.Delete("posts/"+id.ToString(),DataFormat.Json,System.Net.HttpStatusCode.OK);
        }
    }
}