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
    public class ConViewModel : PageModel
    {
        private readonly InvManager.Data.DBContext _context;

        public ConViewModel(InvManager.Data.DBContext context)
        {
            _context = context;
        }

        public IList<ContainerModel> ContainerModel { get;set; }

        public async Task OnGetAsync()
        {
            ContainerModel = await _context.Containers.ToListAsync();
        }
    }
}
