using MeuCondominio.Data;
using MeuCondominio.Models;
using MeuCondominio.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MeuCondominio.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var dashboardGraphs = new DashboardGraphsViewModel();

            dashboardGraphs.ApartmentChart = GetApartmentChartData();
            dashboardGraphs.OccurrenceChart = GetOccurrenceChartData();

            return View(dashboardGraphs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ChartModel GetApartmentChartData()
        {
            var chartData = _context.Apartment
                .GroupBy(a => a.Floor)
                .Select(g => new
                {
                    Floor = g.Key,
                    Count = g.Count()
                })
                .OrderBy(a => a.Floor)
                .ToList();

            var chartLabels = chartData.Select(a => $"Andar {a.Floor}").ToList();
            var chartValues = chartData.Select(a => a.Count).ToList();

            var chartViewModel = new ChartModel
            {
                Labels = chartLabels,
                Values = chartValues
            };

            return chartViewModel;
        }

        public ChartModel GetOccurrenceChartData()
        {
            var chartData = _context.Occurrence
                .Include(o => o.Resident)
                .GroupBy(o => o.Resident.Name)
                .Select(g => new
                {
                    ResidentName = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(o => o.Count)
                .ToList();

            var chartLabels = chartData.Select(o => o.ResidentName).ToList();
            var chartValues = chartData.Select(o => o.Count).ToList();

            var chartViewModel = new ChartModel
            {
                Labels = chartLabels,
                Values = chartValues
            };

            return chartViewModel;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}