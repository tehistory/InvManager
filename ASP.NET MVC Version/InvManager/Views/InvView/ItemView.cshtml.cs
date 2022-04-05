#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InvManager.Data;
using InvManager.Models;

namespace InvManager.Views.InvView
{
    public class ItemViewModel : PageModel
    {
        private readonly InvManager.Data.DBContext _context;

        public ItemViewModel(InvManager.Data.DBContext context)
        {
            _context = context;
        }

        public IList<ItemModel> ItemModel { get;set; }

        public async Task OnGetAsync()
        {
            ItemModel = await _context.Items.ToListAsync();
        }
    }
}
