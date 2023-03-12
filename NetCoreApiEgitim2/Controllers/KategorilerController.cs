using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NetCoreApiEgitim2.Entities;
using NetCoreApiEgitim2.Models;
using Newtonsoft.Json;
using System.Data;
namespace NetCoreApiEgitim2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorilerController : ControllerBase
    {
        [HttpPost]
        [Route("getKategoriler")]
        public IActionResult getKategoriler()
        {
            Thread.Sleep(5000);
            using var context= new Context();
            var values = context.Kategoriler.ToList();
            return Ok(values);
        }


        [HttpPost]
        [Route("addKategoriler")]
        public IActionResult addKategoriler(Kategoriler kategori)
        {
            using var context= new Context();
            context.Add(kategori);
            context.SaveChanges();
            return Ok();
        }


        [HttpPost]
        [Route("updateKategoriler")]
        public IActionResult updateKategoriler(Kategoriler kategori)
        {
            using var context= new Context();
            context.Update(kategori);
            context.SaveChanges();
            return Ok();
        }


        [HttpPost]
        [Route("deleteKategoriler")]
        public IActionResult deleteKategoriler(int id)
        {
            using var context= new Context();
            Kategoriler kategoriler = new Kategoriler();
            kategoriler.id = id;
            context.Remove(kategoriler);
            context.SaveChanges();
            return Ok();
        }


        [HttpPost]
        [Route("getKategorilerJoin")]
        public IActionResult getKategorilerJoin()
        {
            using var context= new Context();
            string query = @"select Kategoriler.ad,kategoriId,Urunler.ad,Urunler.id as urunId from Urunler
left join Kategoriler on Kategoriler.id=Urunler.kategoriId";

            var data = getQueryToDataTable(query, context);

            string json = JsonConvert.SerializeObject(data);

            return Ok(json);
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public DataTable getQueryToDataTable(string query, DbContext context)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }


    }
}
