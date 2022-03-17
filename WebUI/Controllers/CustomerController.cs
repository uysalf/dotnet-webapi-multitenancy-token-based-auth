using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Models;


namespace WebUI.Controllers
{
    [Authorize(Roles = "CustomerManeger,Admin")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            CustomerListModel viewModel = new CustomerListModel();
            using (var client = new HttpClient())
            {
                if (User.Identity.IsAuthenticated)
                {
                    var accessToken = User.Claims.FirstOrDefault(x => x.Type == "access_token").Value;
                    var refresh_token = User.Claims.FirstOrDefault(x => x.Type == "refresh_token").Value;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri("https://localhost:5001/api/");

                ResponseMainModel<IEnumerable<CustomerModel>> responseModel = null;
                var result = await client.GetAsync("Customer");
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await HttpContext.SignOutAsync();
                    return Redirect(String.Format("~/Account/Login?ReturnUrl=/{0}/{1}", ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName));
                }
                responseModel = JsonSerializer.Deserialize<ResponseMainModel<IEnumerable<CustomerModel>>>(await result.Content.ReadAsStringAsync());



                if (!result.IsSuccessStatusCode || responseModel != null)
                {
                    if (responseModel != null)
                    {
                        foreach (var error in responseModel.Errors)
                        {
                            ModelState.AddModelError("other", error);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("other", result.StatusCode.ToString());
                    }

                }
                viewModel.Customers = responseModel.Data.ToList();
            }

            return View(viewModel);

        }

        public IActionResult Create()
        {
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var accessToken = User.Claims.FirstOrDefault(x => x.Type == "access_token").Value;
                        var refresh_token = User.Claims.FirstOrDefault(x => x.Type == "refresh_token").Value;
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    }
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri("https://localhost:5001/api/");
                    string strModel = model.ToString();
                    string jsonString = JsonSerializer.Serialize(model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    ResponseMainModel<CustomerModel> responseModel = null;
                    var result = await client.PostAsync("Customer", content);

                    responseModel = JsonSerializer.Deserialize<ResponseMainModel<CustomerModel>>(await result.Content.ReadAsStringAsync());


                    if (result.IsSuccessStatusCode && responseModel != null)
                    {
                        TempData["Success"] = "Yeni Ürün İşleminiz gerçekleştirildi";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (responseModel != null)
                        {
                            foreach (var error in responseModel.Errors)
                            {
                                ModelState.AddModelError("other", error);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("other", result.StatusCode.ToString());
                        }

                    }
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Update(int id)
        {
            CustomerModel model = new CustomerModel();
            CustomerListModel viewModel = new CustomerListModel();
            using (var client = new HttpClient())
            {
                if (User.Identity.IsAuthenticated)
                {
                    var accessToken = User.Claims.FirstOrDefault(x => x.Type == "access_token").Value;
                    var refresh_token = User.Claims.FirstOrDefault(x => x.Type == "refresh_token").Value;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri("https://localhost:5001/api/");

                ResponseMainModel<CustomerModel> responseModel = null;
                var result = await client.GetAsync("Customer/" + id);

                responseModel = JsonSerializer.Deserialize<ResponseMainModel<CustomerModel>>(await result.Content.ReadAsStringAsync());



                if (!result.IsSuccessStatusCode || responseModel != null)
                {
                    if (responseModel != null)
                    {
                        foreach (var error in responseModel.Errors)
                        {
                            ModelState.AddModelError("other", error);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("other", result.StatusCode.ToString());
                    }

                }

                model = responseModel.Data;


            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var accessToken = User.Claims.FirstOrDefault(x => x.Type == "access_token").Value;
                        var refresh_token = User.Claims.FirstOrDefault(x => x.Type == "refresh_token").Value;
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    }
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri("https://localhost:5001/api/");
                    string strModel = model.ToString();
                    string jsonString = JsonSerializer.Serialize(model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");



                    ResponseMainModel<CustomerModel> responseModel = null;
                    var result = await client.PutAsync("Customer/" + model.Id, content);

                    responseModel = JsonSerializer.Deserialize<ResponseMainModel<CustomerModel>>(await result.Content.ReadAsStringAsync());


                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Success"] = "Güncelleme İşleminiz gerçekleştirildi";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (responseModel != null)
                        {
                            foreach (var error in responseModel.Errors)
                            {
                                ModelState.AddModelError("other", error);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("other", result.StatusCode.ToString());
                        }

                    }
                }
            }
            return View(model);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            using (var client = new HttpClient())
            {
                if (User.Identity.IsAuthenticated)
                {
                    var accessToken = User.Claims.FirstOrDefault(x => x.Type == "access_token").Value;
                    var refresh_token = User.Claims.FirstOrDefault(x => x.Type == "refresh_token").Value;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                }
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri("https://localhost:5001/api/");


                ResponseMainModel<NoDataModel> responseModel = null;
                var result = await client.DeleteAsync("Customer/" + id);

                responseModel = JsonSerializer.Deserialize<ResponseMainModel<NoDataModel>>(await result.Content.ReadAsStringAsync());



                if (!result.IsSuccessStatusCode)
                {
                    if (responseModel != null && responseModel.Errors != null)
                    {
                        foreach (var error in responseModel.Errors)
                        {
                            throw new Exception(String.Join(", ", responseModel.Errors));
                        }
                    }
                    else
                    {
                        throw new Exception(result.StatusCode.ToString());
                    }
                }
            }

            return Json(id);
        }


    }
}
