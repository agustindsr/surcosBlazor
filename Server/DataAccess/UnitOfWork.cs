using SurcosBlazor.Server.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurcosBlazor.Server.DataAccess
{
    public interface IUnitOfWork { 
        
        WebApiDbContext _context { get; }
        void commit();


    }
   
    public class UnitOfWork:   IUnitOfWork
    {
        public WebApiDbContext _context { get; set; }

        public UnitOfWork(WebApiDbContext context)
        {
            _context = context;
        }

        public void commit()
        {
            _context.SaveChanges();
        }
    }
}
