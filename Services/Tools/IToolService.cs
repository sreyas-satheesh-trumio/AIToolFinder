using System.Collections.Generic;
using AIToolFinder.Dtos.Tools;

namespace AIToolFinder.Services.Tools;

public interface IToolService
{
    List<AiTool> GetTools(ToolFilterRequest? filter);
    Task<bool> RecalculateRating(int toolId);
}
