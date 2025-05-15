using Events.core.models;
using WebApp.Core.Interfaces;
using WebApp.Infrastructure.persistence;

namespace WebApp.Infrastructure.Repositories
{
    public class EventRepo : GenericRepo<Event>, IEventRepo
    {
        private readonly AppDbContext _context;
        public EventRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
