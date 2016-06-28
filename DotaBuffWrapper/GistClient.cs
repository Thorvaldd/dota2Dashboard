

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EasyGitHub;
using EasyGitHub.Entities;

namespace DotaBuffWrapper
{
    public class GistClient
    {
        public IDictionary<string, GistFile> GetGist(string gistId)
        {
            var api = GitHubApi.Create();

            //var gists =  api.Gists.Get(gistId).GetAwaiter().GetResult();
            var task= Task.Run(async () =>
            {
               var result = await api.Gists.Get(gistId);
                return result.Files;
            });
            task.Wait();
            return task.Result;
        }
    }
}
