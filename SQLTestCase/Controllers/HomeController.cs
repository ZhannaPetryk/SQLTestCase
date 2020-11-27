using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLTestCase.Interfaces;
using SQLTestCase.Models;

namespace SQLTestCase.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly ISQLParserService _sqlParserService;
        private readonly IDatabaseImportService _databaseImportService;

        public HomeController(ISQLParserService sqlParserService, IDatabaseImportService databaseImportService)
        {
            _sqlParserService = sqlParserService;
            _databaseImportService = databaseImportService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //await _sqlParserService.GetAll();
            return View(new QueryModel(){});
        }

        [HttpPost]
        public IActionResult Index(QueryModel queryModel)
        {
            var result = _sqlParserService.ExecuteSql(queryModel);
            return View(result);
        }
        
        [HttpGet("seed-data")]
        public IActionResult SeedData()
        {
            _databaseImportService.SeedData();
            return RedirectToAction("Index");
        }
    }
}