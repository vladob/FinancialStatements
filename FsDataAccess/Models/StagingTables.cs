using Microsoft.EntityFrameworkCore;

namespace FsDataAccess.Models
{
    public class StagingLegalForm
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string TitleEng { get; set; }
        public string TitleSk { get; set; }
    }

    public class StagingSkNace
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string TitleEng { get; set; }
        public string TitleSk { get; set; }
    }

    public class StagingOwnershipType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string TitleEng { get; set; }
        public string TitleSk { get; set; }
    }

    public class StagingOrganizationSize
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string TitleEng { get; set; }
        public string TitleSk { get; set; }
    }

    public class StagingLocation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string TitleSk { get; set; }
        public string ParentLocation { get; set; }
    }


}


