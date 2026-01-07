using System.Collections.Generic;
using AIToolFinder.Dtos.Tools;

namespace AIToolFinder.Services.Tools;

public interface IToolService
{
    Task<List<AiTool>> GetAllAsync(ToolFilterRequest? filter);
    Task<bool> RecalculateRating(int toolId);
}
