Dotnet Core SDK version used: 3.1.301 (commit 7feb845744)
Dotnet Core project initialization command: `dotnet new webapi --no-https`
Dotnet Core project publish command: `dotnet publish -r win-x64`

Project target: netcoreapp3.1

Assumptions made:
- Project:
  - No authentication is required
  - No HTTPS support is required (HTTPS support makes it more complicated to run and test a service locally)
  - Swashbuckle.AspNetCore external library can be used
  - JetBrains ReSharper can be used in development
  - C# language version used is C# 8
  - files processed are small enough to fit in-memory (smaller than 1024 kb) and no batch processing logic is required
  - files are encoded in UTF-8
- Words:
  - a word is defined as a string of letters and additional characters: `'` (U+0027)
  - a letter is defined as a unicode character belonging to the Letter (L) class (see [this link](https://unicodebook.readthedocs.io/unicode.html#:~:text=4.2.,-Categories&text=Unicode%206.0%20has%207%20character,Nl)%2C%20other%20(No)))
  - words are delimited by any non-empty sequence of other unicode characters (including control codes, e.g. CR)
  - words that are capitalized differently (e.g. `Forest` and `forest`) are considered to be the same word
  - results are returned in lowercase