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
}

