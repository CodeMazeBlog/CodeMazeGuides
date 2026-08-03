using CaseInsensitiveSubstringSearch;

const string sourceString = "Code Maze";
const string substringToSearch = "maze";
const char separator = ' ';

SubstringSearch.StringContains(sourceString, substringToSearch);
SubstringSearch.StringIndexOf(sourceString, substringToSearch);
SubstringSearch.StringToUpperInvariant(sourceString, substringToSearch);
SubstringSearch.RegexIsMatch(sourceString, substringToSearch);
SubstringSearch.LinqStringEquals(sourceString, substringToSearch, separator);
