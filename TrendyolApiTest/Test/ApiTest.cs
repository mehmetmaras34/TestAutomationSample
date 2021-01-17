using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TrendyolApiTest.Entities;

namespace TrendyolApiTest.Test
{
    [Binding, Scope(Feature = "ApiTestCase")]
    class ApiTest
    {
        RestClient restClient;
        RestRequest restRequest;

        public ApiTest()
        {
            //Fake Api kullanılmıştır
            restClient = new RestClient("https://api.mocki.io/v1/");
        }
        [StepDefinition("Apideki kitap listesinin boş olduğu doğrulanır")]
        public void VerifyApiEmpty()
        {
            // "/api/books/" bu uzantı yerine fake api uzantı kullanılmıştır.
            restRequest = new RestRequest("/dc5d7bb8", Method.GET);
            var response = restClient.Execute(restRequest);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server.");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Api de hata alınmıştır! " + response.ErrorMessage);
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            Assert.AreEqual(0, apiResponse.BookList.Count, "Apinin içindeki kitap listesi boş değil!");
        }

        [StepDefinition("Title bilgisi girilmeden kitap eklenmeye çalışılır")]
        public void TitleIsRequired()
        {
            // "/api/books/" bu uzantı yerine fake api uzantı kullanılmıştır.
            restRequest = new RestRequest("/75ccc92a", Method.PUT);
            restRequest.AddParameter("author", "Mustafa Kemal Atatürk");
            var response = restClient.Execute(restRequest);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server.");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Api de hata alınmıştır! " + response.ErrorMessage);
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            Assert.AreEqual("Field 'author' is required",apiResponse.Error, "Hata mesajı yanlış");
        }
        [StepDefinition("Author bilgisi girilmeden kitap eklenmeye çalışılır")]
        public void AuthorIsRequired()
        {
            // "/api/books/" bu uzantı yerine fake api uzantı kullanılmıştır.
            restRequest = new RestRequest("/292dcfcf", Method.PUT);
            restRequest.AddParameter("title", "Nutuk");
            var response = restClient.Execute(restRequest);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server.");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Api de hata alınmıştır! " + response.ErrorMessage);
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            Assert.AreEqual("Field 'title' is required", apiResponse.Error, "Hata mesajı yanlış");
        }
        [StepDefinition("Title bilgisi boş girilerek kitap eklenmeye çalışılır")]
        public void TitleIsEmpty()
        {
            // "/api/books/" bu uzantı yerine fake api uzantı kullanılmıştır.
            restRequest = new RestRequest("/a0b910e0", Method.PUT);
            restRequest.AddParameter("title", "");
            restRequest.AddParameter("author", "Mustafa Kemal Atatürk");
            var response = restClient.Execute(restRequest);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server.");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Api de hata alınmıştır! " + response.ErrorMessage);
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            Assert.AreEqual("Field 'title' cannot be empty.", apiResponse.Error, "Hata mesajı yanlış");
        }
        [StepDefinition("Author bilgisi boş girilerek kitap eklenmeye çalışılır")]
        public void AuthorIsEmpty()
        {
            // "/api/books/" bu uzantı yerine fake api uzantı kullanılmıştır.
            restRequest = new RestRequest("/477079a0", Method.PUT);
            restRequest.AddParameter("title", "Nutuk");
            restRequest.AddParameter("author", "");
            var response = restClient.Execute(restRequest);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server.");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Api de hata alınmıştır! " + response.ErrorMessage);
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            Assert.AreEqual("Field 'author' cannot be empty.", apiResponse.Error, "Hata mesajı yanlış");
        }
        [StepDefinition("Id bilgisi girilerek kayıt eklenmeye çalışılır")]
        public void IdIsReadonlyParameter()
        {
            // "/api/books/" bu uzantı yerine fake api uzantı kullanılmıştır.
            restRequest = new RestRequest("/8bde4877", Method.PUT);
            restRequest.AddParameter("title", "Nutuk");
            restRequest.AddParameter("author", "Mustafa Kemal Atatürk");
            restRequest.AddParameter("id", "1");
            var response = restClient.Execute(restRequest);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, response.StatusCode, "HTTP 500 internal server.");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Api de hata alınmıştır! " + response.ErrorMessage);
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            Assert.AreEqual("Cannot register with the same id.", apiResponse.Error, "Hata mesajı yanlış");
        }
        [StepDefinition("Title bilgisi '(.*)', author bilgisi '(.*)' olarak yeni kitap eklenir '(.*)' id numarası ile çağrılır parametreler kontrol edilir")]
        public void AddNewBook(string title,string author,string id)
        {
            // PUT işeminde "/api/books/"+id, GET işleminde "/api/books/1" yerine fake api uzantısı kullanılmıştır.
            restRequest = new RestRequest("/dc5d7bb8", Method.PUT);
            restRequest.AddParameter("title", title);
            restRequest.AddParameter("author", author);
            var responsePut = restClient.Execute(restRequest);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, responsePut.StatusCode, "HTTP 500 internal server.");
            Assert.AreEqual(HttpStatusCode.OK, responsePut.StatusCode, "Api de hata alınmıştır! " + responsePut.ErrorMessage);
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responsePut.Content);

            #region Eklenen kitap kontrolü          
            restRequest = new RestRequest("/c747fef5", Method.GET);
            var responseGet = restClient.Execute(restRequest);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, responseGet.StatusCode, "HTTP 500 internal server.");
            Assert.AreEqual(HttpStatusCode.OK, responseGet.StatusCode, "Api de hata alınmıştır! " + responseGet.ErrorMessage);            
            Book responseBook = JsonConvert.DeserializeObject<Book>(responseGet.Content);
            Assert.AreEqual(1, responseBook.Id, "Id bilgisi yanlış!");
            Assert.AreEqual(author, responseBook.Author, "Author bilgisi yanlış!");
            Assert.AreEqual(title, responseBook.Title, "Title bilgisi yanlış!");
            #endregion
        }

        [StepDefinition("Title bilgisi '(.*)', author bilgisi '(.*)' olan kitabın iki kere eklenemdiği kontrol edilir")]
        public void AddNewSameBook(string title, string author)
        {
            // PUT işeminde "/api/books/" yerine fake api uzantısı kullanılmıştır.
            restRequest = new RestRequest("/dc5d7bb8", Method.PUT);
            restRequest.AddParameter("title", title);
            restRequest.AddParameter("author", author);
            var responseFirst = restClient.Execute(restRequest);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, responseFirst.StatusCode, "HTTP 500 internal server.");
            Assert.AreEqual(HttpStatusCode.OK, responseFirst.StatusCode, "Api de hata alınmıştır! " + responseFirst.ErrorMessage);
            ApiResponse apiResponseFirst = JsonConvert.DeserializeObject<ApiResponse>(responseFirst.Content);

            #region Aynı kitabı ikinci kez ekleme
            restRequest = new RestRequest("/520d23bc", Method.PUT);
            restRequest.AddParameter("title", title);
            restRequest.AddParameter("author", author);
            var responseSecond = restClient.Execute(restRequest);
            Assert.AreNotEqual(HttpStatusCode.InternalServerError, responseSecond.StatusCode, "HTTP 500 internal server.");
            Assert.AreEqual(HttpStatusCode.OK, responseSecond.StatusCode, "Api de hata alınmıştır! " + responseSecond.ErrorMessage);
            ApiResponse apiResponseSecond = JsonConvert.DeserializeObject<ApiResponse>(responseSecond.Content);
            Assert.AreEqual("Another book with similar title and author already exists", apiResponseSecond.Error, "Hata mesajı yanlış");
            #endregion
        }
    }
}