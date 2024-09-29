using AudioInsight.Domain.Model;
using MediatR;
using System.Linq.Expressions;

namespace AudioInsight.Application.Calls.Commands;
public record GetCallCommand(Expression<Func<Call, bool>> filter) : IRequest<Call>;
