namespace FsApiAccess.Models
{
    public class ApiClasificationResponseModel
    {
        public List<Klasifikacia> Klasifikacie { get; set; }
        public List<Lokacia> Lokacie { get; set; }
    }
    public class Klasifikacia
    {
        public string Kod { get; set; }
        public Nazov Nazov { get; set; }
        public string NadriadenaKlasifikacia { get; internal set; }
    }
    public class Lokacia
    {
        public string Kod { get; set; }
        public Nazov Nazov { get; set; }
        public string NadriadenaKlasifikacia { get; internal set; }
    }
    public class Nazov
    {
        public string En { get; set; }
        public string Sk { get; set; }
    }
    public class ApiAllFinancialReportTemplatesResponseModel
    {
       public List<ApiFinancialReportTemplateModel> sablony { get; set; } = new List<ApiFinancialReportTemplateModel>();
    }
    public partial class ApiFinancialReportTemplateModel
    {
        public int id { get; set; }
        public string? nariadenieMF { get; set; }
        public string? nazov { get; set; }
        public DateOnly? platneOd { get; set; }
        public DateOnly? platneDo { get; set; }
        public virtual ICollection<TemplateTable> tabulky { get; set; } = new List<TemplateTable>();
    }
    public partial class TemplateTable
    {
        public Nazov? nazov { get; set; }
        public int? pocetDatovychStlpcov { get; set; }
        public int? pocetStlpcov { get; set; }
        public virtual ICollection<TemplateHeader> hlavicka { get; set; } = new List<TemplateHeader>();
        public virtual ICollection<TemplateRow> riadky { get; set; } = new List<TemplateRow>();
    }
    public partial class TemplateHeader
    {
        public int riadok { get; set; }
        public int? sirkaStlpca { get; set; }
        public int stlpec { get; set; }
        public Nazov? text { get; set; }
        public int? vyskaRiadku { get; set; }
    }
    public partial class TemplateRow
    {
        public int cisloRiadku { get; set; }
        public Nazov? text { get; set; }
        public string? oznacenie { get; set; }
    }
    public class ApiAccountingEntityResponseModel
    {
        public int Id { get; set; } // identifier of the accounting entity
        public string? Ico { get; set; } // Company Identification Number (CIN)
        public string? Dic { get; set; } // Tax Identification Number (TIN)
        public string? Sid { get; set; } // SID of accounting entity
        public string? NazovUJ { get; set; } // title of accounting entity
        public string? Mesto { get; set; } // address of accounting entity, the city
        public string? Ulica { get; set; } // address of accounting entity, street and number
        public string? Psc { get; set; } // address of accounting entity, zip code
        public DateOnly? DatumZalozenia { get; set; } // date of establishment of the accounting entity
        public DateOnly? DatumZrusenia { get; set; } // date of cancellation of the accounting entity
        public string? PravnaForma { get; set; } // code of the legal form
        public string? SkNace { get; set; } // SK NACE classification code
        public string? VelkostOrganizacie { get; set; } // code for category of the organization size
        public string? DruhVlastnictva { get; set; } // code for category of the organization ownership
        public string? Kraj { get; set; } // registerred office of accounting entity, region code
        public string? Okres { get; set; } // registerred office of accounting entity, district code
        public string? Sidlo { get; set; } // registerred office of accounting entity, code of village or city
        public bool? Konsolidovana { get; set; } // boolean flag - true if the unit has at least one consolidated financial statement
        public List<int>? IdUctovnychZavierok { get; set; } // a list of identifiers of all associated financial statements
        public List<int>? IdVyrocnychSprav { get; set; } // a list of identifiers of all related annual reports
        public string? ZdrojDat { get; set; } // code of the source of data used
        public DateOnly? DatumPoslednejUpravy { get; set; } // date of last modification that affects accounting entity API representation
    }
}

