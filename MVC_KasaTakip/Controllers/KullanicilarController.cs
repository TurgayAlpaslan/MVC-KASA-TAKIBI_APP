using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KasaTakip.Models.Entity;
using System.Web.Security;

namespace MVC_KasaTakip.Controllers
{
  [AllowAnonymous]
    public class KullanicilarController : Controller
    {
        // GET: Kullanicilar

        kasataki_turgayEntities db = new kasataki_turgayEntities();
        [HttpGet]

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar k)
        {
            
            var kullanıcı = db.Kullanicilar.FirstOrDefault(x=> x.KullaniciAdi==k.KullaniciAdi && x.Sifre==k.Sifre);
            if (kullanıcı != null)
            {

                FormsAuthentication.SetAuthCookie(k.KullaniciAdi, false);
                return RedirectToAction("Index","Home");
            }
            ViewBag.Hata = "Kullanıcı Adı veya Şifre Yanlış";
            return View();
        }
        //Burada siteden girilen verileri veritabanında ki veriler ile kıyaslıyor ve kullanıcı adımız boş veya şifremiz yanlış değilse index sayfasına taşıyoruz.
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        //Burası da Kullanıcımızın site ile işi bittiğinde çıkış yapmasını sağlayan controllerimiz.
        [HttpGet]
        public ActionResult Kaydol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydol(Kullanicilar k)
        {
            if (!ModelState.IsValid) return View();

            db.Entry(k).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        //Burada ise kayıt olmak isteyen kullanıcımız için verileri önce ekleyip sonra kayıt ediyoruz.
    }
}
