using System.Collections.Generic;

namespace AIToolFinder.Services.Tools;

public interface IToolService
{
    List<AITool> GetTools(FilterToolsDto? filter);
    bool RecalculateRating(int toolId);
}
