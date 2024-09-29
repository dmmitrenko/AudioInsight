using AudioInsight.Domain.Model;
using AudioInsight.Infrastructure.Repositories;

namespace AudioInsight.DataContext.Repositories;

public class CallRepository(MongoDbContext context) : Repository<Call>(context, nameof(context.Calls)), ICallRepository
{
}
