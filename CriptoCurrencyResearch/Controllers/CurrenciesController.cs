using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CriptoCurrencyResearch.Models;

namespace CriptoCurrencyResearch.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly CurrencyContext _context;

        public CurrenciesController(CurrencyContext context)
        {
            _context = context;
        }

        // GET: Currencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Currencies.ToListAsync());
        }

        public async Task<IActionResult> ChoiceCurrencies(List<Currency> currencies)
        {
            foreach(var item in currencies)
            {
                if(item.CheckboxChecked == true)
                {
                    Currency currency = await _context.Currencies.FirstAsync(x => x.CurrencyId == item.CurrencyId);
                    currency.Quantity = currency.Quantity + 1;
                    _context.Update(currency);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public JsonResult GraphData()
        {
            return Json(_context.Currencies.Select(x => new { x.Name, x.Quantity }));
        }

        // GET: Currencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Currencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurrencyId,Name,Quantity")] Currency currency)
        {
            if (ModelState.IsValid)
            {
                currency.Quantity = 0;
                _context.Add(currency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currency);
        }
    }
}
