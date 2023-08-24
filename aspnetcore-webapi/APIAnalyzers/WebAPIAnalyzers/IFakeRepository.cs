namespace WebAPIAnalyzers
{
    public interface IFakeRepository
    {
        public bool TryGetEmployee(int id, out Employee? employee);
    }
}
