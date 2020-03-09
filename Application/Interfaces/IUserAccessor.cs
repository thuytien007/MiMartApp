namespace Application.Interfaces
{
    //liên quan đến UserAccessor trong Security của Infrastructure
    public interface IUserAccessor
    {
        string GetCurrentUsername();
    }
}