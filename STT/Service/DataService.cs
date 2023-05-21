using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using STT.Model.Crew;

namespace STT.Service
{
    public class DataService
    {
        /// <summary>
        /// Url to retrieve the crew roster
        /// </summary>
        public const string CrewRosterUrl = "https://datacore.app/structured/crew.json";
        
        /// <summary>
        /// Base Url for retrieving various crew assets
        /// </summary>
        public const string CrewAssetUrlBase = "https://assets.datacore.app/";

        /// <summary>
        /// Base Url for retrieving various crew assets
        /// </summary>
        public const string CrewUrlBase = "https://datacore.app/crew/";

        private HttpClient _httpClient;
        private HttpClientHandler _httpClientHandler;

        public DataService() 
        {
            SecureClientFactory.CreateSecureClient(
                new Session("https://datacore.app"), 
                out _httpClient, 
                out _httpClientHandler);

            _httpClient.Timeout = new TimeSpan(0, 0, 60);
        }

        private async Task<string> Fetch(string url) 
        {
            try
            {
                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            catch (Exception ex)
            {
                WriteDebug(ex);
                return null;
            }
        }

        public static void WriteDebug(Exception ex, [CallerMemberName] string caller = null)
        {
            Debug.WriteLine(caller);
            Debug.WriteLine(ex);
        }

        public static void WriteDebug(string s)
        {
            Debug.WriteLine(s);
        }

        private async Task<T> InternalFetchCrewAsync<T>(string url) where T : class, IList<CrewMember>, new()
        {
            var json = await Fetch(url);

            if (json != null)
            {
                var tobj = JsonConvert.DeserializeObject<T>(json);  

                
                return tobj;
            }

            return null;
        }

        public async Task<CrewMember[]> FetchCrewAsync()
        {
            var ci = await InternalFetchCrewAsync<List<CrewMember>>(CrewRosterUrl);
            return ci.ToArray();
        }
        public Task<TList> FetchCrewAsync<TList>() where TList : class, IList<CrewMember>, new() 
        {
            return InternalFetchCrewAsync<TList>(CrewRosterUrl);
        }

        public void BeginFetchCrew<TList>(Action<TList> success, Action<Exception> failure = null) where TList: class, IList<CrewMember>, new()
        {

            try
            {
                InternalFetchCrewAsync<TList>(CrewRosterUrl)
                    .ContinueWith((t) =>
                    {
                        try
                        {
                            success(t.Result);
                        }
                        catch (Exception ex)
                        {
#if DEBUG
                            WriteDebug(ex);
#endif
                            if (failure != null) failure(ex);
                        }
                        
                    });
            }
            catch (Exception ex)
            {
#if DEBUG
                WriteDebug(ex);
#endif
                if (failure != null) failure(ex);
            }

        }



    }
}
