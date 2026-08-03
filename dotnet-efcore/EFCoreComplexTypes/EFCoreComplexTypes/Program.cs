using EFCoreComplexTypes;

var complexTypesDBService = new ComplexTypesDBService();

// complexTypesDBService.SaveComplexType();

var address = await complexTypesDBService.GetComplexTypeFromOwningEntity(1);

var user = await complexTypesDBService.GetComplexTypeOwningEntity(1);