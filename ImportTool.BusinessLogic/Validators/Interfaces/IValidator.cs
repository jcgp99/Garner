namespace ImportTool.BusinessLogic.Validators.Interfaces
{
    public interface IValidator<T>
    {
        bool Validate(T param);
    }
}
