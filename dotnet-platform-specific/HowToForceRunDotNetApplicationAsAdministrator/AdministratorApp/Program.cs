using AdministratorApp;

var administratorChecker = new AdministratorChecker();
bool isAdmin = administratorChecker.IsCurrentUserAdmin();
PrivilegeStatusPrinter.Print(isAdmin);