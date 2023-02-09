namespace Shared.Core.Models
{
    public class BaseRequestFilter
    {
        public int Take { get; set; } = 100;
        public int? Page { get; set; }
        public int? Offset { get; set; } = 0;
        public string? SortingProp { get; set; }
        public bool? Ascending { get; set; } = true;

        public int Skip
        {
            get
            {
                if (Offset != null)
                    return (int)Offset;

                if (Page != null)
                    return ((int)Page - 1) * Take;

                return 0;
            }
        }
    }
}
