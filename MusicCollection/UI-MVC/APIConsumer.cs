using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace UI_MVC
{
    internal static class ApiConsumer<T> where T : class
    {
        internal static IEnumerable<T> GetApi(string path)
        {
            IEnumerable<T> objects = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56396/api/");
                var responseTask = client.GetAsync(path);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    JavaScriptSerializer jSserializer = new JavaScriptSerializer();
                    objects = jSserializer.Deserialize<IEnumerable<T>>(readJob.Result);
                }

                return objects;
            }
        }

        internal static T GetObject(string path, string id)
        {
            T objects = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56396/api/");
                var responseTask = client.GetAsync(path + "/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsStringAsync();
                    JavaScriptSerializer jSserializer = new JavaScriptSerializer();
                    objects = jSserializer.Deserialize<T>(readJob.Result);
                }

                return objects;
            }
        }

        internal static void CreateObject(string path, T t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56396/api/");

                var postTask = client.PostAsJsonAsync<T>(path, t);
                postTask.Wait();
            }
        }

        internal static void UpdateObject(string path, string id, T t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56396/api/");

                var putTask = client.PutAsJsonAsync<T>(path, t);
                putTask.Wait();
            }
        }

        internal static void DeleteObject(string path, string id, T t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56396/api/");
                var url = client.BaseAddress + path + "/" + id;
                var deleteTask = client.DeleteAsync(url);
                deleteTask.Wait();
            }
        }
    }
}