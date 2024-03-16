namespace gmis.Domain.Common
{
    public class MasterUpdateModel : MasterCreateModel
    {
        public Guid Id{ get; set; }
        public bool IsActive { get; set; } = true;
    }
}
