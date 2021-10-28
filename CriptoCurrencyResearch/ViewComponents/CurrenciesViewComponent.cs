using CriptoCurrencyResearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriptoCurrencyResearch.ViewComponents
{
    public class CurrenciesViewComponent : ViewComponent
    {
        private readonly CurrencyContext _currencyContext;

        public CurrenciesViewComponent(CurrencyContext currencyContext)
        {
            _currencyContext = currencyContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _currencyContext.Currencies.ToListAsync());
        }
    }
}
