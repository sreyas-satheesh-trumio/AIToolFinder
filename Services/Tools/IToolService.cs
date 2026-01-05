using System.Collections.Generic;
using AIToolFinder.Dtos.Tools;

namespace AIToolFinder.Services.Tools;

public interface IToolService
{
    List<AiTool> GetTools(ToolFilterRequest? filter);
    bool RecalculateRating(int toolId);
}
