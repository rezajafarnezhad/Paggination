using System.Security.Principal;

namespace webApp.ViewModels.paging;

public class BasePagging
{
    public int DataCount { get; set; }
    public int PageId { get; set; }
    public int Take { get; set; }
    public int PageCount { get; set; }
    public int StartPage { get; set; }
    public int EntPage { get; set; }

    public void GeneratePagging(IQueryable<object> data, int pageId, int take)
    {
        DataCount = data.Count();
        PageId = pageId;
        Take = take;
        PageCount = data.Count() / take;
        if (data.Count() % take > 0)
            PageCount += 1;
        StartPage = ((pageId - 2 <= 0) ? 1 : pageId - 2);
        EntPage = ((pageId + 2 >= PageCount) ? PageCount : pageId + 2);
    }

}
