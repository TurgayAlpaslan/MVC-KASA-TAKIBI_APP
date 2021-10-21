using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_KasaTakip.Models.Entity;

namespace MVC_KasaTakip.Controllers
{

   
    public class HomeController : Controller
    {
       
        kasataki_turgayEntities db = new kasataki_turgayEntities();
       
        public ActionResult Index(string ara)
        {

            kasataki_turgayEntities entities = new kasataki_turgayEntities();

            var model = db.Islemler.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                model = model.Where(x => x.islem_tur.Contains(ara)).ToList();
                return View(model);
            }
            else
            {
                return View(from Islemler in entities.Islemler.Take(10)
                            select Islemler);
            }
            //Burada eğer kullanıcı bir arama yapmışsa aramaya uyan verileri yapmamışsa tüm verileri tablo halinde hizmetine sunuyoruz.
        }
        [HttpGet]
        public ActionResult About()
        {


            return View();
        }
        //About sayfası action controllerimiz burada extra bir işlem bulunmamakta.

        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Ekle2(Islemler p)
        {
            db.Islemler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Burada İslemler tablosuna ekleyi kaydedip index sayfasına dönüyoruz.
        public ActionResult Guncellebilgilerigetir(Islemler p)
        {
            var model = db.Islemler.Find(p.islem_no);
            
            return View();

        }
        public ActionResult Guncelle(Islemler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Burada ise istenen islemi güncelleyip güncellenmiş halini index sayfasına sunuyoruz.

        public ActionResult silbilgigetir(Islemler p)
        {
            var model = db.Islemler.Find(p.islem_no);
            if (model == null) return HttpNotFound();
            return View(model);
        }
        public ActionResult Sil(Islemler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Burada ise istenen islemi silerek tablonun güncel halini müşteriye sunuyoruz.



    }
}