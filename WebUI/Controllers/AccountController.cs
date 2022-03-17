using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        

        [Authorize]
        public async Task<IActionResult> UserInfo()
        {
     
            UserModel userModel = new UserModel();
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

                ResponseMainModel<UserModel> responseModel = null;
                var result = await client.GetAsync("User/GetUserInfoFromLogined");

                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await HttpContext.SignOutAsync();
                    return Redirect(String.Format("~/Account/Login?ReturnUrl=/{0}/{1}", ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName));
                }
                if (result.IsSuccessStatusCode)
                {
                    responseModel = JsonSerializer.Deserialize<ResponseMainModel<UserModel>>(await result.Content.ReadAsStringAsync());
                    userModel = responseModel.Data;  
                }
            }
            return View(userModel);
        }

        [Authorize]
        public IActionResult Forbidden()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl = null)
        {

            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }

        [Authorize]
        public IActionResult Logout(string ReturnUrl = null)
        {
            HttpContext.SignOutAsync();
            return Redirect("~/");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //var reqCookies = Request.Cookies["MySessionCookie"];
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                string jsonString = JsonSerializer.Serialize(model);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await client.PostAsync("/api/Auth/Login", content);

                var responseModel = JsonSerializer.Deserialize<ResponseMainModel<ResponseTokenModel>>(await result.Content.ReadAsStringAsync());
                if (result.IsSuccessStatusCode)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtSecurityToken = handler.ReadJwtToken(responseModel.Data.AccessToken);



                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value),
                        new Claim(ClaimTypes.Email,  jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email).Value ),
                        new Claim(ClaimTypes.Name,  jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value ),
                        new Claim("access_token",  responseModel.Data.AccessToken ),
                        new Claim("refresh_token",  responseModel.Data.RefreshToken ),
                        new Claim(ClaimTypes.Role, "User")
                    };

                    var roleClaims = jwtSecurityToken.Claims.Where(x => x.Type == ClaimTypes.Role);
                    claims.AddRange(roleClaims);

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = responseModel.Data.AccessTokenExpiration,
                    };
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                    return Redirect(model.ReturnUrl ?? "~/");

                }
                else
                {
                    foreach (var error in responseModel.Errors)
                    {
                        ModelState.AddModelError("other", error);
                        return View(model);
                    }
                }



            }

            ModelState.AddModelError("", "Girilen kullanıcı adı veya parola yanlış");
            return View(model);

        }



        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            RegisterModel model = new RegisterModel();
            model.RoleSelectList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                string jsonString = JsonSerializer.Serialize(model);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await client.GetAsync("/api/User/GetAllRoles");
                var responseMainModel = JsonSerializer.Deserialize<ResponseMainModel<List<string>>>(await result.Content.ReadAsStringAsync());

                if (responseMainModel.IsSuccessful)
                {
                    foreach (var item in responseMainModel.Data)
                    {
                        model.RoleSelectList.Add(new SelectListItem { Text = item, Value = item });
                    }
                }
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                string jsonString = JsonSerializer.Serialize(model);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await client.PostAsync("/api/User/Register", content);
                var responseMainModel = JsonSerializer.Deserialize<ResponseMainModel<RegisterModel>>(await result.Content.ReadAsStringAsync());
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in responseMainModel.Errors)
                    {
                        ModelState.AddModelError("other", error);
                        return View(model);
                    }
                }
            }
            return View(model);
        }

    }
}
