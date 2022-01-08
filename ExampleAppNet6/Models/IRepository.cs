namespace ExampleAppNet6.Models {

    public interface IRepository {

        IQueryable<Product> Products { get; }
    }
}
