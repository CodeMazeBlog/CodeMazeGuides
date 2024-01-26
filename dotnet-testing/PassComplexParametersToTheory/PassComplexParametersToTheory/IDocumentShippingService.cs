using PassComplexParametersToTheory.Data;

namespace PassComplexParametersToTheory;

public interface IDocumentShippingService
{
    bool ShipDocument(Document document, Employee employee);
}
