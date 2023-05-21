using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace STT.Service
{

    internal interface ISecureSessionProvider
    {
        string SessionId { get; }
        string CSRFToken { get; }
        string Url { get; }
    }

    internal class Session : ISecureSessionProvider
    {
        public string SessionId { get; set; }

        public string CSRFToken { get; set; }

        public string Url { get; set; }

        public Session(string sessionId, string csrfToken, string url)
        {
            SessionId = sessionId;
            CSRFToken = csrfToken;
            Url = url;
        }

        public Session(string url)
        {
            Url = url;
        }

    }


    /// <summary>
    /// Create secure <see cref="HttpClient"/> and <see cref="HttpWebRequest"/> objects by using data from a <see cref="ISecureSessionProvider"/>.
    /// </summary>
    internal static class SecureClientFactory
    {
        /// <summary>
        /// Create a secure <see cref="HttpClient"/> using session information from a <see cref="ISecureSessionProvider"/>.
        /// </summary>
        /// <param name="session">Session provider.</param>
        /// <param name="HttpClient">The new client object.</param>
        /// <param name="HttpHandler">The new client handler.</param>
        public static void CreateSecureClient(ISecureSessionProvider session, out HttpClient HttpClient, out HttpClientHandler HttpHandler)
        {
            var sessionid = session.SessionId ?? "";
            var token = session.CSRFToken ?? "";
#if DEBUG
            Console.WriteLine("Session Id:" + sessionid);
#endif

            HttpHandler = new HttpClientHandler();

            HttpHandler.UseCookies = true;
            HttpHandler.CookieContainer = new CookieContainer();

            Uri uri = new Uri(session.Url);

            if (!string.IsNullOrEmpty(sessionid))
            {
                HttpHandler.CookieContainer.Add(uri, new Cookie("sessionid", sessionid));
            }

            if (!string.IsNullOrEmpty(token))
            {
                HttpHandler.CookieContainer.Add(uri, new Cookie("csrftoken", token));
            }


            HttpClient = new HttpClient(HttpHandler);

            HttpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            HttpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            HttpClient.DefaultRequestHeaders.Add("X-MicrosoftAjax", "Delta=true");
            HttpClient.DefaultRequestHeaders.Add("Accept", "*/*");

            if (!string.IsNullOrEmpty(token))
            {
                HttpClient.DefaultRequestHeaders.Add("X-CSRFToken", token);
            }

            HttpClient.DefaultRequestHeaders.Add("Origin", session.Url);
        }

    }
}
