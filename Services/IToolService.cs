using System.Collections.Generic;

public interface IToolService
{
    List<AITool> GetTools(FilterToolsDto? filter);
    bool RecalculateRating(int toolId);
}
